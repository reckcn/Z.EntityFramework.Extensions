// Copyright (c) 2015 ZZZ Projects. All rights reserved
// Licensed under MIT License (MIT) (https://github.com/zzzprojects/Z.EntityFramework.Extensions)
// Full Version: http://www.zzzprojects.com/entity-framework-extensions/
// Website: http://www.zzzprojects.com/
// Feedback / Feature Requests / Issues : http://zzzprojects.uservoice.com/forums/283924
// All ZZZ Projects products: Entity Framework Extensions / Bulk Operations / Extension Methods /Icon Library

using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Z.EntityFramework.Extensions.Demos.SqlServer.Model;

namespace Z.EntityFramework.Extensions.Demos.SqlServer
{
    public partial class BulkMethodsHelper
    {
        public static void BulkInsert(int nbRecords, Stopwatch clock, StringBuilder sb)
        {
            var list = new List<EntitySimple>();

            for (int i = 0; i < nbRecords; i++)
            {
                list.Add(new EntitySimple {ColumnInt = i%5});
            }

            using (var ctx = new CodeFirstEntities())
            {
                ctx.EntitySimples.AddRange(list);

                sb.Append(string.Format("INSERT {0} entities", list.Count));

                clock.Start();
                ctx.BulkInsert(list);
                clock.Stop();
            }
        }
    }
}