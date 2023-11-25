using Platform.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Shared.GenericService
{
    public interface IGenericAsyncService<DTO, Entity, TypeId, T>
    {
        List<DTO> GetAll();

        #region Asynchronously Method
        Task<DTO> GetById(TypeId id);
        Task<OperationResult<T>> Create(DTO entity);
        Task<OperationResult<T>> Update(DTO entity);
        Task<OperationResult<T>> Delete(TypeId id);
        #endregion

    }
}
