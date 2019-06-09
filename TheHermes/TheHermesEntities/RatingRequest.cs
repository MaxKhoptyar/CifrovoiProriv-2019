using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    [Table("Claim.Rating")]
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public Guid UserGuid { get; set; }
        public int RatingId { get; set; }
        public string Message { get; set; }
    }
}
