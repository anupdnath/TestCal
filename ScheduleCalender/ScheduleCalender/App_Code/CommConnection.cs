using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ScheduleCalender
{
    public class CommConnection
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public SqlDataAdapter adp;
        public SqlCommand cmd;
        public DataTable dt;
        public CommConnection()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}