using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Helper;
using Morrison.Models;
using System.Text;
//~5~1~a~~s~p~x
namespace WHMD
{
    public partial class AboutUS : System.Web.UI.Page
    {
        protected string hdHTML;
        protected string hd2HTML;
        protected string aboutusHTML;
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
               

                websitetypeinfo hitem = websitetype.getwebsiteinfobytype("关于我们");
                aboutusHTML = hitem.websitecontent;   
            }

        }
    }
}