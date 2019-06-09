using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    public class OrganisationAnswer
    {
        public int Id { get; set; }
        public Guid ClaimGuid { get; set; }
        public string Answer { get; set; }
        public DateTime DateResponse { get; set; }
    }
}
