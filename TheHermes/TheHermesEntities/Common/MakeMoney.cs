using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    [Table("Statistic.MakeMoney")]
    public class MakeMoney
    {
        [Key]
        public int Id { get; set; }
        public string Region { get; set; }
        public int PopulationType { get; set; } // 0 - сельское население; 1- городское население;
        public int Sex { get; set; }// 0 - мужщины; 1 - женщины;
        public int Age { get; set; } //0 - моложе трудоспособного; 1- трудоспособное; 2- старше трудоспособного
        public int AllPopulation { get; set; } // все население
        public int Reporting { get; set; } // "Население, указавшее источники средств к существованию"
        public int AllReporting { get; set; }//"Всего указали источников средств к существованию"
        public int LaborActivity { get; set; }//"трудовую деятельность, включая работу по совмести-тельству"
        public int PersonalSubsidiaryPlots { get; set; }//личное подсобное хозяйство
        public int Scholarship { get; set; }//стипендия
        public int Pension { get; set; }// пенсию (кроме пенсии по инвалид-ности)
        public int DisabilityPension { get; set; }//пенсию по инвалид-ности
        public int Allowance { get; set; }//пособие (кроме пособия по безра-ботице)
        public int UnemploymentBenefits { get; set; }//"пособие по безработице"
        public int StateSecurity { get; set; }//другой вид государст-венного обеспе-чения
        public int Dividends { get; set; }//"сбережения; дивиденды; проценты"
        public int Rent { get; set; }//"сдачу        внаем или в аренду имущества; доход от патентов, авторских прав"
        public int Dependence { get; set; }//"иждивение; помощь других лиц; алименты"
        public int Other { get; set; }//"иной источник средств к существованию"
        public int NotSpecified { get; set; }//Население, не указавшее источник средств к существо-ванию
        public int NumberOfSources1 { get; set; }//"Из общей численности населения указали число источников средств к существованию - 1"			
        public int NumberOfSources2 { get; set; }//"Из общей численности населения указали число источников средств к существованию - 2"			
        public int NumberOfSources3 { get; set; }//"Из общей численности населения указали число источников средств к существованию - 3"			
        public int NumberOfSources4 { get; set; }//"Из общей численности населения указали число источников средств к существованию - 4 и более"	
    }


}
