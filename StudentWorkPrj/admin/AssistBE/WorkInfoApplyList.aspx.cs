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
using System.Text;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class admin_WorkInfoApplyList : BasePage
{
    BLL bll = new BLL();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Band();
          
        }
    }

    public void Band()
    {

        InitData(1);


    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        Band();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataBind();

    }

  
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#F0F0F0'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                
            }
             var type = Request.QueryString["type"];
             if (string.IsNullOrEmpty(type))
             {
                 string Key = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();//得到id

                 ImageButton imgbtnInitPwd = (ImageButton)e.Row.FindControl("aggree");
                 // imgbtnInitPwd.CommandArgument = Key;//关联参数
                 imgbtnInitPwd.Attributes.Add("onclick", "return confirm('Confirm to approve this application');");
             }
        }
    }
     
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //同意申请
        if (e.CommandName == "AggreeApply")
        {
           // string Key = e e.CommandSource.ToString();//得到id
            if (BP_WorkInfo.ValiWorkObjByID(e.CommandArgument.ToString()))
            {
                if (BP_WorkInfo.AggreeWorkObj(e.CommandArgument.ToString()) > 0)
                {
                    Response.Write("<script language='javascript'>alert('Operation succeed');</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('Operation failed');</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Work is full');</script>");
            }

        }
         
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void UcfarPager1_PageChanged(object sender, EventArgs e)
    {

        InitData(UcfarPager1.CurrentPageIndex);
    }

    private void InitData(int pageindex)
    {
        var Shere=GetWhere();
        var type = Request.QueryString["type"];
        if (string.IsNullOrEmpty(type))
        {
            type = "1";
        }
        else
        {
            try
            {
                GridView1.Columns.RemoveAt(8);
            }
            catch { }
        }
        int CountRecord = BP_ApplyWork.GetWorkInfoApplyCount(type);
        this.UcfarPager1.RecordCount = CountRecord;
        if (UcfarPager1.PageSize > CountRecord)
        {
            this.UcfarPager1.Visible = false;
        }
        else
        {
            this.UcfarPager1.Visible = true;
        }
        string sql = @"WITH TT AS(
                     select WorkObj.WorkInfo_FK as ID,MS_Person.NickName,MS_Person.PersonNumber,WorkCompany.CompanyName,
                        WorkInfo.PostName,WorkInfo.Num,WorkInfo.ObjNum,WorkInfo.CreateDate,WorkObj.WorkInfo_FK,WorkObj.ID AS WorkObjID,
                        ROW_NUMBER() OVER (order by [WorkObj].CreateDate desc)as RowNumber
                            from WorkObj
                        inner join WorkInfo on WorkInfo.ID=WorkObj.WorkInfo_FK
                        inner JOIN MS_Person ON MS_Person.MS_PersonOID=WorkObj.MS_Person_FK
                        inner join WorkCompany on WorkCompany.ID=WorkInfo.Company_FK where [Type]=" + type + @"
                    AND WorkInfo.Flg=1 and WorkInfo.Num>WorkInfo.ObjNum and ("+Shere+@")
                         )
                      select * from TT 
                    WHERE RowNumber between " + (UcfarPager1.PageSize * (pageindex - 1)) + @" and " + (UcfarPager1.PageSize * (pageindex));

        GridView1.DataSource = Sqlhlper.GetSet(sql);
        GridView1.DataBind();

        if (CountRecord == 0)
        {
            Msg.InnerHtml = "No application";
        }
    }

    //搜索
    protected void Button2_Click(object sender, EventArgs e)
    {
        InitData(1);
    }
    private string GetWhere()
    {
        var Key = keyword.Text.Trim();
        var Shere = "1=1";
        if (Key != "")
        {
            var f = this.Select_Filed.SelectedItem.Value;
            if (f == "xh")
            {
                Shere = " MS_Person.PersonNumber='" + Key + "'";
            }
            else if (f == "gs")
            {
                Shere = " WorkCompany.CompanyName like '%" + Key + "%'";
            }
            else if (f == "zw")
            {
                Shere = " WorkInfo.PostName like '%" + Key + "%'";
            }
            else if (f == "gj")
            {
                Shere =  Key;
            }
        }
        
        return Shere;
    }
}
