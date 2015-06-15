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