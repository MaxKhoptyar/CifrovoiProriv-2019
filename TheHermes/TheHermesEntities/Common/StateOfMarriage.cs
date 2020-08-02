using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    [Table("Statistic.StateOfMarriage")]
    public class StateOfMarriage
    {
        [Key]
        public int Id { get; set; }
        public string Region { get; set; }
        public int PopulationType { get; set; } // 0 - сельское население; 1- городское население;
        public int Age { get; set; }    //0 - (16 – 17), 1 - (18 - 19), 2 - (20 – 24), 3 - (25 – 29), 4 - (30 – 34), 
                                        //5 - (35 – 39), 6 - (40 – 44), 7 - (45 – 49), 8 - (50 – 54), 9 - (55 – 59)
                                        //10 - (60 – 64), 11 - (65 – 69), 12 - (70 и более), 13 - Возраст не указан
        public int Men { get; set; }// Мужщины
        public int ReportingMen { get; set; }// Мужщины Указавшие состояние в браке"
        public int MarriedMen { get; set; }//Мужщины, состоящие в браке
        public int RegisteredMarriageMen { get; set; }//Мужщины, состоящие в зарегистрированном браке
        public int UnregisteredMarriageMen { get; set; }//Мужщины, состоящие в незарегистрированном браке
        public int UnmarriedMen { get; set; }//Мужщины, "никогда не состоявшие в браке"
        public int OfficiallyDivorcedMen { get; set; }//Мужщины разведен-ные официа-льно
        public int DispersedMen { get; set; }//Мужщины разошед-шиеся
        public int WidowedMen { get; set; }//Вдовые мужщины
        public int NotReportingMen { get; set; }//Мужщины, не указавшие состояние в браке.
        public int Women { get; set; }// Женщины
        public int ReportingWomen { get; set; }// Женщины Указавшие состояние в браке"
        public int MarriedWomen { get; set; }//Женщины, состоящие в браке
        public int RegisteredMarriageWomen { get; set; }//Женщины, состоящие в зарегистрированном браке
        public int UnregisteredMarriageWomen { get; set; }//Женщины, состоящие в незарегистрированном браке
        public int UnmarriedWomen { get; set; }//Женщины, "никогда не состоявшие в браке"
        public int OfficiallyDivorcedWomen { get; set; }//Женщины разведен-ные официа-льно
        public int DispersedWomen { get; set; }//Женщины разошед-шиеся
        public int WidowedWomen { get; set; }//Вдовые Женщины
        public int NotReportingWomen { get; set; }//Женщины, не указавшие состояние в браке.
    }
}
