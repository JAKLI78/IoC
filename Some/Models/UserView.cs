using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Some.Models
{
    public class UserView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> CompanyId { get; set; }
    }
}