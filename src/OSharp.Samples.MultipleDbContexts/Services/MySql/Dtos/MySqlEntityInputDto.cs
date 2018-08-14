using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OSharp.Entity;
using OSharp.Mapping;
using OSharp.Samples.MultipleDbContexts.Services.MySql.Entities;

namespace OSharp.Samples.MultipleDbContexts.Services.MySql.Dtos
{
    [MapTo(typeof(MySqlEntity))]
    public class MySqlEntityInputDto : IInputDto<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }

        public bool IsDeleted { get; set; }
    }
}
