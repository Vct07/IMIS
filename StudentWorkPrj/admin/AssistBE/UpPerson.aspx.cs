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

public partial class admin_UpPerson : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Dp_SemesterBind();
            txtBind();
            EducationBand();
        }

        string Type = Request.QueryString["type"];
        if (Request.QueryString["type"] != null)
        {
            if (Type == "Modify")
            {
                Button2.Visible = true;
                PersonNumber.Enabled = false;
                if (CurrentUser.IfAdmin)
                {
                    TitleName.InnerHtml = "Change student info";                   
                }
                else
                {
                    TitleName.InnerHtml = "Change my info";
                    Btn_back.Visible = false;
                }
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
                string S_PersonNumber = PersonNumber.Text.Trim();
                string S_NickName = NickName.Text.Trim();
                string S_MiddleName = MiddleName.Text.Trim();
                string S_FirstName = FirstName.Text.Trim();
                string S_Email = Email.Text.Trim();
                string S_Phone = Phone.Text.Trim();
                string S_Sex = DP_Sex.SelectedItem.Value;
                string S_Status = DP_Status.SelectedItem.Value;
                string S_Semester = DP_Semester.SelectedItem.Value;
                if (Type == "Modify")
                {//修改               
                    #region Change
                    string StrNickName = NickName.Text.Trim();
                    var key= CurrentUser.IfAdmin? Request.QueryString["id"].ToString():CurrentUser.MS_PersonOID;
                    if (BP_Person.ModifyPersonInfo(S_NickName, S_MiddleName, S_FirstName, S_Email, S_Phone, S_Sex, S_Semester, S_Status, key) > 0)
                    {
                        if (CurrentUser.IfAdmin)
                        {
                            Response.Write("<script language='javascript'>alert('Succeed change info');location.href='PersonManage.aspx'</script>");
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>alert('Succeed change info');</script>");
                        }
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
                    if (S_PersonNumber.Trim() != "")
                    {
                        DataSet ds = BP_Person.ValiPersonInfo(S_PersonNumber);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            Response.Write("<script language='javascript'>alert('Student already exist');</script>");
                        }
                        else
                        {
                            if (BP_Person.AddPersonInfo(S_PersonNumber, S_FirstName, S_MiddleName, S_NickName, S_Email, S_Phone, S_Sex, S_Semester, S_Status) > 0)
                            {
                                Response.Write("<script language='javascript'>alert('Succeed add account');location.href='PersonManage.aspx'</script>");
                                PersonNumber.Text = "";
                                 
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>alert('Failed add account');</script>");
                            }
                        }

                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('Student ID cannot be empty');</script>");
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
        if (GetID() || !CurrentUser.IfAdmin)
        {
            var key = CurrentUser.IfAdmin ? Request.QueryString["id"].ToString() : CurrentUser.MS_PersonOID;
            DataSet ds = BP_Person.GetPersonInfoByid(key);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                PersonNumber.Text = ds.Tables[0].Rows[0]["PersonNumber"].ToString();
                NickName.Text = ds.Tables[0].Rows[0]["NickName"].ToString();
                MiddleName.Text = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                FirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                Email.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                Phone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                DP_Sex.SelectedValue = ds.Tables[0].Rows[0]["Sex"].ToString();
                DP_Status.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
                DP_Semester.SelectedValue = ds.Tables[0].Rows[0]["Semester_FK"].ToString();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Info argument error');location.href='PersonManage.aspx'</script>");
            }
        }             
    }
    //绑定学期
    public void Dp_SemesterBind()
    {
        DataSet ds = new DataSet();
        ds = BP_Semester.GetSemesterByDP();
        DP_Semester.DataSource = ds.Tables[0].DefaultView;
        DP_Semester.DataValueField = ds.Tables[0].Columns["ID"].ColumnName;
        DP_Semester.DataTextField = ds.Tables[0].Columns["Name"].ColumnName;
        DP_Semester.DataBind();
        ds.Dispose();
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
        Response.Redirect("PersonManage.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        var key = CurrentUser.IfAdmin ? Request.QueryString["id"].ToString() : CurrentUser.MS_PersonOID;
        Response.Redirect("UpEducation.aspx?type=Add&pid=" + key);
    }
    public void EducationBand()
    {
        if (GetID() || !CurrentUser.IfAdmin)
        {
            var key = CurrentUser.IfAdmin ? Request.QueryString["id"].ToString() : CurrentUser.MS_PersonOID;
            GridView1.DataSource = BP_Education.GetChooseEducationInfo(key);
            GridView1.DataBind();
        }
         
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
            if (BP_Education.DelEducationInfo(e.CommandArgument.ToString()) > 0)
            {
                EducationBand();
            }
            GridView1.DataBind();
        }
         
        
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}
