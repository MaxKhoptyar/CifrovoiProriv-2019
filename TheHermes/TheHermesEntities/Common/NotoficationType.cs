using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities.Common
{
    [Flags]
    public enum NotificationType
    {
        [Description("Возможность проголосовать за жалобу по ЖКХ")]
        NotificationAddVoice = 1,

        [Description("Была подана жалоба на ЖКХ")]
        NotificationRequestClaim = 2,

        [Description("Ответ на жалобу от ЖКХ")]
        NotificationAnswerClaim = 3,

        [Description("Возможность выставить оценку по работе ЖКХ")]
        NotificationRatingResult = 4,

        [Description("Обновление рейтинга ЖКХ")]
        NotificationUpdateRating = 5
    }
}
