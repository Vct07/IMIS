<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminIndex.aspx.cs" Inherits="Manage_AdminIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Internship Management</title>
</head>
<body style="background-color:#60a6e0;">
    <div style="text-align:center; margin-top:50px; font-family:幼圆; font-size:large; color:Window;">
         <%=UserName%> , Hello ！<br /><br />
        Welcome to IMIS！<br /><br />
        <script language="javascript" type="text/javascript">
            var enabled = 0; today = new Date();
            var day; var date;
            if(today.getDay()==0) day = "Sunday"
            if(today.getDay()==1) day = "Monday"
            if(today.getDay()==2) day = "Tuesday"
            if(today.getDay()==3) day = "Wednesday"
            if(today.getDay()==4) day = "Thursday"
            if(today.getDay()==5) day = "Friday"
            if(today.getDay()==6) day = "Saturday"
            document.fgColor = "000000";
            date = "Today is : " + (today.getFullYear()) + " / " + (today.getMonth() + 1) + " / " + today.getDate() + " / " + day;
            document.write(date);
        </script>
    </div>
</body>
</html>
