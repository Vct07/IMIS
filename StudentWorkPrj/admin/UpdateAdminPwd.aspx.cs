using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using BPElement;

public partial class Manage_UpdateAdminPwd : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserName = CurrentUser.PersonNumber;
    }

    
    //private static string UserID = string.Empty;
    public static string UserName = string.Empty;

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        string OldPwd = this.TextBoxOldPwd.Text.Trim().Replace("'","").Replace("--","");
        string NewPwd = this.TextBoxNewPwd.Text.Trim().Replace("'", "").Replace("--", "");
        string AgainNewPwd = TextBoxConfirmPwd.Text.Trim().Replace("'", "").Replace("--", "");
       
        if (NewPwd.Length < 6)
        {
            Response.Write("<script language='javascript'>alert('Digit of new password MUST be more than 6！');</script>");
        }
        else
        {
	     NewPwd=System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(NewPwd, "MD5");
             OldPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(OldPwd, "MD5");
             AgainNewPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(AgainNewPwd, "MD5");
            if (NewPwd != AgainNewPwd )
            {
                Response.Write("<script language='javascript'>alert('Password confirm failed！');</script>");
            }
            else
            {
                string LoginPersonOID = Sqlhlper.ValidateUser(UserName, OldPwd,CurrentUser.IfAdmin?"1":"0");
                if (LoginPersonOID != "")
                {
                    int Tag = Sqlhlper.ModifyPwd(UserName, NewPwd);
                    if (Tag > 0)
                    {
                        
                        Response.Write("<script language='javascript'>alert('Password changed successfully！');</script>");
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('Password changed failed, Try again later！');</script>");
                    }
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('Password error！');</script>");
                }
            }
        }
    }

    
    protected void Cancel_Click(object sender, EventArgs e)
    {
        TextBoxOldPwd.Text = "";
        TextBoxNewPwd.Text = "";
        TextBoxConfirmPwd.Text = "";
    }
}
