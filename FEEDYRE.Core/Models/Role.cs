using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEDYRE.Core.Models
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)] 
        public string Name { get; set; } = null!;
    }
}
