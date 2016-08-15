using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;
using System.Text;

namespace WHMD
{
    public partial class NewsList : System.Web.UI.Page
    {
        protected string pageHTML;
        protected string cHTML;
        protected string newslistHTML;
        protected string topimgHTML;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
                    string template = " <li><a href=\"/NewsList.aspx/?ntid={0}\">{1}</a></li>";
                    itsb.AppendFormat(template, item.ntid, item.newstype);
                }
                cHTML = itsb.ToString();

                pageinfo pdata = new pageinfo();
                int page;
                if (Request.QueryString["page"] != null)
                {
                    page = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                }
                else
                {
                    page = 1;
                }

                pdata.curpageindex = page;
                pdata.pagesize = 10;


                if (Request.QueryString["ntid"] != null)
                {
                    string ntid = Request.QueryString["ntid"].ToString();
                    pdata.where = "news.ntid=newstype.ntid and news.ntid=" + ntid;
                    pdata.recordcount = news.getnewscountbycondition("news.ntid=" + ntid);
                }              
                else
                {
                    pdata.where = "news.ntid=newstype.ntid";
                    pdata.recordcount = news.getnewscount();
                }
               
                pdata.tablename = "news ,newstype";
                pdata.fieldlist = "news.newsid,news.newstitle,news.newswriter,news.newsfrom,news.newsnote,news.adddate,news.ntid,newstype.newstype,news.ninfo,news.istop,news.newsimg,news.userid";
                pdata.sorttype = 2;
                pdata.primarykey = "newsid";
                pdata.totalpagecount = (pdata.recordcount % pdata.pagesize == 0 ? pdata.recordcount / pdata.pagesize : pdata.recordcount / pdata.pagesize + 1);
                if (pdata.totalpagecount == 0)
                {
                    pdata.totalpagecount = 1;
                }

                List<newsinfo> newslist = news.getnews(pdata);

                StringBuilder sb = new StringBuilder();
                foreach (newsinfo item in newslist)
                {
                    string template = " <li><span class=\"rpoint\"></span><span class=\"fl\"><a href=\"/NewsInf.aspx/?newsid={0}\" target=\"_blank\">{1}</a></span><span class=\"fr f13\">{2}</span></li>";
                    sb.AppendFormat(template, item.newsid, item.newstitle, item.adddate);
                }
                newslistHTML = sb.ToString();
                pageHTML = pagehelper.Pager(pdata.curpageindex, pdata.pagesize, pdata.recordcount, PageMode.Numeric, 5);
            }

        }
    }
}