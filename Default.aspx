<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment5.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to the Writer Tool</title>

    <!--Style the description box and the Service Directory table to look presentable-->
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
        table {
            width: 100%;
            margin:auto
        }
        td {
             border: 1px solid black;
             padding: 5px
        }
        th {
            border: 1px solid black;
            background-color: #2C464E;
            color: white;
            padding: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div style="text-align: center">
            <h1>Welcome to the Writer Tool</h1>

            <div class="descriptionBox">
            <p>This program offers users services to enhance their insights in writing. By using website
                links or blocks of text, users can extract useful information such as the top 10 content words,
                word count, and many more. Users who are not logged in can click the "Member Page" button to sign up
                and access the services. Users who already have an account may click the "Member Login" button 
                to access the Member page containing the services. Staff and admin are able to test the services
                by logging in with the default Staff login. Moreover, they may also create their own credentials by altering
                the Staff.xml file. All of the developed services are integrated into the GUI in both the Member page and Staff page. 
                The services can also be tested by using the TryIt link in the Service Directory 
                table. All the services are packed into a single TryIt link as can be seen in the table below.
            </p>
                </div>
                <p>&nbsp;</p>
            <p>
                <asp:Button ID="Button1" font-size="20px" runat="server" Text="Member Page" OnClick="memberButtonClick" Height="65px" Width="175px" 
                    style="background-color: #FDE74C; color: black"/>
            </p>
                <p>&nbsp;</p>
            <p>
                <asp:Button ID="Button2" font-size="20px" runat="server" Text="Staff Page" OnClick="staffButtonClick" Height="65px" Width="175px" 
                    style="background-color: #111D4A; color: white"/>
            </p>
                <p> &nbsp;</p>
                <p style="font-size: 20px">Already have an account?</p>
            <p>
                <asp:Button ID="Button3" font-size="20px" runat="server" Text="Member Login" OnClick="memberLoginClick" Height="65px" Width="175px" 
                    style="background-color: #111D4A; color: white"/>
            </p>
          </div>
        </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
       <table style="width:90%">
           <tr>
               <th colspan="4">Application and Components Summary Table</th>
           </tr>
           <tr>
               <th colspan="4">Percentage of overall contribution: Yasna Rezvani: 100% <br />
                   Deployment URL: http://webstrar48.fulton.asu.edu/page3/Default.aspx
               </th>
           </tr>
           <tr>
               <th>Provider Name</th>
               <th>Component Type</th>
               <th>Function Description/Operation Name <br />with parameters and return types</th>
               <th>Link to TryIt Page/Resources used</th>
           </tr>
           <tr>
               <td>Yasna Rezvani</td>
               <td>ASPX page and server controls</td>
               <td>Default.aspx: Describe the app and create buttons to access other pages.</td>
               <td>HTML for GUI design and C# code for codebehind file</td>
           </tr>
           <tr>
               <td>Yasna Rezvani</td>
               <td>ASPX page and access controls</td>
               <td>Member.aspx: Describe the user services and provide GUI to test said services.</td>
               <td>HTML for GUI design and C# code for codebehind file</td>
           </tr>
           <tr>
               <td>Yasna Rezvani</td>
               <td>ASPX page and access controls</td>
               <td>Staff.aspx: Describe the user services and provide GUI to test said services.</td>
               <td>HTML for GUI design and C# code for codebehind file</td>
           </tr>
           <tr>
               <td>Yasna Rezvani</td>
               <td>User Control</td>
               <td>Sign up page that allows users to sign up for a member account with image verificaiton.</td>
               <td>HTML for GUI design and C# code for codebehind file</td>
           </tr>
           <tr>
               <td>Yasna Rezvani</td>
               <td>User Control</td>
               <td>Staff login page that allows the TA/Admin to access the Staff Page</td>
               <td>HTML for GUI design and C# code for codebehind file</td>
           </tr>
           <tr>
               <td>Yasna Rezvani</td>
               <td>Global.asax</td>
               <td>At the start of every session, expires the cookie so users aren't wrongfully logged in</td>
               <td>C# code in the Global.asax file</td>
           </tr>
           <tr>
               <td>Yasna Rezvani</td>
               <td>User Control</td>
               <td>Login page that allows user authentication </td>
               <td>HTML for GUI design and C# code for codebehind file. Linked to Default.aspx</td>
           </tr>
           <tr>
               <td>Yasna Rezvani</td>
               <td>RESTful Service</td>
               <td>Word Filter:<br>
                   Input: string<br>
                   Output: string
               </td>
               <td>Deployed in WebStrar: http://webstrar48.fulton.asu.edu/page2/TryIt</td>
           </tr>
           <tr>
               <td>Yasna Rezvani</td>
               <td>WSDL Service</td>
               <td>Word Count:<br>
                   Input: File<br>
                   Output: string
               </td>
               <td>Deployed in WebStrar: http://webstrar48.fulton.asu.edu/page2/TryIt</td>
           </tr>
           <tr>
               <td>Yasna Rezvani</td>
               <td>RESTful Service</td>
               <td>Top 10 Content Words: <br>
                   Input: string URL <br> 
                   Output: string array
               </td>
               <td>Deployed in WebStrar: http://webstrar48.fulton.asu.edu/page2/TryIt</td>
           </tr>
           <tr>
               <td>Yasna Rezvani</td>
               <td>RESTful Service</td>
               <td>Top 5 Sentences: <br>
                   Input: string <br>
                   Output: string array
               </td>
               <td>Deployed in WebStrar: http://webstrar48.fulton.asu.edu/page2/TryIt</td>
           </tr>
           <tr>
               <td>Yasna Rezvani</td>
               <td>RESTful Service</td>
               <td>Compare Text: <br>
                   Input: string URL1, string URL2 <br>
                   Output: string
               </td>
               <td>Deployed in WebStrar: http://webstrar48.fulton.asu.edu/page2/TryIt</td>
           </tr>
</table>

    </form>
</body>
</html>

