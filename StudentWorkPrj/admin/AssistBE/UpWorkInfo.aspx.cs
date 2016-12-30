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

public partial class admin_UpWorkInfo : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BandCompany();
            txtBind();
        }

        string Type = Request.QueryString["type"];
        if (Request.QueryString["type"] != null)
        {
            if (Type == "Modify")
            {
                TitleName.InnerHtml = "Change info";
                Dp_Company.Enabled = false;
            }
            if (Type == "view")
            {
                TitleName.InnerHtml = "Work details";
                Button1.Visible = false;
                Btn_back.Visible = false;
                Dp_Company.Enabled = false;
                PostName.Enabled = false;
                //Responsibility.Enabled = false;
                //Remark.Enabled = false;
                //Requirement.Enabled = false;
                Wages.Enabled = false;
                Num.Enabled = false;
                DP_WorkType.Enabled = false;
                Button2.Visible = true;
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
            int n = 0; int W = 0;
            if (int.TryParse(Wages.Text, out W))
            {
                if (int.TryParse(Num.Text, out n) && n > 0)
                {
                    WorkInfo Model = new WorkInfo()
                    {
                        CreateDate = DateTime.Now,
                        Num = Convert.ToInt32(Num.Text),
                        PostName = PostName.Text,
                        Remark = Remark.Text,
                        Requirement = Requirement.Text,
                        Responsibility = Responsibility.Text,
                        Wages = Convert.ToInt32(Wages.Text),
                        WorkType = DP_WorkType.Text,
                        Company_FK=Dp_Company.SelectedItem.Value
                    };

                    if (Type == "Modify")
                    {//修改               
                        #region Change
                        Model.ID = Request.QueryString["id"].ToString();
                        if (BP_WorkInfo.ModifyWorkInfoInfo(Model) > 0)
                        {
                            Response.Write("<script language='javascript'>alert('Succeed change info');location.href='WorkInfoManage.aspx'</script>");
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
                        if (Model.PostName != "")
                        {
                            if (BP_WorkInfo.AddWorkInfoInfo(Model) > 0)
                            {
                                Response.Write("<script language='javascript'>alert('Succeed change info');location.href='WorkInfoManage.aspx'</script>");

                            }
                            else
                            {
                                Response.Write("<script language='javascript'>alert('Failed change info');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>alert('Position already exist');</script>");
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
                    Response.Write("<script language='javascript'>alert('Number has to be integer');</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Salary has to be positive integer');</script>");
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
            DataSet ds = BP_WorkInfo.GetWorkInfoInfoByID(Request.QueryString["id"].ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                PostName.Text = ds.Tables[0].Rows[0]["PostName"].ToString();
                Responsibility.Text = ds.Tables[0].Rows[0]["Responsibility"].ToString();
                Remark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                Requirement.Text = ds.Tables[0].Rows[0]["Requirement"].ToString();
                Wages.Text = ds.Tables[0].Rows[0]["Wages"].ToString();
                Num.Text = ds.Tables[0].Rows[0]["Num"].ToString();
                DP_WorkType.Text = ds.Tables[0].Rows[0]["WorkType"].ToString();
                Dp_Company.Text = ds.Tables[0].Rows[0]["Company_FK"].ToString(); 
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Info argument error');location.href='WorkInfoList.aspx'</script>");
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


    protected void BandCompany()
    {
        DataSet ds = new DataSet();
        ds = BP_Company.GetCompanyInfo();
        Dp_Company.DataSource = ds.Tables[0].DefaultView;
        Dp_Company.DataValueField = ds.Tables[0].Columns["ID"].ColumnName;
        Dp_Company.DataTextField = ds.Tables[0].Columns["CompanyName"].ColumnName;
        Dp_Company.DataBind();
        ds.Dispose();
    }
    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("WorkInfoManage.aspx");
    }
    //申请职位
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (GetID())
        {
            WorkObj model = new WorkObj()
            {
                MS_Person_FK = CurrentUser.MS_PersonOID,
                Type = 1,
                WorkInfo_FK = Request.QueryString["id"].ToString()
            };
            string sql = " select * from WorkObj where MS_Person_FK='" + CurrentUser.MS_PersonOID + "' and WorkInfo_FK='" + Request.QueryString["id"].ToString() + "'";
            var d = Sqlhlper.GetSet(sql);
            if (d != null && d.Tables.Count > 0 && d.Tables[0].Rows.Count > 0)
            {
                Response.Write("<script language='javascript'>alert('You have already applied this work');location.href='WorkInfoList.aspx'</script>");
            }
            else
            {
                if (BP_WorkInfo.ValiWorkObjInfo(Request.QueryString["id"].ToString()))
                {
                    if (BP_WorkInfo.AddWorkObjInfo(model) > 0)
                    {
                        Response.Write("<script language='javascript'>alert('Succeed applied work');location.href='WorkInfoList.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('Failed applied work');</script>");
                    }
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('The work position is full');</script>");
                }
            }
        }
        else
        {
            Response.Write("<script language='javascript'>alert('Address error!');</script>");
        }
    }
}
