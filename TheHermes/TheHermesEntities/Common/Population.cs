using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    [Table("Statistic.Population")]
    public class Population
    {
        [Key]
        public int Id { get; set; }
        public string Region { get; set; }
        public int UrbanPopulationMen { get; set; }
        public int UrbanPopulationWomen { get; set; }
        public int RuralPopulationMen { get; set; }
        public int RuralPopulationWomen { get; set; }
    }
}
