// Copyright (c) 2015 ZZZ Projects. All rights reserved
// Licensed under MIT License (MIT) (https://github.com/zzzprojects/Z.EntityFramework.Extensions)
// Full Version: http://www.zzzprojects.com/entity-framework-extensions/
// Website: http://www.zzzprojects.com/
// Feedback / Feature Requests / Issues : http://zzzprojects.uservoice.com/forums/283924
// All ZZZ Projects products: Entity Framework Extensions / Bulk Operations / Extension Methods /Icon Library

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Z.EntityFramework.Extensions.Demos.SqlServer.Model;

namespace Z.EntityFramework.Extensions.Demos.SqlServer
{
    public static partial class DbHelper
    {
        public static void SetDemoEntities(CodeFirstEntities ctx, StringBuilder sb, int nbRecords)
        {
            var recordsToUpdate = nbRecords/2;
            var recordsToInsert = nbRecords - recordsToUpdate;

            var listToInsert = new List<EntitySimple>();

            for (var i = 0; i < recordsToInsert; i++)
            {
                listToInsert.Add(new EntitySimple {ColumnInt = i%5});
            }

            ctx.EntitySimples.AddRange(listToInsert);

            var listToUpdate = ctx.EntitySimples.Take(recordsToUpdate).ToList();
            listToUpdate.ForEach(x => x.ColumnInt = x.ColumnInt + 1);

            var listToMerge = listToInsert.ToList();
            listToMerge.AddRange(listToUpdate);

            sb.Append(string.Format("INSERT {0} / UPDATE {1} entities", recordsToInsert, recordsToUpdate));
        }
    }
}