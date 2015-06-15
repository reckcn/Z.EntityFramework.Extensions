using System.Collections.Generic;
using System.Text;
using Z.BulkOperations;
using Z.EntityFramework.Extensions.Demos.SqlServer.Model;

namespace Z.EntityFramework.Extensions.Demos.SqlServer
{
    public partial class BulkMethodsHelper
    {
        public static List<AuditEntry> UseLogDump(int nbRecords, StringBuilder sb)
        {
            using (var ctx = new CodeFirstEntities())
            {
                DbHelper.SetDemoEntities(ctx, sb, nbRecords);

                var auditEntries = new List<AuditEntry>();

                ctx.BulkSaveChanges(operation =>
                {
                    operation.UseLogDump = true;

                    // Multiple bulk operations can be executed in a BulkSaveChanges event, the BulkOperationExecuted action
                    // will be invoked after each bulk operations.
                    // 
                    // The log dump contains all database events.
                    //  - A connection is opened
                    //  - A command is executed
                    //  - A SqlBulkCopy is executed
                    operation.BulkOperationExecuted += bulkOperation => sb.AppendLine(bulkOperation.LogDump.ToString());
                });

                return auditEntries;
            }
        }
    }
}