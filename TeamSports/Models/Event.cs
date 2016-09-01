using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeamSports.Models
{
    public class Event
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        [Display(Name ="Max participants")]
        public int MaxSlots { get; set; }
        [Display(Name = "Available slots")]
        public int AvailableSlots { get; set; }
        public int CurrentSlots { get; set; }
        public string GeoLat { get; set; }
        public string GeoLng { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }
        [Display(Name = "Hour")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH-mm}", ApplyFormatInEditMode = true)]
        public string EventTime { get; set; }

        [Display(Name ="City")]
        public Guid CityID { get; set; }
        [ForeignKey("CityID")]
        public virtual City City { get; set; }

        [Display(Name = "Created by")]
        public string Owner { get; set; }
        [ForeignKey("Owner")]
        public virtual ApplicationUser User { get; set; }

        //Sport
        [Display(Name = "Sport")]
        public Guid SportID { get; set; }
        [ForeignKey("SportID")]
        public virtual Sport Sport { get; set; }

        //Level
        
        public Guid LevelID { get; set; }
        [ForeignKey("LevelID")]
        public virtual Level Level { get; set; }

        public virtual ICollection<UserEvent> Users { get; set; }
    }
}