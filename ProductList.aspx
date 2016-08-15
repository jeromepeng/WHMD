<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="WHMD.ProductList" %>
<%@ Register Src="~/Shared/top.ascx" TagPrefix="UCtop" TagName="topUC" %>
<%@ Register Src="/Shared/footer.ascx" TagPrefix="UCfooter" TagName="footerUC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>时尚家居用品，日式家居展示、美式家居展示，实木家居、棉麻桌旗展示页面</title>
    <link rel="stylesheet" type="text/css" href="/Styles/main.css" media="all" />
    <link rel="stylesheet" type="text/css" href="/Styles/pagecss.css" media="all" />
    <link rel="stylesheet" type="text/css" href="/Styles/productlist.css" media="all" />
</head>
<body>
    <UCtop:topUC ID="mytop" runat="server"></UCtop:topUC>
    <div id="pmain">
        <div id="pmainC">
          <div class="topimg"><%=topimgHTML%></div>
            <div id="pmainleft">
                <h3>
                    家居分类</h3>
               <%=categorysbHTML%>
            </div>
            <div id="pmainright">
                <div id="pdh">
                    <ul>
                        <li><a href="/Index.aspx">首页</a></li><li>&gt;</li><li><a href="/ProductList.aspx">产品列表</a></li><li>&gt;</li><li>
                            <%=dhcategoryHTML%></li></ul>
                </div>
                <div id="productlist">
                    <%=productlistHTML%>
                </div>
                <div class="digg2" style="width: 668px; float: left; font-size: 14px;">
                    <%=PageHTML %>
                </div>
            </div>
        </div>
    </div>
    <UCfooter:footerUC ID="footerUC1" runat="server"></UCfooter:footerUC>
</body>
</html>
