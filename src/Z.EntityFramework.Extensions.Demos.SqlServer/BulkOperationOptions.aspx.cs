using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.UI;
using Z.BulkOperations;

namespace Z.EntityFramework.Extensions.Demos.SqlServer
{
    public partial class BulkOperationOptions : Page
    {
        private readonly int NbRecords = 15;
        private readonly StringBuilder SbOperation = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Bulk Operation Options | Entity Framework Extensions Library";

            // Auditing
            {
                uiUseAudit.ServerClick += (o, args) =>
                {
                    var auditEntries = BulkMethodsHelper.UseAudit(NbRecords, SbOperation);

                    AppendEntries(auditEntries);
                    uiOutput.InnerText = SbOperation.ToString();

                    ShowSourceCode(@"BulkOperationOptionsHelper\UseAudit.cs");
                };
            }

            // Logging
            {
                uiLog.ServerClick += (o, args) =>
                {
                    BulkMethodsHelper.Log(NbRecords, SbOperation);

                    uiOutput.InnerText = SbOperation.ToString();

                    ShowSourceCode(@"BulkOperationOptionsHelper\Log.cs");
                };

                uiUseLogDump.ServerClick += (o, args) =>
                {
                    BulkMethodsHelper.UseLogDump(NbRecords, SbOperation);

                    uiOutput.InnerText = SbOperation.ToString();

                    ShowSourceCode(@"BulkOperationOptionsHelper\UseLogDump.cs");
                };
            }

            // Transient Error Handling
            {
                uiRetryCount.ServerClick += (o, args) =>
                {
                    BulkMethodsHelper.RetryCount(NbRecords, SbOperation);

                    uiOutput.InnerText = SbOperation.ToString();

                    ShowSourceCode(@"BulkOperationOptionsHelper\RetryCount.cs");
                };

                uiRetryInterval.ServerClick += (o, args) =>
                {
                    BulkMethodsHelper.RetryInterval(NbRecords, SbOperation);

                    uiOutput.InnerText = SbOperation.ToString();

                    ShowSourceCode(@"BulkOperationOptionsHelper\RetryInterval.cs");
                };
            }
        }

        private void ShowSourceCode(string path)
        {
            uiSourceCode.InnerHtml = File.ReadAllText(Server.MapPath(path));
        }

        private void AppendEntries(List<AuditEntry> auditEntries)
        {
            SbOperation.AppendLine();
            SbOperation.AppendLine("-- Audit Entries:");

            foreach (var auditEntry in auditEntries)
            {
                SbOperation.AppendLine("Table:" + auditEntry.TableName);
                SbOperation.AppendLine("Action: " + auditEntry.Action);
                SbOperation.AppendLine("Date: " + auditEntry.Date);
                SbOperation.AppendLine("Values:");
                foreach (var value in auditEntry.Values)
                {
                    SbOperation.AppendLine(string.Format("ColumnName: {0}; OldValue: {1}; NewValue: {2}", value.ColumnName, value.OldValue, value.NewValue));
                }

                SbOperation.AppendLine();
                SbOperation.AppendLine();
            }
        }
    }
}