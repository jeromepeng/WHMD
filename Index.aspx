<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WHMD.Index.Index" %>
<%@ Register Src="/Shared/top.ascx" TagPrefix="UCtop" TagName="topUC" %>
<%@ Register Src="/Shared/footer.ascx" TagPrefix="UCfooter" TagName="footerUC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>武汉陵园</title>
    <link rel="stylesheet" type="text/css" href="/Styles/main.css" media="all" />
    <script type="text/javascript" src="/Scripts/jquery_002.js"></script>
    <script type="text/javascript" src="/Scripts/slideswitch.js"></script>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <!--[if IE 6]><script type="text/javascript" src="/js/lib/iepngfix_tilebg.js"></script><![endif]-->
    <!--[if IE]><script src="/js/lib/html5.js"></script><![endif]-->
    <script type="text/javascript">
		$(document).ready(function() { 
			$("a#inline").fancybox({
			'hideOnContentClick': true,
			});
		});
    </script>
</head>
<body>
    <UCtop:topUC id="mytop" runat="server"></UCtop:topUC>
    <div id="hd">
        <div id="hdC">
            <div id="mainvisual">
                <ul id="mvPanel">
                  <%=hd1HTML%> 
                </ul>
                <ul id="mvThumbnail">
                   <%=hd2HTML%>
                </ul>
            </div>
        </div>
    </div>
    <div id="main">
        <div id="mainC">
         <%=pHTML%>
        </div>
    </div>
    <UCfooter:footerUC id="footerUC1" runat="server"></UCfooter:footerUC>
</body>
</html>

