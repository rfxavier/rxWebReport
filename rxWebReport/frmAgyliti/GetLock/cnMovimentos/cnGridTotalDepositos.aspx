<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridTotalDepositos.aspx.cs" Inherits="rxWebReport.frmAgyliti.GetLock.cnMovimentos.cnGridTotalDepositos" %>
<%@ MasterType VirtualPath="~/Main.master" %>
<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <strong>Total Depósitos</strong>
    <dx:ASPxGridView runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="id" ID="ASPxGridView1" OnDataBinding="ASPxGridView1_DataBinding" OnCustomUnboundColumnData="ASPxGridView1_CustomUnboundColumnData">
        <Settings ShowGroupPanel="true" ShowFooter="true" ShowGroupFooter="VisibleAlways" ShowGroupedColumns="True"></Settings>
        <SettingsBehavior AllowFixedGroups="True"></SettingsBehavior>

        <Columns>
            <dx:GridViewDataTextColumn FieldName="cofre" UnboundType="String" Caption="Cofre" VisibleIndex="6" Visible="False"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="data_tmst_end_datetime" SortIndex="0" SortOrder="Descending" ShowInCustomizationForm="True" Caption="Data Movimento" VisibleIndex="7">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                <CellStyle Wrap="False"></CellStyle>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="data_tmst_end_datetime" SortIndex="1" SortOrder="Descending" ShowInCustomizationForm="True" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" Settings-ShowInFilterControl="False" Caption="Hora Movimento" VisibleIndex="8">
                <PropertiesDateEdit DisplayFormatString="HH:mm:ss" EditFormatString="HH:mm:ss"></PropertiesDateEdit>
                <CellStyle Wrap="False"></CellStyle>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="data_hash" ShowInCustomizationForm="True" Caption="ID Operação" VisibleIndex="5"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="id_cofre" ShowInCustomizationForm="True" Caption="ID Cofre" VisibleIndex="9"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="movimento_nome" ShowInCustomizationForm="True" Caption="Movimento" VisibleIndex="10"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="cofre_nome" ShowInCustomizationForm="True" Caption="Nome Cofre" VisibleIndex="11"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="cod_loja" ShowInCustomizationForm="True" Caption="C&#243;d.Loja" VisibleIndex="14"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="razao_social_loja" ShowInCustomizationForm="True" Caption="Loja" VisibleIndex="0" GroupIndex="0"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_user" ShowInCustomizationForm="True" Caption="Usu&#225;rio" Visible="false" VisibleIndex="52"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="user_nome" ShowInCustomizationForm="True" Caption="Usu&#225;rio Nome" Visible="false" VisibleIndex="53"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="user_id" ShowInCustomizationForm="True" Caption="Usuário Id" VisibleIndex="54"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="user_name" ShowInCustomizationForm="True" Caption="Usuário Nome" VisibleIndex="55"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="user_lastname" ShowInCustomizationForm="True" Caption="Usuário Sobrenome" VisibleIndex="56"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TotalCount" UnboundType="Decimal" Caption="Total Cédulas" VisibleIndex="2">
                <PropertiesTextEdit DisplayFormatString="#,#0" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TotalValueAuto" UnboundType="Decimal" Caption="Total Valor Automático" VisibleIndex="3">
                <PropertiesTextEdit DisplayFormatString="#,#0" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TotalValueManual" UnboundType="Decimal" Caption="Total Valor Manual" VisibleIndex="4">
                <PropertiesTextEdit DisplayFormatString="#,#0.00" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TotalValue" UnboundType="Decimal" Caption="Total Valor" VisibleIndex="1">
                <PropertiesTextEdit DisplayFormatString="#,#0.00" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_2" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 2" VisibleIndex="65"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_5" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 5" VisibleIndex="66"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_10" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 10" VisibleIndex="67"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_20" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 20" VisibleIndex="68"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_50" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 50" VisibleIndex="69"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_100" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 100" VisibleIndex="70"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_200" ShowInCustomizationForm="True" Caption="C&#233;dula R$ 200" VisibleIndex="71"></dx:GridViewDataTextColumn>
        </Columns>
        <GroupSummary>
            <dx:ASPxSummaryItem FieldName="TotalValue" ShowInGroupFooterColumn="TotalValue" SummaryType="Sum" DisplayFormat="{0:n2}" />
            <dx:ASPxSummaryItem FieldName="TotalCount" ShowInGroupFooterColumn="TotalCount" SummaryType="Sum" DisplayFormat="{0:n0}" />
            <dx:ASPxSummaryItem FieldName="TotalValueAuto" ShowInGroupFooterColumn="TotalValueAuto" SummaryType="Sum" DisplayFormat="{0:n2}" />
            <dx:ASPxSummaryItem FieldName="TotalValueManual" ShowInGroupFooterColumn="TotalValueManual" SummaryType="Sum" DisplayFormat="{0:n2}" />
        </GroupSummary>
        <TotalSummary>
            <dx:ASPxSummaryItem FieldName="TotalCount" SummaryType="Sum" DisplayFormat="{0:n0}" />
            <dx:ASPxSummaryItem FieldName="TotalValueAuto" SummaryType="Sum" DisplayFormat="{0:n2}" />
            <dx:ASPxSummaryItem FieldName="TotalValueManual" SummaryType="Sum" DisplayFormat="{0:n2}" />
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
            </dx:GridViewToolbar>
        </Toolbars>
        <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" FileName="GetLock-Depositos" />
    </dx:ASPxGridView>
</asp:Content>
