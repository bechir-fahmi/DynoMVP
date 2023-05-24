using Dyno.Platform.ReferentialData.DTO.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices.IUserDataService
{
    public interface ICasierService : IGenericService<CasierDTO>
    {
        CasierDTO GetByEmail(string email);
        CasierDTO GetById(Guid id);
        void Delete(Guid id);
        CasierDTO GetByUserName(string name);
    }
}
