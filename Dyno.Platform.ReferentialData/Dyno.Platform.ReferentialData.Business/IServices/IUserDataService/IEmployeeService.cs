using Dyno.Platform.ReferentialData.DTO.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices.IUserDataService
{
    public interface IEmployeeService : IGenericService<EmployeeDTO>
    {
        EmployeeDTO GetByEmail(string email);
        EmployeeDTO GetById(Guid id);
        void Delete(Guid id);
        EmployeeDTO GetByUserName(string name);
    }
}
