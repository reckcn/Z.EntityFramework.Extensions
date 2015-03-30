﻿// Copyright (c) 2015 ZZZ Projects. All rights reserved
// Licensed under MIT License (MIT) (https://github.com/zzzprojects/Z.EntityFramework.Extensions)
// Full Version: http://www.zzzprojects.com/entity-framework-extensions/
// Website: http://www.zzzprojects.com/
// Feedback / Feature Requests / Issues : http://zzzprojects.uservoice.com/forums/283924
// All ZZZ Projects products: Entity Framework Extensions / Bulk Operations / Extension Methods /Icon Library

using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Z.EntityFramework.Extensions.Demos.SqlServer.Model;

namespace Z.EntityFramework.Extensions.Demos.SqlServer
{
    public partial class BulkMethodsHelper
    {
        public static void BulkUpdate(int nbRecords, Stopwatch clock, StringBuilder sb)
        {
            using (var ctx = new CodeFirstEntities())
            {
                List<EntitySimple> list = ctx.EntitySimples.Take(nbRecords).AsNoTracking().ToList();
                list.ForEach(x => x.ColumnInt = x.ColumnInt + 1);

                sb.Append(string.Format("UPDATE {0} entities", list.Count));

                clock.Start();
                ctx.BulkUpdate(list);
                clock.Stop();
            }
        }
    }
}