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

public partial class admin_CompanyManage : BasePage
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
        if (CurrentUser.IfAdmin)
        {
            GridView1.DataSource = BP_Company.GetCompanyInfo();
            GridView1.DataBind();
        }
        else
        {
            Response.Write("<script>alert('Sorry, no authority to operate！');window.parent.location.href='/loginOut.aspx'</script>");
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
    

    protected void Button1_Click(object sender, EventArgs e)
    {       
        Response.Redirect("UpCompany.aspx?type=Add");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#F0F0F0'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");


            string Key = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();//得到id
            ImageButton imgbtnDelete = (ImageButton)e.Row.FindControl("imgbtnDelete");//实例化image按钮控件
            imgbtnDelete.CommandArgument = Key;//指定删除按钮的关联参数
            imgbtnDelete.Attributes.Add("onclick", "return confirm('confirm to delete');");

             
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
        //执行删除
        if (e.CommandName == "delete")
        {
            if (BP_Company.DelCompanyInfo(e.CommandArgument.ToString()) > 0)
            {
                Band();
            }
            GridView1.DataBind();
        }
         
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
     
}
