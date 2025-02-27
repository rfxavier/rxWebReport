<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnUsuariosApiCofreDetalhe.aspx.cs" Inherits="rxWebReport.frmAgyliti.GetLock.cnUsuariosAdmin.cnUsuariosApiCofreDetalhe" %>
<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">

</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="" Font-Size="Larger"></dx:ASPxLabel>
    <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="<< Voltar" CssClass="button" NavigateUrl="~/frmAgyliti/GetLock/cnUsuariosAdmin/cnUsuariosApiCofre.aspx">
    </dx:ASPxHyperLink>

    <dx:ASPxGridView ID="ASPxGridView1" runat="server" KeyFieldName="CofreId" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" OnDataBinding="ASPxGridView1_DataBinding" OnRowDeleting="ASPxGridView1_RowDeleting" OnRowInserting="ASPxGridView1_RowInserting" OnRowValidating="ASPxGridView1_RowValidating">
        <SettingsDataSecurity AllowInsert="true" />
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="False" ShowInCustomizationForm="True" VisibleIndex="0" ShowNewButtonInHeader="True" ShowDeleteButton="True"></dx:GridViewCommandColumn>
            <dx:GridViewDataComboBoxColumn FieldName="CofreId" Caption="Cofre">
                <PropertiesComboBox TextField="DisplayText" IncrementalFilteringMode="Contains" ValueField="CofreId"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
        </Columns>
        <SettingsBehavior ConfirmDelete="True" />
        <SettingsPopup>
            <EditForm Width="600">
                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" />
            </EditForm>
        </SettingsPopup>
        <Styles>
            <Cell Wrap="False"></Cell>
        </Styles>
    </dx:ASPxGridView>
</asp:Content>
