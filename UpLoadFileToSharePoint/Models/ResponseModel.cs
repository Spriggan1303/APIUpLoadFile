using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpLoadFileToSharePoint.Models
{
    public class ResponseModel
    {
        public ErrorCode ErrorCode { get; set; }
        public string Content { get; set; }
    }
    public enum ErrorCode
    {
        Success = 0,
        GeneralFailure = 1,
        NotFound = 2,
        Exists = 3,
        AlreadyPaid = 4,
        ExistsReceiptNo = 5
    }
}