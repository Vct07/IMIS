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

public partial class Manage_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    BLL BLL = new BLL();

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        string UserName = BLL.CheckStr(this.TextBoxUserName.Text.Trim().ToLower());
        string UserPwd = BLL.CheckStr(this.TextBoxUserPwd.Text.Trim());
        string CodeText = this.TextBoxCode.Text.Trim();
        var IfAdmin = StudentIndity.Checked ? "0" : "1";

        //if (Session["Code"]!=null&& CodeText.Equals(Session["Code"].ToString()))
        //{
            

            UserPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(UserPwd, "MD5");
            string LoginPersonOID = Sqlhlper.ValidateUser(UserName, UserPwd, IfAdmin);
            if (LoginPersonOID!="")
            {
                DataSet ds = Sqlhlper.GetUserInfo(LoginPersonOID);//获取用户信息
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    BPElement.Model.User user = new BPElement.Model.User()
                    {
                        MS_PersonOID = ds.Tables[0].Rows[0]["MS_PersonOID"].ToString(),
                        IfAdmin = Convert.ToBoolean(ds.Tables[0].Rows[0]["IfAdmin"]),
                        NickName = ds.Tables[0].Rows[0]["NickName"].ToString(),
                        PersonNumber = ds.Tables[0].Rows[0]["PersonNumber"].ToString()
                    };
                    Session["User"] = user; 
                    ds.Dispose();
                    Response.Write("<script language='javascript'>window.location.href='admin/ManageMain.aspx';</script>");

                }
                else
                {
                    Response.Write("<script language='javascript'>alert('Server error, fail to get information from user！');</script>");
                }

               
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Uname/Pword error！');</script>");
            }
        //}
        //else 
        //{
        //    Response.Write("<script language='javascript'>alert('Code error！');</script>");
        //}
    }
    
    protected void ButtonReset_Click(object sender, EventArgs e)
    {
        this.TextBoxUserName.Text = string.Empty;
        this.TextBoxUserPwd.Text = string.Empty;
        this.TextBoxCode.Text = string.Empty;
    }
}
