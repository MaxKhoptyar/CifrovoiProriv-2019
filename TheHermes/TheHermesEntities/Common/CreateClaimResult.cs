using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities.Common
{
    [Flags]
    public enum CreateClaimResult
    {
        [Description("Успех")]
        Success = 1,

        [Description("Объединение с существующей заявкой")]
        Merge = 2,

        [Description("Повторное создание")]
        DublicateCreate = 3,

        [Description("Повторное присоедиение")]
        DublicateMerge = 4,

        [Description("Необходимо добавить личные данные")]
        NeedAddInfo = 5
    }
}
