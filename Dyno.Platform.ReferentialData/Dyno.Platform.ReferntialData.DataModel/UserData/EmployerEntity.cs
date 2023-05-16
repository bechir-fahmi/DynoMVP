using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferntialData.DataModel.UserData
{
    public class EmployerEntity 
    {
        public virtual Guid Id { get; set; }
        public virtual UserEntity User { get; set; }
        
        public virtual  String? EntrepriseAdress { get; set; }
        
        public virtual String? EmailRH { get; set; }
      
        public virtual int NumTelRH { get; set; }
       
        public virtual String? PayementMethod { get; set; }
        
        public virtual String? AdressFacturation { get; set; }
        
        public virtual String? CodeTVA { get; set; }
        public virtual ICollection<EmployeeEntity>? Employees { get; set; }
        public virtual double Balance { get; set; }
    }
}
