// Copyright (c) 2015 ZZZ Projects. All rights reserved
// Licensed under MIT License (MIT) (https://github.com/zzzprojects/Z.EntityFramework.Extensions)
// Full Version: http://www.zzzprojects.com/entity-framework-extensions/
// Website: http://www.zzzprojects.com/
// Feedback / Feature Requests / Issues : http://zzzprojects.uservoice.com/forums/283924
// All ZZZ Projects products: Entity Framework Extensions / Bulk Operations / Extension Methods /Icon Library

using System;
using System.Web;

namespace Z.EntityFramework.Extensions.Demos.MySqlServer.Model
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(My.Config.AppSettings.LicenseName))
            {
                LicenseManager.AddLicense(My.Config.AppSettings.LicenseName, My.Config.AppSettings.LicenseKey);
            }

            // DO a warmup call for JIT compilation
            using (var ctx = new CodeFirstEntities())
            {
                ctx.EntitySimples.Add(new EntitySimple {ColumnInt = 1});
                ctx.SaveChanges();

                ctx.EntitySimples.Add(new EntitySimple {ColumnInt = 1});
                ctx.BulkSaveChanges();
            }
        }
    }
}