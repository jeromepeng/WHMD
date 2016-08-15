var statecookie = new Array();
function itemselect(k) {
    var item1 = document.getElementById("leftMenu" + k);
    var img1 = document.getElementById("sysimg" + k);
    statecookie[k] = getCookie("state" + k);
    if (statecookie[k] == 0) {
        item1.style.display = "block";
        img1.src = "/Images/arrBig.gif";
        createcookie('state' + k, '1');

    }
    else {
        item1.style.display = "none";
        img1.src = "/Images/arrBig1.gif";
        createcookie('state' + k, '0');
    }
}

function initstate() {
    for (var n = 1; n < 5; n++) {
        var item1 = document.getElementById("leftMenu" + n);
        statecookie[n] = getCookie("state" + n);
        if (getCookie("state" + n) == 1) {
            item1.style.display = "block";

        }
        else {
            item1.style.display = "none";
            createcookie('state' + n, '0');
        }

    }
}


if (document.all) {

    window.attachEvent('onload', initstate); //IE中

}

else {

    window.addEventListener('load', initstate, false); //firefox

}


var highlightcolor = '#DFF5D1';
//此处clickcolor只能用win系统颜色代码才能成功,如果用#xxxxxx的代码就不行,还没搞清楚为什么:(
var clickcolor = '#51b2f6';
function changeto() {
    source = event.srcElement;
    if (source.tagName == "TR" || source.tagName == "TABLE")
        return;
    while (source.tagName != "TD")
        source = source.parentElement;
    source = source.parentElement;
    cs = source.children;
    //alert(cs.length);
    if (cs[1].style.backgroundColor != highlightcolor && source.id != "nc")
        for (i = 0; i < cs.length; i++) {
        cs[i].style.backgroundColor = highlightcolor;
    }
}

function changeback() {
    cs = source.children;
    if (event.fromElement.contains(event.toElement) || source.contains(event.toElement) || source.id == "nc")
        return
    if (event.toElement != source)
    //source.style.backgroundColor=originalcolor
        for (i = 0; i < cs.length; i++) {
        cs[i].style.backgroundColor = "";
    }
}

//添加图片类别
function addimagestype() {
    var imagestype = escape($("itname").value);
    var url = "/WebServices/ManagerS.asmx/addimagestype";
    var parms = "{'simagestype':'" + imagestype + "'}";
    AjaxFunction(url, parms, "post", "josn", null, addimagestypestate, null, null, false);
}
function addimagestypestate(result) {
    if (result == "t") {
        boxs(1, "添加图片类别成功！");
    }
    else {
        boxs(1, "添加图片类别失败");
    }
}

//编辑图片类别
function edititname(itid, imagestype) {
    $("edititname").value = imagestype;
    $("edititid").value = itid;
    ShowPageDiv("editimagestype", 350, 200);
}

function editimagestype() {
    var itid = $("edititid").value;
    var imagestype = escape($("edititname").value);   
    var url = "/WebServices/ManagerS.asmx/editimagestype";
    var parms = "{'itid':'" + itid + "','simagestype':'" + imagestype + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editimagestypestate, null, null, false);
}
function editimagestypestate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1, "编辑图片类别成功！");
    }
    else {
        boxs(1, "编辑图片类别失败");
    }
}

//删除图片类别
function delimagestype(itid) {
    var url = "/WebServices/ManagerS.asmx/delimagestype";
    var parms = "{'itid':'" + itid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delimagestypestate, null, null, false);

}
function delimagestypestate(result) {
    if (result == "t") {
        boxs(1, "删除图片类别成功！");
    }
    else {
        boxs(1, "删除图片类别失败");
    }
}

//添加内容类别
function addwebsitetype() {
    if ($("wtname").value.length > 0) {
        var websitetype = escape($("wtname").value);
        var url = "/WebServices/ManagerS.asmx/addwebsitetype";
        var parms = "{'swebsitetype':'" + websitetype + "'}";
        AjaxFunction(url, parms, "post", "josn", null, websitetypestate, null, null, false);
    }
    else {
        boxs(1, "内容类别不能为空！");
    }
}
function websitetypestate(result) {
    if (result == "t") {
        boxs(1, "添加内容类别成功！");
    }
    else {
        boxs(1, "添加内容类别失败");
    }
}

