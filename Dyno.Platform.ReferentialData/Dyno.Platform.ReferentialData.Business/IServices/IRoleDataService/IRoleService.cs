using Dyno.Platform.ReferentialData.Business.IServices.IUserDataService;
using Dyno.Platform.ReferentialData.DTO.RoleData;
using Dyno.Platform.ReferntialData.DataModel.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices.IRoleDataService
{
    public interface IRoleService :IGenericService<RoleDTO>

    {
        Task<RoleDTO> GetByName(string name);
        Task<RoleDTO> GetById(string id);
        Task Delete(string id);
    }
}
