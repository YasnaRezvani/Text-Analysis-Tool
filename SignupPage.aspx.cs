using System;
using System.Collections.Generic;
using System.Drawing;
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
    public partial class SignupPage : System.Web.UI.Page
    {
        string randomGeneratedString = String.Empty; //Declare the random string we are going to generate

        bool imageVerified; //Declare a flag for if the image is verified
        
        //Load the main page if the user is already logged in
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/page3/Default.aspx");
            }
        }

        //Handle the user click to generate a random image
        protected void generateImageButtonClick(object sender, EventArgs e)
        {
            //Instantiate a string of all possible characters
            string allPossibleChars = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVYXYZ";

            Random random = new Random(); //Create a Random object

            //Choose 5 random characters from the "allPossibleChars" string, and append it to the random generated string
            for (int i = 0; i < 5; i++)
            {
                char randomChar = allPossibleChars[random.Next(allPossibleChars.Length)];
                randomGeneratedString += randomChar;
            }

            //Set the string in ViewState
            ViewState["randomGeneratedString"] = randomGeneratedString;

            //Use the ASU service to generate the image with our random string
            string url = "https://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + randomGeneratedString;

            Image1.ImageUrl = url; //set the Image to the image we generated in the url
        }

        //Handle the user click to submit their text against the image text
        protected void submitImageTextButtonClick(object sender, EventArgs e)
        {
            if (ViewState["randomGeneratedString"].ToString() == String.Empty)
            {
                imageVerifierStatus.Text = "You must generate an image";
                imageVerifierStatus.Visible = true;
            }
            else
            {
                //If the User answer matches the actual string, send verification message and verify that the user passed the image captcha
                if (imageTextBox.Text == ViewState["randomGeneratedString"].ToString())
                {
                    imageVerifierStatus.Text = "Congrats! You are not a robot!";
                    imageVerifierStatus.ForeColor = ColorTranslator.FromHtml("#1EBF18");
                    imageVerifierStatus.Visible = true;
                    imageVerified = true;
                    ViewState["imageVerified"] = imageVerified;
                }

                //Else, send user error message and store false for the image verified boolean
                else
                {
                    imageVerifierStatus.Text = "Incorrect! Please try again.";
                    imageVerifierStatus.Visible = true;
                    imageVerifierStatus.ForeColor = ColorTranslator.FromHtml("#c80000");
                    imageVerified = false;
                    ViewState["imageVerified"] = imageVerified;
                }
                
            }
        }

        //Handle the user click to sign up
        protected void signUpButtonClick(object sender, EventArgs e)
        {
            //Deny user account if they did not complete the image verification
            if (!((bool)ViewState["imageVerified"]))
            {
                signUpConfirmationLabel.Text = "You must pass the Image Verification to continue";
                signUpConfirmationLabel.Visible = true;
            }

            //Image verification is valid, allow user to continue
            else
            {
                //Inform the user if the passwords don't match
                if (passwordTextBox.Text != password2TextBox.Text)
                {
                    signUpConfirmationLabel.Text = "The passwords do NOT match";
                    signUpConfirmationLabel.Visible = true;
                }
                else
                {
                    //Hash the user password
                    UnicodeEncoding uE = new UnicodeEncoding();
                    byte[] passwordByte = uE.GetBytes(passwordTextBox.Text);
                    SHA1Managed sha = new SHA1Managed();
                    byte[] passwordHashed = sha.ComputeHash(passwordByte);

                    //Create an XMLDocument and load the path to the XML file with the Username and Passwords
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(Server.MapPath("/page3/App_Data/Member.xml"));

                    //If the user's username is already in the xml file, the xmlNode should NOT be null
                    XmlNode xmlNode = xmlDoc.SelectSingleNode($"//User[Username='{usernameTextBox.Text}']");

                    //If the xmlNode is not null, then the username must've been found in the xml file
                    if (xmlNode != null)
                    {
                        signUpConfirmationLabel.Text = "This username is already taken, please try again";
                        signUpConfirmationLabel.Visible = true;
                    }

                    //The username is valid, continue creating their account
                    else
                    {

                        //Create the "Users" root element, and append a "User" element
                        XmlElement users = xmlDoc.DocumentElement;
                        XmlElement user = xmlDoc.CreateElement("User");
                        users.AppendChild(user);

                        //Create the Username and Password element, and store user's information
                        XmlElement username = xmlDoc.CreateElement("Username");
                        XmlElement password = xmlDoc.CreateElement("Password");
                        username.InnerText = usernameTextBox.Text;
                        password.InnerText = Convert.ToBase64String(passwordHashed); //convert the hashed password to string
                        user.AppendChild(username);
                        user.AppendChild(password);

                        xmlDoc.Save(Server.MapPath("/page3/App_Data/Member.xml")); //Save the data in the file

                        //Authenticate the user since they signed up, and redirect them to the Member page
                        FormsAuthentication.SetAuthCookie(usernameTextBox.Text, false);
                        Response.Redirect("/page3/Member.aspx");
                    }
                }
            }
        }
    }
}
