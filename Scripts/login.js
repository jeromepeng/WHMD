//检验验证码
function checkadminvalidator() {
    var validator = $("txtCodeOp").value;
    var yzmcode = getCookie("yzmcode");
    if (validator.toLocaleLowerCase() == yzmcode.toLocaleLowerCase()) {       
        return true;
    }
    else {
        boxs(1, '您的验证码输入错误');      
        return false;
    }
}

//刷新验证码
function refreshValidator() {
    var rnum = parseInt(Math.floor(Math.random() * 10));
    $("validatorimg").innerHTML = "<img src=\"/Helper/Validator.aspx?vnum=5&rnum=" + rnum + " \" alt=\"点击获取新验证码\" style=\"cursor:pointer;\" onclick=\"refreshValidator()\" />";
}

//检测账号是否合法
function checkaccount() {
    var strAccount = $("txtLoginName").value;
    if (strAccount.length > 4 && strAccount.length < 13) {
        return true;
    }
    else {
        boxs(1,'请输入有效的账号');
        return false;
    }
}

//检测密码是否合法
function checkpwd() {
    var strpwd = $("txtLoginPass").value;
    if (strpwd.length > 4 && strpwd.length < 23) {       
        return true;
    }
    else {
        boxs(1,'密码请用5-22个字符或数字');       
        return false;
    }
}

//用户登录
function adminlogin() {
    if (checkaccount()) {
        if (checkpwd()) {
            if (checkadminvalidator()) {
                var strPwd = document.getElementById("txtLoginPass").value;
                var strAdminname = document.getElementById("txtLoginName").value;
                var url = "/WebServices/ManagerS.asmx/adminlogin";
                var parms = "{'pwd':'" + strPwd + "','adminname':'" + strAdminname + "'}";
                AjaxFunction(url, parms, "post", "josn", null, adminloginstate, null, null, false);
            }
        }
    }
}

function adminloginstate(result) {
    if (result == "t") {
        location.href = "/Manager/Index.aspx";
    }
    else {
        boxs(1, "登录失败,请检查管理员账户和密码");
    }
}

