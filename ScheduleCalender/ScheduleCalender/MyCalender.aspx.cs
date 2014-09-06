using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace ScheduleCalender
{
    public partial class MyCalender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region [Get Cal Event]
        
       
        [System.Web.Services.WebMethod]
        public static Event[] ViewEvents()
        {
            DataTable dt = new DataTable();
            List<Event> details = new List<Event>();

            EventBLL oEventBLL = new EventBLL();
            dt = oEventBLL.GetEvents();

            foreach (DataRow dtrow in dt.Rows)
            {
                Event eve = new Event();
                eve.eventID = Int32.Parse(dtrow["eventID"].ToString());
                eve.eventName = dtrow["eventName"].ToString();

                eve.startYear = dtrow["starYear"].ToString();
                eve.startMonth = dtrow["startMonth"].ToString();
                eve.startDay = dtrow["startDay"].ToString();

                eve.startHour = dtrow["startHour"].ToString();
                eve.startMin = dtrow["startMin"].ToString();

                eve.endYear = dtrow["endYear"].ToString();
                eve.endMonth = dtrow["endMonth"].ToString();
                eve.endDay = dtrow["endDay"].ToString();

                eve.endHour = dtrow["endHour"].ToString();
                eve.endMin = dtrow["endMin"].ToString();

                eve.firstName = dtrow["firstName"].ToString();
                eve.lastName = dtrow["lastName"].ToString();
                eve.emailID = dtrow["emailID"].ToString();
                eve.backgroundColor = dtrow["backgroundColor"].ToString();
                eve.foregroundColor = dtrow["foregroundColor"].ToString();
                details.Add(eve);
            }

            return details.ToArray();
        }
        #endregion

        #region [Add Event]
     
        [System.Web.Services.WebMethod]
        public static bool SaveEvent(Event eventdata)
        {
            int r=0;
            if (eventdata != null)
            {
                EventBLL oEventBLL = new EventBLL();
                r= oEventBLL.InsertEvents(eventdata);
            }
            if(r>0)
                return true;
            else
                return false;
        }
        #endregion

        #region [Event Delete]

        [System.Web.Services.WebMethod]
        public static bool DelEvent(Int32 evid)
        {
            int r = 0;
            if (evid != null)
            {
                EventBLL oEventBLL = new EventBLL();
                r = oEventBLL.DelEvents(evid);
            }
            if (r > 0)
                return true;
            else
                return false;
        }
        #endregion
    }
}