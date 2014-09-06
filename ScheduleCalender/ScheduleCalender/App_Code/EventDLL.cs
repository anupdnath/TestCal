using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ScheduleCalender
{
    public class EventDLL : CommConnection
    {
        public int InsertEvents(Event oEvent)
        {
            int iRowAffected = 0;
            cmd = new SqlCommand("Add_Event", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eventName", SqlDbType.VarChar).Value = oEvent.eventName;           
            cmd.Parameters.AddWithValue("@startYear", SqlDbType.VarChar).Value = oEvent.startYear;
            cmd.Parameters.AddWithValue("@startMonth", SqlDbType.VarChar).Value = oEvent.startMonth;
            cmd.Parameters.AddWithValue("@startDay", SqlDbType.VarChar).Value = oEvent.startDay;           
            cmd.Parameters.AddWithValue("@endYear", SqlDbType.VarChar).Value = oEvent.endYear;
            cmd.Parameters.AddWithValue("@endMonth", SqlDbType.VarChar).Value = oEvent.endMonth;
            cmd.Parameters.AddWithValue("@endDay", SqlDbType.VarChar).Value = oEvent.endDay;
            cmd.Parameters.AddWithValue("@startHour", SqlDbType.VarChar).Value = oEvent.startHour;
            cmd.Parameters.AddWithValue("@startMin", SqlDbType.VarChar).Value = oEvent.startMin;
            cmd.Parameters.AddWithValue("@endHour", SqlDbType.VarChar).Value = oEvent.endHour;
            cmd.Parameters.AddWithValue("@endMin", SqlDbType.VarChar).Value = oEvent.endMin;
            cmd.Parameters.AddWithValue("@firstName", SqlDbType.VarChar).Value =oEvent.firstName;
            cmd.Parameters.AddWithValue("@lastName", SqlDbType.VarChar).Value = oEvent.lastName;
            cmd.Parameters.AddWithValue("@emailID", SqlDbType.VarChar).Value = oEvent.emailID;
            cmd.Parameters.AddWithValue("@backgroundColor", SqlDbType.VarChar).Value = oEvent.backgroundColor;
            cmd.Parameters.AddWithValue("@foregroundColor", SqlDbType.VarChar).Value = oEvent.foregroundColor;

            try
            {
                con.Open();
                iRowAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception oException)
            {
                throw oException;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }

            return iRowAffected;

        }
        public DataTable GetEvents()
        {
            DataTable dt = new DataTable();
            try
            {
                adp = new SqlDataAdapter("SP_GET_EVENTs", con);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;                
                adp.Fill(dt);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public int DelEvents(Int32 eventID)
        {
            int iRowAffected = 0;
            try
            {
                cmd = new SqlCommand("Del_Event", con);
                cmd.Parameters.AddWithValue("@eventID", SqlDbType.BigInt).Value = eventID; 
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    iRowAffected = cmd.ExecuteNonQuery();

                }
                catch (Exception oException)
                {
                    throw oException;
                }
                finally
                {
                    con.Close();
                    cmd.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return iRowAffected;
        }
    }
}