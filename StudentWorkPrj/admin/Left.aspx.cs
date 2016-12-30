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
using BPElement;
using System.Text;

public partial class Manage_Left : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    { 
        InitAuth();
    }

    public string UserName = string.Empty;

    private void InitAuth()
    {
        UserName = string.IsNullOrEmpty(CurrentUser.NickName) ? CurrentUser.PersonNumber : CurrentUser.NickName;

        if (CurrentUser.IfAdmin)
        {

            MyWorkInfoApplyList.Visible = false;
            WorkInfoList.Visible = false;
            s_UpPerson.Visible = false;


            WorkInfoManage.Visible = true;
            WorkInfoApplyList.Visible = true;
            AWorkInfoApplyList.Visible = true;
            BasicManage.Visible = true;
        }
        else
        {
            MyWorkInfoApplyList.Visible = true;
            WorkInfoList.Visible = true;
            s_UpPerson.Visible = true;


            WorkInfoManage.Visible = false;
            WorkInfoApplyList.Visible = false;
            AWorkInfoApplyList.Visible = false;
            BasicManage.Visible = false;

        }
         
    }
     
     
    protected void Quit_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("/loginOut.aspx", true);
    }
}
