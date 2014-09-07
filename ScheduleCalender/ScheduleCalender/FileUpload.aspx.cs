using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Globalization;

namespace ScheduleCalender
{
    public partial class FileUpload : System.Web.UI.Page
    {
        #region [Constants]
        static string FILEPATH = "FILEPATH";
        #endregion

        #region [Clear Result / Count]
        void ClearResult()
        {
            rpUpload.DataSource = null;
            rpUpload.DataBind();
            tdCount.Visible = false;
        }
        #endregion

        #region [Upload]
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //lstPattern.SelectedIndex = 0;
                ClearResult();

                if (!FileUpload1.HasFile || FileUpload1.FileBytes.Length == 0)
                {
                    lblUploadErr.Text = "No file selected or invalid file size";
                    return;
                }
                else
                {
                    switch (FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.') + 1))
                    {
                        case "csv":                        
                            

                            String FilePath = String.Format("{0}\\{1}.{2}"
                                , Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["TempFileUpload"])
                                , Guid.NewGuid().ToString()
                                , FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.') + 1));
                            FileUpload1.SaveAs(FilePath);

                            DataTable oDataTable = ImportUtility.CSVToDataTable(FilePath);
                            ViewState[FILEPATH] = FilePath;
                            if (oDataTable.Rows.Count > 0)
                            {
                                BindData(oDataTable, FilePath);
                            }
                            //litErrorCount.Text = oDataTable.Rows.Count.ToString();
                           


                            break;
                        default:
                            lblUploadErr.Text = "Invalid File format!";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                lblUploadErr.Text = ex.Message;
            }
        }
        #endregion

        #region [Bind Data]
        void BindData(DataTable oDataTable, String FilePath)
        {
            int er = 0;
            try
            {
                if (oDataTable.Columns.Count == 4)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Title", typeof(string));
                    dt.Columns.Add("From", typeof(string));
                    dt.Columns.Add("To", typeof(string));
                    dt.Columns.Add("Other", typeof(string));                    
                    foreach (DataRow row in oDataTable.Rows)
                    {
                       
                            DataRow dr = dt.NewRow();
                            dr["Title"] = row[0];
                            dr["From"] = row[1];
                            dr["To"] = row[2];
                            dr["Other"] = row[3];
                            dt.Rows.Add(dr);
                            
                    }
                    rpUpload.DataSource = dt;
                    rpUpload.DataBind();

                    tdCount.Visible = true;
                    litTotalCount.Text = dt.Rows.Count.ToString();
                    
                    File.Delete(FilePath);
                }
            }
            catch (Exception ex)
            {
                lblUploadErr.Text = ex.Message;
            }
        }
        #endregion

        #region [Check Date Range]
        private bool CheckDateRange(DateTime start,DateTime end)
        {
            if (end > start)
            {
                return true;
            }
            else
                return false;
        }
        #endregion

        #region [Check Date]
        private bool CheckDate(string dateString)
        {
            bool status = false;
            string format = "dd/MM/yyyy hh:mm:ss tt";
            DateTime dateTime;
            if (DateTime.TryParseExact(dateString, format, new CultureInfo("en-US"),DateTimeStyles.None, out dateTime))
            {
                status = true;
            }
            else
            {
                status = false;
            }
            return status;
        }
        #endregion

        #region [Data Bound]
        protected void rpUpload_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int er = 0;
            try
            {
                Literal litClass = e.Item.FindControl("litClass") as Literal;
                Label lblFrom = e.Item.FindControl("lblFrom") as Label;
                Label lblTo = e.Item.FindControl("lblTo") as Label;

                if (CheckDate(lblFrom.Text) == true && CheckDate(lblTo.Text) == true)
                {
                    if (CheckDateRange(DateTime.Parse(lblFrom.Text), DateTime.Parse(lblTo.Text)) == false)
                    {
                        lblFrom.CssClass = "error";
                        lblTo.CssClass = "error";
                        er++;
                    }
                    
                }
                else
                {
                    er++;
                    lblFrom.CssClass = "error";
                    lblTo.CssClass = "error";
                }
                litErrorCount.Text = er.ToString();
                spnErrorCount.Visible = (litErrorCount.Text.Trim() != "0");
            }
            catch { }
        }
        #endregion

        #region [Submit Data]
        protected void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (RepeaterItem rpItem in rpUpload.Items)
                {
                    Label lblTitle = rpItem.FindControl("lblTitle") as Label;
                    Label lblFrom = rpItem.FindControl("lblFrom") as Label;
                    Label lblTo = rpItem.FindControl("lblTo") as Label;
                    Label lblOther = rpItem.FindControl("lblOther") as Label;

                    if (lblFrom.CssClass != "error")
                    {
                        DateTime start = DateTime.Parse(lblFrom.Text);
                        DateTime end = DateTime.Parse(lblTo.Text);
                        int sd, sm, sy, ed, em, ey;
                        int shh, smm, sss, ehh, emm, ess;
                        string stt, ett;

                        sd = start.Day;
                        sm = start.Month;
                        sy = start.Year;
                        ed = end.Day;
                        em = end.Month;
                        ey = end.Year;

                        shh = start.Hour;
                        smm = start.Minute;
                        sss = start.Second;
                        ehh = end.Hour;
                        emm = end.Minute;
                        ess= end.Second;

                        stt = start.ToString("tt");
                        ett = end.ToString("tt");

                        if (stt == "AM" && shh == 12)
                        {
                            shh = 0;
                        }
                        else if (stt == "PM" && shh < 12)
                        {
                            shh = shh + 12;
                        }

                        if (ett == "AM" && ehh == 12)
                        {
                            ehh = 0;
                        }
                        else if (ett == "PM" && ehh < 12)
                        {
                            ehh = shh + 12;
                        }

                        #region [Save To Database]
                        Event eventdata = new Event();
                        eventdata.eventName = lblTitle.Text;
                        eventdata.startDay = sd.ToString();
                        eventdata.startMonth = sm.ToString();
                        eventdata.startYear = sy.ToString();
                        eventdata.startHour = shh.ToString();
                        eventdata.startMin = smm.ToString();

                        eventdata.endDay = ed.ToString();
                        eventdata.endMonth = em.ToString();
                        eventdata.endYear = ey.ToString();
                        eventdata.endHour = ehh.ToString();
                        eventdata.endMin = emm.ToString();

                        eventdata.otherInfo = lblOther.Text;
                        eventdata.backgroundColor = "#333333";
                        eventdata.foregroundColor = "#ffffff";
                         EventBLL oEventBLL = new EventBLL();
                         int r= oEventBLL.InsertEvents(eventdata);
                         ClearResult();
                        #endregion
                    }
                }
            }
            catch(Exception ex)
            {

            }

        }
        #endregion
       
    }
}