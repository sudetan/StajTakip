using Staj1.Models;
using Staj1.FormReport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;

namespace Staj1.Controllers
{

    public class FormController : Controller
    {

        public ActionResult Form(StajBasvuruForm form)
        {
            OgrenciReport ogrenciReport = new OgrenciReport();
            byte[] abytes = ogrenciReport.ReportPdf(GetOgrenciler());

            return File(abytes, "application/pdf");
        }

        public List<StajBasvuruForm> GetOgrenciler()
        {
            List<StajBasvuruForm> ogreciler = new List<StajBasvuruForm>();
            StajBasvuruForm ogrenci = new StajBasvuruForm();
            return ogreciler;
        }
    }
}