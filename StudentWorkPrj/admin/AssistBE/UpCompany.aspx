<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpCompany.aspx.cs" Inherits="admin_UpCompany" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Maintain company info</title>
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
                    <div id="TitleName" runat="server">Add company info</div></th>
            </tr>
        </table>
        <br />
        <table border="0" cellspacing="1" class="List" style="width: 98%">
        
            <tr>
                <td class="style1">
                    &nbsp;Company name：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="CompanyName" Enabled="true" Text="" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Address：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="Address" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
              <tr>
                <td class="style1">
                    &nbsp;City：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="City"  Text="Windsor" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Postcode：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="PostCode" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Country：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="Contry" runat="server" Text="Canada" Width="213px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Contact given name：</td>
                <td style="width: 652px">&nbsp;<asp:TextBox ID="ContactMiddleName" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Contact family name：</td>
                <td style="width: 652px">&nbsp;<asp:TextBox ID="ContactFirstName" runat="server" Width="213px"></asp:TextBox></td>
                
            </tr>
            <tr>
                 <td class="style1">
                    &nbsp;Contact position：</td>
                <td style="width: 652px">&nbsp;<asp:TextBox ID="ContactPost" runat="server" Width="213px"></asp:TextBox></td>
                
            </tr>
           <tr>
                 <td class="style1">
                    &nbsp;Telephone：</td>
                <td style="width: 652px">&nbsp;<asp:TextBox ID="Phone" runat="server" Width="213px"></asp:TextBox></td>
                
            </tr>
           <tr>
                 <td class="style1">
                    &nbsp;Email：</td>
                <td style="width: 652px">&nbsp;<asp:TextBox ID="Email" runat="server" Width="213px"></asp:TextBox></td>
                
            </tr>
           <tr>
                 <td class="style1">
                    &nbsp;Company website：</td>
                <td style="width: 652px">&nbsp;<asp:TextBox ID="WebSite" runat="server" Width="213px"></asp:TextBox></td>
                
            </tr>
           <tr>
                 <td class="style1">
                    &nbsp;Note：</td>
                <td style="width: 652px">&nbsp;<asp:TextBox TextMode="MultiLine" Height="200px" ID="Remark" runat="server" Width="413px"></asp:TextBox></td>
                
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
