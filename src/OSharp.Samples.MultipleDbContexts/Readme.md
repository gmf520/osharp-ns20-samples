# OSharpNS 多上下文示例(MySql与SqlServer并存)

## 数据上下文配置

数据上下文配置在节点`OSharp:DbContexts`中，下级节点为数据上下文的名称，如下的`SqlServerDbContext`和`MySqlDbContext`，其他节点说明如下：
* DbContextTypeName：数据上下文类型的全路径，包含所在程序集
* ConnectionString：数据库连接字符串
* DatabaseType：数据库类型，可行项为`SqlServer`,`MySql`，其他数据库类型尚未有支持
* LazyLoadingProxiesEnabled：是否启用延迟加载代理
* AuditEntityEnabled：数据库是否开启 数据实体审计功能
* AutoMigrationEnabled：是否开启自动迁移功能，如启用，系统启动时将查找未提交的迁移记录进行迁移

```
"OSharp": {
  "DbContexts": {
    "SqlServerDbContext": {
      "DbContextTypeName": "OSharp.Samples.MultipleDbContexts.Entity.SqlServerDbContext,OSharp.Samples.MultipleDbContexts",
      "ConnectionString": "Server=.;Database=osharpns.samples.multipledb-sqlserver;Trusted_Connection=True;MultipleActiveResultSets=true",
      "DatabaseType": "SqlServer",
      "LazyLoadingProxiesEnabled": true,
      "AuditEntityEnabled": true,
      "AutoMigrationEnabled": true
    },
    "MySqlDbContext": {
      "DbContextTypeName": "OSharp.Samples.MultipleDbContexts.Entity.MySqlDbContext,OSharp.Samples.MultipleDbContexts",
      "ConnectionString": "Server=127.0.0.1;UserId=root;Password=abcd123456;Database=osharpns.samples.multipledb-mysql;charset='utf8';Allow User Variables=True",
      "DatabaseType": "MySql",
      "LazyLoadingProxiesEnabled": true,
      "AuditEntityEnabled": true,
      "AutoMigrationEnabled": true
    }
  }
}
```

## 数据迁移

因有多个上下文存在，进行数据迁移命令时，要加上 `-context` 参数加以区分。效果如下：

```
PM> add-migration InitMySql -context "OSharp.Samples.MultipleDbContexts.Entity.MySqlDbContext"
entryAssemblyName: OSharp.Samples.MultipleDbContexts
To undo this action, use Remove-Migration.
PM> add-migration InitSqlServer -context "OSharp.Samples.MultipleDbContexts.Entity.SqlServerDbContext"
entryAssemblyName: OSharp.Samples.MultipleDbContexts
To undo this action, use Remove-Migration.
PM> 
```