using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OSharp.Entity;
using OSharp.Mapping;
using OSharp.Samples.MultipleDbContexts.Services.SqlServer.Entities;

namespace OSharp.Samples.MultipleDbContexts.Services.SqlServer.Dtos
{
    [MapFrom(typeof(SqlServerEntity))]
    public class SqlServerEntityOutputDto : IOutputDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
