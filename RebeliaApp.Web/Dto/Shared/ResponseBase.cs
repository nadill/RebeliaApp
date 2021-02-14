using System;
using static RebeliaApp.Web.Model.Enums;

namespace RebeliaApp.Web.Dto.Shared
{
    public abstract class ResponseBase
    {
        public ResponseCode ResponseCode { get; set; }
        public bool Success { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }
    }
}
