<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridGetStatusBitProfile.aspx.cs" Inherits="rxWebReport.frmAgyliti.GetLock.cnConfig.cnGridGetStatusBitProfile" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div><h4>Configuração de Bits Get Status</h4></div>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" KeyFieldName="Id" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" OnDataBinding="ASPxGridView1_DataBinding" OnRowDeleting="ASPxGridView1_RowDeleting" OnRowInserting="ASPxGridView1_RowInserting" OnRowUpdating="ASPxGridView1_RowUpdating" OnRowValidating="ASPxGridView1_RowValidating">
        <SettingsDataSecurity AllowInsert="true" />
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="True" ShowInCustomizationForm="True" VisibleIndex="0" ShowNewButtonInHeader="True" ShowDeleteButton="True">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataComboBoxColumn FieldName="StatusType" Caption="Tipo">
                <PropertiesComboBox TextField="StatusType" IncrementalFilteringMode="Contains" ValueField="StatusType"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataColumn FieldName="Bit" Caption="Bit" />
            <dx:GridViewDataColumn FieldName="Caption" Caption="Descrição" />
        </Columns>
        <SettingsBehavior ConfirmDelete="True" />
        <SettingsPopup>
            <EditForm Width="600">
                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" />
            </EditForm>
            <FilterControl AutoUpdatePosition="False"></FilterControl>
        </SettingsPopup>
        <Styles>
            <Cell Wrap="False"></Cell>
        </Styles>
    </dx:ASPxGridView>

</asp:Content>
