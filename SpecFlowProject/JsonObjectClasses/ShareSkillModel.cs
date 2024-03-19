using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.JsonObjectClasses
{
    public class ShareSkillModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string CategoryTags { get; set; }
        public string ServiceType { get; set; }
        public string LocationType { get; set; }


        public string AvailableStartDate { get; set; }
        public string AvailableStartTime { get; set;}
        public string AvailableEndTime { get; set;}
        public string AvailableEndDate { get; set;}

        public string SkillTrade {  get; set; }

        public string SkillExchangeTag { get; set; }
        public string Amount { get; set; }

        public string ActiveStatus { get; set; }



    }
}
