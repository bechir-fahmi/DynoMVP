using Dyno.Platform.ReferentialData.DTO.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.DTO.TicketData
{
    public class PayementDTO
    {
        public Guid Id { get; set; }
        public DateTime date { get; set; }
        public int DayOfWork { get; set; }
        public EmployeeDTO Employee { get; set; }
        public EmployerDTO Employer { get; set; }
    }
}
