<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="ScheduleCalender.FileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                                        <td style="text-align: left;">
                                            <a href="#" id="uploadFormat" title="">View Upload Format</a>
                                        </td>
                                        <td style="text-align: right;">
                                            <%--<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" ValidationGroup="UPLOAD" />
                                            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClientClick="document.forms[0].reset(); return false;" />--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
