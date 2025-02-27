<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridDepositosUsuario.aspx.cs" Inherits="rxWebReport.frmAgyliti.GetLock.cnRelatorios.cnGridDepositosUsuario" %>
<%@ MasterType VirtualPath="~/Main.master" %>
<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <strong>Depósitos por Usuário</strong>
    <dx:ASPxGridView runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="id" ID="ASPxGridView1" OnDataBinding="ASPxGridView1_DataBinding" OnCustomUnboundColumnData="ASPxGridView1_CustomUnboundColumnData">
        <SettingsDetail ShowDetailRow="False"></SettingsDetail>

        <SettingsPager PageSize="20"></SettingsPager>
        <Settings ShowHeaderFilterButton="True" ShowFilterBar="Visible" ShowFilterRow="true" ShowFilterRowMenu="true"></Settings>
        <Columns>
            <dx:GridViewDataTextColumn FieldName="user_id" ShowInCustomizationForm="True" Caption="Usuário Id" VisibleIndex="49"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="user_name" ShowInCustomizationForm="True" Caption="Usuário Nome" VisibleIndex="50"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="user_lastname" ShowInCustomizationForm="True" Caption="Usuário Sobrenome" VisibleIndex="51"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TotalCount" UnboundType="Decimal" Caption="Total Cédulas" VisibleIndex="60">
                <PropertiesTextEdit DisplayFormatString="#,#0" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TotalValue" UnboundType="Decimal" Caption="Total Valor" VisibleIndex="62">
                <PropertiesTextEdit DisplayFormatString="#,#0" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_2" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 2" VisibleIndex="63"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_5" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 5" VisibleIndex="64"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_10" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 10" VisibleIndex="65"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_20" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 20" VisibleIndex="66"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_50" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 50" VisibleIndex="67"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_100" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 100" VisibleIndex="68"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_200" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 200" VisibleIndex="69"></dx:GridViewDataTextColumn>
        </Columns>
        <Settings ShowFooter="true" />
        <TotalSummary>
            <dx:ASPxSummaryItem FieldName="TotalCount" SummaryType="Sum" DisplayFormat="{0:n0}" />
            <dx:ASPxSummaryItem FieldName="TotalValue" SummaryType="Sum" DisplayFormat="{0:n2}" />
        </TotalSummary>
        <Styles>
            <Header Wrap="True">
            </Header>
            <AlternatingRow Enabled="True" BackColor="#D6EBFF">
            </AlternatingRow>
            <TitlePanel Font-Size="Medium">
            </TitlePanel>
            <Cell Wrap="False"></Cell>
        </Styles>
        <Toolbars>
            <dx:GridViewToolbar>
                <Items>
                    <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Exportar para Excel"></dx:GridViewToolbarItem>
                </Items>

                <SettingsAdaptivity Enabled="true" EnableCollapseRootItemsToIcons="true" />
            </dx:GridViewToolbar>
        </Toolbars>
        <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" FileName="GetLock-DepositosPorUsuario" />
    </dx:ASPxGridView>
</asp:Content>
