// Copyright (c) 2015 ZZZ Projects. All rights reserved
// Licensed under MIT License (MIT) (https://github.com/zzzprojects/Z.EntityFramework.Extensions)
// Full Version: http://www.zzzprojects.com/entity-framework-extensions/
// Website: http://www.zzzprojects.com/
// Feedback / Feature Requests / Issues : http://zzzprojects.uservoice.com/forums/283924
// All ZZZ Projects products: Entity Framework Extensions / Bulk Operations / Extension Methods /Icon Library

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Z.EntityFramework.Extensions.Demos.MySqlServer.Model;

namespace Z.EntityFramework.Extensions.Demos.MySqlServer
{
    public partial class BulkMethodsHelper
    {
        public static void SaveChangesDelete(int nbRecords, Stopwatch clock, StringBuilder sb)
        {
            using (var ctx = new CodeFirstEntities())
            {
                List<EntitySimple> list = ctx.EntitySimples.Take(nbRecords).ToList();
                ctx.EntitySimples.RemoveRange(list);

                sb.Append(string.Format("DELETE {0} entities", list.Count));

                clock.Start();
                ctx.SaveChanges();
                clock.Stop();
            }
        }
    }
}