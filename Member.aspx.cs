using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.Xml;

namespace Assignment5
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //Handle Word Filter Button Click
        protected void wordFilterButton(object sender, EventArgs e)
        {
            Uri baseUri = new Uri("http://webstrar48.fulton.asu.edu/page1/Service.svc/"); //Create base address
            UriTemplate uriTemplate = new UriTemplate("WordFilter?str={str}"); //Define the specific service and the space for the user input
            Uri completeUri = uriTemplate.BindByPosition(baseUri, wordFilterTextBox.Text); //Append the user value to the parameter of the service
            WebClient webClient = new WebClient(); //Create a proxy
            byte[] result = webClient.DownloadData(completeUri); //Download the data from the RESTful service
            wordFilterLiteral.Text = System.Text.Encoding.UTF8.GetString(result); //Retrieve the string content and display it to user
            wordFilterLiteral.Visible = true;
        }

        //Handle Word Count Button Click
        protected void wordCountButton(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile) //Check if user has chosen a file
            {
                if (FileUpload1.PostedFile.ContentLength <= 1048576) //Limit to 1MB
                {
                    //Send the File as a Stream type
                    myServerRef.Service1Client myClient = new myServerRef.Service1Client();
                    string result = myClient.WordCount(FileUpload1.FileContent);
                    myClient.Close();

                    //Set the result and display to user
                    wordCountLiteral.Text = result;
                    wordCountLiteral.Visible = true;
                }
                else
                {
                    wordCountLiteral.Text = "The file size is too big";
                    wordCountLiteral.Visible = true;
                }
            }
            else
            {
                wordCountLiteral.Text = "You must choose a file";
                wordCountLiteral.Visible = true;
            }
        }

        //Handle Top 10 Words Button Click
        protected void top10Button(object sender, EventArgs e)
        {
            Uri baseUri = new Uri("http://webstrar48.fulton.asu.edu/page1/Service.svc/"); //Create base address
            UriTemplate uriTemplate = new UriTemplate("Top10ContentWords?url={url}"); //Define the specific service and the space for the user input
            Uri completeUri = uriTemplate.BindByPosition(baseUri, top10TextBox.Text); //Append the user value to the parameter of the service
            WebClient webClient = new WebClient(); //Create a proxy
            byte[] result = webClient.DownloadData(completeUri); //Download the data from the RESTful service
            Stream stream = new MemoryStream(result); //create a stream
            DataContractSerializer dcs = new DataContractSerializer(typeof(string[])); //Use a DataContractSerializer
            string[] arr; //Declare a string array

            //The RESTful service gives a XML file, so we use a XmlDictionaryReader to read the object and caste to a string array
            using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas()))
            {
                arr = (string[])dcs.ReadObject(reader);
            }
            //Format each word in the string array to be separated with a comma
            string arrayOfWords = string.Join(", ", arr);
            top10Literal.Text = arrayOfWords;
            top10Literal.Visible = true; //Finally, display the text to the user
        }

        //Handle Top 5 Sentences Button Click
        protected void top5Button(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(top5TextBox.Text)))
            {
                MatchCollection matches = Regex.Matches(top5TextBox.Text, @"[.!?]"); //Use MatchCollection to ensure that the input is valid

                if (matches.Count >= 5)
                {
                    Uri baseUri = new Uri("http://webstrar48.fulton.asu.edu/page1/Service.svc/"); //Create base address
                    UriTemplate uriTemplate = new UriTemplate("Top5Sentences?text={text}"); //Define the specific service and the space for the user input
                    Uri completeUri = uriTemplate.BindByPosition(baseUri, top5TextBox.Text); //Append the user value to the parameter of the service
                    WebClient webClient = new WebClient(); //Create a proxy
                    byte[] result = webClient.DownloadData(completeUri); //Download the data from the RESTful service
                    Stream stream = new MemoryStream(result); //create a stream
                    DataContractSerializer dcs = new DataContractSerializer(typeof(string[])); //Use a DataContractSerializer
                    string[] arr; //Declare a string array

                    //The RESTful service gives a XML file, so we use a XmlDictionaryReader to read the object and caste to a string array
                    using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas()))
                    {
                        arr = (string[])dcs.ReadObject(reader);
                    }

                    StringBuilder sb = new StringBuilder(); //Use a String Builder to format

                    //Format each word in the string array to be separated by a number, indicating ranking of sentence
                    for (int i = 0; i < arr.Length; i++)
                    {
                        sb.AppendLine($"{i + 1}. {arr[i]}");
                    }
                    string arrayOfWords = sb.ToString();

                    //Set the string content and display it to user
                    top5Literal.Text = arrayOfWords;
                    top5Literal.Visible = true;
                }
                else
                {
                    top5Literal.Text = "You must enter text with at least 5 sentences";
                    top5Literal.Visible = true;
                }
            }
            else
            {
                top5Literal.Text = "You must enter text";
                top5Literal.Visible = true;
            }
        }

        //Handle Compare Text Button Click
        protected void compareTextButton(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(compareTextBox1.Text)))
            {
                compareTextLiteral1.Text = "You must fill in both textboxes";
                compareTextLiteral1.Visible = true;
            }
            if ((string.IsNullOrEmpty(compareTextBox2.Text)))
            {
                compareTextLiteral1.Text = "You must fill in both textboxes";
                compareTextLiteral1.Visible = true;
            }
            else
            {
                Uri baseUri = new Uri("http://webstrar48.fulton.asu.edu/page1/Service.svc/"); //Create base address
                UriTemplate uriTemplate = new UriTemplate("compareText?url1={url1}&url2={url2}"); //Define the specific service and the space for the first user input
                Uri completeUri = uriTemplate.BindByPosition(baseUri, compareTextBox1.Text, compareTextBox2.Text); //Append the user value to the parameter of the service
                WebClient webClient = new WebClient(); //Create a proxy
                byte[] result = webClient.DownloadData(completeUri); //Download the data from the RESTful service
                string resultString = Encoding.UTF8.GetString(result);

                //Split the string at the Second URL
                string[] firstAndSecond = resultString.Split(new string[] { "URL 2 Top 10 Words:" }, StringSplitOptions.RemoveEmptyEntries);

                compareTextLiteral1.Text = firstAndSecond[0].Trim(); //Set the text to the 1st Literal
                compareTextLiteral1.Visible = true;
                compareTextLiteral2.Text = "URL 2 Top 10 Words:" + firstAndSecond[1].Trim(); //Append what was removed and set to 2nd Literal
                compareTextLiteral2.Visible = true;
            }
        }
    }
}