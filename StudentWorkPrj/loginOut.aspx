<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginOut.aspx.cs" Inherits="loginOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="js/jquery-1.8.2.js"></script>
    <script type="text/javascript">
        $(function () {
            if (window.top != window.self) {
                parent.window.location.href = "Default.aspx";
            }
        })
     </script>
        
</head>
<body>
    <form id="form1" runat="server">
    <div>
    To continue operation，please click-><a href="Default.aspx">Re-enter</a>  
    </div>
    </form>
</body>
</html>
