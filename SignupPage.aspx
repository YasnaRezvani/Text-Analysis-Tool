<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignupPage.aspx.cs" Inherits="Assignment5.SignupPage" %>

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
            background-color: #e0ecf4;
            color: black;
        }
    </style>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center">
            <h1>Welcome to the Signup Page
            </h1>
        <asp:Image ID="Image1" runat="server"/>
        <br />
            <asp:Button ID="Button2" runat="server" Text="Generate Image" OnClick="generateImageButtonClick" 
                style="font-size:20px; background-color: #111D4A; color: white"
                />
        <br />
        <br />
            <asp:Label ID="Label5" runat="server" Text="Enter the text in the image:"></asp:Label>
            <asp:TextBox ID="imageTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
            <asp:Button ID="Button3" runat="server" Text="Submit" OnClick="submitImageTextButtonClick" 
                style="font-size:20px; background-color: #111D4A; color: white"/>
        <br />
        <br />
            <asp:Label ID="imageVerifierStatus" runat="server" Text="Label" Visible="False"></asp:Label>
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
        <asp:Label ID="Label4" runat="server" Text="Re-Enter:"></asp:Label>
        <asp:TextBox ID="password2TextBox" runat="server" TextMode="Password" ></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="signUpButtonClick" Text="Sign Up" 
            style="font-size:20px; background-color: #111D4A; color: white" />
        <br />
        <br />
        <asp:Label ID="signUpConfirmationLabel" runat="server" Text="Label" Visible="False"></asp:Label>
      </div>

    </form>
</body>
</html>