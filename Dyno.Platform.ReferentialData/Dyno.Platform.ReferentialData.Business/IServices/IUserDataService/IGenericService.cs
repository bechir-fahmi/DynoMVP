using Dyno.Platform.ReferentialData.DTO.RoleData;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using Platform.Shared.Result;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices.IUserDataService
{
    public interface IGenericService<T>
    {
        IList<T> GetAll();
        Task<OperationResult> Create(T entity);
        Task Update(T entity);
        


    }
}
