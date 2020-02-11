<%@ Page Title="LeaseSlips" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaseSlip.aspx.cs" Inherits="Group5_CPRG214_Lab2.LeaseSlip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Code by Elias Nahas -->

    <br />
    <br />
    <h1>Current Leases</h1>
    <div class="table table-bordered table-lg table-responsive"><!-- Table to show current leases a customer has reserved -->
        <asp:GridView ID="gvCustSlips" runat="server" AutoGenerateColumns="False" DataSourceID="CustSlipsDataSource" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="LeaseID" HeaderText="LeaseID" SortExpression="LeaseID" />
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
                <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
                <asp:BoundField DataField="DockID" HeaderText="DockID" SortExpression="DockID" />
                <asp:CheckBoxField DataField="ElectricalService" HeaderText="ElectricalService" SortExpression="ElectricalService" />
                <asp:CheckBoxField DataField="WaterService" HeaderText="WaterService" SortExpression="WaterService" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </div>
    
    <asp:ObjectDataSource ID="CustSlipsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetSlipsByCustID" TypeName="SlipsData.CustomerDB">
        <SelectParameters>
            <asp:SessionParameter Name="UserName" SessionField="UserName" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />

    <h2>Available Slips</h2><!-- Table to show slips available to lease for registered customers -->
    <asp:DropDownList ID="ddlDocks" CssClass="form-control col-3" runat="server" AutoPostBack="True" DataSourceID="DocksDataSource" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
    <asp:ObjectDataSource ID="DocksDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocks" TypeName="SlipsData.DockDB"></asp:ObjectDataSource>
    <br />

    <div class="table table-bordered table-lg table-responsive">
        <asp:GridView ID="gvLeaseSlips" runat="server" AutoGenerateColumns="False" DataSourceID="SlipsDataSource" OnSelectedIndexChanged="gvLeaseSlips_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Slip ID" SortExpression="ID" />
                <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
                <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
                <asp:BoundField DataField="DockID" HeaderText="DockID" SortExpression="DockID" />
                <asp:CheckBoxField DataField="ElectricalService" HeaderText="ElectricalService" SortExpression="ElectricalService" />
                <asp:CheckBoxField DataField="WaterService" HeaderText="WaterService" SortExpression="WaterService" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Reserve Slip ID" ShowHeader="True" Text="Reserve" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </div>
   
    <asp:ObjectDataSource ID="SlipsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAvailableSlips" TypeName="SlipsData.SlipServiceDB">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlDocks" Name="DockID" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <br />

</asp:Content>

