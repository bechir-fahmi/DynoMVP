using Dyno.Platform.ReferentialData.DTO.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices.IUserDataService
{
    public interface IResponsibleFinancierService : IGenericService<ResponsibleFinancierDTO>
    {
        ResponsibleFinancierDTO GetByEmail(string email);
        ResponsibleFinancierDTO GetById(Guid id);
        void Delete(Guid id);
        ResponsibleFinancierDTO GetByUserName(string name);
    }
}
