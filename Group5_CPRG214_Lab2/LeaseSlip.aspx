<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaseSlip.aspx.cs" Inherits="Group5_CPRG214_Lab2.LeaseSlip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:DropDownList ID="ddlDocks" runat="server" AutoPostBack="True" DataSourceID="DocksDataSource" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
    <asp:ObjectDataSource ID="DocksDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocks" TypeName="SlipsData.DockDB"></asp:ObjectDataSource>
    <asp:GridView ID="gvLeaseSlips" runat="server" AutoGenerateColumns="False">
    </asp:GridView>

</asp:Content>
