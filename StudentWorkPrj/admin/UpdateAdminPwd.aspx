<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateAdminPwd.aspx.cs" Inherits="Manage_UpdateAdminPwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled page</title>
     <link href="CSS/private.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: #60a6e0; color: Window;">
    <form id="form1" runat="server">
         
            <div style="background-color:#6ca393;width:600px;height:200px;margin-left:200px">
                <center>
                <table  border="0" cellpadding="1" cellspacing="1" width="360px" style="height: 120px;
                text-align: center;margin-top:30px">
                <tr  style="line-height:40px">
                    <td style="width: 90px;">
                        
                    </td>
                    <td>
                        <span style="font-size:18px;color:#ff6a00"><%=UserName %></span> 
                    </td>
                    <td></td>
                </tr>
                <tr style="line-height:25px">
                    <td>
                        Old password:</td>
                    <td>
                        <asp:TextBox ID="TextBoxOldPwd" runat="server" TextMode="Password" Height="16px" Width="197px"></asp:TextBox>                        
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorOldPwd" runat="server" ErrorMessage="*"
                            ControlToValidate="TextBoxOldPwd" Display="Dynamic"></asp:RequiredFieldValidator></td>
                </tr>
                <tr  style="line-height:25px">
                    <td>
                        New password:</td>
                    <td>
                        <asp:TextBox ID="TextBoxNewPwd" runat="server" TextMode="Password" Height="16px" Width="197px"></asp:TextBox>
                        
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorNewPwd" runat="server" ErrorMessage="*"
                            ControlToValidate="TextBoxNewPwd" Display="Dynamic"></asp:RequiredFieldValidator></td>
                </tr>
                <tr  style="line-height:25px">
                    <td>
                        New password:</td>
                    <td>
                        <asp:TextBox ID="TextBoxConfirmPwd" runat="server" TextMode="Password" Height="16px" Width="197px"></asp:TextBox>
                        
                        
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorCPwd" runat="server" ErrorMessage="*"
                            ControlToValidate="TextBoxConfirmPwd" Display="Dynamic"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td colspan="3" style="height:40px">
                        <div style="margin-left:90px">
                        <asp:Button ID="ButtonSubmit" runat="server" Text="Confirm" OnClick="ButtonSubmit_Click" Height="25px" Width="69px" />
                         &nbsp;<asp:Button ID="Button1" runat="server" Text="Cancel" OnClick="Cancel_Click" Height="25px" Width="69px" />
                         </div>
                        </td>
                </tr>
            </table>
                    </center>
            </div>
            
         
    </form>
</body>
</html>
