using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities.Common
{
    [Flags]
    public enum CreateRatingResult
    {
        [Description("Успех")]
        Success = 1,

        [Description("Дубликат оценки")]
        Dublicate = 2,

        [Description("Ошибка")]
        Error = 3
    }
}
