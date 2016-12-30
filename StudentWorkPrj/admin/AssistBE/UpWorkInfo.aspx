<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpWorkInfo.aspx.cs" Inherits="admin_UpWorkInfo" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Maintain work info</title>
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
                    <div id="TitleName" runat="server">Add work info</div></th>
            </tr>
        </table>
        <br />
        <table border="0" cellspacing="1" class="List" style="width: 98%">
            <tr>
                <td class="style1">
                    &nbsp;Company：</td>
                <td style="width: 652px">
                    &nbsp;<asp:DropDownList ID="Dp_Company" runat="server" ></asp:DropDownList>
                   &nbsp; 
                </td>
            </tr>
        <tr>
                <td class="style1">
                    &nbsp;Work：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="PostName" runat="server" Width="249px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Responsibility：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="Responsibility" TextMode="MultiLine" Height="60px" runat="server" Width="513px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Description：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="Remark"  TextMode="MultiLine" Height="60px"  runat="server" Width="513px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Requirement：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="Requirement"  TextMode="MultiLine" Height="60px"  runat="server" Width="513px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Salary：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="Wages" runat="server" Text="0" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Number needed：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="Num" runat="server" Text="1" Width="100px"></asp:TextBox>
                     
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Work：</td>
                <td style="width: 652px">
                    &nbsp;<asp:DropDownList ID="DP_WorkType" runat="server">
                        <asp:ListItem Selected="True" Value="Web dev">Web dev</asp:ListItem>
                        <asp:ListItem Value="Mobile dev">Mobile dev</asp:ListItem>
                        <asp:ListItem Value="System dev">System dev</asp:ListItem>
                        <asp:ListItem Value="Technical support">Technical support</asp:ListItem>
                        <asp:ListItem Value="Networking">Networking</asp:ListItem>
                        <asp:ListItem Value="Data analysis">Data analysis</asp:ListItem>
                        <asp:ListItem Value="Testing">Testing</asp:ListItem>
                        <asp:ListItem Value="Seurity">Security</asp:ListItem>
                        <asp:ListItem Value="Data manage">Data manage</asp:ListItem>
                        <asp:ListItem Value="Other">Other</asp:ListItem>                        
                    </asp:DropDownList></td>
            </tr>
            
               
            <tr>
                <td class="style2">
                </td>
                <td style="width: 652px; height: 22px">
                    &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Font-Size="13px" Height="26px" Width="74px" Text="Submit" />
                    &nbsp;<asp:Button ID="Btn_back" runat="server" Text="Return" Font-Size="13px" Height="26px" Width="74px" OnClick="Back_Click" />
                    &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Visible="false" Font-Size="13px" Height="26px" Width="74px" Text="Apply" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
