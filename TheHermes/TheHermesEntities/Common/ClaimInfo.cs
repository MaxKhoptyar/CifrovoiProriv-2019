using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities.Common
{
    public class ClaimInfo
    {
        public int ClaimId { get; set; }
        public ClaimLifeStatus StatusId { get; set; }
        public ClaimType TypeId { get; set; }
        public DateTime DateTimeUpdate { get; set; }

        public string Message { get; set; }
        public string OrganisationName { get; set; }
        public string OrganisationRating { get; set; }
    }
}
