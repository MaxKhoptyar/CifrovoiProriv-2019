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
    public enum RelationshipType
    {
        [Description("Пользователь")]
        First = 1,
        /////////////////
    }
}