//编辑内容类别
function editwtname(wtid, websitetype) {
    $("editwtname").value = websitetype;
    $("editwtid").value = wtid;
    ShowPageDiv("editimagestype", 350, 200);
}

function editwebsitetype() {
    var wtid = $("editwtid").value;
    var websitetype = escape($("editwtname").value);
    var url = "/WebServices/ManagerS.asmx/editwebsitetype";
    var parms = "{'wtid':'" + wtid + "','swebsitetype':'" + websitetype + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editwebsitetypestate, null, null, false);
}
function editwebsitetypestate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1, "编辑内容类别成功！");
    }
    else {
        boxs(1, "编辑内容类别失败");
    }
}

//删除内容类别
function delwebsitetype(wtid) {
    var url = "/WebServices/ManagerS.asmx/delwebsitetype";
        var parms = "{'wtid':'" + wtid + "'}";
        AjaxFunction(url, parms, "post", "josn", null, delwebsitetypestate, null, null, false);
   
}
function delwebsitetypestate(result) {
    if (result == "t") {
        boxs(1, "删除内容类别成功！");
    }
    else {
        boxs(1, "删除内容类别失败");
    }
}

//删除内容
function delwebsite(wsid) {
    var url = "/WebServices/ManagerS.asmx/delwebsite";
    var parms = "{'wsid':'" + wsid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delwebsitestate, null, null, false);

}
function delwebsitestate(result) {
    if (result == "t") {
        boxs(1, "删除内容成功！");
    }
    else {
        boxs(1, "删除内容失败");
    }
}

//添加新闻类别
function addnewstype() {
    var newstype = escape($("ntname").value);
    var url = "/WebServices/ManagerS.asmx/addnewstype";
    var parms = "{'s_newstype':'" + newstype + "'}";
    AjaxFunction(url, parms, "post", "josn", null, addnewstypestate, null, null, false);
}
function addnewstypestate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1, "添加新闻类别成功！");
    }
    else {
        boxs(1, "添加新闻类别失败");
    }
}
//编辑新闻类别
function editntname(ntid, newstype) {
    $("editntname").value = newstype;
    $("editntid").value = ntid;
    ShowPageDiv("editnewstype", 350, 200);
}

function editnewstype() {
    var ntid = $("editntid").value;
    var newstype = escape($("editntname").value);
    var url = "/WebServices/ManagerS.asmx/editnewstype";
    var parms = "{'ntid':'" + ntid + "','s_newstype':'" + newstype + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editnewstypestate, null, null, false);
}
function editnewstypestate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1, "编辑新闻类别成功！");
    }
    else {
        boxs(1, "编辑新闻类别失败");
    }
}

//删除新闻类别
function delnewstype(ntid) {
    var url = "/WebServices/ManagerS.asmx/delnewstype";
    var parms = "{'ntid':'" + ntid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delnewstypestate, null, null, false);

}
function delnewstypestate(result) {
    if (result == "t") {
        boxs(1, "删除新闻类别成功！");
    }
    else {
        boxs(1, "删除新闻类别失败");
    }
}

//删除新闻
function delnews(newsid,page) {
    var url = "/WebServices/ManagerS.asmx/delnews";
    var parms = "{'newsid':'" + newsid + "','page':'" + page + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delnewsstate, null, null, false);

}
function delnewsstate(result) {
    if (result != "f") {
        location.href = "/Manager/NewsList.aspx/?page=" + result;
    }
    else {
        boxs(1, "删除新闻失败");
    }
}

