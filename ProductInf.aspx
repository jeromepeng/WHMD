<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductInf.aspx.cs" Inherits="WHMD.ProductInf" %>
<%@ Register Src="/Shared/top.ascx" TagPrefix="UCtop" TagName="topUC" %>
<%@ Register Src="/Shared/footer.ascx" TagPrefix="UCfooter" TagName="footerUC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> <%=productnameHTML%></title>
    <link rel="stylesheet" type="text/css" href="/Styles/main.css" media="all" />
    <link rel="stylesheet" type="text/css" href="/Styles/productinfo.css" media="all" />
</head>
<body>
<%var pinfo=productinfoDATA as Morrison.Models.productinfo; %>
   <UCtop:topUC id="mytop" runat="server"></UCtop:topUC>
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
                            <%=productnameHTML%></li></ul>
                </div>
                <div id="productinfo">
                    <div id="productinfo_li">
                        <div id="productinfo_left">
                            <img src="/Files/Product/<%=pinfo.productimg %>" alt="" /></div>
                        <div id="productinfo_right">
                            <ul>
                                <li><span class="fb mb20"><%=pinfo.productname %></span></li><li>大分类：<%=pinfo.bigcategory %></li><li>小分类:<%=pinfo.smallcategory %></li><li>
                                    产品规格：<%=pinfo.productsize %></li><li>价格：￥<%=pinfo.productprice %>元</li>
                            </ul>
                        </div>
                    </div>
                    <div id="productinfo_main">
                    <%=pinfo.productintroduce %>
                    </div>
                </div>
            </div>
        </div>
    </div>
   <UCfooter:footerUC id="footerUC1" runat="server"></UCfooter:footerUC>
</body>
</html>
