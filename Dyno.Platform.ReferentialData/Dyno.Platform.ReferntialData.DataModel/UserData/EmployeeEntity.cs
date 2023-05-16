using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dyno.Platform.ReferntialData.DataModel.UserData
{
    public class EmployeeEntity 
    {
        public virtual Guid Id { get; set; }
        [Required]
        public virtual String? Adress { get; set; }
        public virtual ICollection<EmployerEntity>? Employers { get; set; }
        [Required]
        public virtual double Balance { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
