<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="WHMD.NewsList" %>
<%@ Register Src="/Shared/top.ascx" TagPrefix="UCtop" TagName="topUC" %>
<%@ Register Src="/Shared/footer.ascx" TagPrefix="UCfooter" TagName="footerUC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>时尚家居、家私，风尚家居，装修类新闻列表</title>
    <link rel="stylesheet" type="text/css" href="/Styles/main.css" media="all" />
    <link rel="stylesheet" type="text/css" href="/Styles/newslist.css" media="all" />
     <link rel="stylesheet" type="text/css" href="/Styles/pagecss.css" media="all" />
</head>
<body>
    <UCtop:topUC id="mytop" runat="server"></UCtop:topUC>   
    <div id="pmain">
        <div id="pmainC">
         <div class="topimg"><%=topimgHTML%></div>
            <div id="pmainleft">
            <div id="pmainleft1">
                <h3>
                    新闻分类</h3>
                <ul>
                    <%=cHTML%>
                </ul>  
                </div>                 
                 <img src="/Images/qimu2.jpg" alt="武汉陵园" />             
            </div>
            <div id="pmainright">
                <div id="pdh">
                    <ul>
                        <li><a href="/Index.aspx">首页</a></li><li>&gt;</li><li><a href="/Index/NewsList.aspx">新闻列表</a></li></ul>                       
                </div>
                <div id="newslist">
                    <ul>
                        <%=newslistHTML%>
                    </ul>
                </div>
                 <div class="digg2" style="width: 668px; float: left; font-size: 14px;">
                    <%=pageHTML%>
                </div>
            </div>
        </div>
    </div>
   <UCfooter:footerUC id="footerUC1" runat="server"></UCfooter:footerUC>
</body>
</html>
