using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OSharp.Entity;
using OSharp.Samples.MultipleDbContexts.Services.SqlServer.Entities;

namespace OSharp.Samples.MultipleDbContexts.Services.SqlServer
{
    public partial class SqlServerService : ISqlServerContract
    {
        private readonly IServiceProvider _provider;

        public SqlServerService(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IRepository<SqlServerEntity, Guid> SqlServerEntityRepository =>
            _provider.GetService<IRepository<SqlServerEntity, Guid>>();
    }
}
