# OSharpNS 多上下文示例(MySql与SqlServer并存)

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