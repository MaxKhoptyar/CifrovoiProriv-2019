using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    [Table("UserSystem.User")]
    public partial class User
    {
        [Key]
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string Salt { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}
