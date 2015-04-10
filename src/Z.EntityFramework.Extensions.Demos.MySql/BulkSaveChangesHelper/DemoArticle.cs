// Copyright (c) 2015 ZZZ Projects. All rights reserved
// Licensed under MIT License (MIT) (https://github.com/zzzprojects/Z.EntityFramework.Extensions)
// Full Version: http://www.zzzprojects.com/entity-framework-extensions/
// Website: http://www.zzzprojects.com/
// Feedback / Feature Requests / Issues : http://zzzprojects.uservoice.com/forums/283924
// All ZZZ Projects products: Entity Framework Extensions / Bulk Operations / Extension Methods /Icon Library

using System.Diagnostics;
using System.Linq;
using System.Text;
using Z.BulkOperations;
using Z.EntityFramework.Extensions.Demos.MySqlServer.Model;

namespace Z.EntityFramework.Extensions.Demos.MySqlServer
{
    public partial class BulkSaveChangesHelper
    {
        public static void BulkSaveChanges2(int nbRecords, Stopwatch clock, StringBuilder sb)
        {
            BulkOperationManager.BulkOperationBuilder = operation => operation.BatchSize = 1000;
            using (var ctx = new CodeFirstEntities())
            {
                // Do any kind of change to your context!
                ctx.EntitySimples.ToList().ForEach(x => x.ColumnInt = x.ColumnInt + 1);

                // ctx.SaveChanges();
                ctx.BulkSaveChanges(operation => operation.BatchSize = 50); // Save 50x faster using BulkSaveChanges
            }
        }
    }
}