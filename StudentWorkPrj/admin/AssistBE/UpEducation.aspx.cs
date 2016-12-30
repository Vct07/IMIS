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

public partial class admin_UpEducation : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            
            txtBind();   
        } 
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {//提交

        var Type = Request.QueryString["type"];
        if (Type != null)
        {
            Education Model = new Education()
            {
                DegreeType = DP_DegreeType.SelectedItem.Value,
                CertificateOntology = CertificateOntology.Text,
                CertificateTitle = CertificateTitle.Text,
                ContryName = ContryName.Text,
                GPA = GPA.Text,
                MajorName = MajorName.Text,
                UniversityName = UniversityName.Text,
                Student_FK = CurrentUser.IfAdmin ? Request.QueryString["pid"].ToString() : CurrentUser.MS_PersonOID
            };
            if (Type == "Add")
            {
                #region Add
                if (Model.MajorName != "" && Model.GPA != "")
                {
                    if (BP_Education.AddEducationInfo(Model) > 0)
                    {
                        Response.Write("<script language='javascript'>alert('Succeed add info');location.href='UpPerson.aspx?type=Modify&id=" + Request.QueryString["pid"].ToString() + "'</script>");

                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('Failed add info');</script>");
                    }
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('Major/GPA cannot be empty');</script>");
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
 
    public void txtBind()
    {      
        if (GetID())
        {
            DataSet ds = BP_Education.GetEducationInfo(Request.QueryString["id"].ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                MajorName.Text = ds.Tables[0].Rows[0]["MajorName"].ToString();
                GPA.Text = ds.Tables[0].Rows[0]["GPA"].ToString();
                UniversityName.Text = ds.Tables[0].Rows[0]["UniversityName"].ToString();
                ContryName.Text = ds.Tables[0].Rows[0]["ContryName"].ToString();
                CertificateTitle.Text = ds.Tables[0].Rows[0]["CertificateTitle"].ToString();
                CertificateOntology.Text = ds.Tables[0].Rows[0]["CertificateOntology"].ToString();
                DP_DegreeType.SelectedValue = ds.Tables[0].Rows[0]["DegreeType"].ToString();
                
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Info argument error');location.href='EducationManage.aspx'</script>");
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
        Response.Redirect("UpPerson.aspx?type=Modify&id=" + Request.QueryString["pid"].ToString() + "'");
    }
}
