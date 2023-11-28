using static Hoodie.Web.Utility.StaticDetails;

namespace Hoodie.Web.Models
{
    public class RequestDto
    {
        public ApiTypeEnum ApiType { get; set; } = ApiTypeEnum.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
