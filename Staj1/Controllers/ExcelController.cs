using Staj1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;


namespace Staj1.Controllers
{
    public class ExcelController : Controller
    {
        // GET: Excel
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        Staj1DB context = new Staj1DB();

        OleDbConnection Econ;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExcelPage()
        {
            return View();
        }

        [HttpPost]

        public bool Index(HttpPostedFileBase file)
        {
           
            InsertExceldata(file);
            return false;
        }

        private void ExcelConn(string filepath)
        {
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", filepath);
            Econ = new OleDbConnection(constr);

        }

        private ActionResult InsertExceldata(HttpPostedFileBase excelFile)
        {

            if (excelFile == null
            || excelFile.ContentLength == 0)
            {
                ViewBag.Error = "Lütfen dosya seçimi yapınız.";

                return View();
            }
            else
            {
                //Dosyanın uzantısı xls ya da xlsx ise;
                if (excelFile.FileName.EndsWith("xls")
                || excelFile.FileName.EndsWith("xlsx"))
                {
                    //Seçilen dosyanın nereye yükleneceği seçiliyor.
                    string path = Server.MapPath("~/Content/" + excelFile.FileName);

                    //Dosya kontrol edilir, varsa silinir.
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    //Excel path altına kaydedilir.
                    excelFile.SaveAs(path);

                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;

                   List<Kullanici> localList = new List<Kullanici>();

                    for (int i = 2; i <= range.Rows.Count; i++)
                    {
                        Kullanici lm = new Kullanici();

                        lm.Numara= ((Excel.Range)range.Cells[i, 1]).Text;
                        lm.Adi = ((Excel.Range)range.Cells[i, 2]).Text;
                        lm.Soyadi = ((Excel.Range)range.Cells[i, 3]).Text;
                        lm.Mail = ((Excel.Range)range.Cells[i, 4]).Text;

                        localList.Add(lm);
                    }

                    application.Quit();

                    ViewBag.ListDetay = localList;


                    foreach (var item in localList)
                    {
                        //Rol kullanici = context.Rol.FirstOrDefault(x => x.RolAdi == "Kullanici");
                        //KullaniciRol kr = new KullaniciRol();
                        bool kayitOlustur = new AdminController().InsertUser(item);
                        
                    }

                    return View();
                }
                else
                {
                    ViewBag.Error = "Dosya tipiniz yanlış, lütfen '.xls' yada '.xlsx' uzantılı dosya yükleyiniz.";

                    return View();
                }
            }
        }
        //{
        //    string fullpath = Server.MapPath("/excelfolder/") + filename;
        //    ExcelConn(fullpath);
        //    string query = string.Format("Select * from [{0}]", "Sheet1$");
        //    OleDbCommand Ecom = new OleDbCommand(query, Econ);
        //    Econ.Open();

        //    DataSet ds = new DataSet();
        //    OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);
        //    Econ.Close();
        //    oda.Fill(ds);

        //    DataTable dt = ds.Tables[0];

        //    SqlBulkCopy objbulk = new SqlBulkCopy(con);
        //    objbulk.DestinationTableName = "Kullanici";
        //    objbulk.ColumnMappings.Add("Numara", "Numara");
        //    objbulk.ColumnMappings.Add("Adi", "Adi");
        //    objbulk.ColumnMappings.Add("Soyadi", "Soyadi");
        //    objbulk.ColumnMappings.Add("Mail", "Mail");
        //    con.Open();
        //    objbulk.WriteToServer(dt);
        //    con.Close();
        //}
    }
}