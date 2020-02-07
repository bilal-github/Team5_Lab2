<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaseSlip.aspx.cs" Inherits="Group5_CPRG214_Lab2.LeaseSlip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />
   <asp:GridView ID="gvCustSlips" runat="server" AutoGenerateColumns="False" DataSourceID="CustSlipsDataSource">
        <Columns>
            <asp:BoundField DataField="LeaseID" HeaderText="LeaseID" SortExpression="LeaseID" />
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
            <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
            <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
            <asp:BoundField DataField="DockID" HeaderText="DockID" SortExpression="DockID" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="CustSlipsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetSlipsByCustID" TypeName="SlipsData.CustomerDB">
        <SelectParameters>
            <asp:SessionParameter Name="UserName" SessionField="UserName" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:DropDownList ID="ddlDocks" runat="server" AutoPostBack="True" DataSourceID="DocksDataSource" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
    <asp:ObjectDataSource ID="DocksDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocks" TypeName="SlipsData.DockDB"></asp:ObjectDataSource>
    <asp:GridView ID="gvLeaseSlips" runat="server" AutoGenerateColumns="False" DataSourceID="SlipsDataSource" OnSelectedIndexChanged="gvLeaseSlips_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
            <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
            <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
            <asp:BoundField DataField="DockID" HeaderText="DockID" SortExpression="DockID" />
            <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Lease Slip" ShowHeader="True" Text="Lease Slip" />
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource ID="SlipsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAvailableSlips" TypeName="SlipsData.SlipDB">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlDocks" Name="DockID" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <br />

</asp:Content>

