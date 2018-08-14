using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OSharp.Entity;
using OSharp.Samples.MultipleDbContexts.Services.MySql.Entities;

namespace OSharp.Samples.MultipleDbContexts.Services.MySql
{
    public partial class MySqlService : ISqlServerContract
    {
        private readonly IServiceProvider _provider;

        public MySqlService(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IRepository<MySqlEntity, int> MySqlEntityRepository =>
            _provider.GetService<IRepository<MySqlEntity, int>>();
    }
}
