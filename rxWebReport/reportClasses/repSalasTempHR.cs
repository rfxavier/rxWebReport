using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DevExpress.XtraCharts;
using rxWebReport.dataObjClasses;

namespace rxWebReport.reportClasses
{
    public partial class repSalasTempHR : DevExpress.XtraReports.UI.XtraReport
    {
        public repSalasTempHR()
        {
            InitializeComponent();
        }

        public void ConfigureReadings(string item, string initialDate, string finalDate)
        {
            var readings = dsJaSaude.GetReportData(item, initialDate, finalDate);
            DataSource = readings;

            // Bind nullable values so XRChart retains gaps when it binds during printing.
            // The table and summaries retain only actual collected readings.
            var series = chart2.Series[0];
            series.ArgumentDataMember = "SensorDate";
            series.ValueDataMembersSerializable = "Value";
            var chartReadings = CreateChartPoints(readings, item,
                DateTime.Parse(initialDate, CultureInfo.InvariantCulture),
                DateTime.Parse(finalDate, CultureInfo.InvariantCulture))
                .Select(point => new ChartReading {
                    SensorDate = point.DateTimeArgument,
                    Value = point.IsEmpty ? (double?)null : point.Values[0]
                }).ToList();
            chart2.DataSource = chartReadings;
            series.DataSource = chartReadings;
        }

        public class ChartReading
        {
            public DateTime SensorDate { get; set; }
            public double? Value { get; set; }
        }

        internal static IEnumerable<SeriesPoint> CreateChartPoints(
            IEnumerable<dsJaSaude.dadosSensor> readings, string item, DateTime start, DateTime end)
        {
            bool isPressure = dsJaSaude.IsPressureItem(item);
            int interval = isPressure ? 60 : 15;
            var byMinute = readings.ToLookup(reading =>
                new DateTime(reading.SensorDate.Year, reading.SensorDate.Month, reading.SensorDate.Day,
                    reading.SensorDate.Hour, isPressure ? 0 : reading.SensorDate.Minute, 0));
            var slot = start.Date.AddHours(start.Hour);
            while (slot.AddMinutes(isPressure ? interval : 1) <= start)
                slot = slot.AddMinutes(interval);

            for (; slot <= end; slot = slot.AddMinutes(interval))
            {
                var collected = byMinute[slot]
                    .Where(reading => reading.SensorDate >= start && reading.SensorDate <= end)
                    .OrderBy(reading => reading.SensorDate).ToList();
                if (collected.Count == 0 && slot >= start)
                    yield return new SeriesPoint(slot);
                else
                    foreach (var reading in collected)
                        yield return new SeriesPoint(reading.SensorDate, (double)reading.Value);
            }
        }

    }
}