//添加网站内容
function addwebsite(wsc) {
    var index = document.getElementById("wtid").selectedIndex;
    var wtid = document.getElementById("wtid").options[index].value;
    var website = escape(wsc);
    var url = "/WebServices/ManagerS.asmx/addwebsite";
    var parms = "{'wtid':'" + wtid + "','s_website':'" + website + "'}";
    AjaxFunction(url, parms, "post", "josn", null, addwebsitestate, null, null, false);
}
function addwebsitestate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1, "添加网站内容成功！");
    }
    else {
        boxs(1, "添加网站内容失败");
    }
}
//编辑网站内容
function editwebsite(wsc) {  
    var wsid = document.getElementById("wsid").value;
    var website = escape(wsc);
    var url = "/WebServices/ManagerS.asmx/editwebsite";
    var parms = "{'s_website':'" + website + "','wsid':'" + wsid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editwebsitestate, null, null, false);
}
function editwebsitestate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1, "编辑网站内容成功！");
    }
    else {
        boxs(1, "编辑网站内容失败");
    }
}

//删除内容图片
function delwebimages(wiid,page) {
    var url = "/WebServices/ManagerS.asmx/delwebimages";
    var parms = "{'wiid':'" + wiid + "','page':'" + page + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delwebimagesstate, null, null, false);

}
function delwebimagesstate(result) {
    if (result != "f") {
        location.href = "/Manager/WebImages.aspx/?page=" + result;
    }
    else {
        boxs(1, "删除图片失败");
    }
}

//添加产品大类别
function addbigcategory() {
    var bigcategory = escape($("bcname").value);
    var url = "/WebServices/ManagerS.asmx/addbigcategory";
    var parms = "{'sbigcategory':'" + bigcategory + "'}";
    AjaxFunction(url, parms, "post", "josn", null, addbigcategorystate, null, null, false);
}
function addbigcategorystate(result) {
    if (result == "t") {
        boxs(1, "添加产品大类别成功！");
    }
    else {
        boxs(1, "添加产品大类别失败");
    }
}

//编辑产品大类别
function editbcname(bcid, bigcategory) {
    $("editbcname").value = bigcategory;
    $("editbcid").value = bcid;
    ShowPageDiv("editimagestype", 350, 200);
}

function editbigcategory() {
    var bcid = $("editbcid").value;
    var bigcategory = escape($("editbcname").value);
    var url = "/WebServices/ManagerS.asmx/editbigcategory";
    var parms = "{'bcid':'" + bcid + "','sbigcategory':'" + bigcategory + "'}";
    AjaxFunction(url, parms, "post", "josn", null, editbigcategorystate, null, null, false);
}
function editbigcategorystate(result) {
    if (result == "t") {
        HideMsg();
        boxs(1, "编辑产品大类别成功！");
    }
    else {
        boxs(1, "编辑产品大类别失败");
    }
}

//删除产品大类别
function delbigcategory(bcid) {
    var url = "/WebServices/ManagerS.asmx/delbigcategory";
    var parms = "{'bcid':'" + bcid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delbigcategorystate, null, null, false);

}
function delbigcategorystate(result) {
    if (result == "t") {
        boxs(1, "删除产品大类别成功！");
    }
    else {
        boxs(1, "删除产品大类别失败");
    }
}

//删除产品小类别
function delsmallcategory(scid) {
    var url = "/WebServices/ManagerS.asmx/delsmallcategory";
    var parms = "{'scid':'" + scid + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delsmallcategorystate, null, null, false);

}
function delsmallcategorystate(result) {
    if (result == "t") {
        boxs(1, "删除产品小类别成功！");
    }
    else {
        boxs(1, "删除产品小类别失败");
    }
}

//删除产品
function delproduct(productid,page) {
    var url = "/WebServices/ManagerS.asmx/delproduct";
    var parms = "{'productid':'" + productid + "','page':'" + page + "'}";
    AjaxFunction(url, parms, "post", "josn", null, delproductstate, null, null, false);

}
function delproductstate(result) {
    if (result != "f") {
        location.href = "/Manager/ProductList.aspx/?page=" + result;
    }
    else {
        boxs(1, "删除产品失败");
    }
}