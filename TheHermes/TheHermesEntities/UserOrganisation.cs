using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    public class UserOrganisation
    {
        public Guid UserGuid { get; set; }
        public Guid OrganisationGuid { get; set; }
    }
}
