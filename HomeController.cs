using Dynmmic_checkbox_value.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dynmmic_checkbox_value.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CollectionVM collectionVM = new CollectionVM();
            List<RiskCategoryOption> optionList = new List<RiskCategoryOption>();
            optionList.Add(new RiskCategoryOption() { OptionId = 1, RiskCategoryId=3, Text = "Objective Choice 1",isAvalable= false });
            optionList.Add(new RiskCategoryOption() { OptionId = 2, RiskCategoryId=3,Text = "Objective Choice 2",isAvalable = false });
            optionList.Add(new RiskCategoryOption() { OptionId = 3, RiskCategoryId=2,Text = "Objective Choice 3",isAvalable = false });
            optionList.Add(new RiskCategoryOption() { OptionId = 4, RiskCategoryId=2,Text = "Objective Choice 4",isAvalable= false});
            optionList.Add(new RiskCategoryOption() { OptionId = 5, RiskCategoryId = 2, Text = "Objective Choice 5", isAvalable = false });

            List<RiskCategoryQuestion> QuestionList = new List<RiskCategoryQuestion>();
            QuestionList.Add(new RiskCategoryQuestion() { RiskCategoryId = 1, Question = "Question1", FiledType = 1 });
            QuestionList.Add(new RiskCategoryQuestion() { RiskCategoryId = 2, Question = "Question2", FiledType = 2 });
            QuestionList.Add(new RiskCategoryQuestion() { RiskCategoryId = 3, Question = "Question3", FiledType = 3 });
            
            collectionVM.RiskCategoryOption = optionList;
            collectionVM.RiskCategoryQuestion = QuestionList;
            return View(collectionVM);
           // return View();
        }

        [HttpPost]
        public ActionResult Index(CollectionVM collectionVM)
        {
            //CollectionVM collectionVM = new CollectionVM();
            //List<ChoiceViewModel> choiceList = new List<ChoiceViewModel>();
            //choiceList.Add(new ChoiceViewModel() { SNo = 1, Text = "Objective Choice 1" });
            //choiceList.Add(new ChoiceViewModel() { SNo = 2, Text = "Objective Choice 2" });
            //choiceList.Add(new ChoiceViewModel() { SNo = 3, Text = "Objective Choice 3" });
            //choiceList.Add(new ChoiceViewModel() { SNo = 4, Text = "Objective Choice 4" });

            //collectionVM.ChoicesVM = choiceList;
            //collectionVM.SelectedChoices = new List<long>();
            //return View(collectionVM);
             return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}