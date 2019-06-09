using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities.Common
{
    [Flags]
    public enum UpdateOrganisationResult
    {
        [Description("Успех")]
        Success = 1,

        [Description("Дубликат")]
        ErrorDublicate = 2
    }
}
