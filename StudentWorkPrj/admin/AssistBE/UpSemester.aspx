<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpSemester.aspx.cs" Inherits="admin_UpSemester" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Maintain Semester/Year info</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../CSS/private.css" rel="stylesheet" type="text/css" />

    <script src="../CSS/private.js" type="text/javascript" language="javascript"></script>

    <style type="text/css">
        .style1
        {
            width: 78px;
        }
        .style2
        {
            height: 22px;
            width: 78px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellspacing="1" class="Navi" width="98%">
            <tr>
                <th style="width: 930px; height: 24px">
                    <div id="TitleName" runat="server">Add semester/year</div></th>
            </tr>
        </table>
        <br />
        <table border="0" cellspacing="1" class="List" style="width: 98%">
        
            <tr>
                <td class="style1">
                    &nbsp;Semester：</td>
                <td style="width: 652px">
                    &nbsp;<asp:DropDownList ID="DP_Stype" runat="server">
                        <asp:ListItem Selected="True" Value="1">Fall</asp:ListItem>
                        <asp:ListItem Value="2">Winter</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Year：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="SYear" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
               
            <tr>
                <td class="style2">
                </td>
                <td style="width: 652px; height: 22px">
                    &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Font-Size="13px" Height="26px" Width="74px" Text="Submit" />
                    &nbsp;<asp:Button ID="Btn_back" runat="server" Text="Return" Font-Size="13px" Height="26px" Width="74px" OnClick="Back_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
