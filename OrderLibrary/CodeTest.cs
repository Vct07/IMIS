using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
/// <summary>
/// Test 的摘要说明
/// </summary>
public class CodeTest
{

    private static String code;
    public CodeTest()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static String makeCode(Page page)
    {
        ValidateNumber vn = new ValidateNumber();
        code = vn.CreateValidateNumber(4);
        //int a = 2;
        vn.CreateValidateGraphic(page, code);
        
        return code;
    }

    // 
    public static String Code
    {
        get
        {
            return code;
        }
    }
}
