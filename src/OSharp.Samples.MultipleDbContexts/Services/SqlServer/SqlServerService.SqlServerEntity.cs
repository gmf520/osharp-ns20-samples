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
    public partial class SqlServerService
    {
        public IQueryable<SqlServerEntity> SqlServerEntitys => SqlServerEntityRepository.Query();

        public Task<bool> CheckSqlServerEntityExists(Expression<Func<SqlServerEntity, bool>> predicate, Guid id = default(Guid))
        {
            return SqlServerEntityRepository.CheckExistsAsync(predicate, id);
        }

        public Task<OperationResult> CreateSqlServerEntitys(params SqlServerEntityInputDto[] dtos)
        {
            return SqlServerEntityRepository.InsertAsync(dtos);
        }

        public Task<OperationResult> UpdateSqlServerEntitys(params SqlServerEntityInputDto[] dtos)
        {
            return SqlServerEntityRepository.UpdateAsync(dtos);
        }

        public Task<OperationResult> DeleteSqlServerEntitys(params Guid[] ids)
        {
            return SqlServerEntityRepository.DeleteAsync(ids);
        }
    }
}
