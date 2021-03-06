﻿// Copyright (c) 2015 ZZZ Projects. All rights reserved
// Licensed under MIT License (MIT) (https://github.com/zzzprojects/Z.EntityFramework.Extensions)
// Full Version: http://www.zzzprojects.com/entity-framework-extensions/
// Website: http://www.zzzprojects.com/
// Feedback / Feature Requests / Issues : http://zzzprojects.uservoice.com/forums/283924
// All ZZZ Projects products: Entity Framework Extensions / Bulk Operations / Extension Methods /Icon Library

using System;
using MySql.Data.MySqlClient;

namespace Z.EntityFramework.Extensions.Demos.MySqlServer
{
    public static partial class DbHelper
    {
        public static Int64 GetRecordCount(string tableName)
        {
            using (var connection = new MySqlConnection(My.Config.ConnectionStrings.Demos))
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = string.Format("SELECT COUNT(1) FROM {0}", tableName);

                    connection.Open();

                    return Convert.ToInt64(command.ExecuteScalar());
                }
            }
        }
    }
}