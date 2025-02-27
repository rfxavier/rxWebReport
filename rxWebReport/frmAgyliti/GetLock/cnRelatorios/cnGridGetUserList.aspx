<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridGetUserList.aspx.cs" Inherits="rxWebReport.frmAgyliti.GetLock.cnRelatorios.cnGridGetUserList" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div><h4>Lista Usuários</h4></div>

    <div style="display: flex">
        <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="170px" NullText="Cofre ID"></dx:ASPxTextBox>
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Listar Usuários" OnClick="ASPxButton1_Click" BackColor="#2A4E70" CssClass="noImage" ForeColor="White"></dx:ASPxButton>
    </div>

    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" OnDataBinding="ASPxGridView1_DataBinding" KeyFieldName="id" OnAutoFilterCellEditorInitialize="ASPxGridView1_AutoFilterCellEditorInitialize" OnProcessColumnAutoFilter="ASPxGridView1_ProcessColumnAutoFilter">
        <SettingsPager PageSize="20"></SettingsPager>

        <Settings ShowHeaderFilterButton="True" ShowFilterBar="Visible" ShowFilterRow="true" ShowFilterRowMenu="true"></Settings>

        <SettingsCookies Enabled="true" />
        
        <Columns>
            <dx:GridViewDataTextColumn FieldName="TopicDeviceId" Caption="Cofre Id" VisibleIndex="0"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CofreNome" Caption="Cofre Nome" VisibleIndex="1"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="TimestampDatetime" SortIndex="0" SortOrder="Descending" Caption="Data Status" VisibleIndex="2" Settings-FilterMode="Value">
                <CellStyle Wrap="False"></CellStyle>
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="TimestampDatetime" SortIndex="1" Caption="Hora Status" VisibleIndex="3" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" Settings-ShowInFilterControl="False">
                <CellStyle Wrap="False"></CellStyle>
                <PropertiesDateEdit DisplayFormatString="HH:mm:ss" EditFormatString="HH:mm:ss">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="trackCreationTime" SortIndex="2" SortOrder="Descending" Caption="Data Mensagem" VisibleIndex="4" Settings-FilterMode="Value">
                <CellStyle Wrap="False"></CellStyle>
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="trackCreationTime" SortIndex="3" Caption="Hora Mensagem" VisibleIndex="5" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" Settings-ShowInFilterControl="False">
                <CellStyle Wrap="False"></CellStyle>
                <PropertiesDateEdit DisplayFormatString="HH:mm:ss" EditFormatString="HH:mm:ss">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="Total" Caption="Total" VisibleIndex="6"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="UserIndex" Caption="Usuário Índice" VisibleIndex="7"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="UserId" Caption="Usuário Id" VisibleIndex="8"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="UserEnable" Caption="Usuário Habilitado" VisibleIndex="9"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="UserName" Caption="Usuário Nome" VisibleIndex="10"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="UserLastName" Caption="Usuário Sobrenome" VisibleIndex="11"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="UserPasswd" Caption="Usuário Senha" VisibleIndex="12"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="IsAck" Caption="É Ack" VisibleIndex="13"></dx:GridViewDataTextColumn>
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
        <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" FileName="GetLock-GetUserList" Landscape="true" />
        <SettingsBehavior EnableCustomizationWindow="true" />
        <Styles>
            <AlternatingRow Enabled="True" BackColor="#D6EBFF">
            </AlternatingRow>
            <Cell Wrap="False"></Cell>
        </Styles>
    </dx:ASPxGridView>
</asp:Content>
