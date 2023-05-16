using Dyno.Platform.ReferntialData.DataModel.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices
{
    public interface IGenericService<T>
    {
        IList<T> GetAll();
        T GetById(Guid id);
        T GetByUserName(string name);
        T GetByEmail(string email);
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid id);

    }
}
