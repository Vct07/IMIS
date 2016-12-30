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

public partial class admin_UpCompany : BasePage
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
                TitleName.InnerHtml = "Change company info";
                CompanyName.Enabled = false;
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
                Company Model = new Company()
                {
                    Address = Address.Text.Trim(),
                    City = City.Text.Trim(),
                    CompanyName = CompanyName.Text.Trim(),
                    ContactFirstName = ContactFirstName.Text.Trim(),
                    ContactMiddleName = ContactMiddleName.Text.Trim(),
                    ContactPost = ContactPost.Text.Trim(),
                    Contry = Contry.Text.Trim(),
                    Phone = Phone.Text.Trim(),
                    PostCode = PostCode.Text.Trim(),
                    Remark = Remark.Text.Trim(),
                    WebSite = WebSite.Text.Trim(),
                    Email = Email.Text.Trim()
                };
                 
                if (Type == "Modify")
                {//修改               
                    #region Change
                    Model.ID = Request.QueryString["id"].ToString();
                    if (BP_Company.ModifyCompanyInfo(Model) > 0)
                    {
                        Response.Write("<script language='javascript'>alert('Succeed change info');location.href='CompanyManage.aspx'</script>");
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
                    if (Model.CompanyName != "")
                    {
                        DataSet ds = BP_Company.ValiCompanyInfo(Model.CompanyName);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            Response.Write("<script language='javascript'>alert('Company name already exist');</script>");
                        }
                        else
                        {
                            if (BP_Company.AddCompanyInfo(Model) > 0)
                            {
                                Response.Write("<script language='javascript'>alert('Succeed add company info');location.href='CompanyManage.aspx'</script>");
                                CompanyName.Text = "";
                                 
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>alert('Failed add company info');</script>");
                            }
                        }

                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('Company name cannot be empty');</script>");
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
            DataSet ds = BP_Company.GetCompanyInfo(Request.QueryString["id"].ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                CompanyName.Text = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                Address.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                City.Text = ds.Tables[0].Rows[0]["City"].ToString();
                PostCode.Text = ds.Tables[0].Rows[0]["PostCode"].ToString();
                Contry.Text = ds.Tables[0].Rows[0]["Contry"].ToString();
                ContactMiddleName.Text = ds.Tables[0].Rows[0]["ContactMiddleName"].ToString();
                ContactPost.Text = ds.Tables[0].Rows[0]["ContactPost"].ToString();
                Phone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                WebSite.Text = ds.Tables[0].Rows[0]["WebSite"].ToString();
                Remark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();                
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Info argument error');location.href='CompanyManage.aspx'</script>");
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
        Response.Redirect("CompanyManage.aspx");
    }
}
