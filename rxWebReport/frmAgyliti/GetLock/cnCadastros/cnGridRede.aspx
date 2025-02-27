<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridRede.aspx.cs" Inherits="rxWebReport.frmAgyliti.GetLock.cnCadastros.cnGridRede" %>

<%@ Register Assembly="Microsoft.AspNet.EntityDataSource" Namespace="Microsoft.AspNet.EntityDataSource" TagPrefix="ef" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div><h4>Cadastro Loja</h4></div>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="EntityDataSource1" KeyFieldName="id" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" OnRowInserting="ASPxGridView1_RowInserting" OnRowValidating="ASPxGridView1_RowValidating">
        <SettingsDataSecurity AllowInsert="true" />
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="True" ShowInCustomizationForm="True" VisibleIndex="0" ShowNewButtonInHeader="True" ShowDeleteButton="True"></dx:GridViewCommandColumn>
            <dx:GridViewDataColumn FieldName="cod_rede" Caption="Código Rede" />
            <dx:GridViewDataColumn FieldName="nome" Caption="Nome" />
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
    <ef:EntityDataSource ID="EntityDataSource1" runat="server" ContextTypeName="rxApp.Models.ApplicationDbContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntitySetName="GetLockRedes"></ef:EntityDataSource>
</asp:Content>
