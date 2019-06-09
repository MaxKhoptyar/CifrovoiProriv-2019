using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    [Table("Claim.ClaimUserCollaboration")]
    public class ClaimUserCollaboration
    {
        [Key]
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public Guid UserGuid { get; set; }
        public string AccompanyingMessage { get; set; }
    }
}
