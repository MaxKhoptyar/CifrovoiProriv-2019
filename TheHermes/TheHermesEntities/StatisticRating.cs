using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    [Table("Claim.StatisticRating")]
    public class StatisticRating
    {
        [Key]
        public int Id { get; set; }
        public Guid OrganisationGuid { get; set; }
        public double Rating { get; set; }
    }
}
