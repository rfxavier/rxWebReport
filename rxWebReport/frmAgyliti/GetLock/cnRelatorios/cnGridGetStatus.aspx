<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridGetStatus.aspx.cs" Inherits="rxWebReport.frmAgyliti.GetLock.cnRelatorios.cnGridGetStatus" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div><h4>Status de Dispositivos</h4></div>

    <div style="display: flex">
        <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="170px" NullText="Cofre ID"></dx:ASPxTextBox>
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Solicitar status" OnClick="ASPxButton1_Click" BackColor="#2A4E70" CssClass="noImage" ForeColor="White"></dx:ASPxButton>
    </div>
    <dx:ASPxGridView runat="server" AutoGenerateColumns="False" KeyFieldName="id" ID="ASPxGridView1" OnDataBinding="ASPxGridView1_DataBinding" OnAutoFilterCellEditorInitialize="ASPxGridView1_AutoFilterCellEditorInitialize" OnProcessColumnAutoFilter="ASPxGridView1_ProcessColumnAutoFilter">
        <SettingsPager PageSize="20"></SettingsPager>

        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowHeaderFilterButton="True" ShowFilterBar="Visible"></Settings>

        <SettingsBehavior EnableCustomizationWindow="True"></SettingsBehavior>

        <SettingsCookies Enabled="True"></SettingsCookies>

        <SettingsPopup>
            <FilterControl AutoUpdatePosition="False"></FilterControl>
        </SettingsPopup>

        <SettingsExport FileName="GetLock-GetStatus" Landscape="True" EnableClientSideExportAPI="True" ExcelExportMode="WYSIWYG"></SettingsExport>
        <Columns>
            <dx:GridViewDataTextColumn FieldName="TopicDeviceId" ShowInCustomizationForm="True" Caption="Cofre Id" VisibleIndex="0"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CofreNome" Caption="Cofre Nome" VisibleIndex="1"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="TimestampDatetime" SortIndex="0" SortOrder="Descending" ShowInCustomizationForm="True" Caption="Data Status" VisibleIndex="2">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy"></PropertiesDateEdit>

                <CellStyle Wrap="False"></CellStyle>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="TimestampDatetime" SortIndex="1" ShowInCustomizationForm="True" Caption="Hora Status" VisibleIndex="3">
                <PropertiesDateEdit DisplayFormatString="HH:mm:ss" EditFormatString="HH:mm:ss"></PropertiesDateEdit>

                <Settings AllowAutoFilter="False" AllowHeaderFilter="False" ShowInFilterControl="False"></Settings>

                <CellStyle Wrap="False"></CellStyle>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="trackCreationTime" SortIndex="2" SortOrder="Descending" ShowInCustomizationForm="True" Caption="Data Mensagem" VisibleIndex="4">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy"></PropertiesDateEdit>

                <CellStyle Wrap="False"></CellStyle>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="trackCreationTime" SortIndex="3" ShowInCustomizationForm="True" Caption="Hora Mensagem" VisibleIndex="5">
                <PropertiesDateEdit DisplayFormatString="HH:mm:ss" EditFormatString="HH:mm:ss"></PropertiesDateEdit>

                <Settings AllowAutoFilter="False" AllowHeaderFilter="False" ShowInFilterControl="False"></Settings>

                <CellStyle Wrap="False"></CellStyle>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="UptimeSec" ShowInCustomizationForm="True" Caption="Uptime" VisibleIndex="6"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="IsAck" ShowInCustomizationForm="True" Caption="&#201; Ack" VisibleIndex="7"></dx:GridViewDataTextColumn>
        </Columns>
        <Toolbars>
            <dx:GridViewToolbar>
                <Items>
                    <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Exportar para Excel"></dx:GridViewToolbarItem>
                    <dx:GridViewToolbarItem Command="ExportToPdf" Text="Exportar para PDF"></dx:GridViewToolbarItem>
                    <dx:GridViewToolbarItem Command="ShowCustomizationWindow"></dx:GridViewToolbarItem>
                </Items>

                <SettingsAdaptivity Enabled="True" EnableCollapseRootItemsToIcons="True"></SettingsAdaptivity>
            </dx:GridViewToolbar>
        </Toolbars>

        <Styles>
            <AlternatingRow Enabled="True" BackColor="#D6EBFF"></AlternatingRow>
            <Cell Wrap="False"></Cell>
        </Styles>
    </dx:ASPxGridView>
</asp:Content>
