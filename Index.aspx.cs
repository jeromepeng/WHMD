using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Models;
using Morrison.Helper;
using System.Text;
//_来_自_5_1_a_s_p_x
namespace WHMD.Index
{
    public partial class Index : System.Web.UI.Page
    {
        protected string hd1HTML;
        protected string hd2HTML;       
        protected string pHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //幻灯大图片绑定
                List<webimagesinfo> webimageslist = webimages.bindwebimages(5, "幻灯大图");
                StringBuilder webimagessb = new StringBuilder();
                int bimgn = webimageslist.Count;
                for (int k = 0; k < bimgn; k++)
                {
                    string template;
                    if (k == 1)
                    {
                        template = "<li style=\"display: list-item;\" class=\"b active\"><a href=\"{0}\"><img src=\"/Files/WebImages/{1}\" alt=\"\" height=\"370\" width=\"880\"></a></li>";

                    }
                    else
                    {
                        template = "<li style=\"display: none;\" class=\"b\"><a href=\"{0}\"><img src=\"/Files/WebImages/{1}\" alt=\"\" height=\"370\" width=\"880\"></a></li>";
                    }
                    webimagessb.AppendFormat(template, webimageslist[k].imgurl, webimageslist[k].imgname);
                }
                hd1HTML = webimagessb.ToString();

                //幻灯小图片绑定
                List<webimagesinfo> webimageslist2 = webimages.bindwebimages(5, "幻灯小图");
                StringBuilder webimagessb2 = new StringBuilder();
                int simgn = webimageslist2.Count;
                for (int k = 0; k < simgn; k++)
                {
                    string template;
                    if (k == 1)
                    {
                        template = " <li class=\"active\"><a href=\"{0}\" rel=\"{1}\"><img src=\"/Files/WebImages/{2}\" alt=\"\" height=\"40\" width=\"40\"></a></li>";
                    }
                    else
                    {
                        template = " <li class=\"\"><a href=\"{0}\" rel=\"{1}\"><img src=\"/Files/WebImages/{2}\" alt=\"\" height=\"40\" width=\"40\"></a></li>";
                    }
                    webimagessb2.AppendFormat(template, webimageslist2[k].imgurl, k, webimageslist2[k].imgname);
                }
                hd2HTML = webimagessb2.ToString();

                //产品分类
                List<categoryinfo> clist = category.getbigcategory();
                StringBuilder psb = new StringBuilder();
                int nint = clist.Count;
                for (int i = 0; i < nint; i++)
                {
                    string btem = "<div class=\"product\"><div class=\"productdh\"><div class=\"productdh_left\"><a href=\"/ProductList.aspx/?bigcategoryid={0}\"><img src=\"/Files/WebImages/{1}\" alt=\"\" /></a></div><div class=\"productdh_right\"><a href=\"/ProductList.aspx/?bigcategoryid={2}\">更多产品</a></div></div><div class=\"productmain\">";
                    psb.AppendFormat(btem, clist[i].bigcategoryid, clist[i].bigcategoryimg, clist[i].bigcategoryid);
                    List<productinfo> list1 = index.getproductN(8, clist[i].bigcategoryid);

                    foreach (productinfo item1 in list1)
                    {
                        string template = "<div class=\"productli\"><a href=\"/ProductInf.aspx/?productid={0}\" target=\"_blank\" class=\"fh\"><img src=\"/Files/Product/{1}\" alt=\"\" /></a><a href=\"/ProductInf.aspx/?productid={2}\" title=\"{3}\" class=\"tl\" target=\"_blank\"><span class=\"tcolor\">{4}</span></a><a href=\"/ProductInf.aspx/?productid={5}\"  class=\"tl\" target=\"_blank\"><span>分类：</span>{6}</a><a href=\"/ProductInf.aspx/?productid={7}\"  class=\"tl\" target=\"_blank\"><span>规格：</span>{8}</a><a href=\"/ProductInf.aspx/?productid={9}\"  class=\"tl\" target=\"_blank\">价格：<span class=\"red\">￥{10}元</span></a></div>";
                        psb.AppendFormat(template, item1.productid, item1.productimg, item1.productid, item1.productname, comm.SubStr(item1.productname, 13), item1.productid, item1.bigcategory, item1.productid, item1.productsize, item1.productid, item1.productprice);
                    }
                    psb.Append("</div></div>");
                }
                pHTML = psb.ToString();
            }
                 
        }
    }
}