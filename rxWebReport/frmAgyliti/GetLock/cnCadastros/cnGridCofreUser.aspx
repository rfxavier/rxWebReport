<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridCofreUser.aspx.cs" Inherits="rxWebReport.frmAgyliti.GetLock.cnCadastros.cnGridCofreUser" %>

<%@ Register Assembly="Microsoft.AspNet.EntityDataSource" Namespace="Microsoft.AspNet.EntityDataSource" TagPrefix="ef" %>

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
    <div><h4>Cadastro Cofre Usuário</h4></div>
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="2" ColumnCount="2">
        <Items>
            <dx:LayoutItem ColSpan="1" HorizontalAlign="Left" Caption="Cofre">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">

                        <dx:ASPxDropDownEdit ClientInstanceName="checkComboBox" ID="ASPxDropDownEdit1" Width="285px" runat="server" AnimationType="None">
                            <DropDownWindowStyle CssClass="dropDownWindow" />
                            <DropDownWindowTemplate>
                                <dx:ASPxListBox Width="100%" ID="ASPxListBoxCofre" ClientInstanceName="checkListBox" SelectionMode="CheckColumn" CssClass="listBox" runat="server" Height="200" EnableSelectAll="true" OnInit="ASPxListBoxCofre_Init">
                                    <FilteringSettings ShowSearchUI="true" />
                                    <Border BorderStyle="None" />
                                    <BorderBottom BorderStyle="Solid" BorderWidth="1px" />
                                    <Items>
                                    </Items>
                                    <ClientSideEvents SelectedIndexChanged="updateText" Init="updateText" />
                                </dx:ASPxListBox>
                                <table style="width: 100%">
                                    <tr>
                                        <td style="padding: 4px">
                                            <dx:ASPxButton ID="ASPxButton1" AutoPostBack="False" runat="server" Text="Close" Style="float: right">
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
            <dx:LayoutItem ColSpan="1" Caption="ID Usu&#225;rio">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxTextBox runat="server" ID="ID_Usuario"></dx:ASPxTextBox>

                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem ColSpan="1" Caption="Nome">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxTextBox runat="server" ID="Nome"></dx:ASPxTextBox>

                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Sobrenome" ColSpan="1">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxTextBox runat="server" ID="Sobrenome"></dx:ASPxTextBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>

            <dx:LayoutItem ColSpan="1" Caption="Habilitado">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxCheckBox runat="server" AccessibilityLabelText="" CheckState="Unchecked" ID="Habilitado"></dx:ASPxCheckBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem ColSpan="1" Caption="Access Level">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxComboBox ID="Access_Level" runat="server" ValueType="System.String" ValueField="ID" TextFormatString="{0}" DropDownStyle="DropDown" OnDataBinding="Access_Level_DataBinding">
                        </dx:ASPxComboBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem ColSpan="1" Caption="Senha">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxTextBox runat="server" ID="Senha"></dx:ASPxTextBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="" ShowCaption="False" ColSpan="1">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxButton runat="server" ID="InsertBatch" Text="Inserir Usuários" OnClick="ASPxButton1_Click">
                            <ClientSideEvents Click="function(s, e){ checkListBox.UnselectAll(); }" />
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
        </Items>
    </dx:ASPxFormLayout>

    <dx:ASPxGridView ID="ASPxGridView1" runat="server" KeyFieldName="id" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" OnDataBinding="ASPxGridView1_DataBinding" OnRowDeleting="ASPxGridView1_RowDeleting" OnRowInserting="ASPxGridView1_RowInserting" OnRowUpdating="ASPxGridView1_RowUpdating" OnRowValidating="ASPxGridView1_RowValidating">
        <SettingsPager PageSize="20"></SettingsPager>
        <SettingsDataSecurity AllowInsert="true" />
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="True" ShowInCustomizationForm="True" VisibleIndex="0" ShowNewButtonInHeader="True" ShowDeleteButton="True"></dx:GridViewCommandColumn>
            <dx:GridViewDataColumn FieldName="id_cofre" Caption="ID Cofre" />
            <dx:GridViewDataColumn FieldName="data_user" Caption="ID Usuário" />
            <dx:GridViewDataColumn FieldName="nome" Caption="Nome" />
            <dx:GridViewDataColumn FieldName="sobrenome" Caption="Sobrenome" />
            <dx:GridViewDataColumn FieldName="enable" Caption="Habilitado" />
            <dx:GridViewDataComboBoxColumn FieldName="access_level" Caption="Access Level">
                <PropertiesComboBox TextField="access_level" IncrementalFilteringMode="Contains" ValueField="txt_access_level"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataColumn FieldName="passwd" Caption="Senha" />
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

    <div><h4>Operações Usuário</h4></div>
    <dx:ASPxGridView ID="ASPxGridView2" runat="server" KeyFieldName="Id" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" OnDataBinding="ASPxGridView2_DataBinding">
        <SettingsPager PageSize="20"></SettingsPager>
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewDataDateColumn FieldName="TimestampDatetime" SortIndex="0" SortOrder="Descending" Caption="Data Operação" VisibleIndex="0" Settings-FilterMode="Value">
                <CellStyle Wrap="False"></CellStyle>
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm:ss">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataColumn FieldName="TopicDeviceId" Caption="ID Cofre" />
            <dx:GridViewDataColumn FieldName="Destiny" Caption="Destiny" />
            <dx:GridViewDataColumn FieldName="Operation" Caption="Operação" />
            <dx:GridViewDataColumn FieldName="UserId" Caption="User ID" />
            <dx:GridViewDataColumn FieldName="Response" Caption="Resp" />
        </Columns>
        <Styles>
            <Cell Wrap="False"></Cell>
        </Styles>
    </dx:ASPxGridView>

</asp:Content>
