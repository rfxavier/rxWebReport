<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridCofreCadastro.aspx.cs" Inherits="rxWebReport.frmAgyliti.GetLock.cnRelatorios.cnGridCofreCadastro" %>
<%@ MasterType VirtualPath="~/Main.master" %>
<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <strong>Cofres</strong>
    <dx:ASPxGridView runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="id" ID="ASPxGridView1" OnDataBinding="ASPxGridView1_DataBinding">
        <SettingsDetail ShowDetailRow="False"></SettingsDetail>

        <SettingsPager PageSize="20"></SettingsPager>
        <Settings ShowHeaderFilterButton="True" ShowFilterBar="Visible" ShowFilterRow="true" ShowFilterRowMenu="true"></Settings>
        <SettingsCookies Enabled="true" />
        <Columns>
            <dx:GridViewDataColumn FieldName="id_cofre" Caption="ID Cofre" />
            <dx:GridViewDataColumn FieldName="nome" Caption="Nome" />
            <dx:GridViewDataColumn FieldName="serie" Caption="Série" />
            <dx:GridViewDataColumn FieldName="tipo" Caption="Tipo" />
            <dx:GridViewDataColumn FieldName="marca" Caption="Marca" />
            <dx:GridViewDataColumn FieldName="modelo" Caption="Modelo" />
            <dx:GridViewDataColumn FieldName="tamanho_malote" Caption="Tamanho Malote" />
            <dx:GridViewDataColumn FieldName="cod_loja" Caption="Código Loja" />
            <dx:GridViewDataColumn FieldName="loja_nome" Caption="Loja Nome Fantasia" />
            <dx:GridViewDataColumn FieldName="loja_razao_social" Caption="Loja Razão Social" />
            <dx:GridViewDataColumn FieldName="loja_cnpj" Caption="Loja CNPJ" />
            <dx:GridViewDataColumn FieldName="loja_endereco" Caption="Loja Endereço" />
            <dx:GridViewDataColumn FieldName="loja_complemento" Caption="Loja Complemento" />
            <dx:GridViewDataColumn FieldName="loja_bairro" Caption="Loja Bairro" />
            <dx:GridViewDataColumn FieldName="loja_cidade" Caption="Loja Cidade" />
            <dx:GridViewDataColumn FieldName="loja_uf" Caption="Loja UF" />
            <dx:GridViewDataColumn FieldName="loja_CEP" Caption="Loja CEP" />
            <dx:GridViewDataColumn FieldName="loja_latitude" Caption="Loja Latitude" />
            <dx:GridViewDataColumn FieldName="loja_longitude" Caption="Loja Longitude" />
            <dx:GridViewDataColumn FieldName="loja_pessoa_contato" Caption="Loja Pessoa Contato" />
            <dx:GridViewDataColumn FieldName="loja_email" Caption="Loja Email" />
            <dx:GridViewDataColumn FieldName="loja_cod_cliente" Caption="Loja Código Cliente" />
            <dx:GridViewDataColumn FieldName="cliente_nome" Caption="Cliente Nome Fantasia" />
            <dx:GridViewDataColumn FieldName="cliente_razao_social" Caption="Cliente Razão Social" />
            <dx:GridViewDataColumn FieldName="cliente_cnpj" Caption="Cliente CNPJ" />
            <dx:GridViewDataColumn FieldName="cliente_endereco" Caption="Cliente Endereço" />
            <dx:GridViewDataColumn FieldName="cliente_complemento" Caption="Cliente Complemento" />
            <dx:GridViewDataColumn FieldName="cliente_bairro" Caption="Cliente Bairro" />
            <dx:GridViewDataColumn FieldName="cliente_cidade" Caption="Cliente Cidade" />
            <dx:GridViewDataColumn FieldName="cliente_uf" Caption="Cliente UF" />
            <dx:GridViewDataColumn FieldName="cliente_CEP" Caption="Cliente CEP" />
            <dx:GridViewDataColumn FieldName="cliente_latitude" Caption="Cliente Latitude" />
            <dx:GridViewDataColumn FieldName="cliente_longitude" Caption="Cliente Longitude" />
            <dx:GridViewDataColumn FieldName="cliente_pessoa_contato" Caption="Cliente Pessoa Contato" />
            <dx:GridViewDataColumn FieldName="cliente_email" Caption="Cliente Email" />
            <dx:GridViewDataColumn FieldName="cliente_cod_rede" Caption="Cliente Código Rede" />
            <dx:GridViewDataColumn FieldName="rede_nome" Caption="Rede Nome" />
        </Columns>
        <Settings ShowFooter="true" />
        <TotalSummary>
            <dx:ASPxSummaryItem FieldName="TotalCount" SummaryType="Count" DisplayFormat="{0:n0}" />
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
                    <dx:GridViewToolbarItem Command="ShowCustomizationWindow" />
                </Items>

                <SettingsAdaptivity Enabled="true" EnableCollapseRootItemsToIcons="true" />
            </dx:GridViewToolbar>
        </Toolbars>
        <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" FileName="GetLock-Cofres" />
        <SettingsBehavior EnableCustomizationWindow="true" />
    </dx:ASPxGridView>
</asp:Content>
