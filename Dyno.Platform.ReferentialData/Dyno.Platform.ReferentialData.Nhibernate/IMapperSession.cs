using Dyno.Platform.ReferentialData.DTO.UserData;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Nhibernate
{
    public interface IMapperSession<T>
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        void  Add(T entity);
        void Delete(T entity);
        T GetById(Guid id);
       IList<T> GetAll();
        IQueryable<T> Entity { get; }
    }
}
