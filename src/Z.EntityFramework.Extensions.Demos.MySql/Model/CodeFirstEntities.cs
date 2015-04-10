// Copyright (c) 2015 ZZZ Projects. All rights reserved
// Licensed under MIT License (MIT) (https://github.com/zzzprojects/Z.EntityFramework.Extensions)
// Full Version: http://www.zzzprojects.com/entity-framework-extensions/
// Website: http://www.zzzprojects.com/
// Feedback / Feature Requests / Issues : http://zzzprojects.uservoice.com/forums/283924
// All ZZZ Projects products: Entity Framework Extensions / Bulk Operations / Extension Methods /Icon Library

using System.Data.Entity;

namespace Z.EntityFramework.Extensions.Demos.MySqlServer.Model
{
    public class CodeFirstEntities : DbContext
    {
        public CodeFirstEntities()
            : base("Demos")
        {
        }


        public DbSet<EntitySimple> EntitySimples { get; set; }
    }
}