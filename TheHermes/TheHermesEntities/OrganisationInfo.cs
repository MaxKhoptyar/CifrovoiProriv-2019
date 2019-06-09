using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    [Table("Organisation.OrganisationInfo")]
    public class OrganisationInfo
    {
        [Key]
        public Guid OrganisationGuid { get; set; }
        public string Name { get; set; }
        public int Inn { get; set; }
        public double Staff { get; set; }
        public double Profitability { get; set; }
        public double Tariffs { get; set; }
        public double ManagementArea { get; set; }
        public double LawerStatistic { get; set; }
        public double InformationResourses { get; set; }
    }
}
