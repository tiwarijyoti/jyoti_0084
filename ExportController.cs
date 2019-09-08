using DocumentFormat.OpenXml.Spreadsheet;
using ExportExcel.Code;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExportExcel.Controllers
{
    public class ExportController : Controller
    {
        // GET: Export
        public ActionResult Index()
        {
            Random rand = new Random();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Area", typeof(string));
            dt.Columns.Add("Area Element", typeof(string));

            for (int i = 0; i < 1; ++i)
            {
                //dt.Rows.Add(string.Format("Prod{0}", rand.Next(5)),
                //    string.Format("{0}.{1}.{2}.{3}", rand.Next(256), rand.Next(256), rand.Next(256), rand.Next(256)),
                //    DateTime.UtcNow.AddDays(rand.NextDouble() * 20),
                //    decimal.Round((decimal)(rand.NextDouble() * 500 + 200), 4),
                //    decimal.Round((decimal)(rand.NextDouble() * 20 + 5), 2));
                dt.Rows.Add(("Area"), ("Area Element"));
            }

            //System.Data.DataTable dt = new System.Data.DataTable();
            //dt.Columns.Add("Product", typeof(string));
            //dt.Columns.Add("IP Address", typeof(string));
            //dt.Columns.Add("Date (UTC)", typeof(DateTime));
            //dt.Columns.Add("Size (MB)", typeof(double));
            //dt.Columns.Add("Cost", typeof(decimal));


            //for (int i = 0; i < 10; ++i)
            //{
            //    dt.Rows.Add(string.Format("Prod{0}", rand.Next(5)),
            //        string.Format("{0}.{1}.{2}.{3}", rand.Next(256), rand.Next(256), rand.Next(256), rand.Next(256)),
            //        DateTime.UtcNow.AddDays(rand.NextDouble() * 20),
            //        decimal.Round((decimal)(rand.NextDouble() * 500 + 200), 4),
            //        decimal.Round((decimal)(rand.NextDouble() * 20 + 5), 2));
            //}

            SLDocument sl = new SLDocument();

            int iStartRowIndex = 3;
            int iStartColumnIndex = 2;

            //SLTable tbl = sl.CreateTable("B2", "G6");
            //tbl.SetTableStyle(SLTableStyleTypeValues.Medium4);
            //sl.InsertTable(tbl)

            sl.ImportDataTable(iStartRowIndex, iStartColumnIndex, dt, true);

            // This part sets the style, but you might be using a template,
            // so the styles are probably already set.
            SLStyle style = sl.CreateStyle();
            //for (int i = 0; i < dt.Rows.Count + 1; i++)
            //{
            //    style.Border.LeftBorder.BorderStyle = BorderStyleValues.Thick;
            //    style.Border.LeftBorder.Color = System.Drawing.Color.Black;
            //    sl.SetColumnStyle(iStartRowIndex, style);
            //}

            style.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            style.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            style.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            style.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;

            style.Border.TopBorder.Color = System.Drawing.Color.Black;
            style.Border.LeftBorder.Color = System.Drawing.Color.Black;
            style.Border.RightBorder.Color = System.Drawing.Color.Black;
            style.Border.BottomBorder.Color = System.Drawing.Color.Black;

            int iEndRowIndex = iStartRowIndex + dt.Rows.Count + 1 - 1;
            int iEndColumnIndex = iStartColumnIndex + dt.Columns.Count;


            sl.SetRowStyle(iStartRowIndex, iEndColumnIndex, style);
            sl.SetColumnStyle(iStartColumnIndex, iEndColumnIndex, style);
            
            //style.FormatCode = "#,##0.0000";
            //sl.SetColumnStyle(5, style);

            //style.FormatCode = "$#,##0.00";
            //sl.SetColumnStyle(6, style);

            // The next part is optional, but it shows how you can set a table on your
            // data based on your DataTable's dimensions.

            // + 1 because the header row is included
            // - 1 because it's a counting thing, because the start row is counted.
            //int iEndRowIndex = iStartRowIndex + dt.Rows.Count + 1 - 1;
            //// - 1 because it's a counting thing, because the start column is counted.
            //int iEndColumnIndex = iStartColumnIndex + dt.Columns.Count - 1;

            //// format cells - add borders
            //using (ExcelRange r = workiStartRowIndex + 1, 1, iStartRowIndex + dt.Rows.Count, dt.Columns.Count])
            //{
            //    r.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            //    r.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            //    r.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            //    r.Style.Border.Right.Style = ExcelBorderStyle.Thin;

            //    r.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
            //    r.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
            //    r.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
            //    r.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
            //}

            //SLTable table = sl.CreateTable(iStartRowIndex, iStartColumnIndex, iEndRowIndex, iEndColumnIndex);
            //table.SetTableStyle(S)
            //table.SetTableStyle(SLTableStyleTypeValues.Medium17);
            //table.SetTableStyle(SLTableStyleTypeValues.Medium17);
            //table.SetTableStyle(sl);
            //table.HasTotalRow = true;
            //table.SetTotalRowFunction(5, SLTotalsRowFunctionValues.Sum);
            //sl.InsertTable(table);


            sl.SaveAs(@"E:\\ImportDataTable11.xlsx");

            //Console.WriteLine("End of program");
            //Console.ReadLine();
            //return View();
            List<Technology> technologies = StaticData.Technologies;
            string[] columns = { "Name", "Project", "Developer" };
            byte[] filecontent = ExcelExportHelper.ExportExcel(technologies, "Technology", true, columns);
            return File(filecontent, ExcelExportHelper.ExcelContentType, "Technologies.xlsx");
           // return View();
        }
    }
}