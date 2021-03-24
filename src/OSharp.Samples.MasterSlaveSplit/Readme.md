# 主从分离示例

## 示例创建

### 新建项目，引入nuget

新建 `ASP.NET Core 空` 项目，引入 nuget 包如下

```
  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="5.0.4">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="OSharpNS.AspNetCore" Version="5.0.4" />
    <PackageReference Include="OSharpNS.AutoMapper" Version="5.0.4" />
    <PackageReference Include="OSharpNS.EntityFrameworkCore.SqlServer" Version="5.0.4" />
    <PackageReference Include="OSharpNS.Log4Net" Version="5.0.4" />
  </ItemGroup>
```

### 添加迁移模块

在项目中添加如下两个类，用于上下文`DefaultDbContext`的数据迁移

```c#
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
```

```c#
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
```

启动类Startup中，添加需要的Osharp Pack

```c#
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOSharp()
                .AddPack<Log4NetPack>()
                .AddPack<AutoMapperPack>()
                .AddPack<MvcPack>()
                .AddPack<EntityInfoPack>()
                .AddPack<EndpointsPack>()
                .AddPack<SqlServerDefaultDbContextMigrationPack>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles()
                .UseStaticFiles()
                .UseOSharp();
        }
    }
```

### 在appsetting.json中进行数据访问配置

```json
  "OSharp": {
    "DbContexts": {
      "SqlServer": {
        "DbContextTypeName": "OSharp.Entity.DefaultDbContext,OSharp.EntityFrameworkCore",
        "ConnectionString": "Server=localhost;Database=osharpns-samples.split-master;User Id=sa;Password=********;MultipleActiveResultSets=true",
        "Slaves": [
          {
            "Name": "Slave01",
            "Weight": 2,
            "ConnectionString": "Server=localhost;Database=osharpns-samples.split-slave1;User Id=sa;Password=********;MultipleActiveResultSets=true"
          },
          {
            "Name": "Slave02",
            "Weight": 5,
            "ConnectionString": "Server=localhost;Database=osharpns-samples.split-slave2;User Id=sa;Password=********;MultipleActiveResultSets=true"
          }
        ],
        "SlaveSelectorName": "Weight",
        "DatabaseType": "SqlServer",
        "AuditEntityEnabled": true,
        "AutoMigrationEnabled": true
      }
    }
    ... 其他配置
  }
```

### 执行数据库迁移，生成主数据库

在VS的程序包管理器控制台逐条执行如下命令（前提是要引用`Microsoft.EntityFrameworkCore.Tools`）

```
add-migration Init
update-database
```

输出如下

```
PM> add-migration Init
Build started...
Build succeeded.
MigrationAssembly: OSharp.Samples.MasterSlaveSplit
To undo this action, use Remove-Migration.
PM> update-database
Build started...
Build succeeded.
MigrationAssembly: OSharp.Samples.MasterSlaveSplit
Applying migration '20210324045358_Init'.
Done.
PM> 
```

没有出错的话，将自动创建主数据库`osharpns-samples.split-master`

![](https://gitee.com/i66soft/blog-media/raw/master/osharp/20210324130228.png)

### 数据库主从配置

分别创建名称为`osharpns-samples.split-slave1`，`osharpns-samples.split-slave2`的两个空数据库

![image-20210324131223894](https://gitee.com/i66soft/blog-media/raw/master/osharp/image-20210324131223894.png)

数据库主从复制配置略过，参考：https://www.jianshu.com/p/983cee503e6c

