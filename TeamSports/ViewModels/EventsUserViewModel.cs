using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamSports.Models;

namespace TeamSports.ViewModels
{
    public class EventsUserViewModel
    {
        public Event Event { get; set; }
        public List<string> Username { get; set; }
    }
}