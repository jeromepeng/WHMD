﻿<%@ Page Title="" Language="C#" MasterPageFile="/Shared/Manager.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="EditProduct.aspx.cs" Inherits="WHMD.Manager.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RightURL" runat="server">
 <p>
        <span></span>你当前位置：产品管理 - 产品编辑</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightSearch" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <% var productinfo = productinfoDATA as Morrison.Models.productinfo; %>
 <script type="text/javascript" src="/Scripts/imgreview.js"></script>
    <script charset="utf-8" src="/kindeditor/kindeditor.js" type="text/javascript"></script>
    <script charset="utf-8" src="/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script type="text/javascript">
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('#MainContent_editor_id', {
                resizeType: 2,
                uploadJson: '/kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: '/kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: false,
                resizeMode: 0,
                width: '700px',
                resizeType: 1,
                items: ['source', 'undo', 'redo', 'fontname', 'fontsize', 'forecolor', 'hilitecolor', 'bold', 'justifyleft', 'justifycenter', 'justifyright', 'image', 'flash', 'media', 'insertfile', 'baidumap', 'pagebreak', 'textcolor', 'bgcolor']
            });
        });
    </script>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="white">
        <tr>
            <td width="160px" style="padding-right: 10px" height="30" bgcolor="cadee8">
                <div align="right">
                    产品名称</div>
            </td>
            <td width="610px" style="padding-left: 10px" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="productname" id="productname" runat="server" type="text" style="border: solid 1px #cacaca;
                        width: 300px; height: 20px; line-height: 20px; text-align: left;" />
                </div>
            </td>
        </tr>      
        <tr>
            <td width="160px" style="padding-right: 10px" height="30" bgcolor="cadee8">
                <div align="right">
                    产品编号</div>
            </td>
            <td width="610px" style="padding-left: 10px" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="productcode" id="productcode" runat="server" type="text" style="border: solid 1px #cacaca;
                        width: 300px; height: 20px; line-height: 20px; text-align: left;" />
                </div>
            </td>
        </tr>
        <tr>
            <td width="160px" style="padding-right: 10px" height="30" bgcolor="cadee8">
                <div align="right">
                    产品分类</div>
            </td>
            <td width="610px" style="padding-left: 10px" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <asp:DropDownList ID="bcID" runat="server" OnSelectedIndexChanged="ChangeSmallSelect"
                        AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:DropDownList ID="scID" runat="server">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td width="160px" style="padding-right: 10px" height="30" bgcolor="cadee8">
                <div align="right">
                    产品图片</div>
            </td>
            <td width="610px" style="padding-left: 10px" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="imgfile" id="imgfile" runat="server" type="file" onchange="onUploadImgChange(this)" /><label
                        id="imgnote" runat="server"></label>
                </div>
            </td>
        </tr>
          <tr>
            <td width="160px" height="130" bgcolor="#cadee8">
                <div align="left">
                </div>
            </td>
            <td width="610px" height="130" bgcolor="#e9f2f7">
                <div id="preview_fake">
                    <img id="preview" onload="onPreviewLoad(this)" src="/Files/Product/<%=productinfo.productimg %>" alt="" />
                    <img id="preview_size_fake" alt="" />
                </div>
            </td>
        </tr>
        <tr>
            <td width="160px" style="padding-right: 10px" height="30" bgcolor="cadee8">
                <div align="right">
                    产品价格</div>
            </td>
            <td width="610px" style="padding-left: 10px" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="productprice" id="productprice" runat="server" type="text" style="border: solid 1px #cacaca;
                        width: 50px; height: 20px; line-height: 20px; text-align: center;" />
                    元
                </div>
            </td>
        </tr>
        <tr>
            <td width="160px" style="padding-right: 10px" height="30" bgcolor="cadee8">
                <div align="right">
                    VIP价格</div>
            </td>
            <td width="610px" style="padding-left: 10px" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input name="vipprice" id="vipprice" runat="server" type="text" style="border: solid 1px #cacaca;
                        width: 50px; height: 20px; line-height: 20px; text-align: center;" />
                    元
                </div>
            </td>
        </tr>
         <tr>
            <td width="160px" style="padding-right: 10px" height="30" bgcolor="cadee8">
                <div align="right">
                    产品规格</div>
            </td>
            <td width="610px" style="padding-left: 10px" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input id="productsize" runat="server" type="text" style="border: solid 1px #cacaca;
                        width: 300px; height: 20px; line-height: 20px; text-align: left;" />
                    
                </div>
            </td>
        </tr>
          <tr>
            <td width="160px" style="padding-right: 10px" height="30" bgcolor="cadee8">
                <div align="right">
                    产品颜色</div>
            </td>
            <td width="610px" style="padding-left: 10px" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <input id="productcolor" runat="server" type="text" style="border: solid 1px #cacaca;
                        width: 300px; height: 20px; line-height: 20px; text-align: left;" />                    
                </div>
            </td>
        </tr>
        <tr>
            <td width="160px" style="padding-right: 10px" height="90" bgcolor="cadee8">
                <div align="right">
                    产品简介</div>
            </td>
            <td width="610px" style="padding-left: 10px" height="90" bgcolor="e9f2f7">
                <div align="left">
                    <textarea name="productbrief" id="productbrief" runat="server" style="border: solid 1px #cacaca;
                        width: 300px; height: 80px; text-align: left;"></textarea>
                </div>
            </td>
        </tr>
        <tr>
            <td width="160px" style="padding-right: 10px" height="510" bgcolor="cadee8">
                <div align="right">
                    产品详情</div>
            </td>
            <td width="610px" style="padding-left: 10px" height="510" bgcolor="e9f2f7">
                <div align="left">
                    <textarea name="productintroduce" id="editor_id" runat="server" style="border: solid 1px #cacaca;
                        width: 650px; height: 500px; text-align: left;"></textarea>
                </div>
            </td>
        </tr>
        <tr>
            <td width="160px" style="padding-right: 10px" height="30" bgcolor="cadee8">
                <div align="left">
                </div>
            </td>
            <td width="610px" style="padding-left: 10px" height="30" bgcolor="e9f2f7">
                <div align="left">
                    <asp:Button ID="Button1" runat="server" OnClick="EditProductInfo" Text="编辑产品" />
                </div>
            </td>
        </tr>
    </table>
    <input type="hidden" id="sproductid" runat="server" /><input type="hidden" id="oldproductimg" runat="server" />
</asp:Content>
