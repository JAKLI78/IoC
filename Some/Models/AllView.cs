using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Some.Models
{
    public class AllView
    {
        public List<UserView> UserViews { get; set; }
        public List<CompanyView> CompanyViews { get; set; }

        public AllView(List<UserView> userViews, List<CompanyView> companyViews)
        {
            UserViews = userViews;
            CompanyViews = companyViews;
        }
    }
}