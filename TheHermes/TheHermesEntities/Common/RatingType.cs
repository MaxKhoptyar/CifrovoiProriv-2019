using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities.Common
{
    [Flags]
    public enum RatingType
    {
        [Description("Проблема не решена, и попытки решения не было")]
        VeryBad = 1,

        [Description("Проблема не решена, но были попытки решения проблемы")]
        Bad = 2,

        [Description("Проблема решена, но с претензиями к качеству выполнения или времени выполнения")]
        Normal = 3,

        [Description("Проблема решена, но с незначительными претензиями к качествувыполнения")]
        Good = 4,

        [Description("Проблема решена, качество абсолютно устраивает, время реакции устраивает")]
        Excelent = 5
    }
}
