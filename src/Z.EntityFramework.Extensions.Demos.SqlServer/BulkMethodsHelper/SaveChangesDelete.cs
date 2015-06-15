using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Z.EntityFramework.Extensions.Demos.SqlServer.Model;

namespace Z.EntityFramework.Extensions.Demos.SqlServer
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