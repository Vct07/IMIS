<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonManage.aspx.cs" Inherits="admin_PersonManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student info management</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../CSS/private.css" rel="stylesheet" type="text/css" />

    <link href="../../css/BaseStyle.css" rel="stylesheet" />    
</head>
<body>
    <form id="form1" runat="server">
      <table border="0" cellspacing="1" class="Navi" width="98%">
            <tr>
                <th style="width: 930px; height: 24px">
                    <div id="TitleName" runat="server">Student info management</div></th>
            </tr>
        </table>
        <asp:TextBox  name="keyword" ID="keyword"  runat="server" Width="213px"></asp:TextBox>&nbsp;
        <asp:Button ID="Search" runat="server" CssClass="LinkStyle" Text="Search" OnClick="Button2_Click" Width="62px" />&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" CssClass="LinkStyle" Text="Add student" OnClick="Button1_Click" />
                 &nbsp;
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="Vertical" Width="98%"
            DataKeyNames="MS_PersonOID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" PageSize="20">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#D9E4FC" />
            <Columns>
                <asp:TemplateField HeaderText="id" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("MS_PersonOID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("MS_PersonOID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="PersonNumber" HeaderText="Student ID"  ItemStyle-Width="100px" />
                 <asp:BoundField DataField="NickName" HeaderText="Student given name"  ItemStyle-Width="100px" />    
                <asp:BoundField DataField="MiddleName" HeaderText="Student middle name"  ItemStyle-Width="80px" />                  
               <asp:BoundField DataField="FirstName" HeaderText="Student family name"  ItemStyle-Width="80px" />
                 <asp:TemplateField HeaderText="Email" ItemStyle-Width="100px"> 
                    <ItemTemplate>
                         <a href='<%#"mailto:"+Eval("Email").ToString()%>' ><%#Eval("Email")%></a>                            
                    </ItemTemplate>
                </asp:TemplateField> 
                 
                 <asp:BoundField DataField="Phone" HeaderText="Telephone"  ItemStyle-Width="80px" /> 
                <asp:TemplateField HeaderText="Gender" ItemStyle-Width="80px"> 
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToBoolean(Eval("Sex"))?"Male":"Female" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" ItemStyle-Width="80px"> 
                    <ItemTemplate>
                        <asp:Label ID="Status_Label" runat="server" Text='<%# Eval("Status").ToString()=="2"?"Citizen":"Internation" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                               
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%# string.Format("~/admin/AssistBE/UpPerson.aspx?type=Modify&id={0}",Eval("MS_PersonOID")) %>'>Details</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="80px" />
                </asp:TemplateField>
                   <%-- <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl='<%# string.Format("~/admin/AssistBE/UpEducation.aspx?id={0}",Eval("MS_PersonOID")) %>'>Add edu</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="80px" />
                </asp:TemplateField>--%>                  
                 <asp:TemplateField HeaderText=""> 
                  <ItemTemplate>
                  <div style="text-align:center; cursor:pointer">
                  <asp:ImageButton ToolTip="Reset password" ID="imgbtnInitPwd" ImageUrl="../images/Reset.png" CommandName="InitPwd" CssClass="LinkStyle" Width="15px" Height="11px" runat="server" CommandArgument='<%# Eval("MS_PersonOID") %>'/></div>                     
                  </ItemTemplate>
                    <ItemStyle Width="65px" />
                 </asp:TemplateField> 
               <asp:TemplateField HeaderText=""> 
                  <ItemTemplate>
                  <div style="text-align:center; cursor:pointer">
                  <asp:ImageButton ToolTip="Delete student" ID="imgbtnDelete" ImageUrl="../images/delete.png" CommandName="delete" CssClass="LinkStyle" Width="15px" Height="11px" runat="server" CommandArgument='<%# Eval("MS_PersonOID") %>'/></div>                     
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
