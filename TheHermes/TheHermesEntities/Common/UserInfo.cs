using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    [Table("User.UserInfo")]
    public class UserInfo
    {
        [Key]
        public Guid UserGuid { get; set; }
        public Guid OrganisationGuid { get; set; }
        public int Age { get; set; }
        public int ChildrenCount { get; set; }
        public int Weight { get; set; }
        //public int DisabledClass { get; set; }
        //public bool HaveCar { get; set; }
    }
}
