namespace Hoodie.Web.Utility
{
    public class StaticDetails
    {
        public static string CouponAPIBase { get; set; }

        public enum ApiTypeEnum { 
            GET,
            POST, 
            PUT, 
            DELETE
        }
    }
}
