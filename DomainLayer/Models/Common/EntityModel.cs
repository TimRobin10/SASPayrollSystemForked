using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Common
{
    abstract class EntityModel : IEntityModel
    {
        public int Id { get; set; }
    }
}
