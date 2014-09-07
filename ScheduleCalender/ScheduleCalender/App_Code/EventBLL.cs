using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ScheduleCalender
{
    public class EventBLL
    {
        #region [Get Save Event]
        public int InsertEvents(Event oEvent)
        {
            EventDLL oEventDLL = new EventDLL();
            return oEventDLL.InsertEvents(oEvent);
        }
        #endregion

        #region [Get Display Event]
        public DataTable GetEvents()
        {
            EventDLL oEventDLL = new EventDLL();
            return oEventDLL.GetEvents();
        }
        #endregion

        #region [Delete Event]
        public int DelEvents( Int32 eventID)
        {
            EventDLL oEventDLL = new EventDLL();
            return oEventDLL.DelEvents(eventID);
        }
        #endregion

        #region [Drag Event]
        public int DragEvents(Event oEvent)
        {
            EventDLL oEventDLL = new EventDLL();
            return oEventDLL.DragEvents(oEvent);
        }
        #endregion

        #region [Get Display Details Event]
        public DataTable GetEventDetails(int evID)
        {
            EventDLL oEventDLL = new EventDLL();
            return oEventDLL.GetEventDetails(evID);
        }
        #endregion

         #region [Save File]
        public int InsertFile(Event oEvent)
        {
            EventDLL oEventDLL = new EventDLL();
            return oEventDLL.InsertFile(oEvent);
        }
         #endregion
    }
}