<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AvailableSlips.aspx.cs" Inherits="Group5_CPRG214_Lab2.AvailableSlips" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="container">
        <asp:DropDownList ID="ddlAvailableSlipsDockID" CssClass="dropdown" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocks" TypeName="SlipsData.DockDB"></asp:ObjectDataSource>
        <br />
        <asp:GridView CssClass="table" ID="dgvAvailableSlips" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
                <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
                <asp:BoundField DataField="DockID" HeaderText="DockID" SortExpression="DockID" />
            </Columns>
        </asp:GridView>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAvailableSlips" TypeName="SlipsData.SlipDB">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlAvailableSlipsDockID" Name="DockID" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>


</asp:Content>
