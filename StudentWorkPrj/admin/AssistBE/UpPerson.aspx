<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpPerson.aspx.cs" Inherits="admin_UpPerson" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Maintain student info</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../CSS/private.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" r src="../../js/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="../../js/Person.js"></script>
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
                    <div id="TitleName" runat="server">Add student info</div></th>
            </tr>
        </table>
        <br />
        <table border="0" cellspacing="1" class="List" style="width: 98%">
           
            <tr>
                <td class="style1">
                    &nbsp;Student ID：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="PersonNumber" Enabled="true" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Student given name：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="NickName" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
              <tr>
                <td class="style1">
                    &nbsp;Student middle name：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="MiddleName" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Student family name：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="FirstName" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Email：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="Email" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Telephone：</td>
                <td style="width: 652px">
                    &nbsp;<asp:TextBox ID="Phone" runat="server" Width="213px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Gender：</td>
                <td style="width: 652px">
                    &nbsp;<asp:DropDownList ID="DP_Sex" runat="server">
                        <asp:ListItem Selected="True" Value="1">Male</asp:ListItem>
                        <asp:ListItem Value="0">Female</asp:ListItem>
                    </asp:DropDownList></td>
                
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;Status：</td>
                <td style="width: 652px"> &nbsp;
                    <asp:DropDownList ID="DP_Status" runat="server">
                        <asp:ListItem Selected="True" Value="1">International</asp:ListItem>
                        <asp:ListItem Value="2">Citizen</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
           <tr>
                <td class="style1">
                    &nbsp;Semester/Year：</td>
                <td style="width: 652px">
                    &nbsp;<asp:DropDownList ID="DP_Semester" runat="server">
                       
                    </asp:DropDownList></td>
                
            </tr>
               <tr id="tr_skill">
                <td class="style1">
                    &nbsp;skill：</td>
                <td style="width: 652px">
                    <div id="skills"> </div>
                    </td>
                
            </tr>
             
            <tr>
                <td class="style2">
                </td>
                <td style="width: 652px; height: 22px">
                    &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Font-Size="13px" Height="26px" Width="74px" Text="Submit" />
                    &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Visible="false" Font-Size="13px" Height="26px" Width="74px" Text="Add edu" />
                    &nbsp;<asp:Button ID="Btn_back" runat="server" Text="Return" Font-Size="13px" Height="26px" Width="74px" OnClick="Back_Click" />
                </td>
            </tr>
        </table>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="False" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" GridLines="Vertical" Width="800px"
            DataKeyNames="ID"  PageSize="30">
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
                  <asp:ImageButton ToolTip="Delete" ID="imgbtnDelete" ImageUrl="../images/delete.png" CommandName="delete" CssClass="LinkStyle" Width="15px" Height="11px" runat="server" CommandArgument='<%# Eval("ID") %>'/></div>                     
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
