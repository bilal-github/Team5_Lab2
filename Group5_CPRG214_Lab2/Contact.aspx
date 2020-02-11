<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Group5_CPRG214_Lab2.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h2><%: Title %> Us.</h2>
    <hr />
    <address>
        Inland Lake Marina<br />
        Box 123<br />
        Inland Lake, Arizona<br />
        86038<br />
        <br />
        <abbr title="Phone">Ph: </abbr>
        425.555.0100
        <br />
        <abbr title="Office Phone">O: </abbr>
        928-450-2234
        <br />
        <abbr title="Leasing Phone">L: </abbr>
        928-450-2235
        <br />
        <abbr title="Fax">F: </abbr>
        928-450-2236
        
    </address>
    <address>
        <strong>Manager: </strong> Glenn Cooke <br />
        <strong>Slip Manager: </strong>Kimberley Carson<br />
        <strong>Contact:</strong> <a href="mailto:info@inlandmarina.com">info@inlandmarina.com</a>
    </address>
</asp:Content>
