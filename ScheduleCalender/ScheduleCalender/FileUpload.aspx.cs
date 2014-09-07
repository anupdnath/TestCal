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
            try
            {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("PLT", typeof(string));
                    dt.Columns.Add("DEPT", typeof(string));
                    dt.Columns.Add("MACH", typeof(string));
                    dt.Columns.Add("YEARX", typeof(string));
                    dt.Columns.Add("NUMX", typeof(string));
                    dt.Columns.Add("UPC", typeof(string));
                    dt.Columns.Add("PDTNM", typeof(string));
                    dt.Columns.Add("PPDT3", typeof(string));
                    dt.Columns.Add("PPDT4", typeof(string));
                    dt.Columns.Add("PPDT5", typeof(string));
                    dt.Columns.Add("ORDER#", typeof(string));
                    dt.Columns.Add("RO", typeof(string));
                    dt.Columns.Add("REPQTY", typeof(string));
                    dt.Columns.Add("SCHQTY", typeof(string));
                    dt.Columns.Add("DLVQTY", typeof(string));
                    dt.Columns.Add("AVGQTY", typeof(string));
                    dt.Columns.Add("STDATE", typeof(string));
                    dt.Columns.Add("TMDATE", typeof(string));
                    dt.Columns.Add("DLDATE", typeof(string));
                    dt.Columns.Add("LWDATE", typeof(string));
                    dt.Columns.Add("ENDATE", typeof(string));
                    dt.Columns.Add("MCHTYP", typeof(string));
                    dt.Columns.Add("SRMK1", typeof(string));
                    dt.Columns.Add("SRMK2", typeof(string));
                    dt.Columns.Add("SRMK3", typeof(string));
                    dt.Columns.Add("SRMK4", typeof(string));
                    dt.Columns.Add("SRMK5", typeof(string));
                    dt.Columns.Add("EOQ", typeof(string));
                    dt.Columns.Add("ROP", typeof(string));
                    dt.Columns.Add("TOTBK", typeof(string));
                    dt.Columns.Add("ACTAL", typeof(string));
                    dt.Columns.Add("AVGSHP", typeof(string));
                    dt.Columns.Add("INST1", typeof(string));
                    dt.Columns.Add("INST2", typeof(string));
                    dt.Columns.Add("INST3", typeof(string));
                    dt.Columns.Add("SEQ#", typeof(string));
                    dt.Columns.Add("CTRMID", typeof(string));
                    dt.Columns.Add("CUSRID", typeof(string));
                    dt.Columns.Add("CCHGDT", typeof(string));
                    dt.Columns.Add("CCHGTM", typeof(string));
                    dt.Columns.Add("CSTS", typeof(string));
                   
                    foreach (DataRow row in oDataTable.Rows)
                    {
                       
                            DataRow dr = dt.NewRow();
                            dr["PLT"] = row[0];
                            dr["DEPT"] = row[1];
                            dr["MACH"] = row[2];
                            dr["YEARX"] = row[3];
                            dr["NUMX"] = row[4];
                            dr["UPC"] = row[5];
                            dr["PDTNM"] = row[6];
                            dr["PPDT3"] = row[7];
                            dr["PPDT4"] = row[8];
                            dr["PPDT5"] = row[9];
                            dr["ORDER#"] = row[10];
                            dr["RO"] = row[11];
                            dr["REPQTY"] = row[12];
                            dr["SCHQTY"] = row[13];
                            dr["DLVQTY"] = row[14];
                            dr["AVGQTY"] = row[15];
                            dr["STDATE"] = row[16];
                            dr["TMDATE"] = row[17];
                            dr["DLDATE"] = row[18];
                            dr["LWDATE"] = row[19];
                            dr["ENDATE"] = row[20];
                            dr["MCHTYP"] = row[21];
                            dr["SRMK1"] = row[22];
                            dr["SRMK2"] = row[23];
                            dr["SRMK3"] = row[24];
                            dr["SRMK4"] = row[25];
                            dr["SRMK5"] = row[26];
                            dr["EOQ"] = row[27];
                            dr["ROP"] = row[28];
                            dr["TOTBK"] = row[29];
                            dr["ACTAL"] = row[30];
                            dr["AVGSHP"] = row[31];
                            dr["INST1"] = row[32];
                            dr["INST2"] = row[33];
                            dr["INST3"] = row[34];
                            dr["SEQ#"] = row[35];
                            dr["CTRMID"] = row[36];
                            dr["CUSRID"] = row[37];
                            dr["CCHGDT"] = row[38];
                            dr["CCHGTM"] = row[39];
                            dr["CSTS"] = row[40];

                            dt.Rows.Add(dr);
                            
                    }
                    rpUpload.DataSource = dt;
                    rpUpload.DataBind();

                    tdCount.Visible = true;
                    litTotalCount.Text = dt.Rows.Count.ToString();
                    
                    File.Delete(FilePath);
                
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
                Label lblSTDATE = e.Item.FindControl("lblSTDATE") as Label;
                Label lblTMDATE = e.Item.FindControl("lblTMDATE") as Label;
                if (lblSTDATE.Text.Length < 7 && lblSTDATE.Text.Length < 7)
                {

                    lblSTDATE.CssClass = "error";
                    lblTMDATE.CssClass = "error";
                        er++;

                    
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
                    Label lblPLT = rpItem.FindControl("lblPLT") as Label;
                    Label lblDEPT = rpItem.FindControl("lblDEPT") as Label;
                    Label lblMACH = rpItem.FindControl("lblMACH") as Label;
                    Label lblYEARX = rpItem.FindControl("lblYEARX") as Label;
                    Label lblNUMX = rpItem.FindControl("lblNUMX") as Label;
                    Label lblUPC = rpItem.FindControl("lblUPC") as Label;
                    Label lblPDTNM = rpItem.FindControl("lblPDTNM") as Label;
                    Label lblPPDT3 = rpItem.FindControl("lblPPDT3") as Label;
                    Label lblPPDT4 = rpItem.FindControl("lblPPDT4") as Label;
                    Label lblPPDT5 = rpItem.FindControl("lblPPDT5") as Label;
                    Label lblORDER = rpItem.FindControl("lblORDER") as Label;
                    Label lblRO = rpItem.FindControl("lblRO") as Label;
                    Label lblREPQTY = rpItem.FindControl("lblREPQTY") as Label;
                    Label lblSCHQTY = rpItem.FindControl("lblSCHQTY") as Label;
                    Label lblDLVQTY = rpItem.FindControl("lblDLVQTY") as Label;
                    Label lblAVGQTY = rpItem.FindControl("lblAVGQTY") as Label;
                    Label lblSTDATE = rpItem.FindControl("lblSTDATE") as Label;
                    Label lblTMDATE = rpItem.FindControl("lblTMDATE") as Label;
                    Label lblDLDATE = rpItem.FindControl("lblDLDATE") as Label;
                    Label lblLWDATE = rpItem.FindControl("lblLWDATE") as Label;
                    Label lblENDATE = rpItem.FindControl("lblENDATE") as Label;
                    Label lblMCHTYP = rpItem.FindControl("lblMCHTYP") as Label;
                    Label lblSRMK1 = rpItem.FindControl("lblSRMK1") as Label;
                    Label lblSRMK2 = rpItem.FindControl("lblSRMK2") as Label;
                    Label lblSRMK3 = rpItem.FindControl("lblSRMK3") as Label;
                    Label lblSRMK4 = rpItem.FindControl("lblSRMK4") as Label;
                    Label lblSRMK5 = rpItem.FindControl("lblSRMK5") as Label;
                    Label lblEOQ = rpItem.FindControl("lblEOQ") as Label;
                    Label lblROP = rpItem.FindControl("lblROP") as Label;
                    Label lblTOTBK = rpItem.FindControl("lblTOTBK") as Label;
                    Label lblACTAL = rpItem.FindControl("lblACTAL") as Label;
                    Label lblAVGSHP = rpItem.FindControl("lblAVGSHP") as Label;
                    Label lblINST1 = rpItem.FindControl("lblINST1") as Label;
                    Label lblINST2 = rpItem.FindControl("lblINST2") as Label;
                    Label lblINST3 = rpItem.FindControl("lblINST3") as Label;
                    Label lblSEQ = rpItem.FindControl("lblSEQ") as Label;
                    Label lblCTRMID = rpItem.FindControl("lblCTRMID") as Label;
                    Label lblCUSRID = rpItem.FindControl("lblCUSRID") as Label;
                    Label lblCCHGDT = rpItem.FindControl("lblCCHGDT") as Label;
                    Label lblCCHGTM = rpItem.FindControl("lblCCHGTM") as Label;
                    Label lblCSTS = rpItem.FindControl("lblCSTS") as Label;


                    if (lblTMDATE.CssClass != "error")
                    {
                       
                        
                        int sd, sm, sy, ed, em, ey;
                        int shh, smm, sss, ehh, emm, ess;                        
                        string starty = "20"+ lblSTDATE.Text.Substring(1, 2);                        
                        string endy = "20"+lblTMDATE.Text.Substring(1, 2);

                        sd = int.Parse(lblSTDATE.Text.Substring(5, 2));
                        sm = int.Parse(lblSTDATE.Text.Substring(3, 2));

                        ed = int.Parse(lblTMDATE.Text.Substring(5, 2));
                        em = int.Parse(lblTMDATE.Text.Substring(3, 2));
                        

                        shh = 0;
                        smm = 0;
                        sss = 0;
                        ehh = 0;
                        emm = 0;
                        ess= 0;

                        #region [Save To Database]
                        Event eventdata = new Event();
                        eventdata.eventName = lblPLT.Text;
                        eventdata.startDay = sd.ToString();
                        eventdata.startMonth = sm.ToString();
                        eventdata.startYear = starty;
                        eventdata.startHour = shh.ToString();
                        eventdata.startMin = smm.ToString();

                        eventdata.endDay = ed.ToString();
                        eventdata.endMonth = em.ToString();
                        eventdata.endYear = endy;
                        eventdata.endHour = ehh.ToString();
                        eventdata.endMin = emm.ToString();

                        eventdata.otherInfo = "";
                        eventdata.backgroundColor = "#333333";
                        eventdata.foregroundColor = "#ffffff";
                         EventBLL oEventBLL = new EventBLL();
                         int r= oEventBLL.InsertEvents(eventdata);
                         #region [File Data]
                         if (r > 0)
                         {
                             eventdata.eventID = r;
                             eventdata.PLT = lblPLT.Text;
                             eventdata.DEPT = lblDEPT.Text;
                             eventdata.MACH = lblMACH.Text;
                             eventdata.YEARX = lblYEARX.Text;
                             eventdata.NUMX = lblNUMX.Text;
                             eventdata.UPC = lblUPC.Text;
                             eventdata.PDTNM = lblPDTNM.Text;
                             eventdata.PPDT3 = lblPPDT3.Text;
                             eventdata.PPDT4 = lblPPDT4.Text;
                             eventdata.PPDT5 = lblPPDT5.Text;
                             eventdata.ORDER = lblORDER.Text;
                             eventdata.RO = lblRO.Text;
                             eventdata.REPQTY = lblREPQTY.Text;
                             eventdata.SCHQTY = lblSCHQTY.Text;
                             eventdata.DLVQTY = lblDLVQTY.Text;
                             eventdata.AVGQTY = lblAVGQTY.Text;
                             eventdata.STDATE = lblSTDATE.Text;
                             eventdata.TMDATE = lblTMDATE.Text;
                             eventdata.DLDATE = lblDLDATE.Text;
                             eventdata.LWDATE = lblLWDATE.Text;
                             eventdata.ENDATE = lblENDATE.Text;
                             eventdata.MCHTYP = lblMCHTYP.Text;
                             eventdata.SRMK1 = lblSRMK1.Text;
                             eventdata.SRMK2 = lblSRMK2.Text;
                             eventdata.SRMK3 = lblSRMK3.Text;
                             eventdata.SRMK4 = lblSRMK4.Text;
                             eventdata.SRMK5 = lblSRMK5.Text;
                             eventdata.EOQ = lblEOQ.Text;
                             eventdata.ROP = lblROP.Text;
                             eventdata.TOTBK = lblTOTBK.Text;
                             eventdata.ACTAL = lblACTAL.Text;
                             eventdata.AVGSHP = lblAVGSHP.Text;
                             eventdata.INST1 = lblINST1.Text;
                             eventdata.INST2 = lblINST2.Text;
                             eventdata.INST3 = lblINST3.Text;
                             eventdata.SEQ = lblSEQ.Text;
                             eventdata.CTRMID = lblCTRMID.Text;
                             eventdata.CUSRID = lblCUSRID.Text;
                             eventdata.CCHGDT = lblCCHGDT.Text;
                             eventdata.CCHGTM = lblCCHGTM.Text;
                             eventdata.CSTS = lblCSTS.Text;

                             oEventBLL = new EventBLL();
                             r = oEventBLL.InsertFile(eventdata);
                         }
                         #endregion

                        #endregion
                    }
                }

                ClearResult();
            }
            catch(Exception ex)
            {

            }

        }
        #endregion
       
    }
}