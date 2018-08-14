using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OSharp.Data;
using OSharp.Samples.MultipleDbContexts.Services.SqlServer.Dtos;
using OSharp.Samples.MultipleDbContexts.Services.SqlServer.Entities;

namespace OSharp.Samples.MultipleDbContexts.Services.SqlServer
{
    public interface ISqlServerContract
    {
        #region SqlServer实体信息业务

        /// <summary>
        /// 获取 SqlServer实体信息查询数据集
        /// </summary>
        IQueryable<SqlServerEntity> SqlServerEntitys { get; }

        /// <summary>
        /// 检查SqlServer实体信息信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的SqlServer实体信息编号</param>
        /// <returns>SqlServer实体信息是否存在</returns>
        Task<bool> CheckSqlServerEntityExists(Expression<Func<SqlServerEntity, bool>> predicate, Guid id = default(Guid));

        /// <summary>
        /// 添加SqlServer实体信息信息
        /// </summary>
        /// <param name="dtos">要添加的SqlServer实体信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> CreateSqlServerEntitys(params SqlServerEntityInputDto[] dtos);

        /// <summary>
        /// 更新SqlServer实体信息信息
        /// </summary>
        /// <param name="dtos">包含更新信息的SqlServer实体信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> UpdateSqlServerEntitys(params SqlServerEntityInputDto[] dtos);

        /// <summary>
        /// 删除SqlServer实体信息信息
        /// </summary>
        /// <param name="ids">要删除的SqlServer实体信息编号</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> DeleteSqlServerEntitys(params Guid[] ids);

        #endregion

    }
}
