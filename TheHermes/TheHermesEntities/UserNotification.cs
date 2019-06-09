using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{

    [Table("Notification.Notification")]
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public Guid UserGuid { get; set; }

        public DateTime Date { get; set; }

        public int NotificationType { get; set; }

        public int ClaimId { get; set; }

        public bool IsConfirm { get; set; }
    }
}
