using System;
using System.Text;
using Z.EntityFramework.Extensions.Demos.SqlServer.Model;

namespace Z.EntityFramework.Extensions.Demos.SqlServer
{
    public partial class BulkMethodsHelper
    {
        public static void RetryInterval(int nbRecords, StringBuilder sb)
        {
            using (var ctx = new CodeFirstEntities())
            {
                DbHelper.SetDemoEntities(ctx, sb, nbRecords);

                ctx.BulkSaveChanges(operation =>
                {
                    operation.RetryCount = 3;

                    // RetryInterval property allows to wait X ms before retrying the operation when a transient error occurs.
                    // Transient error: https://msdn.microsoft.com/en-us/library/4cff491e-9359-4454-bd7c-fb72c4c452ca#bkmk_connection_errors
                    operation.RetryInterval = new TimeSpan(0, 0, 1);
                });
            }
        }
    }
}