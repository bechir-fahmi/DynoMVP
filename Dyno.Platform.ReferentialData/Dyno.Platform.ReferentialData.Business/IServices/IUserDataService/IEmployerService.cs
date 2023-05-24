using Dyno.Platform.ReferentialData.DTO.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices.IUserDataService
{
    public interface IEmployerService : IGenericService<EmployerDTO>
    {
        EmployerDTO  GetByEmail(string email);
        EmployerDTO GetById(Guid id);
        void Delete(Guid id);
        EmployerDTO GetByUserName(string name);
    }
}
