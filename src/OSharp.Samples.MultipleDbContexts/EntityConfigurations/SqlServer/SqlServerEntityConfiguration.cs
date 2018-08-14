using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSharp.Entity;
using OSharp.Samples.MultipleDbContexts.Entity;
using OSharp.Samples.MultipleDbContexts.Services.SqlServer.Entities;

namespace OSharp.Samples.MultipleDbContexts.EntityConfigurations.SqlServer
{
    public class SqlServerEntityConfiguration : EntityTypeConfigurationBase<SqlServerEntity, Guid>
    {
        public override Type DbContextType { get; } = typeof(SqlServerDbContext);

        public override void Configure(EntityTypeBuilder<SqlServerEntity> builder)
        {

        }
    }
}
