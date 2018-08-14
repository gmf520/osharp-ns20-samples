using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OSharp.Data;
using OSharp.Samples.MultipleDbContexts.Services.MySql.Dtos;
using OSharp.Samples.MultipleDbContexts.Services.MySql.Entities;

namespace OSharp.Samples.MultipleDbContexts.Services.MySql
{
    public interface ISqlServerContract
    {
        #region MySql实体信息业务

        /// <summary>
        /// 获取 MySql实体信息查询数据集
        /// </summary>
        IQueryable<MySqlEntity> MySqlEntitys { get; }

        /// <summary>
        /// 检查MySql实体信息信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的MySql实体信息编号</param>
        /// <returns>MySql实体信息是否存在</returns>
        Task<bool> CheckMySqlEntityExists(Expression<Func<MySqlEntity, bool>> predicate, int id = 0);

        /// <summary>
        /// 添加MySql实体信息信息
        /// </summary>
        /// <param name="dtos">要添加的MySql实体信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> CreateMySqlEntitys(params MySqlEntityInputDto[] dtos);

        /// <summary>
        /// 更新MySql实体信息信息
        /// </summary>
        /// <param name="dtos">包含更新信息的MySql实体信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> UpdateMySqlEntitys(params MySqlEntityInputDto[] dtos);

        /// <summary>
        /// 删除MySql实体信息信息
        /// </summary>
        /// <param name="ids">要删除的MySql实体信息编号</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> DeleteMySqlEntitys(params int[] ids);

        #endregion

    }
}
