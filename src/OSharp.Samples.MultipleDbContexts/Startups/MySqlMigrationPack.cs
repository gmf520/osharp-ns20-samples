// -----------------------------------------------------------------------
//  <copyright file="MySqlDefaultDbContextMigrationPack.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-06-27 4:50</last-date>
// -----------------------------------------------------------------------

using System;
using OSharp.Entity;
using OSharp.Entity.MySql;
using OSharp.Samples.MultipleDbContexts.Entity;

namespace OSharp.Samples.MultipleDbContexts.Startups
{
    /// <summary>
    /// MySql迁移模块
    /// </summary>
    public class MySqlMigrationPack : MySqlMigrationModuleBase<MySqlDbContext>
    {
        /// <summary>
        /// 获取 模块启动顺序，模块启动的顺序先按级别启动，级别内部再按此顺序启动，
        /// 级别默认为0，表示无依赖，需要在同级别有依赖顺序的时候，再重写为>0的顺序值
        /// </summary>
        public override int Order => 2;

        protected override MySqlDbContext CreateDbContext(IServiceProvider scopedProvider)
        {
            return new MySqlDesignTimeDbContextFactory(scopedProvider).CreateDbContext(new string[0]);
        }
    }
}