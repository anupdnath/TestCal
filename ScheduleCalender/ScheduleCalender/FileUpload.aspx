<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="ScheduleCalender.FileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .td_whitenormal1 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            color: #000000;
            font-weight: normal;
            border-right: 1px solid #444;
            border-bottom: 1px solid #444; /*A1CDF2;*/
            padding: 1px;
            /*background-color:#FFFFFF*/
        }

        .bulletin_head {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            color: #000000;
            font-weight: bold;
            border-right: 1px solid #444; /*A1CDF2;*/
            border-bottom: 4px solid #000000;
            padding: 1px;
            background-color: #C2C2C2;
            text-align: center;
        }

        .lgn-heading {
            font-size: 16px;
            font-weight: bold;
            height: 30px;
            padding: 5px;
            padding-top: 2px;
            padding-bottom: 2px;
            color: #FFF;
            font-weight: bold;
            background: rgb(89,106,114); /* Old browsers */
            background: -moz-linear-gradient(left, rgba(89,106,114,1) 0%, rgba(206,220,231,1) 91%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, right top, color-stop(0%,rgba(89,106,114,1)), color-stop(91%,rgba(206,220,231,1))); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(left, rgba(89,106,114,1) 0%,rgba(206,220,231,1) 91%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(left, rgba(89,106,114,1) 0%,rgba(206,220,231,1) 91%); /* Opera 11.10+ */
            background: -ms-linear-gradient(left, rgba(89,106,114,1) 0%,rgba(206,220,231,1) 91%); /* IE10+ */
            background: linear-gradient(to right, rgba(89,106,114,1) 0%,rgba(206,220,231,1) 91%); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#596a72', endColorstr='#cedce7',GradientType=1 ); /* IE6-9 */
            border-top-left-radius: 5px;
            -moz-border-radius-topleft: 5px;
        }

        .td-dark-left {
            text-align: center;
            padding-left: 5px;
            font-weight: bold;
            background-color: rgb(89,106,114);
            color: #FFF;
            border-top-left-radius: 5px;
            border-bottom-left-radius: 5px;
        }

        .error {
            color: rgb(255,0,0);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0">
            <tr>
                <td class="lgn-heading">File Upload</td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td class="td-dark-left">Choose File</td>
                            <td class="td-light">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <asp:RequiredFieldValidator ID="reqValFile" runat="server" ControlToValidate="FileUpload1" Display="None" ErrorMessage="Please select a file to upload" ValidationGroup="UPLOAD"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="hidFileName" runat="server" />
                            </td>
                            <td>
                                <table width="100%" border="0">
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" ValidationGroup="UPLOAD" />
                                            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClientClick="document.forms[0].reset(); return false;" />
                                        </td>

                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;" colspan="3">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="error" ValidationGroup="UPLOAD" />
                                <asp:Label ID="lblUploadErr" runat="server" CssClass="error"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td id="tdCount" runat="server" visible="false" colspan="3">
                                <asp:Literal ID="litTotalCount" runat="server"></asp:Literal>
                                information Loaded.
                <br />
                                <span id="spnErrorCount" runat="server" visible="false" class="error">
                                    <asp:Literal ID="litErrorCount" runat="server"></asp:Literal>
                                    information contain error.
                                </span>
                                <asp:HiddenField ID="hidErrorCount" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table id="tblMessages" width="100%" border="0" cellspacing="0" cellspacing="0" style="border-left: 1px solid #000; border-top: 1px solid #000;">
                        <thead>
                            <tr>
                                <th class="bulletin_head">PLT</th>
                                <th class="bulletin_head">DEPT</th>
                                <th class="bulletin_head">MACH</th>
                                <th class="bulletin_head">YEARX</th>
                                <th class="bulletin_head">NUMX</th>
                                <th class="bulletin_head">UPC</th>
                                <th class="bulletin_head">PDTNM</th>
                                <th class="bulletin_head">PPDT3</th>
                                <th class="bulletin_head">PPDT4</th>
                                <th class="bulletin_head">PPDT5</th>
                                <th class="bulletin_head">ORDER#</th>
                                <th class="bulletin_head">RO</th>
                                <th class="bulletin_head">REPQTY</th>
                                <th class="bulletin_head">SCHQTY</th>
                                <th class="bulletin_head">DLVQTY</th>
                                <th class="bulletin_head">AVGQTY</th>
                                <th class="bulletin_head">STDATE</th>
                                <th class="bulletin_head">TMDATE</th>
                                <th class="bulletin_head">DLDATE</th>
                                <th class="bulletin_head">LWDATE</th>
                                <th class="bulletin_head">ENDATE</th>
                                <th class="bulletin_head">MCHTYP</th>
                                <th class="bulletin_head">SRMK1</th>
                                <th class="bulletin_head">SRMK2</th>
                                <th class="bulletin_head">SRMK3</th>
                                <th class="bulletin_head">SRMK4</th>
                                <th class="bulletin_head">SRMK5</th>
                                <th class="bulletin_head">EOQ</th>
                                <th class="bulletin_head">ROP</th>
                                <th class="bulletin_head">TOTBK</th>
                                <th class="bulletin_head">ACTAL</th>
                                <th class="bulletin_head">AVGSHP</th>
                                <th class="bulletin_head">INST1</th>
                                <th class="bulletin_head">INST2</th>
                                <th class="bulletin_head">INST3</th>
                                <th class="bulletin_head">SEQ#</th>
                                <th class="bulletin_head">CTRMID</th>
                                <th class="bulletin_head">CUSRID</th>
                                <th class="bulletin_head">CCHGDT</th>
                                <th class="bulletin_head">CCHGTM</th>
                                <th class="bulletin_head">CSTS</th>

                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpUpload" runat="server" OnItemDataBound="rpUpload_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblPLT" Text='<%# Eval("PLT").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblDEPT" Text='<%# Eval("DEPT").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblMACH" Text='<%# Eval("MACH").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblYEARX" Text='<%# Eval("YEARX").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblNUMX" Text='<%# Eval("NUMX").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblUPC" Text='<%# Eval("UPC").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblPDTNM" Text='<%# Eval("PDTNM").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblPPDT3" Text='<%# Eval("PPDT3").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblPPDT4" Text='<%# Eval("PPDT4").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblPPDT5" Text='<%# Eval("PPDT5").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblORDER" Text='<%# Eval("ORDER#").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblRO" Text='<%# Eval("RO").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblREPQTY" Text='<%# Eval("REPQTY").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblSCHQTY" Text='<%# Eval("SCHQTY").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblDLVQTY" Text='<%# Eval("DLVQTY").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblAVGQTY" Text='<%# Eval("AVGQTY").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblSTDATE" Text='<%# Eval("STDATE").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblTMDATE" Text='<%# Eval("TMDATE").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblDLDATE" Text='<%# Eval("DLDATE").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblLWDATE" Text='<%# Eval("LWDATE").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblENDATE" Text='<%# Eval("ENDATE").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblMCHTYP" Text='<%# Eval("MCHTYP").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblSRMK1" Text='<%# Eval("SRMK1").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblSRMK2" Text='<%# Eval("SRMK2").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblSRMK3" Text='<%# Eval("SRMK3").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblSRMK4" Text='<%# Eval("SRMK4").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblSRMK5" Text='<%# Eval("SRMK5").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblEOQ" Text='<%# Eval("EOQ").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblROP" Text='<%# Eval("ROP").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblTOTBK" Text='<%# Eval("TOTBK").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblACTAL" Text='<%# Eval("ACTAL").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblAVGSHP" Text='<%# Eval("AVGSHP").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblINST1" Text='<%# Eval("INST1").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblINST2" Text='<%# Eval("INST2").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblINST3" Text='<%# Eval("INST3").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblSEQ" Text='<%# Eval("SEQ#").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblCTRMID" Text='<%# Eval("CTRMID").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblCUSRID" Text='<%# Eval("CUSRID").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblCCHGDT" Text='<%# Eval("CCHGDT").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblCCHGTM" Text='<%# Eval("CCHGTM").ToString().Trim() %>' runat="server"></asp:Label></td>
                                        <td class="td_whitenormal1" style="padding-left: 10px; align-content: center;">
                                            <asp:Label ID="lblCSTS" Text='<%# Eval("CSTS").ToString().Trim() %>' runat="server"></asp:Label></td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    <asp:Button ID="btnSave1" runat="server" Text="Submit" OnClick="btnSave1_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
