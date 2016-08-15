using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morrison.Models;
using Morrison.Helper;
using System.Text;

namespace WHMD.Manager
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected string productlistHTML;        
        protected string pageHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int page = 1;
                if (Request.QueryString["page"] != null)
                {
                    page = TypeParse.DbObjToInt(Request.QueryString["page"].ToString(), 1);
                }
                pageinfo pdata = new pageinfo();
                pdata.curpageindex = page;
                pdata.pagesize = 5;
                pdata.where = "smallcategory.smallcategoryid=product.smallcategoryid and bigcategory.bigcategoryid=smallcategory.bigcategoryid";
                pdata.recordcount = product.getproductcount();
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
                    string template = "<tr><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\" style=\"padding:5px 0;\"><img src=\"/Files/product/{0}\" style=\"width:120px;height:100px;\"/></div></td><td height=\"20\" bgcolor=\"#FFFFFF\" style=\"padding:0 0 0 5px;\"><div align=\"left\">{1}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\" style=\"padding:0 0 0 5px;\">{2}</div></td><td height=\"20\" bgcolor=\"#FFFFFF\"><div align=\"center\"><a href=\"/Manager/EditProduct.aspx/?productid={3}\" style=\"color:blue;cursor:pointer;\">编辑</a> | <a href=\"javascript:delproduct('{4}','{5}')\" style=\"color:blue;cursor:pointer;\">删除</a></div></td></tr>";
                    sb.AppendFormat(template, item.productimg, item.productname, item.productprice, item.productid, item.productid, pdata.curpageindex);
                }
                productlistHTML = sb.ToString();
                pageHTML = pagehelper.Pager(pdata.curpageindex, pdata.pagesize, pdata.recordcount, PageMode.Numeric, 5);
            }

        }
    }
}