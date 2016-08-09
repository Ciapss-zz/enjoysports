using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamSports.Models
{
    public class City
    {
        public Guid ID { get; set; }
        [Display(Name = "City")]
        public string Name { get; set; }
        public string GeoLat { get; set; }
        public string GeoLng { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}