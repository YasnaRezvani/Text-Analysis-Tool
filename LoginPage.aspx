<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Assignment5.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <style>
        body, input[type="text"], input[type="password"]{
            font-size: 20px;
        }
        body{
            text-align: center;
            background-color: #E0ECF4;
        }
    </style>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to the Login Page
            </h1>
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox ID="usernameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password" ></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="loginButtonClick" Text="Login" 
            style="font-size: 20px; background-color: #111D4A; color: white"/>
        <br />
        <br />
        <asp:Label ID="loginConfirmationLabel" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>