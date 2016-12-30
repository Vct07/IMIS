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

public partial class admin_MyWorkInfoApplyList : BasePage
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
        int CountRecord = BP_ApplyWork.GetMyWorkInfoApplyCount(CurrentUser.MS_PersonOID);
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
                        WorkInfo.PostName,WorkInfo.Num,WorkInfo.ObjNum,WorkInfo.CreateDate,WorkObj.WorkInfo_FK,WorkObj.Type,
                        ROW_NUMBER() OVER (order by [WorkObj].CreateDate desc)as RowNumber
                            from WorkObj
                        inner join WorkInfo on WorkInfo.ID=WorkObj.WorkInfo_FK
                        LEFT JOIN MS_Person ON MS_Person.MS_PersonOID=WorkObj.MS_Person_FK
                        left join WorkCompany on WorkCompany.ID=WorkInfo.Company_FK where [Type]=2
                    AND WorkInfo.Flg=1 and WorkInfo.Num>WorkInfo.ObjNum and WorkObj.MS_Person_FK='" + CurrentUser.MS_PersonOID+@"'
                         )
                      select * from TT 
                    WHERE RowNumber between " + (UcfarPager1.PageSize * (pageindex - 1)) + @" and " + (UcfarPager1.PageSize * (pageindex));

        GridView1.DataSource = Sqlhlper.GetSet(sql);
        GridView1.DataBind();

        if (CountRecord == 0)
        {
            Msg.InnerHtml = "You didn't applied any work";
        }
    }
     
}
