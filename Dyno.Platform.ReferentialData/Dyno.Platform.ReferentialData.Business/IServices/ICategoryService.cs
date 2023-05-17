using Dyno.Platform.ReferentialData.DTO.TicketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices
{
    public interface ICategoryService
    {
       IList<CategoryDTO> GetAll();
        CategoryDTO GetById(Guid id);
        void Create(CategoryDTO entity);
        void Update(CategoryDTO entity);
        void Delete(Guid id);
    }
}
