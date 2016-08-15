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
    public partial class ProductInf : System.Web.UI.Page
    {
        protected string categorysbHTML;
        protected productinfo productinfoDATA;
        protected string productnameHTML;
        protected string topimgHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["productid"]==null)               
            {
                Response.Redirect("/ProductList.aspx");
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

            //产品类别
            List<categoryinfo> bigcategorylist = category.getbigcategory();
            StringBuilder categorysb = new StringBuilder();
            int bint = bigcategorylist.Count;
            for (int i = 0; i < bint; i++)
            {
                string btem = "<img src=\"/Files/WebImages/{0}\" alt=\"\" /><ul>";
                categorysb.AppendFormat(btem, bigcategorylist[i].bigcategoryimg);
                List<categoryinfo> smallcategorylist = category.getsmallcategorybyid(bigcategorylist[i].bigcategoryid);

                foreach (categoryinfo item1 in smallcategorylist)
                {
                    string template = " <li><a href=\"/ProductList.aspx/?smallcategoryid={0}\">{1}</a></li>";
                    categorysb.AppendFormat(template, item1.smallcategoryid, item1.smallcategory);
                }
                categorysb.Append("</ul>");
            }
           categorysbHTML = categorysb.ToString();

           productinfo data = product.getproductinfo(TypeParse.DbObjToInt(Request.QueryString["productid"].ToString(), 0));
           productinfoDATA = data;

           productnameHTML = data.productname;

        }
    }
}