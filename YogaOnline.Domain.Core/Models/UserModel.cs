using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaOnline.Domain.Core.Models
{
    public class UserModel : BaseEntity
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? CPF { get; set; }
    }
}
