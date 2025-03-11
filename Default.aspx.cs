using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class Default : System.Web.UI.Page
    {
        //Redirect the user to the correct page
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Redirect the user to the correct page
        protected void memberButtonClick(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
               Response.Redirect("/page3/SignupPage.aspx");
            }
            else
            {
               Response.Redirect("/page3/Member.aspx");
            }
        }

        //Redirect the user to the correct page
        protected void staffButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("/page3/StaffLoginPage.aspx");
        }

        //Redirect the user to the correct page
        protected void memberLoginClick(object sender, EventArgs e)
        {
            Response.Redirect("/page3/LoginPage.aspx");
        }
    }
}
