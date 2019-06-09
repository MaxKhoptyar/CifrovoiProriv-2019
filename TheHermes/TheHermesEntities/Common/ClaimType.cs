using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    [Flags]
    public enum ClaimType
    {
        [Description("Вывоз мусора")]
        GarbageProblem = 1,

        [Description("Проблема с городским оформлением")]
        Environmental = 2,

        [Description("Работа сантехника")]
        SanitaryEngineering = 3,

        [Description("Работа электрика")]
        ElectricianEngineering = 4,

        [Description("Уборка территории")]
        CleaningTerritory = 5,

        [Description("Текущий ремонт")]
        CurrentRepair = 6,

        [Description("Работа паспортного стола")]
        PassportOffice = 7,

        [Description("Прием платежей")]
        PaymentAcceptance = 8,

        [Description("Уборка подъездов")]
        CleaningEntrances = 9,

        [Description("Прочее")]
        Other = 10
    }
}
