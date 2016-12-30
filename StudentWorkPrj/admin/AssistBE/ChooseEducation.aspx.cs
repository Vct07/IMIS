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

public partial class admin_ChooseEducation : BasePage
{
   // BLL bll = new BLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            Band();
        }
    }

    public void Band()
    {

        GridView1.DataSource = BP_Education.GetNoChooseEducationInfo(Request.QueryString["id"].ToString());
        GridView1.DataBind();
        
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

 

             
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
        //执行添加
        if (e.CommandName == "choose")
        {
            if (GetID())
            {
                if (BP_Education.AddEducationMapInfo(Request.QueryString["id"].ToString(), e.CommandArgument.ToString()) > 0)
                {
                    Band();
                }
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Error！');</script>");
            }
        }
         
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
     
}
