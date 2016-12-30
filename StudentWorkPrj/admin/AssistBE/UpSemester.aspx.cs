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
using System.IO;
using BPElement;
using System.Collections.Generic;
using BPElement.Model;

public partial class admin_UpSemester : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txtBind();
        }

        string Type = Request.QueryString["type"];
        if (Request.QueryString["type"] != null)
        {
            if (Type == "Modify")
            {
                TitleName.InnerHtml = "Change info";
                
            }
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {//提交
        //if (Session["UserName"] != null && Session["UserName"] != "")
        //{
        var Type = Request.QueryString["type"];
        if (Type != null)
        {
            Semester Model = new Semester()
            {
                Stype = DP_Stype.Text.Trim(),
                SYear = SYear.Text.Trim(),

            };

            if (Type == "Modify")
            {//修改               
                #region Change
                Model.ID = Request.QueryString["id"].ToString();
                if (BP_Semester.ModifySemesterInfo(Model) > 0)
                {
                    Response.Write("<script language='javascript'>alert('Succeed change info');location.href='SemesterManage.aspx'</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('Failed change info');</script>");
                }
                #endregion
            }
            else if (Type == "Add")
            {//添加
                #region Add
                if (Model.SYear != "")
                {
                    if (BP_Semester.AddSemesterInfo(Model) > 0)
                    {
                        Response.Write("<script language='javascript'>alert('Succeed change info');location.href='SemesterManage.aspx'</script>");
                         
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('Failed change info');</script>");
                    } 
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('Year cannot be empty');</script>");
                }
                #endregion
            }
            else
            {
                Response.Write("<script language='javascript'>alert('No rogue operation!');</script>");
            }
        }
        else
        {
            Response.Write("<script language='javascript'>alert('Address error!');</script>");
        }


    }
    //绑定
    public void txtBind()
    {
        if (GetID())
        {
            DataSet ds = BP_Semester.GetSemesterInfo(Request.QueryString["id"].ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DP_Stype.Text = ds.Tables[0].Rows[0]["Stype"].ToString();
                SYear.Text = ds.Tables[0].Rows[0]["SYear"].ToString();
                
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Info argument error');location.href='SemesterManage.aspx'</script>");
            }
        }
    }

    private bool GetID()
    {
        try
        {
            if (Request.QueryString["id"] != null && Request.QueryString["id"].Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }


    protected void BandPost()
    {

    }
    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("SemesterManage.aspx");
    }
}
