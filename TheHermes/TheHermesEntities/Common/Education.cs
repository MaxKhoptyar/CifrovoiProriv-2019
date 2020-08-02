using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    [Table("Statistic.Education")]
    public partial class Education
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        public string Region { get; set; }
        public int PopulationType { get; set; } // 0 - сельское население; 1- городское население;
        public int Sex { get; set; }// 0 - мужщины; 1 - женщины;
        public int Age { get; set; } //0 - (15 – 17), 1 - (18 – 19), 2 - (20 – 24), 3 - (25 – 29),
                                     //4 - (30 – 34), 5 - (35 – 39), 6 - (40 – 44), 7 - (45 – 49),
                                     //8 - (50 – 54), 9 - (55 – 59), 10 - (60 – 64), 11 - (65 – 69),
                                     //12 - (70 и более), 13 - (трудоспособном), 14 - (старше трудоспособного),
                                     //15 - (16 - 29 лет)

        public int Total { get; set; }//Всего
        public int Indicated { get; set; }//указавшие уровень образования
        public int Postgraduate { get; set; }//Послевузовское
        public int Higher { get; set; } //Высшее образование
        public int Bachelor { get; set; } // Бакалавр
        public int Specialist { get; set; }//Специалист
        public int Master { get; set; }//Магистр
        public int IncompleteHigher { get; set; }//Неполное высшее
        public int AverageProf { get; set; }// Среднее профессиональное
        public int InitialProf { get; set; }//Начальное профессиональное
        public int Average { get; set; }// Среднее общее
        public int TheMain { get; set; }//Основное общее
        public int Initial { get; set; }// Начальное общее
        public int NotGeneralEducation { get; set; }//Не имеющие начального общего образования
        public int Illiterate { get; set; }//Из них неграмотные
        public int NotIndicated { get; set; }// Не указавшие уровень образования
    }
}
