<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnCofrePorListaCofres.aspx.cs" Inherits="rxWebReport.frmAgyliti.GetLock.cnCofrePorListaCofres.cnCofrePorListaCofres" %>

<%@ Register Assembly="DevExpress.Dashboard.v21.1.Web.WebForms, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <style>  
        .dx-dashboard-item-header {  
            height:auto;  
        }  
        .dx-dashboard-title-toolbar .dx-dashboard-ellipsis {  
            font-size: 22px;  
            padding-top: 10px;  
            padding-bottom: 10px;
            font-weight: bold;
            color: black;
        }  
        .dx-toolbar-items-container {
            background-color: white;
        }  
    </style>  
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div style="position: absolute; left:320px; right:0; top:70px; bottom:0;">
        <dx:ASPxDashboard ID="ASPxDashboard1" runat="server" WorkingMode="ViewerOnly" Width="100%" Height="100%" OnDataLoading="ASPxDashboard1_DataLoading" OnConfigureDataReloadingTimeout="ASPxDashboard1_ConfigureDataReloadingTimeout">

        </dx:ASPxDashboard>
    </div>
</asp:Content>
