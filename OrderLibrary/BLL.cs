using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text.RegularExpressions;


/// <summary>
/// ProductsBLL 的摘要说明
/// </summary>
public class BLL
{
	public BLL()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
    }

    //#region
    /// <summary>
    /// 替换SQL关键符号
    /// </summary>
    /// <param name="Str">要替换的字符串</param>
    /// <returns>替换后的字符串</returns>
    public string CheckStr(string Str)
    {
        string NewStr = string.Empty;

        if (!Str.Equals(string.Empty))
        {
            NewStr = Str.Replace("'", "").Replace("<", "").Replace(">", "").Replace("and", "").Replace("=", "").Replace("or", "");
        }
        return NewStr;
    }

    /// <summary>
    /// 替换SQL关键字
    /// </summary>
    /// <param name="OldStr">要替换的字符串</param>
    /// <returns>替换后的字符串</returns>
    public string ReplaceSQLStr(string Str)
    {
        string NewStr = string.Empty;
        if (!Str.Equals(string.Empty))
        {
            NewStr = Str.Replace("select", "非法字符").Replace("insert", "非法字符").Replace("delete", "非法字符").Replace("drop table", "非法字符").Replace("update", "非法字符").Replace("exec", "非法字符").Replace("truncate", "非法字符").Replace("administrators", "非法字符");
        }
        return NewStr;
    }

    /// <summary>
    /// 判断文件类型
    /// </summary>
    /// <param name="FileUp"></param>
    /// <returns></returns>
    public bool CheckExtension(HttpPostedFile FileUp)
    {
        bool Tag = false;
        string strOldPath = FileUp.FileName.ToString();
        string[] arrExtension = { ".gif", ".jpg", ".bmp", ".png" };
        string strExtension = strOldPath.Substring(strOldPath.LastIndexOf("."));
        for (int i = 0; i < arrExtension.Length; i++)
        {
            if (strExtension.Equals(arrExtension[i]))
            {
                Tag = true;
            }
        }
        return Tag;
    }

    /// <summary>
    /// 判断文件大小
    /// </summary>
    /// <param name="FileUp"></param>
    /// <returns></returns>
    public bool CheckLength(HttpPostedFile FileUp)
    {
        int MaxLength = 1024 * 1024;  //文件最大值为1M
        if (FileUp.ContentLength <= MaxLength)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 上传文件类
    /// </summary>
    /// <param name="ServerPath">物理路径(Server.MapPath)</param>
    /// <param name="TheFile">要上传的文件(HttpPostedFile类型)</param>
    /// <param name="OldImgName">原文件名 没有则为空</param>
    /// <returns>上传结果(string)</returns>
    public string UploadFile(string ServerPath, HttpPostedFile TheFile, string OldImgName)
    {
        string str = string.Empty;
        string NewImgName = TheFile.FileName.Substring(TheFile.FileName.LastIndexOf("\\") + 1);
        string NewImgUrl = ServerPath + NewImgName;
        string OldImgUrl = ServerPath + OldImgName;

        if (TheFile.ContentLength > 0)
        {
            if (CheckExtension(TheFile))
            {
                if (CheckLength(TheFile))
                {
                    if (!File.Exists(NewImgUrl))
                    {
                        if (!Directory.Exists(ServerPath))  //判断目标文件夹是否存在 如果不存在则创建
                        {
                            Directory.CreateDirectory(ServerPath);
                        }
                        if (OldImgName.Length > 0)
                        {
                            File.Delete(OldImgUrl);
                        }
                        TheFile.SaveAs(NewImgUrl);

                        str = "文件上传成功！";
                    }
                    else
                    {
                        str = "文件已存在！请重命名后再试！";
                    }
                }
                else
                {
                    str = "文件太大！";
                }
            }
            else
            {
                str = "文件类型错误";
            }
        }
        return str;
    }

    /// <summary>
    /// 过滤HTML标签
    /// </summary>
    /// <param name="Htmlstring">要过滤的代码</param>
    /// <returns>过滤后的文本</returns>
    public string NoHTML(string Htmlstring)
    {
        //删除脚本
        Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "",
            RegexOptions.IgnoreCase);
        //删除HTML
        Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
        Htmlstring.Replace("<", "");
        Htmlstring.Replace(">", "");
        Htmlstring.Replace("\r\n", "");
        Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
        return Htmlstring;
    }

    /// <summary>
    /// 取字符串中的图片的路径
    /// </summary>
    /// <param name="Htmlstring">字符串</param>
    /// <returns>图片路径</returns>
    public string GetImgURL(string Htmlstring)
    {
        string ImgURL = string.Empty;
        MatchCollection matchs = Regex.Matches(Htmlstring, @"<img\s[^>]*src=([""']*)(?<src>[^'""]*)\1[^>]*>", RegexOptions.IgnoreCase);
        foreach (Match m in matchs)
        {
            ImgURL = m.Groups["src"].Value.Replace("/Products/", "");
        }
        return ImgURL;
    }

    /// <summary>
    /// 截断字符串
    /// </summary>
    /// <param name="OldStr">被截断的代码</param>
    /// <param name="Length">被截断的长度</param>
    /// <param name="EndStr">结尾代码</param>
    /// <returns></returns>
    public string CutString(string OldStr, int Length, string EndStr)
    {
        string NewStr = string.Empty;        
        if (OldStr.Trim().Length > Length)
        {
            OldStr = NoHTML(OldStr);
            NewStr = OldStr.Substring(0, Length) + EndStr;
        }
        else
        {
            OldStr = NoHTML(OldStr);
            NewStr = OldStr;
        }
        return  NewStr;
    }
   
    //public DataTable GetNewYe(string id, int start, int endnum, int rownum)
    //{
    //    string sql = "Exec new " + id + "," + start + "," + endnum + "," + rownum + "";
    //    return SqlHelper.ExecuteDataTable(SqlHelper.CONNSTR, CommandType.Text, sql);
    //}
    //public DataTable GetExhYe(string id, int start, int endnum, int rownum)
    //{
    //    string sql = "Exec exh " + id + "," + start + "," + endnum + "," + rownum + "";
    //    return SqlHelper.ExecuteDataTable(SqlHelper.CONNSTR, CommandType.Text, sql);
    //}
    //public DataTable GetAllExhYe(int start, int endnum, int rownum)
    //{
    //    string sql = "Exec allExib " + start + "," + endnum + "," + rownum + "";
    //    return SqlHelper.ExecuteDataTable(SqlHelper.CONNSTR, CommandType.Text, sql);
    //}
}
