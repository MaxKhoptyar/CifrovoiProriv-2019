using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    [Flags]
    public enum ClaimLifeStatus
    {
        [Description("Подача заявки")]
        Submission = 1,

        [Description("В работе по сбору подтверждений")]
        InWork = 2,

        [Description("Ожидание действий ЖКХ")]
        Execution = 3,

        [Description("Сбор оценок по реагированию")]
        Evaluation = 4,

        [Description("Завершение")]
        Сompletion = 5,

        [Description("Оценка учтена")]
        Ranging = 6
    }
}
