using Dyno.Platform.ReferentialData.DTO.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices.IUserDataService
{
    public interface ISuperUserService : IGenericService<SuperUserDTO>
    {
        SuperUserDTO GetByEmail(string email);
        SuperUserDTO GetById(Guid id);
        void Delete(Guid id);
        SuperUserDTO GetByUserName(string name);
    }
}
