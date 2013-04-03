using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportPortal
{
    public class Sales : Page
    {
        protected global::Microsoft.Reporting.WebForms.ReportViewer ReportViewer;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                ReportViewer.ServerReport.Timeout = 999999;
                ReportViewer.ShowParameterPrompts = true;
                ReportViewer.ServerReport.ReportServerCredentials = new ReportServerCredentials("ReportUser", "Popov2010", "win-uhs144f12ua");
                ReportViewer.ServerReport.ReportServerUrl = new Uri("http://88.198.7.228/ReportServer_DESCARTES");
                ReportViewer.ServerReport.ReportPath = "/LarrysListReports/Sales"; //+ ConfigurationManager.AppSettings["env"];
            }

        }
     }
    
    
    }

