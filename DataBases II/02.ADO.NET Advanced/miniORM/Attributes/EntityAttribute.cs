using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniORM.Attributes
{
    class EntityAttribute : Attribute
    {
        public string TableName { get; set; }
    }
}
