<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridLoja.aspx.cs" Inherits="rxWebReport.frmAgyliti.GetLock.cnCadastros.cnGridLoja" %>

<%@ Register Assembly="Microsoft.AspNet.EntityDataSource" Namespace="Microsoft.AspNet.EntityDataSource" TagPrefix="ef" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div><h4>Cadastro Loja</h4></div>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" KeyFieldName="id" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" OnDataBinding="ASPxGridView1_DataBinding" OnRowDeleting="ASPxGridView1_RowDeleting" OnRowInserting="ASPxGridView1_RowInserting" OnRowUpdating="ASPxGridView1_RowUpdating" OnRowValidating="ASPxGridView1_RowValidating">
        <SettingsDataSecurity AllowInsert="true" />
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="True" ShowInCustomizationForm="True" VisibleIndex="0" ShowNewButtonInHeader="True" ShowDeleteButton="True">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataColumn FieldName="cod_loja" Caption="Código Loja" />
            <dx:GridViewDataColumn FieldName="nome" Caption="Nome Fantasia" />
            <dx:GridViewDataComboBoxColumn FieldName="cod_cliente" Caption="Cliente">
                <PropertiesComboBox TextField="nome" IncrementalFilteringMode="Contains" ValueField="cod_cliente"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataColumn FieldName="razao_social" Caption="Razão Social" />
            <dx:GridViewDataColumn FieldName="cnpj" Caption="CNPJ" />
            <dx:GridViewDataColumn FieldName="endereco" Caption="Endereço" />
            <dx:GridViewDataColumn FieldName="complemento" Caption="Complemento" />
            <dx:GridViewDataColumn FieldName="bairro" Caption="Bairro" />
            <dx:GridViewDataColumn FieldName="cidade" Caption="Cidade" />
            <dx:GridViewDataColumn FieldName="uf" Caption="UF" />
            <dx:GridViewDataColumn FieldName="CEP" Caption="CEP" />
            <dx:GridViewDataColumn FieldName="latitude" Caption="Latitude" />
            <dx:GridViewDataColumn FieldName="longitude" Caption="Longitude" />
            <dx:GridViewDataColumn FieldName="pessoa_contato" Caption="Pessoa Contato" />
            <dx:GridViewDataColumn FieldName="email" Caption="Email" />
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
