using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.RadenRovcanin.Contracts.Entities
{
    public class BaseEntity
    {
        public DateTime DateCreated { get; set; } = default!;
    }
}
