param([switch]$Live)
$ErrorActionPreference = 'Stop'
$projectRoot = Split-Path -Parent $PSScriptRoot
$assembly = [Reflection.Assembly]::LoadFrom((Join-Path $projectRoot 'bin\rxWebReport.dll'))
$reportType = $assembly.GetType('rxWebReport.reportClasses.repSalasTempHR', $true)
$readingType = $assembly.GetType('rxWebReport.dataObjClasses.dsJaSaude+dadosSensor', $true)
$method = $reportType.GetMethod('CreateChartPoints', [Reflection.BindingFlags]'Static,NonPublic')
$listType = [System.Collections.Generic.List``1].MakeGenericType($readingType)

function Assert($condition, $message) {
    if (-not $condition) { throw $message }
}

foreach ($case in @(
    @{ Item = 'TTU-01BIPE Temperatura'; Interval = 15 },
    @{ Item = 'CCL-01UEA Umidade'; Interval = 15 },
    @{ Item = 'TDP-01BIPE'; Interval = 60 }
)) {
    $start = [datetime]'2026-10-04T09:00:00'
    $end = $start.AddMinutes(4 * $case.Interval)
    $readings = [Activator]::CreateInstance($listType)
    foreach ($offset in @(1, 3)) {
        $reading = [Activator]::CreateInstance($readingType)
        $reading.Item = $case.Item
        $reading.SensorDate = $start.AddMinutes($offset * $case.Interval).AddSeconds(17)
        $reading.Value = if ($offset -eq 1) { 0 } else { 12.4 }
        $readings.Add($reading)
    }
    $points = @($method.Invoke($null, @($readings, $case.Item, $start, $end)))
    Assert ($points.Count -eq 5) 'Expected five reference slots'
    foreach ($index in @(0, 2, 4)) {
        Assert $points[$index].IsEmpty 'Missing readings must be genuine empty points'
        Assert ($points[$index].DateTimeArgument -eq $start.AddMinutes($index * $case.Interval)) 'Incorrect gap time'
    }
    Assert (-not $points[1].IsEmpty) 'A collected zero must not be treated as missing'
    Assert ($points[1].Values[0] -eq 0) 'Collected zero changed'
    Assert ($points[3].Values[0] -eq 12.4) 'Raw collected value changed'
    Assert ($points[3].DateTimeArgument -eq $readings[1].SensorDate) 'Collection seconds changed'

    $emptyReadings = [Activator]::CreateInstance($listType)
    $emptyPoints = @($method.Invoke($null, @($emptyReadings, $case.Item, $start, $end)))
    Assert ($emptyPoints.Count -eq 5) 'Entirely missing period lost its reference slots'
    Assert (@($emptyPoints | Where-Object { -not $_.IsEmpty }).Count -eq 0) 'Missing period gained fabricated values'
    $partial = @($method.Invoke($null, @($emptyReadings, $case.Item, $start.AddMinutes(1), $end.AddMinutes(-1))))
    Assert ($partial.Count -eq 3) 'Partial period includes slots outside requested bounds'
}
$selector = $assembly.GetType('rxWebReport.dataObjClasses.dsJaSaude').GetMethod('SelectReportReadings', [Reflection.BindingFlags]'Static,NonPublic')
$readings = [Activator]::CreateInstance($listType)
foreach ($time in @('09:18:22', '09:25:22', '10:00:17', '10:18:22', '12:18:22')) {
    $reading = [Activator]::CreateInstance($readingType)
    $reading.Item = 'TDP-01BIPE'
    $reading.SensorDate = [datetime]('2026-09-14T' + $time)
    $reading.Value = 43.5 + $readings.Count
    $readings.Add($reading)
}
$selected = $selector.Invoke($null, [object[]](,$readings))
Assert ($selected.Count -eq 3) 'Pressure must select one actual reading per available hour'
Assert ($selected[0].SensorDate -eq [datetime]'2026-09-14T09:00:00') 'Pressure must display HH:00:00'
Assert ($selected[1].SensorDate -eq [datetime]'2026-09-14T10:00:00') 'Pressure seconds must also be masked'
Assert ($selected[0].Value -eq 43.5) 'Fallback must retain the first raw value'
Assert ($selected[1].Value -eq 45.5) 'Minute 00 must take precedence without averaging'
Assert ($readings[0].SensorDate.Minute -eq 18) 'Presentation must not mutate original collection time'
$points = @($method.Invoke($null, @($selected, 'TDP-01BIPE', [datetime]'2026-09-14T09:00:00', [datetime]'2026-09-14T12:59:59')))
Assert ($points.Count -eq 4) 'Pressure hourly slots missing'
Assert $points[2].IsEmpty 'Hour without any reading must remain empty'
Assert ($points[0].DateTimeArgument -eq [datetime]'2026-09-14T09:00:00') 'Chart must display pressure at HH:00:00'

