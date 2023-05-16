using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.BusinessModel.UserData
{
    public class Employer
    {
        public Guid Id { get; set; }
        public User? User { get; set; }
        public String? EntrepriseAdress { get; set; }
        public String? EmailRh { get; set; }
        public int NumTelRH { get; set; }
        public String? PayementMethod { get; set; }
        public String? AdressFacturation { get; set; }
        public String? CodeTVA { get; set; }
        public double Balance { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
