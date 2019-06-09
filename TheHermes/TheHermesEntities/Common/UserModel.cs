using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHermesEntities.Common;

namespace TheHermesEntities
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
        public RoleType UserType { get; set; }
        public Guid UserGuid { get; set; }
    }
}
