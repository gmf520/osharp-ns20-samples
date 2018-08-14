using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OSharp.Entity;

namespace OSharp.Samples.MultipleDbContexts.Services.SqlServer.Dtos
{
    public class SqlServerEntityInputDto : IInputDto<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }

        public bool IsDeleted { get; set; }
    }
}
