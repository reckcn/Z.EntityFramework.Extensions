using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Z.EntityFramework.Extensions.Demos.SqlServer.Model;

namespace Z.EntityFramework.Extensions.Demos.SqlServer
{
    public partial class BulkMethodsHelper
    {
        public static void SaveChangesUpdate(int nbRecords, Stopwatch clock, StringBuilder sb)
        {
            using (var ctx = new CodeFirstEntities())
            {
                List<EntitySimple> list = ctx.EntitySimples.Take(nbRecords).ToList();
                list.ForEach(x => x.ColumnInt = x.ColumnInt + 1);

                sb.Append(string.Format("UPDATE {0} entities", list.Count));

                clock.Start();
                ctx.SaveChanges();
                clock.Stop();
            }
        }
    }
}