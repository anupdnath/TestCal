using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ScheduleCalender
{
    public class EventBLL
    {
        public int InsertEvents(Event oEvent)
        {
            EventDLL oEventDLL = new EventDLL();
            return oEventDLL.InsertEvents(oEvent);
        }

        public DataTable GetEvents()
        {
            EventDLL oEventDLL = new EventDLL();
            return oEventDLL.GetEvents();
        }
    }
}