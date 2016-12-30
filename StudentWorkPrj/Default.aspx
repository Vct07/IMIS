<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Manage_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Internship Management Information System(IMIS)</title>
    <style type="text/css">
        body {
        background-image: url(admin/images/bg.gif);
	    margin: 0px;
	    background-repeat: repeat-x;
	    background-color: #60A6E0;
        }
        table,td{
        font-family:"宋体";
        font-size:12px;
        }
        .inputtext{
        border-left:1px solid balck;
        border-right:1px solid balck;
        border-top:1px solid balck;
        border-bottom:1px solid balck;
        }
        .loginbg {
        font-size: 12px;
        width: 59px;
        height: 26px;
        background-image: url(admin/images/login_bg.gif);
        border: none;
        padding-top: 3px;
        color:white;
        }
    </style>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>

<script type="text/javascript">
        String.prototype.Trim = function()
		{
		    return this.replace(/(^\s*)|(\s*$)/g, "");
		}
        function show(im)
        {
            im.src="../Code.aspx?" + new Date;
        }
        function CheckForm()
        {
            if(document.form1.TextBoxUserName.value.Trim() == "" || document.form1.TextBoxUserPwd.value.Trim() == "" || document.form1.TextBoxCode.value.Trim() == "")
            {
                alert("User name/Password cannot be empty.");
                return false;
            }
        }
</script>

<body onload="javascript:return document.form1.TextBoxUserName.focus();">
    <form id="form1" runat="server">
        <div style="text-align: center">
            <table width="100%" style="height: 98px;" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                    </td>
                </tr>
            </table>
            <table width="50%" style="text-align: center;margin:0px auto; height: 34px" border="0" cellspacing="0"
                cellpadding="0">
                <tr>
                    <td>
                       <%-- <img src="admin/Images/admin_02.gif" width="291" height="34" alt="" />--%>
                        <b><span style="font-size:26px;color:#fff;font-family:'Microsoft YaHei'">Internship Management Information System(IMIS)</span></b>
                    </td>
                </tr>
            </table>
            <table width="100%" style="height: 30px;" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                    </td>
                </tr>
            </table>
            <table width="100%" style="height: 261px; text-align: center;" border="0" cellpadding="0"
                cellspacing="0">
                <tr>
                    <td valign="top" >
                        <table style="margin:0px auto" width="457" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td colspan="3" style="height: 40px">
                                    <img src="admin/Images/admin_05.gif" alt="" width="457" height="40" style="border: 0px;"
                                        usemap="#Map" /></td>
                            </tr>
                            <tr>
                                <td style="width: 142px;" rowspan="3">
                                    <img src="admin/Images/admin_07.gif" width="142" height="221" alt="" /></td>
                                <td style="width: 240px; height: 35px;" valign="top">
                                    <img src="admin/Images/admin_08.gif" width="240" height="35" alt="" /></td>
                                <td rowspan="3" style="width: 75px">
                                    <img src="admin/images/admin_09.gif" width="75" height="221" alt="" /></td>
                            </tr>
                            <tr>
                                <td valign="top" style="background-image: url(admin/images/admin_10.gif); height: 107px;">
                                    <table width="95%" style="text-align: center; height: 100%;" border="0" cellpadding="0"
                                        cellspacing="0">
                                        <tr>
                                            <td align="right" style="width: 66px; height: 18px;">
                                                Uname：</td>
                                            <td style="width: 163px; height: 18px;" align="left">
                                                <asp:TextBox runat="server" ID="TextBoxUserName"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="height: 18px; width: 66px;">
                                                Pword：</td>
                                            <td style="width: 163px; height: 18px;" align="left">
                                                <asp:TextBox runat="server" ID="TextBoxUserPwd" TextMode="Password"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="height: 18px; width: 66px;">
                                                Role：
                                            </td>
                                             <td style="width: 163px; height: 18px;" align="left">
                                                <input checked="True" runat="server" type="radio" id="StudentIndity" name="role"/>Student
                                                <input type="radio" runat="server" id="AdminIndity" name="role"/>Admin
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="height: 18px; width: 66px;">
                                                Code：</td>
                                            <td align="left" valign="middle" style="width: 163px; height: 18px">
                                                <asp:TextBox ID="TextBoxCode" runat="server" Width="80"></asp:TextBox>
                                                <img src="Code.aspx" onclick="show(this)" alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px;" colspan="2" align="center">
                                                <asp:Button ID="ButtonSubmit" runat="server" Text="Login" OnClick="ButtonSubmit_Click"
                                                    OnClientClick="javascript:return CheckForm();" />
                                                <asp:Button ID="ButtonReset" runat="server" Text="Reset" OnClick="ButtonReset_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="middle" style="background-image: url(admin/Images/admin_11.gif);
                                    height: 72px;">
                                </td>
                            </tr>
                        </table>
                        <br />
                    </td>
                </tr>
            </table>
            <table width="750" border="0" style="text-align: center;" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; </td>
                </tr>
            </table>
        </div>
    </form>
    <map name="Map" id="Map">
        <area alt="" shape="rect" coords="378,13,433,26" href="#" target="_blank" />
    </map>
</body>
</html>
