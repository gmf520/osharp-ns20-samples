using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OSharp.Core.Packs;
using OSharp.Dependency;
using OSharp.Entity;
using OSharp.Entity.SqlServer;


namespace OSharp.Samples.MasterSlaveSplit.Startups
{
    /// <summary>
    /// SqlServer-DefaultDbContext数据迁移模块
    /// </summary>
    [DependsOnPacks(typeof(SqlServerEntityFrameworkCorePack))]
    public class SqlServerDefaultDbContextMigrationPack : MigrationPackBase<DefaultDbContext>
    {
        /// <summary>重写实现获取数据上下文实例</summary>
        /// <param name="scopedProvider">服务提供者</param>
        /// <returns></returns>
        protected override DefaultDbContext CreateDbContext(IServiceProvider scopedProvider)
        {
            return new DesignTimeDefaultDbContextFactory(scopedProvider).CreateDbContext(new string[0]);
        }

        /// <summary>获取 数据库类型</summary>
        protected override DatabaseType DatabaseType => DatabaseType.SqlServer;
    }
}
