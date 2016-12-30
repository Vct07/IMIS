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

public partial class admin_WorkInfoList : BasePage
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
                //if (Convert.ToBoolean(drv.Row["IfDown"]))
                //{
                //    e.Row.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    e.Row.ForeColor = System.Drawing.Color.Red;
                //}
            }

            //string Key = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();//得到id
            //ImageButton imgbtnDelete = (ImageButton)e.Row.FindControl("imgbtnDelete");//实例化image按钮控件
            //imgbtnDelete.CommandArgument = Key;//指定删除按钮的关联参数
            //imgbtnDelete.Attributes.Add("onclick", "return confirm('You will also delete related user, are you sure?');");
        }
    }
     
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
         
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
        int CountRecord = BP_WorkInfo.GetWorkInfoCount();
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
                     select  WorkInfo.[ID]
                          ,WorkInfo.[PostName]
                          ,WorkInfo.[Remark],WorkInfo.Num
                          ,WorkInfo.[Responsibility]
                          ,WorkInfo.[Requirement]
                          ,WorkInfo.[CreateDate]     
                          ,WorkInfo.[Company_FK]
                          ,WorkInfo.[WorkType]
                          ,WorkInfo.[Wages]
                          ,WorkInfo.[Flg]
                          ,WorkInfo.Num-WorkInfo.ObjNum as ObjNum,ROW_NUMBER() OVER (order by [WorkInfo].CreateDate desc)as RowNumber
                      FROM [WorkInfo] inner join WorkCompany on WorkCompany.ID=WorkInfo.Company_FK where Flg=1)
                      select * from TT 
                    WHERE RowNumber between " + (UcfarPager1.PageSize * (pageindex - 1)) + @" and " + (UcfarPager1.PageSize * (pageindex));

        GridView1.DataSource = Sqlhlper.GetSet(sql);
        GridView1.DataBind();

        if (CountRecord == 0)
        {
            Msg.InnerHtml = "No work info";
        }
    }
     
    
}
