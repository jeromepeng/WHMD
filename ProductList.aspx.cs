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
namespace WHMD
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected string categorysbHTML;
        protected string dhcategoryHTML;
        protected string productlistHTML;
        protected string PageHTML;
        protected string topimgHTML;

        protected void Page_Load(object sender, EventArgs e)
        {
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

            //图片绑定
            List<webimagesinfo> webimageslist = webimages.bindwebimages(1, "顶部图片");
            StringBuilder webimagessb = new StringBuilder();
            foreach (webimagesinfo item in webimageslist)
            {
                string template = "<a href=\"{0}\" target=\"_blank\"><img src=\"/Files/WebImages/{1}\" alt=\"\" target=\"_blank\"/></a>";
                webimagessb.AppendFormat(template, item.imgurl, item.imgname);
            }
            topimgHTML = webimagessb.ToString();

            //产品列表
            int page = 1;
            if (Request.QueryString["page"] != null)
            {
                page = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
            }
            pageinfo pdata = new pageinfo();
            pdata.curpageindex = page;
            pdata.pagesize = 12;
            if (Request.QueryString["bigcategoryid"] != null)
            {
                string bcid = Request.QueryString["bigcategoryid"].ToString();
                pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid and product.bigcategoryid=" + bcid;
                pdata.recordcount = product.getproductcountbycondition("product.bigcategoryid=" + bcid);
                categoryinfo item = category.getbigcategoryinfo(TypeParse.DbObjToInt(bcid, 0));
                dhcategoryHTML = item.bigcategory;
            }
            else if (Request.QueryString["smallcategoryid"] != null)
            {
                string scid = Request.QueryString["smallcategoryid"].ToString();
                pdata.where = "product.smallcategoryid=smallcategory.smallcategoryid and smallcategory.bigcategoryid=bigcategory.bigcategoryid  and smallcategory.smallcategoryid=" + TypeParse.DbObjToInt(scid, 0);
                pdata.recordcount = product.getproductcountbycondition("product.smallcategoryid=" + scid);
                categoryinfo item = category.getsmallcategoryinfo(TypeParse.DbObjToInt(scid,0));
                dhcategoryHTML = item.smallcategory;

            }
            else
            {
                pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid";
                pdata.recordcount = product.getproductcount();
                dhcategoryHTML = "所有类别";
            }
           
            pdata.tablename = "smallcategory,product,bigcategory";
            pdata.fieldlist = "product.productid,product.productname,product.productprice,product.productcode,product.productbrief,product.productintroduce,product.vipprice,product.productimg,product.smallcategoryid,product.bigcategoryid,smallcategory.smallcategory,bigcategory.bigcategory,product.productsize,product.productcolor";
            pdata.sorttype = 2;
            pdata.primarykey = "productid";
            pdata.totalpagecount = (pdata.recordcount % pdata.pagesize == 0 ? pdata.recordcount / pdata.pagesize : pdata.recordcount / pdata.pagesize + 1);
            if (pdata.totalpagecount == 0)
            {
                pdata.totalpagecount = 1;
            }

            List<productinfo> list = product.getproduct(pdata);
            StringBuilder sb = new StringBuilder();
            foreach (productinfo item in list)
            {
                string producttemplate = "<div class=\"pli\"><a href=\"/ProductInf.aspx/?productid={0}\" target=\"_blank\" class=\"fh\"><img src=\"/Files/Product/{1}\" alt=\"\" /></a><a href=\"/ProductInf.aspx/?productid={2}\" title=\"{3}\"  class=\"tl\" target=\"_blank\"><span class=\"tcolor\">{4}</span></a><a href=\"/ProductInf.aspx/?productid={5}\"  class=\"tl\" target=\"_blank\"><span class=\"fb\">颜色：</span>{6}</a><a href=\"/ProductInf.aspx/?productid={7}\"  class=\"tl\" target=\"_blank\"><span class=\"fb\">尺寸：</span>{8}</a><a href=\"/ProductInf.aspx/?productid={9}\"  class=\"tl\" target=\"_blank\"><span class=\"red\">￥：{10}元</span></a></div> ";
                sb.AppendFormat(producttemplate, item.productid, item.productimg, item.productid, item.productname, comm.SubStr(item.productname, 12), item.productid, item.productcolor, item.productid, item.pagesize, item.productid, item.productprice);
            }
            productlistHTML = sb.ToString();
            PageHTML = pagehelper.Pager(pdata.curpageindex, pdata.pagesize, pdata.recordcount, PageMode.Numeric, 5);

        }
    }
}