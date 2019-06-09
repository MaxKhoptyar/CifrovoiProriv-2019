using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities.Common
{
    [Flags]
    public enum DisabledClassType
    {
        [Description("Первая категория")]
        WithoutCategory = 1,

        [Description("Первая категория")]
        FirstCategory = 2,

        [Description("Вторая категория")]
        SecondCategory = 3,

        [Description("Третья категория")]
        ThirdCategory = 4
    }
}
