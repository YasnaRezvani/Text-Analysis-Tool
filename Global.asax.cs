using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Assignment5
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        //Handle the event at the beginning of each session, user should not be logged in throughout multiple sessions
        protected void Session_Start(object sender, EventArgs e)
        {
            
            //When there is an active cookie, expire the cookie at the start of the session
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null){
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName);
                cookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(cookie);
            }
            
            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}