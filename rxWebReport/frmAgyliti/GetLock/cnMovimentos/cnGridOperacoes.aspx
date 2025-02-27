<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridOperacoes.aspx.cs" Inherits="rxWebReport.frmAgyliti.GetLock.cnMovimentos.cnGridOperacoes" %>
<%@ MasterType VirtualPath="~/Main.master" %>
<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <strong>Depósitos</strong>
    <dx:ASPxGridView runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="id" ID="ASPxGridView1" OnDataBinding="ASPxGridView1_DataBinding" OnCustomUnboundColumnData="ASPxGridView1_CustomUnboundColumnData">
        <SettingsDetail ShowDetailRow="False"></SettingsDetail>

        <SettingsPager PageSize="20"></SettingsPager>
        <Settings ShowHeaderFilterButton="True" ShowFilterBar="Visible" ShowFilterRow="true" ShowFilterRowMenu="true"></Settings>
        <Columns>
            <dx:GridViewDataDateColumn FieldName="data_tmst_end_datetime" SortIndex="0" SortOrder="Ascending" ShowInCustomizationForm="True" Caption="Data Movimento" VisibleIndex="0">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy"></PropertiesDateEdit>

                <CellStyle Wrap="False"></CellStyle>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="data_tmst_end_datetime" SortIndex="1" SortOrder="Ascending" ShowInCustomizationForm="True" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" Settings-ShowInFilterControl="False" Caption="Hora Movimento" VisibleIndex="1">
                <PropertiesDateEdit DisplayFormatString="HH:mm:ss" EditFormatString="HH:mm:ss"></PropertiesDateEdit>

                <CellStyle Wrap="False"></CellStyle>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="movimento_nome" ShowInCustomizationForm="True" Caption="Operação" VisibleIndex="2"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_hash" ShowInCustomizationForm="True" Caption="ID Operação" VisibleIndex="3"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="id_cofre" ShowInCustomizationForm="True" Caption="ID Cofre" VisibleIndex="4"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="cofre_nome" ShowInCustomizationForm="True" Caption="Nome Cofre" VisibleIndex="5"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="cod_loja" ShowInCustomizationForm="True" Caption="C&#243;d.Loja" VisibleIndex="8"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="razao_social_loja" ShowInCustomizationForm="True" Caption="Raz&#227;o Social Loja" VisibleIndex="10"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_user" ShowInCustomizationForm="True" Caption="Usu&#225;rio" Visible="false" VisibleIndex="47"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="user_nome" ShowInCustomizationForm="True" Caption="Usu&#225;rio Nome" Visible="false" VisibleIndex="48"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="user_id" ShowInCustomizationForm="True" Caption="Usuário Id" VisibleIndex="49"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="user_name" ShowInCustomizationForm="True" Caption="Usuário Nome" VisibleIndex="50"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="user_lastname" ShowInCustomizationForm="True" Caption="Usuário Sobrenome" VisibleIndex="51"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TotalCount" UnboundType="Decimal" Caption="Total Cédulas" VisibleIndex="60">
                <PropertiesTextEdit DisplayFormatString="#,#0" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TotalValue" UnboundType="Decimal" Caption="Total Valor" VisibleIndex="61">
                <PropertiesTextEdit DisplayFormatString="#,#0.00" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_2" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 2" VisibleIndex="62"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_5" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 5" VisibleIndex="63"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_10" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 10" VisibleIndex="64"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_20" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 20" VisibleIndex="65"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_50" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 50" VisibleIndex="66"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_100" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 100" VisibleIndex="67"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_200" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 200" VisibleIndex="68"></dx:GridViewDataTextColumn>
        </Columns>
        <Settings ShowFooter="true" />
        <TotalSummary>
            <dx:ASPxSummaryItem FieldName="TotalCount" SummaryType="Sum" DisplayFormat="{0:n0}" />
            <dx:ASPxSummaryItem FieldName="TotalValue" SummaryType="Sum" DisplayFormat="{0:c}" />
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
        <Templates>
            <DetailRow>
                <dx:ASPxGridView runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="id" ID="ASPxGridView2" OnBeforePerformDataSelect="ASPxGridView2_BeforePerformDataSelect">
                    <SettingsPager PageSize="20"></SettingsPager>
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="data_currency_bill_2" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 2" VisibleIndex="53"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="data_currency_bill_5" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 5" VisibleIndex="54"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="data_currency_bill_10" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 10" VisibleIndex="55"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="data_currency_bill_20" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 20" VisibleIndex="56"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="data_currency_bill_50" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 50" VisibleIndex="57"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="data_currency_bill_100" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 100" VisibleIndex="58"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="data_currency_bill_200" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 200" VisibleIndex="59"></dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </DetailRow>
        </Templates>
        <Toolbars>
            <dx:GridViewToolbar>
                <Items>
                    <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Exportar para Excel"></dx:GridViewToolbarItem>
                </Items>

                <SettingsAdaptivity Enabled="true" EnableCollapseRootItemsToIcons="true" />
            </dx:GridViewToolbar>
        </Toolbars>
        <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" FileName="GetLock-Depositos" />
    </dx:ASPxGridView>
</asp:Content>
