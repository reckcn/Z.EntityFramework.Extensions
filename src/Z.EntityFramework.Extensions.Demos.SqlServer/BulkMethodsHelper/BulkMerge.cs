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
        public static void BulkMerge(int nbRecords, Stopwatch clock, StringBuilder sb)
        {
            var recordsToUpdate = nbRecords/2;
            var recordsToInsert = nbRecords - recordsToUpdate;

            var listToInsert = new List<EntitySimple>();

            for (var i = 0; i < recordsToInsert; i++)
            {
                listToInsert.Add(new EntitySimple {ColumnInt = i%5});
            }

            using (var ctx = new CodeFirstEntities())
            {
                ctx.EntitySimples.AddRange(listToInsert);

                var listToUpdate = ctx.EntitySimples.Take(recordsToUpdate).AsNoTracking().ToList();
                listToUpdate.ForEach(x => x.ColumnInt = x.ColumnInt + 1);

                var listToMerge = listToInsert.ToList();
                listToMerge.AddRange(listToUpdate);

                sb.Append(string.Format("INSERT {0} / UPDATE {1} entities", recordsToInsert, recordsToUpdate));

                clock.Start();
                ctx.BulkMerge(listToMerge);
                clock.Stop();
            }
        }
    }
}