using ExportExcel.Code;
using ExportExcel.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ExportExcel.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            TechnologyViewModel model = new TechnologyViewModel();
            return View(model);
        }

        [HttpGet]
        public FileContentResult ExportToExcel()
        {
            List<Technology> technologies = StaticData.Technologies;
            string[] columns = {"Name","Project","Developer"};
            byte[] filecontent = ExcelExportHelper.ExportExcel(technologies, "Technology", true,columns );
            return File(filecontent, ExcelExportHelper.ExcelContentType, "Technologies.xlsx");
        }

    }
}