using System.Collections.Generic;
using System.Text;
using Z.BulkOperations;
using Z.EntityFramework.Extensions.Demos.SqlServer.Model;

namespace Z.EntityFramework.Extensions.Demos.SqlServer
{
    public partial class BulkMethodsHelper
    {
        public static List<AuditEntry> UseAudit(int nbRecords, StringBuilder sb)
        {
            using (var ctx = new CodeFirstEntities())
            {
                DbHelper.SetDemoEntities(ctx, sb, nbRecords);

                var auditEntries = new List<AuditEntry>();

                ctx.BulkSaveChanges(operation =>
                {
                    operation.UseAudit = true;

                    // Multiple bulk operations can be executed in a BulkSaveChanges event, the BulkOperationExecuted action
                    // will be invoked after each bulk operations.
                    //
                    // Audit entries contain information about:
                    // - Table
                    // - Operation
                    // - Date
                    // - Old Column Value
                    // - New Column Value
                    operation.BulkOperationExecuted += bulkOperation => auditEntries.AddRange(bulkOperation.AuditEntries);
                });

                return auditEntries;
            }
        }
    }
}