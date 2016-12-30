<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChooseEducation.aspx.cs" Inherits="admin_ChooseEducation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Choose edu info</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../CSS/private.css" rel="stylesheet" type="text/css" />

    <link href="../../css/BaseStyle.css" rel="stylesheet" />    
</head>
<body>
    <form id="form1" runat="server">
        
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
                 <asp:TemplateField HeaderText="Degree type" ItemStyle-Width="120px"> 
                    <ItemTemplate>
                        <asp:Label ID="Status_Label" runat="server" Text='<%# Eval("DegreeType").ToString()=="0"?"Undergraduate":"Graduate" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                 <asp:BoundField DataField="MajorName" HeaderText="Major"  ItemStyle-Width="120px" />    
                <asp:BoundField DataField="GPA" HeaderText="GPA"  ItemStyle-Width="80px" />                  
               <asp:BoundField DataField="UniversityName" HeaderText="Degree University"  ItemStyle-Width="120px" /> 
                 <asp:BoundField DataField="ContryName" HeaderText="University location"  ItemStyle-Width="100px" /> 
                 <asp:BoundField DataField="CertificateTitle" HeaderText="Certification title"  ItemStyle-Width="100px" /> 
                 <asp:BoundField DataField="CertificateOntology" HeaderText="Certification body"  ItemStyle-Width="100px" /> 
                  
               <asp:TemplateField HeaderText=""> 
                  <ItemTemplate>
                  <div style="text-align:center; cursor:pointer">
                     <asp:LinkButton ToolTip="Choose edu info" ID="choose" CommandName="choose" CssClass="LinkStyle" Width="55px" Height="11px" runat="server" CommandArgument='<%# Eval("ID") %>'>Choose</asp:LinkButton>
                  </div>                     
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
