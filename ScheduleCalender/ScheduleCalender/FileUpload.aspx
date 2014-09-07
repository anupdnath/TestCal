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
        .td-dark-left
{
    text-align:center;
    padding-left:5px;
    font-weight:bold;
    background-color: rgb(89,106,114);
    color:#FFF;
    border-top-left-radius:5px;
    border-bottom-left-radius:5px;
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
                        <td style="text-align:center;" colspan="3">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="error" ValidationGroup="UPLOAD" />
                            <asp:Label ID="lblUploadErr" runat="server" CssClass="error"></asp:Label>
                        </td>
                    </tr>
                              <tr>
            <td id="tdCount" runat="server" visible="false" colspan="3">
                <asp:Literal ID="litTotalCount" runat="server"></asp:Literal> information Loaded.
                <br />
                <span id="spnErrorCount" runat="server" visible="false" class="error">
                    <asp:Literal ID="litErrorCount" runat="server"></asp:Literal> information contain error.
                </span>
                <asp:HiddenField ID="hidErrorCount" runat="server" />
            </td>
        </tr>
                    </table>
                </td>
            </tr>
            <tr>
            <td>
                <table id="tblMessages" width="100%" border="0" cellspacing="0" cellspacing="0" style="border-left: 1px solid #000; border-top:1px solid #000;">
                    <thead>
                        <tr>
                            <th class="bulletin_head">Title</th>
                            <th class="bulletin_head">Start Date</th>
                            <th class="bulletin_head">End Date</th>
                            <th class="bulletin_head">Other Info</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpUpload" runat="server" OnItemDataBound="rpUpload_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td class="td_whitenormal1" style="padding-left:10px;align-content:center;">
                                        <asp:Label ID="lblTitle" Text='<%# Eval("Title").ToString().Trim() %>' runat="server"></asp:Label>
                                    </td>
                                     <td class="td_whitenormal1" style="padding-left:10px;">
                                        <asp:Label ID="lblFrom" Text='<%# Eval("From").ToString().Trim() %>' runat="server"></asp:Label>
                                    </td>
                                     <td class="td_whitenormal1" style="padding-left:10px;">
                                        <asp:Label ID="lblTo" Text='<%# Eval("To").ToString().Trim() %>' runat="server"></asp:Label>
                                    </td>                                   
                                    <td class="td_whitenormal1" style="padding-left:10px;">
                                        <asp:Label ID="lblOther" Text='<%# Eval("Other").ToString().Trim() %>' runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </td>
        </tr>
            <tr>
            <td style="text-align:right;">
                <asp:Button ID="btnSave1" runat="server" Text="Submit" OnClick="btnSave1_Click" />
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