if ($Live) {
    $sensorType = $assembly.GetType('rxWebReport.dataObjClasses.dsJaSaude', $true)
    $getSensorData = $sensorType.GetMethod('GetSensorData', [Reflection.BindingFlags]'Static,NonPublic')
    $apnReadings = $getSensorData.Invoke($null, @('TDP-02APN', '2026-10-05 00:00:00', '2026-10-05 23:59:59', $true))
    $legacyApnReadings = $getSensorData.Invoke($null, @('TDP-02APN', '2026-10-05 00:00:00', '2026-10-05 23:59:59', $false))
    Assert ($apnReadings.Count -gt 0) 'TDP-02APN must return real Fieldlogger readings'
    Assert ($apnReadings.Count -eq $legacyApnReadings.Count) 'Report acquisition must retain all legacy APN readings'
    Assert (@($apnReadings | Where-Object { $_.Hostname -ne 'Fieldlogger REG-01AMT' -or $_.Item -ne 'TDP-02APN' }).Count -eq 0) 'APN query selected the wrong host or item'
    $apnReportReadings = $sensorType.GetMethod('GetReportData').Invoke($null, @('TDP-02APN', '2026-10-05 00:00:00', '2026-10-05 23:59:59'))
    Assert ($apnReportReadings.Count -gt 0) 'TDP-02APN report must contain readings'
    Write-Output ('PASS: live TDP-02APN: {0} acquired readings, {1} report readings.' -f $apnReadings.Count, $apnReportReadings.Count)
    $report = [Activator]::CreateInstance($reportType)
    try {
        $report.Parameters['parRepItemPrefix'].Value = 'TDP-01BIPE'
        $report.Parameters['parRepInitialDate'].Value = '2026-09-14 00:00:00'
        $report.Parameters['parRepFinalDate'].Value = '2026-09-14 23:59:59'
        $report.ConfigureReadings('TDP-01BIPE', '2026-09-14 00:00:00', '2026-09-14 23:59:59')
        Assert ($report.DataSource.Count -eq 24) 'Real report table must contain 24 readings'
        $chart = $report.FindControl('chart2', $true)
        Assert ($chart.Series[0].DataSource.Count -eq 24) 'Real chart must contain 24 readings'
        foreach ($reading in $report.DataSource) {
            Assert ($reading.SensorDate.Minute -eq 0 -and $reading.SensorDate.Second -eq 0) 'Real table must display HH:00:00'
        }
        foreach ($point in $chart.Series[0].DataSource) {
            Assert ($point.SensorDate.Minute -eq 0 -and $point.SensorDate.Second -eq 0) 'Real chart must display HH:00:00'
        }
        Assert ($report.DataSource[0].Value -eq 43.5) 'Real raw value changed'
        $report.CreateDocument()
        Assert ($report.Pages.Count -gt 0) 'Real report did not generate pages'
        Assert ($chart.Series[0].DataSource.Count -eq 24) 'Chart data lost during document creation'
        Write-Output ('PASS: live TDP-01BIPE 2026-09-14: 24 table readings, 24 chart points, {0} generated pages.' -f $report.Pages.Count)
    } finally { $report.Dispose() }
}
Write-Output 'PASS: gaps, missing periods, bounds, raw values, temperature/humidity timestamps, pressure HH:00:00 presentation and minute 00 priority.'
