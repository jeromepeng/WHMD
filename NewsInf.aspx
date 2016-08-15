<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsInf.aspx.cs" Inherits="WHMD.NewsInf" %>
<%@ Register Src="/Shared/top.ascx" TagPrefix="UCtop" TagName="topUC" %>
<%@ Register Src="~/Shared/footer.ascx" TagPrefix="UCfooter" TagName="footerUC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=ntitleHTML%></title>
    <link rel="stylesheet" type="text/css" href="/Styles/main.css" media="all" />
    <link rel="stylesheet" type="text/css" href="/Styles/newslist.css" media="all" />
</head>
<body>
<%var ninfo=ninfoDATA as Morrison.Models.newsinfo; %>
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
                 <img src="../../Images/qimu2.jpg" alt="武汉陵园" />             
            </div>
            <div id="pmainright">
                <div id="pdh">
                    <ul>
                        <li><a href="/Index.aspx">首页</a></li><li>&gt;</li><li><a href="/NewsList.aspx">新闻列表</a></li><li>&gt;</li><li><%=ntitleHTML%></li></ul>
                </div>
                <div id="newsinfo">
                    <div id="newstitle">
                       <h3><%=ninfo.newstitle %></h3>
                       <ul><li>来源：<span style="color:#336699"><%=ninfo.newsfrom %></span></li><li>作者：<span style="color:#336699"><%=ninfo.newswriter %></span></li><li>发布时间：<%=ninfo.adddate %></li></ul>
                    </div>  
                    <div id="newscontent">
                      <%=ninfo.ninfo %>
                    </div>
                </div>
            </div>
        </div>
    </div>
   <UCfooter:footerUC id="footerUC1" runat="server"></UCfooter:footerUC>
</body>
</html>
