using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TheHermesEntities;
using TheHermesEntities.Common;

namespace TheHermes.Models
{
    public class NotificationUserModel
    {
        public Dictionary<int,ClaimInfo> Claims { get; set; } 
        public List<Notification> Notification { get; set; }
    }
    public class NotificationOrganisationModel
    {
        public List<Notification> Notification { get; set; }
        public Dictionary<int, ClaimInfo> Claims { get; set; }
    }
}
