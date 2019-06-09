using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    [Table("UserSystem.UserRole")]
    public class UserRole
    {
        [Key]
        public Guid UserGuid { get; set; }
        public int RoleId { get; set; }
    }
}
