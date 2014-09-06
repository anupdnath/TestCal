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
        #region [Get Save Event]
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
            cmd.Parameters.AddWithValue("@OtherInfo", SqlDbType.VarChar).Value = oEvent.otherInfo;
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
        #endregion

        #region [Get Display Event]
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
        #endregion

        #region [Delete Event]
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
        #endregion

        #region [Drag Event]
        public int DragEvents(Event oEvent)
        {
            int iRowAffected = 0;
            try
            {
                cmd = new SqlCommand("Drag_Event", con);
                cmd.Parameters.AddWithValue("@eventID", SqlDbType.BigInt).Value = oEvent.eventID;
                cmd.Parameters.AddWithValue("@startYear", SqlDbType.VarChar).Value = oEvent.startYear;
                cmd.Parameters.AddWithValue("@startMonth", SqlDbType.VarChar).Value = oEvent.startMonth;
                cmd.Parameters.AddWithValue("@startDay", SqlDbType.VarChar).Value = oEvent.startDay;  
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
        #endregion
    }
}