<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SemesterManage.aspx.cs" Inherits="admin_SemesterManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Semester/Year management</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../CSS/private.css" rel="stylesheet" type="text/css" />

    <link href="../../css/BaseStyle.css" rel="stylesheet" />    
</head>
<body>
    <form id="form1" runat="server">
         <table border="0" cellspacing="1" class="Navi" width="98%">
            <tr>
                <th style="width: 930px; height: 24px">
                    <div id="TitleName" runat="server">Semester/Year management</div></th>
            </tr>
        </table>
        <br />
        <asp:Button ID="Button1" runat="server" CssClass="LinkStyle" Text="Add semester/year" OnClick="Button1_Click" />
                 &nbsp;
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="Vertical" Width="98%"
            DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" PageSize="30">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#D9E4FC" />
            <Columns>
                <asp:TemplateField HeaderText="id" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:BoundField DataField="SYear" HeaderText="Year"  ItemStyle-Width="120px" />    
                 <asp:TemplateField HeaderText="Semester" ItemStyle-Width="120px"> 
                    <ItemTemplate>
                        <asp:Label ID="Status_Label" runat="server" Text='<%# Eval("Stype").ToString()=="1"?"Fall":"Winter" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
                 
                 
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%# string.Format("~/admin/AssistBE/UpSemester.aspx?type=Modify&id={0}",Eval("ID")) %>'>Change</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="30px" />
                </asp:TemplateField> 
               <asp:TemplateField HeaderText=""> 
                  <ItemTemplate>
                  <div style="text-align:center; cursor:pointer">
                  <asp:ImageButton ToolTip="Delete semester/year" ID="imgbtnDelete" ImageUrl="../images/delete.png" CommandName="delete" CssClass="LinkStyle" Width="15px" Height="11px" runat="server" CommandArgument='<%# Eval("ID") %>'/></div>                     
                  </ItemTemplate>
                    <ItemStyle Width="25px" />
                 </asp:TemplateField> 
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </form>
</body>
</html>
