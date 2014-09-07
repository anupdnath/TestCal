using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleCalender
{
    public class Event
    {
        public int? eventID { get; set; }
        public string eventName { get; set; }

        //public string starDate { get; set; }
        public string startYear { get; set; }
        public string startMonth { get; set; }
        public string startDay { get; set; }

        //public string endDate { get; set; }
        public string endYear { get; set; }
        public string endMonth { get; set; }
        public string endDay { get; set; }

        public string startHour { get; set; }
        public string startMin { get; set; }
        
        public string endHour { get; set; }
        public string endMin { get; set; }
       
        public string addDate { get; set; }
        public string otherInfo { get; set; }  
        public string backgroundColor { get; set; }
        public string foregroundColor { get; set; }
    }
}