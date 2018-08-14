using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OSharp.Entity;

namespace OSharp.Samples.MultipleDbContexts.Services.MySql.Entities
{
    public class MySqlEntity : EntityBase<int>, ICreatedTime
    {
        public string Name { get; set; }

        public string Remark { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
