using BPElement;
using BPElement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Transactions;

/// <summary>
/// WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    { 
        
        //InitializeComponent(); 
    }
    /// <summary>
    /// 获取技能信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public Result<List<Skill>> GeSkillInfo(string pid)
    {
        Result<List<Skill>> result = new Result<List<Skill>>();
        try
        {
             var User = Session["User"] as User;
             if (User != null)
             {
                 pid = User.IfAdmin ? pid : User.MS_PersonOID;
             }
            var Obj = BP_Skill.GetSkillInfo();
            var MyObj = BP_Skill.GetMySkillInfo(pid);
            if (Obj != null && Obj.Tables.Count > 0&&Obj.Tables[0].Rows.Count>0)
            {
                // model = re;
                result.IfSuccess = true;
                List<Skill> list = new List<Skill>();
                for (var i = 0; i < Obj.Tables[0].Rows.Count; i++)
                {
                    var check = false;
                    for (var n = 0; n < MyObj.Tables[0].Rows.Count; n++)
                    {
                        if (MyObj.Tables[0].Rows[n]["Skill_FK"].ToString() == Obj.Tables[0].Rows[i]["ID"].ToString())
                        {
                            check = true;
                            break;
                        }
                    }
                    var model = new Skill()
                    {
                        ID = Obj.Tables[0].Rows[i]["ID"].ToString(),
                        Name = Obj.Tables[0].Rows[i]["Name"].ToString(),
                        Type = check?"check":""
                    };
                    list.Add(model);
                }
                result.Data = list;
            }
            else
            {//
                result.IfSuccess = false;
                result.Message = "not any skill information！";
            }
        }
        catch (Exception ex)
        {
            result.IfSuccess = false;
            result.Message = ex.Message;
        }

        return result;
    }
    [WebMethod(EnableSession = true)]
    public Result SetSkill(string skill_FK, string Person_FK, string T)
    {
        Result result = new Result() { IfSuccess = false, Message = "init data fail" };
        var User = Session["User"] as User;
        if (User != null)
        {
            Person_FK = User.IfAdmin ? Person_FK : User.MS_PersonOID;
        }
        if (BP_Skill.SetSkill(skill_FK, Person_FK, T))
        {
            result.IfSuccess = true;
            result.Message = "success";
        }

        return result;


    }
  

}

public class Result<T>
{
    public Result()
    {

    }
    public string Message { get; set; }
    public bool IfSuccess { get; set; }
    public int Code { get; set; }
    public T Data { get; set; }
}
public class Result
{
    public Result()
    {

    }
    public string Message { get; set; }
    public bool IfSuccess { get; set; }
    public string FilePath { get; set; }
    public int Code { get; set; }
}