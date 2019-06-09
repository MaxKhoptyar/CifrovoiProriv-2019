using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities.Common
{
    [Flags]
    public enum RoleType
    {

        [Description("Пользователь")]
        User = 1,

        [Description("Организация ЖКХ")]
        Organisation = 2,

        [Description("Администратор портала")]
        Administrator = 3
    }
}
