<%@ Page Title="" Language="C#" MasterPageFile="/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WHMD.WebContent.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderCPH" runat="server">
    <%=ctitleHTML %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bannerCPH" runat="server">
    <%=bannerHTML %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="leftCPH" runat="server">
    <div class="master_left1">
       <div class="master_left1_1"></div>
       <div class="master_left1_2">
        <ul>
             <%=categorylistHTML%>
          </ul>
       </div>
       <div class="master_left1_3"></div>
    </div>
    <div class="master_left2">
        <a href="/WS/3">
            <img src="/Images/ico_message.jpg" alt="" /></a> <a href="/WS/4">
                <img src="/Images/ico_job.jpg" alt="" /></a>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="rightCPH" runat="server">
    <div class="master_right1">
        <ul>
            <li><a href="/Default">首页</a></li><li>&gt;</li><li><%=ctitleHTML %></li></ul>
    </div>
    <div class="master_right2">
        <img src="/Images/TextImage.png" alt="" /><img src="/Images/tle_mid.jpg" alt="" /><img
            src="/Images/TextImage(1).png" alt="" />
    </div>
    <div class="master_right3">
       <div class="master_info">
        <%=contentHTML %>
       </div>
    </div>
</asp:Content>

