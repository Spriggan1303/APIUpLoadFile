using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpLoadFileToSharePoint.Helper;

namespace UpLoadFileToSharePoint.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //string SiteUrl = "https://itdvn.sharepoint.com/sites/iwater_test";
            //string DocumentLibrary = "Documents";
            //string FileName = @"D:\HinhAnh\a.jpg";
            //string CustomerFolder = "Subfolder";
            //string UserName = "danh.nguyen@itd.com.vn";
            //string Password = "01232308947Aa";
            //UpLoadFileToSharepointHelper.UploadFileToSharePoint(SiteUrl, DocumentLibrary, CustomerFolder, FileName, UserName, Password);
            return View();
        }
    }
}
