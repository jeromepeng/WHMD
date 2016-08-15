using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Morrison.Models;
using Morrison.Helper;
//|5|1|a|s|p|x
namespace WHMD.WebServices
{
    /// <summary>
    /// ManagerS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class ManagerS : System.Web.Services.WebService
    {
        #region 管理员

        #region 管理员登录

        [WebMethod]
        public string adminlogin(string pwd, string adminname)
        {
            string md5pwd = TextEncrypt.EncryptPassword(pwd);
            bool result = admin.VLogin(adminname,md5pwd);
            if (result)
            {
                int uid = admin.getAdminID(adminname);
                HttpCookie uidcookie = new HttpCookie("g_adminid");
                uidcookie.Value = uid.ToString();
                HttpContext.Current.Response.Cookies.Add(uidcookie);
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 检查管理员账户是否存在

        [WebMethod]
        public string checkadminname(string adminname)
        {
            bool result = admin.checkadminname(adminname);
            if (result)
            {
                return "f";
            }
            else
            {
                return "t";
            }
        }

        #endregion

        #region 添加新管理员

        [WebMethod]
        public string addadmin(string pwd, string adminname)
        {

            admininfo data = new admininfo();
            data.adminname = adminname;
            data.adminpwd = TextEncrypt.EncryptPassword(pwd);
            data.adddate = DateTime.Now;
            data.updatedate = DateTime.Now;
            data.roleid = 0;
            bool result = admin.AddNewAdmin(data);
            if (result)
            {                
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 修改管理员密码

        [WebMethod]
        public string editadminpwd(string newpwd, string adminid)
        {

            admininfo data = new admininfo();
            data.adminid = TypeParse.DbObjToInt(adminid,0);
            data.adminpwd = TextEncrypt.EncryptPassword(newpwd);           
            data.updatedate = DateTime.Now;
            bool result = admin.updatepwd(data);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 删除管理员

        [WebMethod]
        public string deladmin( string adminid)
        {           
            bool result = admin.delSysAdminyid(adminid);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #endregion

        #region 网站内容

        #region 添加内容类别

        [WebMethod]
        public string addwebsitetype(string swebsitetype)
        {
            string strit = HttpUtility.UrlDecode(TypeParse.DbObjToString(swebsitetype, ""));
            websitetypeinfo data = new websitetypeinfo();
            data.websitetype = strit;
            bool result = websitetype.addwebsitetype(data);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 删除内容类别

        [WebMethod]
        public string delwebsitetype(string wtid)
        {
            int id = TypeParse.DbObjToInt(wtid, 0);
            bool result = websitetype.delwebsitetype(id);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 编辑内容类别

        [WebMethod]
        public string editwebsitetype(string wtid, string swebsitetype)
        {

            websitetypeinfo data = new websitetypeinfo();
            data.websitetype = HttpUtility.UrlDecode(TypeParse.DbObjToString(swebsitetype, ""));
            data.wtid = TypeParse.DbObjToInt(wtid, 0);
            bool result = websitetype.editwebsitetype(data);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 添加网站内容

        [WebMethod]
        public string addwebsite(string s_website,string wtid)
        {
            string strit = HttpUtility.UrlDecode(TypeParse.DbObjToString(s_website, ""));
            websitetypeinfo data = new websitetypeinfo();
            data.websitecontent = strit;
            data.wtid = TypeParse.DbObjToInt(wtid, 0);
            bool result = websitetype.addwebsite(data);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 编辑网站内容

        [WebMethod]
        public string editwebsite(string s_website, string wsid)
        {
            string strit = HttpUtility.UrlDecode(TypeParse.DbObjToString(s_website, ""));
            websitetypeinfo data = new websitetypeinfo();
            data.websitecontent = strit;            
            data.wsid = TypeParse.DbObjToInt(wsid, 0);
            bool result = websitetype.editwebsite(data);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 删除内容

        [WebMethod]
        public string delwebsite(string wsid)
        {
            int id = TypeParse.DbObjToInt(wsid, 0);
            bool result = websitetype.delwebsite(id);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #endregion

        #region 网站图片

        #region 添加图片类别

        [WebMethod]
        public string addimagestype(string simagestype)
        {
            string strit = HttpUtility.UrlDecode(TypeParse.DbObjToString(simagestype, ""));
            webimagesinfo data = new webimagesinfo();
            data.imagestype = strit;
            bool result = webimages.addimagestype(data);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 删除图片类别

        [WebMethod]
        public string delimagestype(string itid)
        {
            int id = TypeParse.DbObjToInt(itid, 0);
            bool result = webimages.delimagestype(id);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 编辑图片类别

        [WebMethod]
        public string editimagestype(string itid, string simagestype)
        {

            webimagesinfo data = new webimagesinfo();
            data.imagestype = HttpUtility.UrlDecode(TypeParse.DbObjToString(simagestype, ""));
            data.itid = TypeParse.DbObjToInt(itid, 0);
            bool result = webimages.editimagestype(data);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 删除图片

        [WebMethod]
        public string delwebimages(string wiid,string page)
        {
            int id = TypeParse.DbObjToInt(wiid, 0);
            bool result = webimages.delwebimages(id);
            if (result)
            {
                return page;
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #endregion

        #region 新闻

        #region 添加新闻类别

        [WebMethod]
        public string addnewstype(string s_newstype)
        {
            string strit = HttpUtility.UrlDecode(TypeParse.DbObjToString(s_newstype, ""));
            newsinfo data = new newsinfo();
            data.newstype = strit;
            bool result = news.addnewstype(data);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 删除新闻类别

        [WebMethod]
        public string delnewstype(string ntid)
        {
            int id = TypeParse.DbObjToInt(ntid, 0);
            bool result = news.delnewstype(id);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 编辑新闻类别

        [WebMethod]
        public string editnewstype(string ntid, string s_newstype)
        {

            newsinfo data = new newsinfo();
            data.newstype = HttpUtility.UrlDecode(TypeParse.DbObjToString(s_newstype, ""));
            data.ntid = TypeParse.DbObjToInt(ntid, 0);
            bool result = news.editnewstype(data);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion       

        #region 删除新闻

        [WebMethod]
        public string delnews(string newsid,string page)
        {
            int id = TypeParse.DbObjToInt(newsid, 0);
            bool result = news.delnews(id.ToString());
            if (result)
            {
                return page;
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #endregion

        #region 产品大类别

        #region 添加产品大类别

        [WebMethod]
        public string addbigcategory(string sbigcategory)
        {
            string strbc = HttpUtility.UrlDecode(TypeParse.DbObjToString(sbigcategory, ""));
            categoryinfo data = new categoryinfo();
            data.bigcategory = strbc;
            bool result = category.addbigcategory(data);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 删除产品大类别

        [WebMethod]
        public string delbigcategory(string bcid)
        {
            int id = TypeParse.DbObjToInt(bcid, 0);
            bool result = category.delbigcategory(id);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 编辑产品大类别

        [WebMethod]
        public string editbigcategory(string bcid, string sbigcategory)
        {

            categoryinfo data = new categoryinfo();
            data.bigcategory = HttpUtility.UrlDecode(TypeParse.DbObjToString(sbigcategory, ""));
            data.bigcategoryid = TypeParse.DbObjToInt(bcid, 0);
            bool result = category.editbigcategory(data);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion     

        #region 删除产品小类别

        [WebMethod]
        public string delsmallcategory(string scid)
        {
            int id = TypeParse.DbObjToInt(scid, 0);
            bool result = category.delsmallcategory(id);
            if (result)
            {
                return "t";
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #region 删除产品

        [WebMethod]
        public string delproduct(string productid,string page)
        {
            int id = TypeParse.DbObjToInt(productid, 0);
            bool result = product.delproduct(id);
            if (result)
            {
                return page;
            }
            else
            {
                return "f";
            }
        }

        #endregion

        #endregion
    }
}
