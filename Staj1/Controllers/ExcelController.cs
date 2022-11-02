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

namespace Staj1.Controllers
{
    public class ExcelController : Controller
    {
        // GET: Excel
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Staj1"].ConnectionString);
        OleDbConnection Econ;
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(HttpPostedFileBase file)
        {
            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            String filepath = "/excelfolder/" + filename;
            file.SaveAs(Path.Combine(Server.MapPath("/excelfolder/"), filename));
            InsertExceldata(filepath, filename);
            return View();
        }

        private void ExcelConn(string filepath)
        {
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", filepath);
            Econ = new OleDbConnection(constr);

        }

        private void InsertExceldata(string filepath, string filename)
        {
            string fullpath = Server.MapPath("/excelfolder/") + filename;
            ExcelConn(fullpath);
            string query = string.Format("Select * from [{0}]", "Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);
            Econ.Close();
            oda.Fill(ds);

            DataTable dt = ds.Tables[0];

            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            objbulk.DestinationTableName = "Kullanici";
            objbulk.ColumnMappings.Add("Numara", "Numara");
            objbulk.ColumnMappings.Add("Adi", "Adi");
            objbulk.ColumnMappings.Add("Soyadi", "Soyadi");
            objbulk.ColumnMappings.Add("Mail", "Mail");
            con.Open();
            objbulk.WriteToServer(dt);
            con.Close();
        }
    }
}