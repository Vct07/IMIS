<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="Manage_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CSS/myweb.css" type="text/css" />
    <link rel="stylesheet" href="CSS/private.css" type="text/css" />
    <title>Untitled page</title>
    <style type="text/css">
    body {
    background-image: url(images/left_bg.gif);
    }
.STYLE1 {color: #000000; line-height:22px;}
.STYLE2 {color: #FF0000}
.STYLE3 {color: #0000FF}
</style>

    <script type="text/javascript">
var old='';
function menu(name)
{
	submenu=eval("submenu_"+name+".style");
	if(old!=submenu)
	{
		if(old!='')
		{
				old.display='none';
		}
		submenu.display='block';
		old=submenu;
	}
	else
	{
		submenu.display='none';
		old='';
	}
}

function SelectAll(tempControl)
	{
	   var theBox=tempControl;
	   xState=theBox.checked;
	   elem=theBox.form.elements;
	   for(i=0;i<elem.length;i++)
	   {
	     if(elem[i].type=="checkbox" && elem[i].id!=theBox.id)
	     {
	       if(elem[i].checked!=xState)
	       {
	         elem[i].click();
	       }
	     }
	   }
	}
	function changecolor(cbo,o)
	{
	  var theBox=cbo;
	  var tr=document.getElementById(o);
	  if(theBox.checked)
	  {
	    tr.style.backgroundColor="#f4f4f4";
	  }
	  else
	  {
	    tr.style.backgroundColor="#D9E4FC";
	    
	  }
	}
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left" valign="top" style="width: 100%; background-image: url(images/left_bg.gif);
                        height: 100%;">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 18%">
                            <tr>
                                <td align="left" rowspan="2" style="width: 80%; height: 99%" valign="top">
                                  
                                    <table runat="server" id="Manage" cellpadding="0" cellspacing="0" width="100%" border="0" style="vertical-align: top;
                                        text-align: left;">
                                        <tr>
                                            <td style="width: 100%; background-image: url(images/menu_bg.gif); height: 36px;
                                                cursor: pointer" class="menu_title" onclick="menu(4);">
                                                <span class="font_span">IMIS</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="background-image: url(images/left_bg.gif); display: none;" class="myweb_td"
                                                id="submenu_4">
                                                 <table runat="server" id="WorkInfoManage"  visible="false" width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="height: 22px; padding-left:20px" onmouseout="this.style.backgroundColor=''" onmouseover="this.style.backgroundColor='#ffffff'">
                                                            <img src="images/icon.gif" alt="" />
                                                            <a href="AssistBE/WorkInfoManage.aspx" target="mainFrame">Work management</a></td>
                                                    </tr>
                                                </table>       
                                                <table runat="server" id="WorkInfoList" width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="height: 22px; padding-left:20px" onmouseout="this.style.backgroundColor=''" onmouseover="this.style.backgroundColor='#ffffff'">
                                                            <img src="images/icon.gif" alt="" />
                                                            <a href="AssistBE/WorkInfoList.aspx" target="mainFrame">Work list</a></td>
                                                    </tr>
                                                </table>                                       
                                                <table   runat="server" id="WorkInfoApplyList" width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="height: 22px; padding-left:20px" onmouseout="this.style.backgroundColor=''" onmouseover="this.style.backgroundColor='#ffffff'">
                                                            <img src="images/icon.gif" alt="" />
                                                            <a href="AssistBE/WorkInfoApplyList.aspx" target="mainFrame">Applicant list</a></td>
                                                    </tr>
                                                </table>
                                                <table   runat="server" id="AWorkInfoApplyList" width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="height: 22px; padding-left:20px" onmouseout="this.style.backgroundColor=''" onmouseover="this.style.backgroundColor='#ffffff'">
                                                            <img src="images/icon.gif" alt="" />
                                                            <a href="AssistBE/WorkInfoApplyList.aspx?type=2" target="mainFrame">Applied work</a></td>
                                                    </tr>
                                                </table>
                                                <table   runat="server" id="MyWorkInfoApplyList" width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="height: 22px; padding-left:20px" onmouseout="this.style.backgroundColor=''" onmouseover="this.style.backgroundColor='#ffffff'">
                                                            <img src="images/icon.gif" alt="" />
                                                            <a href="AssistBE/MyWorkInfoApplyList.aspx" target="mainFrame">My work</a></td>
                                                    </tr>
                                                </table>  
                                                <table   runat="server" id="s_UpPerson" width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="height: 22px; padding-left:20px" onmouseout="this.style.backgroundColor=''" onmouseover="this.style.backgroundColor='#ffffff'">
                                                            <img src="images/icon.gif" alt="" />
                                                            <a href="AssistBE/UpPerson.aspx?type=Modify" target="mainFrame">My info</a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <table  runat="server" visible="false"  id="BasicManage"  cellpadding="0" cellspacing="0" width="100%" border="0" style="vertical-align: top;
                                        text-align: left;">
                                        <tr>
                                            <td style="width: 100%; background-image: url(images/menu_bg.gif); height: 36px;
                                                cursor:pointer" class="menu_title" onclick="menu(6);">
                                                <span class="font_span">Basic info</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="background-image: url(images/left_bg.gif); display: none;" class="myweb_td"
                                                id="submenu_6">
                                                <table  runat="server" id="PersonManage" width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="height: 22px; padding-left:20px" onmouseout="this.style.backgroundColor=''" onmouseover="this.style.backgroundColor='#ffffff'">
                                                            <img src="images/icon.gif" alt="" />
                                                            <a href="AssistBE/PersonManage.aspx" target="mainFrame">Student management</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table runat="server" id="SemesterManage" width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="height: 22px; padding-left:20px" onmouseout="this.style.backgroundColor=''" onmouseover="this.style.backgroundColor='#ffffff'">
                                                            <img src="images/icon.gif" alt="" />
                                                            <a href="AssistBE/SemesterManage.aspx" target="mainFrame">Semester/Year</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                                  <%-- <table runat="server" id="EducationManage" width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="height: 22px; padding-left:20px" onmouseout="this.style.backgroundColor=''" onmouseover="this.style.backgroundColor='#ffffff'">
                                                            <img src="images/icon.gif" alt="" />
                                                            <a href="AssistBE/EducationManage.aspx" target="mainFrame">Edu info</a>
                                                        </td>
                                                    </tr>
                                                </table>--%>
                                                 <table runat="server" id="CompanyManage" width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="height: 22px; padding-left:20px" onmouseout="this.style.backgroundColor=''" onmouseover="this.style.backgroundColor='#ffffff'">
                                                            <img src="images/icon.gif" alt="" />
                                                            <a href="AssistBE/CompanyManage.aspx" target="mainFrame">Company Info</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                     
                                    <table cellpadding="0" cellspacing="0" width="180" border="0" style="vertical-align: top;
                                        text-align: left">
                                        <tr>
                                            <td style="background-image: url(images/menu_bg.gif); height: 36px; cursor:pointer"
                                                class="menu_title" onclick="javascript:window.open('UpdateAdminPwd.aspx','mainFrame')">
                                                <span class="font_span">Change Pword</span></td>
                                        </tr>
                                    </table>
                                    <table cellpadding="0" cellspacing="0" width="180" border="0" style="vertical-align: top;
                                        text-align: left">
                                        <tr>
                                            <td style="background-image: url(images/menu_bg.gif); height: 36px; cursor: hand"
                                                class="menu_title" onclick="javascript:location.href='/loginOut.aspx';">
                                                <span class="font_span">Exit</span></td>
                                        </tr>
                                    </table>
                                    
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
