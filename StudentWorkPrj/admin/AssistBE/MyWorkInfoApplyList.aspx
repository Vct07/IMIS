<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyWorkInfoApplyList.aspx.cs" Inherits="admin_MyWorkInfoApplyList" %>
<%@ Register Assembly="UcfarPager" Namespace="UcfarPager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My applied work list</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../CSS/private.css" rel="stylesheet" type="text/css" />

    <link href="../../css/BaseStyle.css" rel="stylesheet" />    

     <link rel="Stylesheet" href="../CSS/AutoComplete/AutoComplete.css" />
    
</head>
<body>
    <form id="form1" runat="server">
          <table border="0" cellspacing="1" class="Navi" width="98%">
            <tr>
                <th style="width: 930px; height: 24px">
                    <div id="TitleName" runat="server">My applied work list</div></th>
            </tr>
        </table>
        <br />
       
         <div id="Msg" runat="server" style="margin-top:10px;margin-left:5px"></div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="Vertical" Width="100%"
            DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" PageSize="15">
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
                 <asp:BoundField DataField="NickName" HeaderText="Applicant"  ItemStyle-Width="100px" />  
                 <asp:BoundField DataField="PersonNumber" HeaderText="Student ID"  ItemStyle-Width="120px" /> 
                 <asp:BoundField DataField="CompanyName" HeaderText="Company"  ItemStyle-Width="120px" /> 
                 <asp:BoundField DataField="PostName" HeaderText="Position"  ItemStyle-Width="120px" />    
                <%-- <asp:TemplateField HeaderText="Description" ItemStyle-Width="320px"> 
                    <ItemTemplate>
                        <asp:Label ID="Status_Label" runat="server" Text='<%# Eval("Remark").ToString().Length>30?Eval("Remark").ToString().Substring(0,29):Eval("Remark").ToString() %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>    --%>               
                <asp:BoundField DataField="Num" HeaderText="Number needed"  ItemStyle-Width="100px" />
                               
                <asp:BoundField DataField="CreateDate" HeaderText="Applied time"  ItemStyle-Width="120px" />
                   <asp:TemplateField HeaderText="Status" ItemStyle-Width="80px"> 
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToInt32(Eval("Type"))==1?"Applied":"Approved" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
         <div style="margin-top:5px;margin-left:5px">
        <cc1:UcfarPager ID="UcfarPager1" runat="Server" MainTableStyle="text-align:left;" 
            onpagechanged="UcfarPager1_PageChanged" PageSize="20"   
        NavigatePreviousText="Last page" NavigateNextText="Next page" DisplayPagerNum="10"   >
        </cc1:UcfarPager>
            </div>
            <div id='floor' class='floor'></div>
    </form>
</body>
</html>
