<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpEducation.aspx.cs" Inherits="admin_UpEducation" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Maintain edu</title>
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
                    <div id="TitleName" runat="server">Add edu info</div></th>
            </tr>
        </table>
        <br />
        <table border="0" cellspacing="1" class="List" style="width: 98%">
        
            <tr>
                <td class="style1">
                    &nbsp;Degree type��</td>
                 <td style="width: 652px">
                    &nbsp;<asp:DropDownList ID="DP_DegreeType" runat="server">
                        <asp:ListItem Selected="True" Value="0">Undergraduate</asp:ListItem>
                        <asp:ListItem Value="1">Graduate</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Major��</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="MajorName" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
              <tr>
                <td class="style1">
                    &nbsp;GPA��</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="GPA" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;University��</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="UniversityName" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Country��</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="ContryName" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Cer title��</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="CertificateTitle" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Cer body��</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="CertificateOntology" runat="server" Width="213px"></asp:TextBox></td>
            </tr> 
             
           
            <tr>
                <td class="style2">
                </td>
                <td style="width: 652px; height: 22px">
                    &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Font-Size="13px" Height="26px" Width="74px" Text="Confirm" />
                    &nbsp;<asp:Button ID="Btn_back" runat="server" Text="Return" Font-Size="13px" Height="26px" Width="74px" OnClick="Back_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
