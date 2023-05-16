using Dyno.Platform.ReferntialData.DataModel.UserData;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferntialData.DataModel.PayementData
{
    public class PayementEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual int DayOfWork { get; set; }
        public virtual EmployeeEntity Employee { get; set; }
        public virtual EmployerEntity Employer { get; set; }
    }
}
