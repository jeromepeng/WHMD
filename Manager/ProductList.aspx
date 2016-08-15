<%@ Page Title="" Language="C#" MasterPageFile="/Shared/Manager.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="WHMD.Manager.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RightURL" runat="server">
<p>
        <span></span>你当前位置：产品管理 - 产品列表页</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#a8c7ce"
        style="margin-bottom: 10px;" onmouseover="changeto()" onmouseout="changeback()">
        <tr>
            <td width="25%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>产品图片</span></div>
            </td>
            <td width="35%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>产品名称</span></div>
            </td>
            <td width="20%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>产品价格</span></div>
            </td>                     
            <td width="20%" height="25" bgcolor="#B7E895">
                <div align="center">
                    <span>操作</span></div>
            </td>
        </tr>
        <%=productlistHTML%>
    </table>
    <div class="digg">
        <%=pageHTML%>
    </div> 
    <span id="boxs"></span>  
</asp:Content>
