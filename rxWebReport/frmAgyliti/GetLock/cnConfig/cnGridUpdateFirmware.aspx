<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridUpdateFirmware.aspx.cs" Inherits="rxWebReport.frmAgyliti.GetLock.cnConfig.cnGridUpdateFirmware" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <script type="text/javascript">
        var textSeparator = ",";
        function updateText() {
            var selectedItems = checkListBox.GetSelectedItems();
            checkComboBox.SetText(getSelectedItemsText(selectedItems));
        }
        function synchronizeListBoxValues(dropDown, args) {
            checkListBox.UnselectAll();
            var texts = dropDown.GetText().split(textSeparator);
            var values = getValuesByTexts(texts);
            checkListBox.SelectValues(values);
            updateText(); // for remove non-existing texts
        }
        function getSelectedItemsText(items) {
            var texts = [];
            for (var i = 0; i < items.length; i++)
                    texts.push(items[i].text);
            return texts.join(textSeparator);
        }
        function getValuesByTexts(texts) {
            var actualValues = [];
            var item;
            for(var i = 0; i < texts.length; i++) {
                item = checkListBox.FindItemByText(texts[i]);
                if(item != null)
                    actualValues.push(item.value);
            }
            return actualValues;
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div><h4>Atualizar Firmware</h4></div>
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="3" ColumnCount="3">
        <Items>
            <dx:LayoutItem ColSpan="1" HorizontalAlign="Left" Caption="Cofre">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <%--<dx:ASPxComboBox ID="ASPxComboCofreID" runat="server" ValueType="System.String" OnDataBinding="ASPxComboCofreID_DataBinding"  Width="300px"></dx:ASPxComboBox>--%>

                    <dx:ASPxDropDownEdit ClientInstanceName="checkComboBox" ID="ASPxDropDownEdit1" Width="285px" runat="server" AnimationType="None">
                        <DropDownWindowStyle CssClass="dropDownWindow" />
                        <DropDownWindowTemplate>
                            <dx:ASPxListBox Width="100%" ID="ASPxListBoxCofre" ClientInstanceName="checkListBox" SelectionMode="CheckColumn" CssClass="listBox" runat="server" Height="200" EnableSelectAll="true" OnInit="ASPxListBoxCofre_Init">
                                <FilteringSettings ShowSearchUI="true"/>
                                <Border BorderStyle="None" />
                                <BorderBottom BorderStyle="Solid" BorderWidth="1px" />
                                <Items>
                                </Items>
                                <ClientSideEvents SelectedIndexChanged="updateText" Init="updateText" />
                            </dx:ASPxListBox>
                            <table style="width: 100%">
                                <tr>
                                    <td style="padding: 4px">
                                        <dx:ASPxButton ID="ASPxButton1" AutoPostBack="False" runat="server" Text="Close" style="float: right">
                                            <ClientSideEvents Click="function(s, e){ checkComboBox.HideDropDown(); }" />
                                        </dx:ASPxButton>
                                    </td>
                                </tr>
                            </table>
                        </DropDownWindowTemplate>
                        <ClientSideEvents TextChanged="synchronizeListBoxValues" DropDown="synchronizeListBoxValues" />
                    </dx:ASPxDropDownEdit>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
                <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
            </dx:LayoutItem>
            <dx:LayoutItem ColSpan="1" Caption="Nome arquivo">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxComboBox runat="server" ID="ASPxFileName" Width="350px"></dx:ASPxComboBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem ColSpan="1" HorizontalAlign="Right" ShowCaption="False">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxButton runat="server" Text="Atualizar Firmware" BackColor="#2A4E70" CssClass="noImage" ForeColor="White" ID="ASPxButton1" OnClick="ASPxButton1_Click">
                            <ClientSideEvents Click="function(s, e){ checkListBox.UnselectAll(); }" />
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:EmptyLayoutItem ColSpan="1"></dx:EmptyLayoutItem>
            <dx:LayoutItem ColSpan="1" ShowCaption="False" HorizontalAlign="Center">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxButton runat="server" ID="ASPxDeleteDir" Text="Deletar arquivos" OnClick="ASPxDeleteDir_Click"></dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem ColSpan="1" ShowCaption="False" Caption="" HorizontalAlign="Right">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxUploadControl runat="server" AutoStartUpload="True" ShowProgressPanel="True" ShowUploadButton="True" AddUploadButtonsHorizontalPosition="InputRightSide" Width="280px" ID="ASPxUploadControl1" OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete">
                            <ValidationSettings AllowedFileExtensions=".srec" MaxFileSize="409600000"></ValidationSettings>

                            <ClientSideEvents FileUploadComplete="function(s, e) {  
                                window.location.reload();  
                            }"></ClientSideEvents>

                            <BrowseButton Text="Fazer upload de um arquivo de firmware..."></BrowseButton>
                        </dx:ASPxUploadControl>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
                <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
            </dx:LayoutItem>
            <dx:LayoutItem ShowCaption="False" ColSpan="3" ColumnSpan="3">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxGridView runat="server" AutoGenerateColumns="False" KeyFieldName="id" ID="ASPxGridView1" OnDataBinding="ASPxGridView1_DataBinding" OnAutoFilterCellEditorInitialize="ASPxGridView1_AutoFilterCellEditorInitialize" OnProcessColumnAutoFilter="ASPxGridView1_ProcessColumnAutoFilter">
                            <SettingsPager PageSize="20"></SettingsPager>

                            <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowHeaderFilterButton="True" ShowFilterBar="Visible"></Settings>

                            <SettingsBehavior EnableCustomizationWindow="True"></SettingsBehavior>

                            <SettingsCookies Enabled="True"></SettingsCookies>

                            <SettingsPopup>
                                <FilterControl AutoUpdatePosition="False"></FilterControl>
                            </SettingsPopup>

                            <SettingsExport FileName="GetLock-UpdateFirmware" Landscape="True" EnableClientSideExportAPI="True" ExcelExportMode="WYSIWYG"></SettingsExport>
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="TopicDeviceId" ShowInCustomizationForm="True" Caption="Cofre Id" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CofreNome" ShowInCustomizationForm="True" Caption="Cofre Nome" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="TimestampDatetime" SortIndex="0" SortOrder="Descending" ShowInCustomizationForm="True" Caption="Data Status" VisibleIndex="2">
                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy"></PropertiesDateEdit>

                                    <CellStyle Wrap="False"></CellStyle>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn FieldName="TimestampDatetime" SortIndex="1" ShowInCustomizationForm="True" Caption="Hora Status" VisibleIndex="4">
                                    <PropertiesDateEdit DisplayFormatString="HH:mm:ss" EditFormatString="HH:mm:ss"></PropertiesDateEdit>

                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" ShowInFilterControl="False"></Settings>

                                    <CellStyle Wrap="False"></CellStyle>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn FieldName="trackCreationTime" SortIndex="2" SortOrder="Descending" ShowInCustomizationForm="True" Caption="Data Mensagem" VisibleIndex="3">
                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy"></PropertiesDateEdit>

                                    <CellStyle Wrap="False"></CellStyle>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn FieldName="trackCreationTime" SortIndex="3" ShowInCustomizationForm="True" Caption="Hora Mensagem" VisibleIndex="5">
                                    <PropertiesDateEdit DisplayFormatString="HH:mm:ss" EditFormatString="HH:mm:ss"></PropertiesDateEdit>

                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" ShowInFilterControl="False"></Settings>

                                    <CellStyle Wrap="False"></CellStyle>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="UpdateFirmware" ShowInCustomizationForm="True" Caption="Update Firmware" VisibleIndex="6"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="IsAck" ShowInCustomizationForm="True" Caption="&#201; Ack" VisibleIndex="7"></dx:GridViewDataTextColumn>
                            </Columns>
                            <Toolbars>
                                <dx:GridViewToolbar>
                                    <Items>
                                        <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Exportar para Excel"></dx:GridViewToolbarItem>
                                        <dx:GridViewToolbarItem Command="ExportToPdf" Text="Exportar para PDF"></dx:GridViewToolbarItem>
                                        <dx:GridViewToolbarItem Command="ShowCustomizationWindow"></dx:GridViewToolbarItem>
                                    </Items>

                                    <SettingsAdaptivity Enabled="True" EnableCollapseRootItemsToIcons="True"></SettingsAdaptivity>
                                </dx:GridViewToolbar>
                            </Toolbars>

                            <Styles>
                                <AlternatingRow Enabled="True" BackColor="#D6EBFF"></AlternatingRow>
                            </Styles>
                        </dx:ASPxGridView>




                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
        </Items>
    </dx:ASPxFormLayout>
</asp:Content>
