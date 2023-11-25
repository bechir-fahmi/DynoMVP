using Platform.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Shared.GenericService
{
    public interface IGenericSyncService<DTO, Entity, TypeId, T>
    {
        List<DTO> GetAll();


        #region Synchronously Method
        DTO GetById(TypeId id);
        OperationResult<T> Create(DTO entity);
        OperationResult<T> Update(DTO entity);
        OperationResult<T> Delete(TypeId id);
        #endregion
    }
}
