using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeamSports.Models
{
    public class UserEvent
    {
        public Guid ID { get; set; }

        public Guid EventID { get; set; }
        [ForeignKey("EventID")]
        public virtual Event Event { get; set; }

        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
    }
}