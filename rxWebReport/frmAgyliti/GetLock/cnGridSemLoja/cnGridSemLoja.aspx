<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridSemLoja.aspx.cs" Inherits="rxWebReport.frmRx.Agyliti.GetLock.cnGridSemLoja.cnGridSemLoja" %>
<%@ MasterType VirtualPath="~/Main.master" %>
<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <script type="text/javascript">
        function OnToolbarItemClick(s, e) {
            e.processOnServer=true;
            e.usePostBack=true;
        }
    </script>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="updateDetails" runat="server" OnUnload="UpdatePanel_Unload" UpdateMode="Conditional">
        <ContentTemplate>
            <div><h4>Ocorrências Sem Loja</h4></div>

            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" OnDataBinding="ASPxGridView1_DataBinding" KeyFieldName="id" OnAutoFilterCellEditorInitialize="ASPxGridView1_AutoFilterCellEditorInitialize" OnProcessColumnAutoFilter="ASPxGridView1_ProcessColumnAutoFilter" OnToolbarItemClick="ASPxGridView1_ToolbarItemClick">
                <SettingsPager PageSize="20"></SettingsPager>

                <Settings ShowHeaderFilterButton="True" ShowFilterBar="Visible" ShowFilterRow="true" ShowFilterRowMenu="true"></Settings>

                <SettingsCookies Enabled="true" />
        
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" ShowClearFilterButton="true" SelectAllCheckboxMode="Page" VisibleIndex="0"></dx:GridViewCommandColumn>
                    <dx:GridViewDataDateColumn FieldName="data_tmst_end_datetime" SortIndex="0" SortOrder="Descending" Caption="Data Movimento" VisibleIndex="1" Settings-FilterMode="Value">
                        <CellStyle Wrap="False"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="data_tmst_end_datetime" SortIndex="1" Caption="Hora Movimento" VisibleIndex="2" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" Settings-ShowInFilterControl="False">
                        <CellStyle Wrap="False"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm:ss" EditFormatString="HH:mm:ss">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="id_cofre" Caption="ID Cofre" VisibleIndex="2"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="info_id" Caption="ID &#218;nico Cofre" VisibleIndex="41"></dx:GridViewDataTextColumn>
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
                    <dx:GridViewDataTextColumn FieldName="info_ip" Caption="IP" VisibleIndex="42"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="info_mac" Caption="Mac" VisibleIndex="43"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="info_json" Caption="Json" VisibleIndex="44"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_hash" Caption="ID Operação" VisibleIndex="45"></dx:GridViewDataTextColumn>
                </Columns>
                <Toolbars>
                    <dx:GridViewToolbar>
                        <Items>
                            <dx:GridViewToolbarItem Text="APLICAR LOJA"></dx:GridViewToolbarItem>
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
                <ClientSideEvents ToolbarItemClick="OnToolbarItemClick" />
            </dx:ASPxGridView>
            <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" Width="320" CloseAction="CloseButton" CloseOnEscape="true" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pc" HeaderText="Aplicar Loja" AllowDragging="True" PopupAnimationType="None" EnableViewState="False" AutoUpdatePosition="true">
                <ContentCollection>
                    <dx:PopupControlContentControl runat="server">
                        <dx:ASPxPanel ID="Panel1" runat="server" DefaultButton="btOK">
                            <PanelCollection>
                                <dx:PanelContent runat="server">
                                    <dx:ASPxFormLayout runat="server" ID="ASPxFormLayout1" Width="100%" Height="100%">
                                        <Items>
                                            <dx:LayoutItem Caption="Loja">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox runat="server" ID="comboLoja" DropDownStyle="DropDownList" TextFormatString="{1} ({0})" IncrementalFilteringMode="StartsWith" OnDataBinding="comboLoja_DataBinding">
                                                            <Columns>
                                                                <dx:ListBoxColumn FieldName="cod_loja" Caption="Código Loja" Width="50px" />
                                                                <dx:ListBoxColumn FieldName="nome_loja" Caption="Nome Loja" Width="150px" />
                                                                <dx:ListBoxColumn FieldName="nome_cliente" Caption="Nome Cliente" Width="150px" />
                                                                <dx:ListBoxColumn FieldName="nome_rede" Caption="Nome Rede" Width="150px" />
                                                            </Columns>
                                                        </dx:ASPxComboBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Paddings-PaddingTop="19" Caption="Mensagens selecionadas">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxLabel runat="server" ClientInstanceName="tbLogin" Width="100%" ID="lbTitle"></dx:ASPxLabel>


                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem ShowCaption="False" ColSpan="1">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                        <dx:ASPxButton runat="server" Text="OK" Width="80px" ID="btOK" Style="float: left; margin-right: 8px" OnClick="btOK_Click"></dx:ASPxButton>

                                                        <dx:ASPxButton runat="server" AutoPostBack="False" Text="Cancel" Width="80px" ID="btCancel" Style="float: left; margin-right: 8px">
                                                            <ClientSideEvents Click="function(s, e) { pc.Hide(); }"></ClientSideEvents>
                                                        </dx:ASPxButton>

                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>

                                                <Paddings PaddingTop="19px"></Paddings>
                                            </dx:LayoutItem>
                                        </Items>
                                    </dx:ASPxFormLayout>
                                    <dx:ASPxHiddenField ID="ASPxHiddenField1" runat="server"></dx:ASPxHiddenField>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxPanel>
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:ASPxPopupControl>
        </ContentTemplate>
    </asp:UpdatePanel>
    <dx:EntityServerModeDataSource ID="EntityServerModeDataSource1" runat="server" ContextTypeName="rxApp.Models.ApplicationDbContext" TableName="GetLockMessageViews" OnSelecting="EntityServerModeDataSource1_Selecting" />
</asp:Content>