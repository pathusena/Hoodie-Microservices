﻿namespace Hoodie.Web.Utility
{
    public class StaticDetails
    {
        public static string CouponAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }
        public const string RoleAdmin = "ADMIN";
        public const string RoleCustomer = "CUSTOMER";
        public enum ApiTypeEnum { 
            GET,
            POST, 
            PUT, 
            DELETE
        }
    }
}
