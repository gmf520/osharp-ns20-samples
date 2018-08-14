using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSharp.Entity;
using OSharp.Samples.MultipleDbContexts.Entity;
using OSharp.Samples.MultipleDbContexts.Services.MySql.Entities;

namespace OSharp.Samples.MultipleDbContexts.EntityConfigurations.MySql
{
    public class MySqlEntityConfiguration : EntityTypeConfigurationBase<MySqlEntity, int>
    {
        public override Type DbContextType { get; } = typeof(MySqlDbContext);

        public override void Configure(EntityTypeBuilder<MySqlEntity> builder)
        {

        }
    }
}
