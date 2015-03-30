// Copyright (c) 2015 ZZZ Projects. All rights reserved
// Licensed under MIT License (MIT) (https://github.com/zzzprojects/Z.EntityFramework.Extensions)
// Full Version: http://www.zzzprojects.com/entity-framework-extensions/
// Website: http://www.zzzprojects.com/
// Feedback / Feature Requests / Issues : http://zzzprojects.uservoice.com/forums/283924
// All ZZZ Projects products: Entity Framework Extensions / Bulk Operations / Extension Methods /Icon Library

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Z.EntityFramework.Extensions.Demos.SqlServer.Model;

namespace Z.EntityFramework.Extensions.Demos.SqlServer
{
    public partial class BulkSaveChangesHelper
    {
        public static void SaveChanges(int nbRecords, Stopwatch clock, StringBuilder sb)
        {
            using (var ctx = new CodeFirstEntities())
            {
                List<EntitySimple> list = ctx.EntitySimples.Take(nbRecords/2).ToList();
                int recordToUpdate = list.Count/2;
                int recordToDelete = list.Count - recordToUpdate;
                int recordToInsert = nbRecords - recordToUpdate - recordToDelete;

                // Insert
                {
                    var listToInsert = new List<EntitySimple>();

                    for (int i = 0; i < recordToInsert; i++)
                    {
                        listToInsert.Add(new EntitySimple {ColumnInt = i%5});
                    }
                    ctx.EntitySimples.AddRange(listToInsert);
                }

                // Update
                {
                    List<EntitySimple> listToUpdate = list.Take(recordToUpdate).ToList();
                    listToUpdate.ForEach(x => x.ColumnInt = x.ColumnInt + 1);
                }

                // Delete
                {
                    List<EntitySimple> listToDelete = list.Skip(recordToUpdate).ToList();
                    ctx.EntitySimples.RemoveRange(listToDelete);
                }

                sb.Append(string.Format("INSERT {0} / UPDATE {1} / DELETE {2} entities", recordToInsert, recordToUpdate, recordToDelete));

                clock.Start();
                ctx.SaveChanges();
                clock.Stop();
            }
        }
    }
}