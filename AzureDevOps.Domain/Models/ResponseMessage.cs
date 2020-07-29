using System;
using System.Collections.Generic;
using System.Text;

namespace AzureDevOps.Domain.Models
{
    public class ResponseMessage
    {
        public string ErrorCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Detail { get; set; }
    }
}
