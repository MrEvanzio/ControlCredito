<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ControlCredito._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <br />Nombre<br />
        <asp:TextBox ID="user_name" runat="server"></asp:TextBox>
        <asp:Label ID="error_name" runat="server" ForeColor="Red" Text=""></asp:Label>

        <br />Monto<br />
        <asp:TextBox ID="user_monto" runat="server"></asp:TextBox>UF<br />
        <asp:Label ID="error_monto" runat="server" ForeColor="Red" Text=""></asp:Label>
        

        <br />Cuotas (años)<br />
        
        <asp:DropDownList ID="user_monto_list" runat="server">
        </asp:DropDownList>
        <asp:Label ID="error_list" runat="server" ForeColor="Red" Text=""></asp:Label>

        <br />Seguro Desgravamen<br />
        <asp:RadioButton ID="desTrue" Groupname="des" runat="server" Text="Si"/>
        <asp:RadioButton ID="desFalse" Groupname="des" Text="No" runat="server" /><br />
        <asp:Label ID="error_des" runat="server" ForeColor="Red" Text=""></asp:Label>

        <br />Seguro Contra Incendios<br />
        <asp:RadioButton ID="burnTrue" GroupName="burn" Text ="Si" runat="server" />
        <asp:RadioButton ID="burnFalse" GroupName="burn" Text ="No" runat="server" /><br />
        <asp:Label ID="error_burn" runat="server" ForeColor="Red" Text=""></asp:Label>
        <br />
        <asp:Button OnClick="Enviar_Click" ID="Button1" runat="server" Text="Button" />
        <br /> <asp:Label ID="valorFinal" runat="server" ForeColor="blue" Text=""></asp:Label>
    </div>

</asp:Content>
