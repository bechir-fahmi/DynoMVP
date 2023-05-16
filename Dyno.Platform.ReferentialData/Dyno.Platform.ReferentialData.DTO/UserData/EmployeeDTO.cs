using Dyno.Platform.ReferntialData.DataModel.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.DTO.UserData
{
    public class EmployeeDTO
    {
        public Guid    Id { get; set; }
        
        public String? Adress { get; set; }
        public double Balance { get; set; }
        public UserDTO User { get; set; }
        public  List<EmployerDTO>? Employers { get; set; }
        
    }
}
