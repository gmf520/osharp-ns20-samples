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
    public partial class MySqlService
    {
        public IQueryable<MySqlEntity> MySqlEntitys => MySqlEntityRepository.Query();

        public Task<bool> CheckMySqlEntityExists(Expression<Func<MySqlEntity, bool>> predicate, int id = 0)
        {
            return MySqlEntityRepository.CheckExistsAsync(predicate, id);
        }

        public Task<OperationResult> CreateMySqlEntitys(params MySqlEntityInputDto[] dtos)
        {
            return MySqlEntityRepository.InsertAsync(dtos);
        }

        public Task<OperationResult> UpdateMySqlEntitys(params MySqlEntityInputDto[] dtos)
        {
            return MySqlEntityRepository.UpdateAsync(dtos);
        }

        public Task<OperationResult> DeleteMySqlEntitys(params int[] ids)
        {
            return MySqlEntityRepository.DeleteAsync(ids);
        }
    }
}
