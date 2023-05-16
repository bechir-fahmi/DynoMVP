using AutoMapper;
using Dyno.Platform.ReferentialData.Business.IServices;
using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferntialData.DataModel.UserData;

using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NHibernate.Engine.Query.CallableParser;

namespace Dyno.Platform.ReferentialData.Business.Services
{
    public class EmployerService : IEmployerService
    {
        public readonly IMapperSession<EmployerEntity> _mapperSession;
        public readonly IMapper _mapper;
        private readonly ISession _session;
        public EmployerService(IMapperSession<EmployerEntity> mapperSession,
            IMapper mapper, ISession session)

        {
            _mapperSession = mapperSession;
            _mapper = mapper;
            _session = session;
        }
        public void Create(EmployerDTO entity)
        {
            Employer employer = _mapper.Map<Employer>(entity);
            EmployerEntity userEntity = _mapper.Map<EmployerEntity>(employer);

            _mapperSession.Add(userEntity);
        }

        public void Delete(Guid id)
        {
            EmployerEntity employerEntity = _mapperSession.GetById(id);
            
            if (employerEntity != null) 
            { 
            
                _mapperSession.Delete(employerEntity);
            
            
            }

        }

        [Obsolete]
        public IList<EmployerDTO> GetAll()
        {
            
            var query = _session.QueryOver<EmployerEntity>();
                         
            IList<EmployerEntity> employerEntities = query.List<EmployerEntity>();
            foreach (var entity in employerEntities)
            {
                foreach (var employee in entity.Employees) { employee.Employers = null; }
            }

            IList<Employer> employers = _mapper.Map<IList<Employer>>(employerEntities);
            IList<EmployerDTO> employerDTOs = _mapper.Map<IList<EmployerDTO>>(employers);
            
            return (List<EmployerDTO>)employerDTOs;
        }

        public EmployerDTO GetByEmail(string email)
        {
            var query=_session.Query<EmployerEntity>()
                .Where(e=>e.User.Email==email);
           EmployerEntity employerEntity=query.Single<EmployerEntity>();
            
            foreach (var employee in employerEntity.Employees) { employee.Employers = null; }

            Employer employer=_mapper.Map<Employer>(employerEntity);
            EmployerDTO employerDTO=_mapper.Map<EmployerDTO>(employer);
           

            return employerDTO;

        }

        public EmployerDTO GetById(Guid id)
        {
            var query = _session.Query<EmployerEntity>()
               .Where(e => e.Id == id);
               EmployerEntity employerEntity = query.Single<EmployerEntity>();

            foreach (var employee in employerEntity.Employees) { employee.Employers = null; }
            Employer employer = _mapper.Map<Employer>(employerEntity);
            EmployerDTO employerDTO = _mapper.Map<EmployerDTO>(employer);
           

            return employerDTO;
        }
        public EmployerDTO GetByUserName(string name)
        {
            var query = _session.Query<EmployerEntity>()
               .Where(e => e.User.UserName == name);
               EmployerEntity employerEntity = query.Single<EmployerEntity>();

            foreach (var employee in employerEntity.Employees) { employee.Employers = null; }
            Employer employer = _mapper.Map<Employer>(employerEntity);
            EmployerDTO employerDTO = _mapper.Map<EmployerDTO>(employer);
            
            return employerDTO;
        }

        public void Update(EmployerDTO entity)
        {
            throw new NotImplementedException();
        }
       

    }
}
