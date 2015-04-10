// Copyright (c) 2015 ZZZ Projects. All rights reserved
// Licensed under MIT License (MIT) (https://github.com/zzzprojects/Z.EntityFramework.Extensions)
// Full Version: http://www.zzzprojects.com/entity-framework-extensions/
// Website: http://www.zzzprojects.com/
// Feedback / Feature Requests / Issues : http://zzzprojects.uservoice.com/forums/283924
// All ZZZ Projects products: Entity Framework Extensions / Bulk Operations / Extension Methods /Icon Library

using System.Configuration;

namespace Z.EntityFramework.Extensions.Demos.MySqlServer
{
    public class My
    {
        public static string ApplicationTable;

        public class Config
        {
            public class AppSettings
            {
                /// <summary>Name of the license.</summary>
                public static string LicenseName = ConfigurationManager.AppSettings["LicenseName"];

                /// <summary>The license key.</summary>
                public static string LicenseKey = ConfigurationManager.AppSettings["LicenseKey"];
            }

            public class ConnectionStrings
            {
                /// <summary>The SQL connection.</summary>
                public static string Demos = ConfigurationManager.ConnectionStrings["Demos"].ConnectionString;
            }
        }
    }
}