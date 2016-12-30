using BPElement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

 
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {

        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            var User = Session["User"] as User;
            if (User == null)
            {
                Response.Redirect("~/Default.aspx", true);
            }
        }

        public User CurrentUser
        {
            get
            {
                var User = Session["User"] as User;
                if (User != null)
                {
                    return User;
                }
                else
                {
                    return null;
                }
            }
        }
    }
  
 