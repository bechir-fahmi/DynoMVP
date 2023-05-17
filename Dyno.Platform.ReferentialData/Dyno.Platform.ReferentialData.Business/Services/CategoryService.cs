using AutoMapper;
using Dyno.Platform.ReferentialData.Business.IServices;
using Dyno.Platform.ReferentialData.BusinessModel.TicketData;
using Dyno.Platform.ReferentialData.DTO.TicketData;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferntialData.DataModel.PayementData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly IMapperSession<CategoryEntity> _mapperSession;
        public readonly IMapper _mapper;

        public CategoryService(IMapperSession<CategoryEntity> mapperSession, IMapper mapper)
        {
            _mapperSession = mapperSession;
                _mapper = mapper;
        }
        


        public void Create(CategoryDTO entity)
        {
            Category category = _mapper.Map<Category>(entity);
            CategoryEntity categoryEntity= _mapper.Map<CategoryEntity>(category);
            _mapperSession.Add(categoryEntity);
        }

        public void Delete(Guid id)
        {
            CategoryEntity categoryEntity = _mapperSession.GetById(id);
            _mapperSession.Delete(categoryEntity);
        }

        public IList<CategoryDTO> GetAll()
        {
           IList<CategoryEntity> categoryEntities = _mapperSession.GetAll();
            IList<Category> categories = _mapper.Map<IList<Category>>(categoryEntities);
            IList<CategoryDTO> categoryDTOs = _mapper.Map<IList<CategoryDTO>>(categories);
            return categoryDTOs;
        }

        public CategoryDTO GetById(Guid id)
        {
            CategoryEntity categoryEntity = _mapperSession.GetById(id);
            Category category = _mapper.Map<Category>(categoryEntity);
            CategoryDTO categoryDTO = _mapper.Map<CategoryDTO>(category);
            return categoryDTO;
        }

        public void Update(CategoryDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
