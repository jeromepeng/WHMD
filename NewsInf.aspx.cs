using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Morrison.Models;
using Morrison.Helper;

namespace WHMD
{
    public partial class NewsInf : System.Web.UI.Page
    {
        protected string cHTML;
        protected string ntitleHTML;
        protected newsinfo ninfoDATA;
        protected string topimgHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                 if (Request.QueryString["newsid"] == null)
            {
                Response.Redirect("/NewsList.aspx");
            }
                 //图片绑定
                 List<webimagesinfo> webimageslist = webimages.bindwebimages(1, "顶部图片");
                 StringBuilder webimagessb = new StringBuilder();
                 foreach (webimagesinfo item in webimageslist)
                 {
                     string template = "<a href=\"{0}\" target=\"_blank\"><img src=\"/Files/WebImages/{1}\" alt=\"\" target=\"_blank\"/></a>";
                     webimagessb.AppendFormat(template, item.imgurl, item.imgname);
                 }
                 topimgHTML = webimagessb.ToString();

            //资讯类型
            List<newsinfo> itlist = news.getnewstype();
            StringBuilder itsb = new StringBuilder();
            foreach (newsinfo item in itlist)
            {
                string template = " <li><a href=\"/Index/NewsList/?ntid={0}\">{1}</a></li>";
                itsb.AppendFormat(template, item.ntid, item.newstype);
            }
            cHTML = itsb.ToString();
            string newsid = Request.QueryString["newsid"].ToString();
            newsinfo ninfo = news.getnewsinfo(newsid);
            ninfoDATA = ninfo;
            ntitleHTML = ninfo.newstitle;
            }
        }
    }
}