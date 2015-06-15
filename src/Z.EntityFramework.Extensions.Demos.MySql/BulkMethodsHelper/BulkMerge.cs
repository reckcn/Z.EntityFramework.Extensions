// Copyright (c) 2015 ZZZ Projects. All rights reserved
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
using Z.EntityFramework.Extensions.Demos.MySqlServer.Model;

namespace Z.EntityFramework.Extensions.Demos.MySqlServer
{
    public partial class BulkMethodsHelper
    {
        public static void BulkMerge(int nbRecords, Stopwatch clock, StringBuilder sb)
        {
            int recordsToUpdate = nbRecords/2;
            int recordsToInsert = nbRecords - recordsToUpdate;

            var listToInsert = new List<EntitySimple>();

            for (int i = 0; i < recordsToInsert; i++)
            {
                listToInsert.Add(new EntitySimple {ColumnInt = i%5});
            }

            using (var ctx = new CodeFirstEntities())
            {
                ctx.EntitySimples.AddRange(listToInsert);

                List<EntitySimple> listToUpdate = ctx.EntitySimples.Take(recordsToUpdate).AsNoTracking().ToList();
                listToUpdate.ForEach(x => x.ColumnInt = x.ColumnInt + 1);

                sb.Append(string.Format("INSERT {0} / UPDATE {1} entities", recordsToInsert, recordsToUpdate));

                clock.Start();
                ctx.BulkMerge(listToUpdate);
                clock.Stop();
            }
        }
    }
}