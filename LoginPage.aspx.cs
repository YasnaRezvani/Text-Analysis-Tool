using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using HashingFunction;

namespace Assignment5
{
    public partial class LoginPage : System.Web.UI.Page
    {
        //Load the main page if the user is already logged in
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //Handle the user click to login
        protected void loginButtonClick(object sender, EventArgs e)
        {
            //Create an XMLDocument and load the path to the XML file with the Username and Passwords
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath("/page3/App_Data/Member.xml"));

            //Hash the user password
            UnicodeEncoding uE = new UnicodeEncoding();
            byte[] passwordByte = uE.GetBytes(passwordTextBox.Text);
            SHA1Managed sha = new SHA1Managed();
            byte[] passwordHashed = sha.ComputeHash(passwordByte);

            //If the user's login details are valid(found in the xml file), the xmlNode should NOT be null
            XmlNode xmlNode = xmlDoc.SelectSingleNode($"//User[Username='{usernameTextBox.Text}' and Password='{Convert.ToBase64String(passwordHashed)}']");

            //Inform user of error status
            if (xmlNode == null)
            {
                loginConfirmationLabel.Text = "Unable to sign in, username and/or password is not correct";
                loginConfirmationLabel.Visible = true;
            }

            //The user has logged in successfully, redirect them to the main page
            else
            {
                FormsAuthentication.SetAuthCookie(usernameTextBox.Text, false);
                Response.Redirect("/page3/Member.aspx");
            }
        }
    }
}
