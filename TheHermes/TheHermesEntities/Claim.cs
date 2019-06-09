using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    [Table("Claim.Claim")]
    public partial class Claim
    {
        [Key]
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public Guid OrganisationGuid { get; set; }
        public DateTime DateTimeUpdate { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }
        public string AccompanyingMessage { get; set; }
    }
}
