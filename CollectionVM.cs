using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dynmmic_checkbox_value.Models
{
    public class CollectionVM
    {
        public List<RiskCategoryOption> RiskCategoryOption { get; set; }
        public List<RiskCategoryQuestion> RiskCategoryQuestion { get; set; }
    }

    public class RiskCategoryOption
    {
        public int OptionId { get; set; }
        public int RiskCategoryId { get; set; }              
        public string Text { get; set; }
        public bool isAvalable { get; set; }
        public string SelectedPaymentType { set; get; }
    }

    public class RiskCategoryQuestion
    {
        public int RiskCategoryId { get; set; }
        public string Question { get; set; }
        public int FiledType { get; set; }        
    }
}