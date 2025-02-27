<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridCofre.aspx.cs" Inherits="rxWebReport.frmRx.Agyliti.GetLock.cnCadastros.cnGridCofre" %>

<%@ Register Assembly="Microsoft.AspNet.EntityDataSource" Namespace="Microsoft.AspNet.EntityDataSource" TagPrefix="ef" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div><h4>Cadastro Cofre</h4></div>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" KeyFieldName="id" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" OnDataBinding="ASPxGridView1_DataBinding" OnRowDeleting="ASPxGridView1_RowDeleting" OnRowInserting="ASPxGridView1_RowInserting" OnRowUpdating="ASPxGridView1_RowUpdating" OnRowValidating="ASPxGridView1_RowValidating">
        <SettingsDataSecurity AllowInsert="true" />
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="True" ShowInCustomizationForm="True" VisibleIndex="0" ShowNewButtonInHeader="True" ShowDeleteButton="True"></dx:GridViewCommandColumn>
            <dx:GridViewDataColumn FieldName="id_cofre" Caption="ID Cofre" />
            <dx:GridViewDataColumn FieldName="nome" Caption="Nome" />
            <dx:GridViewDataColumn FieldName="serie" Caption="Série" />
            <dx:GridViewDataColumn FieldName="tipo" Caption="Tipo" />
            <dx:GridViewDataColumn FieldName="marca" Caption="Marca" />
            <dx:GridViewDataColumn FieldName="modelo" Caption="Modelo" />
            <dx:GridViewDataColumn FieldName="tamanho_malote" Caption="Tamanho Malote" />
            <dx:GridViewDataComboBoxColumn FieldName="cod_loja" Caption="Loja">
                <PropertiesComboBox TextField="nome" IncrementalFilteringMode="Contains" ValueField="cod_loja"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
        </Columns>
        <SettingsBehavior ConfirmDelete="True" />
        <SettingsPopup>
            <EditForm Width="600">
                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" />
            </EditForm>
        </SettingsPopup>
        <SettingsSearchPanel Visible="true"  />
        <Styles>
            <Cell Wrap="False"></Cell>
        </Styles>
    </dx:ASPxGridView>
</asp:Content>
