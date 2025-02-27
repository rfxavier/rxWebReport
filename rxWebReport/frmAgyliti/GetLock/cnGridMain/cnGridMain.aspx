<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridMain.aspx.cs" Inherits="rxWebReport.frmRx.Agyliti.GetLock.cnGridMain.cnGridMain" %>
<%@ MasterType VirtualPath="~/Main.master" %>
<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="updateDetails" runat="server" OnUnload="UpdatePanel_Unload">
        <ContentTemplate>
            <div><h4>Ocorrências</h4></div>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" OnDataBinding="ASPxGridView1_DataBinding" KeyFieldName="id" OnAutoFilterCellEditorInitialize="ASPxGridView1_AutoFilterCellEditorInitialize" OnProcessColumnAutoFilter="ASPxGridView1_ProcessColumnAutoFilter">
                <SettingsPager PageSize="20"></SettingsPager>

                <Settings ShowHeaderFilterButton="True" ShowFilterBar="Visible" ShowFilterRow="true" ShowFilterRowMenu="true"></Settings>

                <SettingsCookies Enabled="true" />
        
                <Columns>
                    <dx:GridViewDataDateColumn FieldName="data_tmst_end_datetime" SortIndex="0" SortOrder="Descending" Caption="Data Movimento" VisibleIndex="0" Settings-FilterMode="Value">
                        <CellStyle Wrap="False"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="data_tmst_end_datetime" SortIndex="1" Caption="Hora Movimento" VisibleIndex="1" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" Settings-ShowInFilterControl="False">
                        <CellStyle Wrap="False"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm:ss" EditFormatString="HH:mm:ss">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="id_cofre" Caption="ID Cofre" VisibleIndex="2"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cofre_nome" Caption="Nome Cofre" VisibleIndex="3"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cofre_serie" Caption="S&#233;rie Cofre" VisibleIndex="4"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cofre_tipo" Caption="Tipo Cofre" VisibleIndex="5"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cofre_marca" Caption="Marca Cofre" VisibleIndex="6"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cofre_modelo" Caption="Modelo Cofre" VisibleIndex="7"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cofre_tamanho_malote" Caption="Tamanho Malote Cofre" VisibleIndex="8"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cod_loja" Caption="C&#243;d.Loja" VisibleIndex="9"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="nome_loja" Caption="Nome Fantasia Loja" VisibleIndex="10"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="razao_social_loja" Caption="Razão Social Loja" VisibleIndex="11"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cnpj_loja" Caption="CNPJ Loja" VisibleIndex="12"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="endereco_loja" Caption="Endereço Loja" VisibleIndex="13"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="complemento_loja" Caption="Complemento Loja" VisibleIndex="14"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="bairro_loja" Caption="Bairro Loja" VisibleIndex="15"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cidade_loja" Caption="Cidade Loja" VisibleIndex="16"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="uf_loja" Caption="UF Loja" VisibleIndex="17"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cep_loja" Caption="CEP Loja" VisibleIndex="18"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="latitude_loja" Caption="Latitude Loja" VisibleIndex="19"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="longitude_loja" Caption="Longitude Loja" VisibleIndex="20"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="pessoa_contato_loja" Caption="Pessoa Contato Loja" VisibleIndex="21"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="email_loja" Caption="Email Loja" VisibleIndex="22"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="telefone_loja" Caption="Telefone Loja" VisibleIndex="23"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cod_cliente" Caption="C&#243;d.Cliente" VisibleIndex="24"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="nome_cliente" Caption="Nome Fantasia Cliente" VisibleIndex="25"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="razao_social_cliente" Caption="Razão Social Cliente" VisibleIndex="26"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cnpj_cliente" Caption="CNPJ Cliente" VisibleIndex="27"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="endereco_cliente" Caption="Endereço Cliente" VisibleIndex="28"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="complemento_cliente" Caption="Complemento Cliente" VisibleIndex="29"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="bairro_cliente" Caption="Bairro Cliente" VisibleIndex="30"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cidade_cliente" Caption="Cidade Cliente" VisibleIndex="31"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="uf_cliente" Caption="UF Cliente" VisibleIndex="32"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cep_cliente" Caption="CEP Cliente" VisibleIndex="33"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="latitude_cliente" Caption="Latitude Cliente" VisibleIndex="34"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="longitude_cliente" Caption="Longitude Cliente" VisibleIndex="35"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="pessoa_contato_cliente" Caption="Pessoa Contato Cliente" VisibleIndex="36"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="email_cliente" Caption="Email Cliente" VisibleIndex="37"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="telefone_cliente" Caption="Telefone Cliente" VisibleIndex="38"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cod_rede" Caption="C&#243;d.Rede" VisibleIndex="39"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="nome_rede" Caption="Nome Rede" VisibleIndex="40"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="info_id" Caption="ID &#218;nico Cofre" VisibleIndex="41"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="info_ip" Caption="IP" VisibleIndex="42"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="info_mac" Caption="Mac" VisibleIndex="43"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="info_json" Caption="Json" VisibleIndex="44"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_hash" Caption="ID Operação" VisibleIndex="45"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="data_tmst_begin_datetime" Caption="Timestamp Inicial" VisibleIndex="46">
                        <CellStyle Wrap="False"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm" EditFormatString="dd/MM/yyyy HH:mm">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="data_tmst_end_datetime" Caption="Timestamp Final" VisibleIndex="47">
                        <CellStyle Wrap="False"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm" EditFormatString="dd/MM/yyyy HH:mm">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="user_id" Caption="Usuário Id" VisibleIndex="50"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="user_name" Caption="Usuário Nome" VisibleIndex="51"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="user_lastname" Caption="Usuário Sobrenome" VisibleIndex="52"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_type" Caption="Movimento" VisibleIndex="53"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="movimento_nome" Caption="Movimento Nome" VisibleIndex="54"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="movimento_tipo" Caption="Movimento Tipo" VisibleIndex="55"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_total" Caption="Valor Total" VisibleIndex="56"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_2" Caption="C&#233;dula R$ 2" VisibleIndex="57"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_5" Caption="C&#233;dula R$ 5" VisibleIndex="58"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_10" Caption="C&#233;dula R$ 10" VisibleIndex="59"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_20" Caption="C&#233;dula R$ 20" VisibleIndex="60"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_50" Caption="C&#233;dula R$ 50" VisibleIndex="61"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_100" Caption="C&#233;dula R$ 100" VisibleIndex="62"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_200" Caption="C&#233;dula R$ 200" VisibleIndex="63"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_rejected" Caption="C&#233;dula Rejeitada" VisibleIndex="64"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_envelope" Caption="Envelope" VisibleIndex="65"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_envelope_total" Caption="Envelope Valor Total" VisibleIndex="66"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill" Caption="Quantidade de C&#233;dulas" VisibleIndex="67"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_total" Caption="Valor total de C&#233;dulas" VisibleIndex="68"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_sensor" Caption="Sensor" VisibleIndex="69"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="balance" Caption="Saldo Cofre" VisibleIndex="70"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="limit_deposit_enabled" Caption="Limite Depósito Habilitado" VisibleIndex="71"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="limit_deposit_value" Caption="Valor Limite Depósito" VisibleIndex="72"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="balance_id" Caption="ID Saldo Cofre" VisibleIndex="73"></dx:GridViewDataTextColumn>
                </Columns>
                <Toolbars>
                    <dx:GridViewToolbar>
                        <Items>
                            <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Exportar para Excel"></dx:GridViewToolbarItem>
                            <dx:GridViewToolbarItem Command="ExportToPdf" Text="Exportar para PDF"></dx:GridViewToolbarItem>
                            <dx:GridViewToolbarItem Command="ShowCustomizationWindow" />
                        </Items>

                        <SettingsAdaptivity Enabled="true" EnableCollapseRootItemsToIcons="true" />
                    </dx:GridViewToolbar>
                </Toolbars>
                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" FileName="GetLock-Ocorrencias" Landscape="true" />
                <SettingsBehavior EnableCustomizationWindow="true" />
                <Styles>
                    <AlternatingRow Enabled="True" BackColor="#D6EBFF">
                    </AlternatingRow>
                    <Cell Wrap="False"></Cell>
                </Styles>
            </dx:ASPxGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <dx:EntityServerModeDataSource ID="EntityServerModeDataSource1" runat="server" ContextTypeName="rxApp.Models.ApplicationDbContext" TableName="GetLockMessageViews" OnSelecting="EntityServerModeDataSource1_Selecting" />
</asp:Content>