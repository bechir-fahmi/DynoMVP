using Dyno.Platform.ReferntialData.DataModel.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.BusinessModel.UserData
{
    public class Employee 
    {
        public Guid Id { get; set; } 
        public String? Adress { get; set; }
        public double Balance { get; set; }
        public User user { get; set; }        
        public List<Employer>? Employers { get; set; }
    }
}
