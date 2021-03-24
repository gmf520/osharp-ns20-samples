using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using OSharp.Entity;


namespace OSharp.Samples.MasterSlaveSplit.Startups
{
    /// <summary>
    /// 设计时<see cref="DefaultDbContext"/>实例工厂
    /// </summary>
    public class DesignTimeDefaultDbContextFactory : DesignTimeDbContextFactoryBase<DefaultDbContext>
    {
        /// <summary>
        /// 初始化一个<see cref="T:OSharp.Entity.DesignTimeDbContextFactoryBase`1" />类型的新实例
        /// </summary>
        public DesignTimeDefaultDbContextFactory()
            : base(null)
        { }

        /// <summary>
        /// 初始化一个<see cref="T:OSharp.Entity.DesignTimeDbContextFactoryBase`1" />类型的新实例
        /// </summary>
        public DesignTimeDefaultDbContextFactory(IServiceProvider serviceProvider)
            : base(serviceProvider)
        { }

        /// <summary>创建设计时使用的ServiceProvider，主要用于执行 Add-Migration 功能</summary>
        /// <returns></returns>
        protected override IServiceProvider CreateDesignTimeServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider provider = services.BuildServiceProvider();
            return provider;
        }
    }
}
