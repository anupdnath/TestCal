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
        #region [Save Event]
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
            cmd.Parameters.AddWithValue("@eventID", SqlDbType.Int).Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                iRowAffected = Convert.ToInt32(cmd.Parameters["@eventID"].Value);

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

        #region [Get Display Details Event]
        public DataTable GetEventDetails(int evID)
        {
            DataTable dt = new DataTable();
            try
            {
                adp = new SqlDataAdapter("SP_GET_EVENTBY_ID", con);
                adp.SelectCommand.Parameters.AddWithValue("@eventID", evID);               
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

        #region [Save File]
        public int InsertFile(Event oEvent)
        {
            int iRowAffected = 0;
            cmd = new SqlCommand("SP_ADD_FileData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PLT", SqlDbType.VarChar).Value = oEvent.PLT;
             cmd.Parameters.AddWithValue("@DEPT", SqlDbType.VarChar).Value = oEvent.DEPT;
             cmd.Parameters.AddWithValue("@MACH", SqlDbType.VarChar).Value = oEvent.MACH;
             cmd.Parameters.AddWithValue("@YEARX", SqlDbType.VarChar).Value = oEvent.YEARX;
             cmd.Parameters.AddWithValue("@NUMX", SqlDbType.VarChar).Value = oEvent.NUMX;
             cmd.Parameters.AddWithValue("@UPC", SqlDbType.VarChar).Value = oEvent.UPC;
             cmd.Parameters.AddWithValue("@PDTNM", SqlDbType.VarChar).Value = oEvent.PDTNM;
             cmd.Parameters.AddWithValue("@PPDT3", SqlDbType.VarChar).Value = oEvent.PPDT3;
             cmd.Parameters.AddWithValue("@PPDT4", SqlDbType.VarChar).Value = oEvent.PPDT4;
             cmd.Parameters.AddWithValue("@PPDT5", SqlDbType.VarChar).Value = oEvent.PPDT5;
             cmd.Parameters.AddWithValue("@ORDER#", SqlDbType.VarChar).Value = oEvent.ORDER;
             cmd.Parameters.AddWithValue("@RO", SqlDbType.VarChar).Value = oEvent.RO;
             cmd.Parameters.AddWithValue("@REPQTY", SqlDbType.VarChar).Value = oEvent.REPQTY;
             cmd.Parameters.AddWithValue("@SCHQTY", SqlDbType.VarChar).Value = oEvent.SCHQTY;
             cmd.Parameters.AddWithValue("@DLVQTY", SqlDbType.VarChar).Value = oEvent.DLVQTY;
             cmd.Parameters.AddWithValue("@AVGQTY", SqlDbType.VarChar).Value = oEvent.AVGQTY;
             cmd.Parameters.AddWithValue("@STDATE", SqlDbType.VarChar).Value = oEvent.STDATE;
             cmd.Parameters.AddWithValue("@TMDATE", SqlDbType.VarChar).Value = oEvent.TMDATE;
             cmd.Parameters.AddWithValue("@DLDATE", SqlDbType.VarChar).Value = oEvent.DLDATE;
             cmd.Parameters.AddWithValue("@LWDATE", SqlDbType.VarChar).Value = oEvent.LWDATE;
             cmd.Parameters.AddWithValue("@ENDATE", SqlDbType.VarChar).Value = oEvent.ENDATE;
             cmd.Parameters.AddWithValue("@MCHTYP", SqlDbType.VarChar).Value = oEvent.MCHTYP;
             cmd.Parameters.AddWithValue("@SRMK1", SqlDbType.VarChar).Value = oEvent.SRMK1;
             cmd.Parameters.AddWithValue("@SRMK2", SqlDbType.VarChar).Value = oEvent.SRMK2;
             cmd.Parameters.AddWithValue("@SRMK3", SqlDbType.VarChar).Value = oEvent.SRMK3;
             cmd.Parameters.AddWithValue("@SRMK4", SqlDbType.VarChar).Value = oEvent.SRMK4;
             cmd.Parameters.AddWithValue("@SRMK5", SqlDbType.VarChar).Value = oEvent.SRMK5;
             cmd.Parameters.AddWithValue("@EOQ", SqlDbType.VarChar).Value = oEvent.EOQ;
             cmd.Parameters.AddWithValue("@ROP", SqlDbType.VarChar).Value = oEvent.ROP;
             cmd.Parameters.AddWithValue("@TOTBK", SqlDbType.VarChar).Value = oEvent.TOTBK;
             cmd.Parameters.AddWithValue("@ACTAL", SqlDbType.VarChar).Value = oEvent.ACTAL;
             cmd.Parameters.AddWithValue("@AVGSHP", SqlDbType.VarChar).Value = oEvent.AVGSHP;
             cmd.Parameters.AddWithValue("@INST1", SqlDbType.VarChar).Value = oEvent.INST1;
             cmd.Parameters.AddWithValue("@INST2", SqlDbType.VarChar).Value = oEvent.INST2;
             cmd.Parameters.AddWithValue("@INST3", SqlDbType.VarChar).Value = oEvent.INST3;
             cmd.Parameters.AddWithValue("@SEQ#", SqlDbType.VarChar).Value = oEvent.SEQ;
             cmd.Parameters.AddWithValue("@CTRMID", SqlDbType.VarChar).Value = oEvent.CTRMID;
             cmd.Parameters.AddWithValue("@CUSRID", SqlDbType.VarChar).Value = oEvent.CUSRID;
             cmd.Parameters.AddWithValue("@CCHGDT", SqlDbType.VarChar).Value = oEvent.CCHGDT;
             cmd.Parameters.AddWithValue("@CCHGTM", SqlDbType.VarChar).Value = oEvent.CCHGTM;
             cmd.Parameters.AddWithValue("@CSTS", SqlDbType.VarChar).Value = oEvent.CSTS;
             cmd.Parameters.AddWithValue("@eventID", SqlDbType.VarChar).Value = oEvent.eventID;

            try
            {
                con.Open();
                iRowAffected=cmd.ExecuteNonQuery();

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
    }
}