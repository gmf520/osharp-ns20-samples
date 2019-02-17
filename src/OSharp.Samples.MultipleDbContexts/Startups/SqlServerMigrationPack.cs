// -----------------------------------------------------------------------
//  <copyright file="SqlServerDefaultDbContextMigrationPack.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-06-27 4:50</last-date>
// -----------------------------------------------------------------------

using System;
using OSharp.Entity;
using OSharp.Entity.SqlServer;
using OSharp.Samples.MultipleDbContexts.Entity;

namespace OSharp.Samples.MultipleDbContexts.Startups
{
    /// <summary>
    /// SqlServer迁移模块
    /// </summary>
    public class SqlServerMigrationPack : MigrationPackBase<SqlServerDbContext>
    {
        /// <summary>
        /// 获取 模块启动顺序，模块启动的顺序先按级别启动，级别内部再按此顺序启动，
        /// 级别默认为0，表示无依赖，需要在同级别有依赖顺序的时候，再重写为>0的顺序值
        /// </summary>
        public override int Order => 2;

        protected override SqlServerDbContext CreateDbContext(IServiceProvider scopedProvider)
        {
            return new SqlServerDesignTimeDbContextFactory(scopedProvider).CreateDbContext(new string[0]);
        }

        /// <summary>获取 数据库类型</summary>
        protected override DatabaseType DatabaseType { get; } = DatabaseType.SqlServer;
    }
}