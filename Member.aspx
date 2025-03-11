<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Assignment5.Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<style>
    .descriptionBox {
        width: 85%;
        background-color: #2C464E;
        color: white;
        border: 2px solid black;
        padding: 15px;
        margin: auto;
}
    body{
        background-color: #e0ecf4;
        color: black;
    }
    </style>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="text-align: center">
                <h1>Welcome to the Member Page</h1>
                <div class="descriptionBox">
                    <p>This page offers users direct access to the website's services. As specified next to each service, a website link or block of text
                        may be used to perform the services. Users will find that the tools extract useful information to writers such as the word filter, top 10 content words,
                        word count, top 5 sentences, and text comparison tool.
                    </p>
                    </div>
            </div>
            <br />

   <div style="margin-left: 90px">
                    Word Filter Service<br />
    A) Analyze a string of words, filter out the stop words, and return a string with the stop words removed.<br />
    B) string WordFilter(string str)<br />
    <asp:TextBox ID="wordFilterTextBox" runat="server" Width="275px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Height="30px" Text="Perform Word Filter" Width="175px" OnClick="wordFilterButton"
        style="background-color: #111d4a; color: white;"/>
    <br />
    <asp:Literal ID="wordFilterLiteral" runat="server" Visible="False"></asp:Literal>
&nbsp;<br />
    <br />
    Word Count Service<br />
    A) Analyze a text file and return the word count of each word in key-value pairs as a string of JSON data.<br />
    B) string WordCount(Stream file)<br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="Button2" runat="server" Height="30px" OnClick="wordCountButton" Text="Perform Word Count" Width="175px"
        style="background-color: #111d4a; color: white;"/>
    <br />
    <asp:Literal ID="wordCountLiteral" runat="server" Visible="False"></asp:Literal>
&nbsp;<br />
    <br />
    Top 10 Content Words Service<br />
    A) Analyze the content at a URL and return the top 10 most occured words.<br />
    B) string[] Top10ContentWords(string url)<br />
    <asp:TextBox ID="top10TextBox" runat="server" Width="275px"></asp:TextBox>
    <asp:Button ID="Button3" runat="server" Height="30px" OnClick="top10Button" Text="Find Top 10 Content Words" Width="220px" 
        style="background-color: #111d4a; color: white;"/>
    <br />
    <asp:Literal ID="top10Literal" runat="server" Visible="False"></asp:Literal>
&nbsp;<br />
    <br />
    Top 5 Sentences Service<br />
    A) Analyze the content in the text, and return the top 5 most important sentences based on the number of top 10 words each sentence has.<br />
    B) string[] Top5Sentences(string text)<br />
    <asp:TextBox ID="top5TextBox" runat="server" Width="274px"></asp:TextBox>
    <asp:Button ID="Button4" runat="server" Height="30px" OnClick="top5Button" Text="Find Top 5 Sentences" Width="220px"
        style="background-color: #111d4a; color: white;"/>
    <br />
    <asp:Literal ID="top5Literal" runat="server" Visible="False"></asp:Literal>
&nbsp;<br />
    <br />
    Compare Text Service<br />
    A) Analyze the content at each URL, and return the top 10 most common words from each.<br />
    B) string compareText(string url1, string url2)<br />
    <asp:TextBox ID="compareTextBox1" runat="server" Width="275px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="compareTextBox2" runat="server" Width="275px"></asp:TextBox>
    <asp:Button ID="Button5" runat="server" Height="30px" OnClick="compareTextButton" Text="Compare the Texts" Width="220px"
        style="background-color: #111d4a; color: white;"/>
&nbsp;<br />
    <br />
    <asp:Literal ID="compareTextLiteral1" runat="server" Visible="False"></asp:Literal>
&nbsp;<br />
    <br />
    <asp:Literal ID="compareTextLiteral2" runat="server" Visible="False"></asp:Literal>
&nbsp;
    </div>
   
        </div>
    </form>
</body>
</html>