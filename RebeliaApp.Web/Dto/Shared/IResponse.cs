using System;
using static RebeliaApp.Web.Model.Enums;

namespace RebeliaApp.Web.Dto.Shared
{
    public abstract class ResponseBase
    {
        public RESPONSE_CODE ResponseCode { get; set; }
        public string Message { get; set; }
    }
}
