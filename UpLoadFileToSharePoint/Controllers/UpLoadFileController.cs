using System;
using System.IO;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using UpLoadFileToSharePoint.Helper;
using UpLoadFileToSharePoint.Models;

namespace UpLoadFileToSharePoint.Controllers
{
    public class UpLoadFileController : ApiController
    {
        [Route("PostFile")]
        [HttpPost]
        public ResponseModel PostFile(string UserName, string Password,string SiteUrl,string DocumentLibrary,string CustomerFolder)
        {
            try
            {
                string res = "";
                if (HttpContext.Current.Request.Files.Count > 0)
                {
                    var httpRequest = HttpContext.Current.Request;
                    var httpPostedFile = System.Web.HttpContext.Current.Request.Files[0];
                    var fileSave = System.Web.HttpContext.Current.Server.MapPath("UploadedFiles");
                    if (!Directory.Exists(fileSave))
                    {
                        Directory.CreateDirectory(fileSave);
                    }
                    // tạo file lưu trữ tạm thời
                    var fileSavePath = Path.Combine(fileSave, httpPostedFile.FileName);
                    if (!System.IO.File.Exists(fileSavePath))
                    {    /*To save files at server*/
                        httpPostedFile.SaveAs(fileSavePath);
                        HttpResponse Response = System.Web.HttpContext.Current.Response;
                        Response.Clear();
                    }
            
                    string FileName = fileSavePath;
              

                    res = UpLoadFileToSharepointHelper.UploadFileToSharePoint(SiteUrl, DocumentLibrary, CustomerFolder,
                        FileName, UserName, Password);
                    //Xóa file giải phóng bộ nhớ
                    if (System.IO.File.Exists(fileSavePath))
                    {
                        System.IO.File.Delete(fileSavePath);
                    }

                }
                if (res == "") return new ResponseModel
                {
                    ErrorCode = ErrorCode.Success,
                    Content = ""
                };
                return new ResponseModel
                {
                    ErrorCode = ErrorCode.GeneralFailure,
                    Content = res
                };
            }
            catch (Exception ex)
            {

                return new ResponseModel
                {
                    ErrorCode = ErrorCode.GeneralFailure,
                    Content = ex.ToString()
                };
            }
        }
    }
}
