using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Models;
using Morrison.Helper;
using System.Text;
using System.Web.Routing;

namespace WHMD.WebContent
{
    public partial class Index : System.Web.UI.Page
    {
        protected string categorylistHTML;
        protected string ctitleHTML;
        protected string contentHTML;
        protected string bannerHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //网站内容目录
                List<websitetypeinfo> itlist = websitetype.getwebsitetype();
                StringBuilder itsb = new StringBuilder();
                foreach (websitetypeinfo item in itlist)
                {
                    string template = "<li><span class=\"newslipoint\"></span><a href=\"/WS/{0}\">{1}</a></li>";
                    itsb.AppendFormat(template, item.wtid, item.websitetype);
                }
                categorylistHTML = itsb.ToString();

                if (RouteData.Values["contenttype"] != null && RouteData.Values["contenttype"].ToString() != "")
                {
                    string k = RouteData.Values["contenttype"].ToString();
                    string wstype = "关于我们";
                    switch (k)
                    {
                        case "1":
                            wstype = "关于我们";
                            bannerHTML = "<a href=\"/Default\">首页</a><a href=\"/ProductShow\">产品展示</a><a href=\"/WS/3\">工程项目</a><a href=\"/NewsShow\">业内资讯</a><a href=\"/WS/1\"  style=\"color: Green\">关于我们</a><a href=\"/WS/3\">联系我们</a>";
                            break;                       
                        case "3":
                            wstype = "联系我们";
                            bannerHTML = "<a href=\"/Default\">首页</a><a href=\"/ProductShow\">产品展示</a><a href=\"/WS/3\">工程项目</a><a href=\"/NewsShow\">业内资讯</a><a href=\"/WS/1\">关于我们</a><a href=\"/WS/3\"  style=\"color: Green\">联系我们</a>";
                            break;
                        case "4":
                            wstype = "人才招聘";
                            bannerHTML = "<a href=\"/Default\">首页</a><a href=\"/ProductShow\">产品展示</a><a href=\"/WS/3\">工程项目</a><a href=\"/NewsShow\">业内资讯</a><a href=\"/WS/1\">关于我们</a><a href=\"/WS/3\"  style=\"color: Green\">联系我们</a>";
                            break;
                        default:
                            wstype = "关于我们";
                            bannerHTML = "<a href=\"/Default\">首页</a><a href=\"/ProductShow\">产品展示</a><a href=\"/WS/3\">工程项目</a><a href=\"/NewsShow\">业内资讯</a><a href=\"/WS/1\"  style=\"color: Green\">关于我们</a><a href=\"/WS/3\">联系我们</a>";
                            break;
                    }

                    websitetypeinfo item = websitetype.getwebsiteinfobytype(wstype);
                    ctitleHTML = "杰尔雅照明-" + item.websitetype;
                    contentHTML = item.websitecontent;
                }
                else
                {
                    string wstype = "关于我们";
                    websitetypeinfo item = websitetype.getwebsiteinfobytype(wstype);
                    ctitleHTML ="杰尔雅照明-"+ item.websitetype;
                    contentHTML = item.websitecontent;
                    bannerHTML = "<a href=\"/Default\">首页</a><a href=\"/ProductShow\">产品展示</a><a href=\"/WS/3\">工程项目</a><a href=\"/NewsShow\">业内资讯</a><a href=\"/WS/1\"  style=\"color: Green\">关于我们</a><a href=\"/WS/3\">联系我们</a>";
                }
            }

        }
    }
}