using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BPElement.Model;

namespace BPElement
{
  public  class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {

        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            var User = Session["User"] as User;
            if (User == null)
            {
                Response.Redirect("~/loginOut.aspx", true);
            }
        }

        public User CurrentUser
        {
            get
            {
                //User m = new User() {IfAdmin = true};

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
        public string GetID()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"].Length > 0)
                {
                    return Request.QueryString["id"].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
