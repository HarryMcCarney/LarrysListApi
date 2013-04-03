<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  Inherits="ReportPortal.Sales" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="reportViewer">
        <rsweb:ReportViewer ID="ReportViewer" runat="server" Font-Names="Verdana" Font-Size="8pt"  ProcessingMode="Remote" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="954px" ShowBackButton="False" ShowCredentialPrompts="False" ShowDocumentMapButton="False" ShowFindControls="False" ShowPageNavigationControls="True" ShowParameterPrompts="False" ShowPrintButton="False" ShowPromptAreaButton="False" ShowRefreshButton="False" ShowWaitControlCancelLink="False" ShowZoomControl="False" SizeToReportContent="True" Width="1380px">
</rsweb:ReportViewer>
</asp:Content>

 
 
     

