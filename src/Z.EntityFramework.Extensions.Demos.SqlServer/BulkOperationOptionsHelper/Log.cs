using System.Text;
using Z.EntityFramework.Extensions.Demos.SqlServer.Model;

namespace Z.EntityFramework.Extensions.Demos.SqlServer
{
    public partial class BulkMethodsHelper
    {
        public static void Log(int nbRecords, StringBuilder sb)
        {
            using (var ctx = new CodeFirstEntities())
            {
                DbHelper.SetDemoEntities(ctx, sb, nbRecords);

                // The log event is invoked every time a database event occurs.
                //  - A connection is opened
                //  - A command is executed
                //  - A SqlBulkCopy is executed
                ctx.BulkSaveChanges(operation => { operation.Log += s => sb.AppendLine(s); });
            }
        }
    }
}