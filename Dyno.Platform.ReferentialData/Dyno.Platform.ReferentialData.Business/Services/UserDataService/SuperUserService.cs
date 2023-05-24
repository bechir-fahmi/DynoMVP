using AutoMapper;
using Dyno.Platform.ReferentialData.Business.IServices;
using Dyno.Platform.ReferentialData.Business.IServices.IUserDataService;
using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using Microsoft.AspNetCore.Http;
using NHibernate;
using SimpleInjector.Advanced;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISession = NHibernate.ISession;

namespace Dyno.Platform.ReferentialData.Business.Services.UserDataService
{
    public class SuperUserService : ISuperUserService

    {
        public readonly IMapperSession<SuperUserEntity> _mapperSession;
        public readonly IMapper _mapper;
        public readonly ISession _session;

        public SuperUserService(IMapperSession<SuperUserEntity> mapperSession, IMapper mapper, ISession session)
        {
            _mapperSession = mapperSession;
            _mapper = mapper;
            _session = session;
        }

        public async Task Create(SuperUserDTO entity)
        {
            SuperUser superUser = _mapper.Map<SuperUser>(entity);
            SuperUserEntity superUserEntity = _mapper.Map<SuperUserEntity>(superUser);
            _mapperSession.Add(superUserEntity);
        }

        public void Delete(Guid id)
        {
            SuperUserEntity superUserEntity = _mapperSession.GetById(id);
            if (superUserEntity != null)
            {
                _mapperSession.Delete(superUserEntity);
            }
        }

        public IList<SuperUserDTO> GetAll()
        {
            IList<SuperUserEntity> superUserEntities=_mapperSession.GetAll();
            
            IList<SuperUser> superUsers = _mapper.Map<IList<SuperUser>>(superUserEntities);
            IList<SuperUserDTO> superUserDTOs = _mapper.Map<IList<SuperUserDTO>>(superUsers);
            return (List<SuperUserDTO>)superUserDTOs;

        }

        public SuperUserDTO GetByEmail(string email)
        {
            var query = _session.Query<SuperUserEntity>()
                .Where(e => e.User.Email == email);
            SuperUserEntity superUserEntity = query.Single();
            SuperUser superUser = _mapper.Map<SuperUser>(superUserEntity);
            SuperUserDTO superUserDTO = _mapper.Map<SuperUserDTO>(superUser);
            return superUserDTO;
        }

        public SuperUserDTO GetById(Guid id)
        {
            var query = _session.Query<SuperUserEntity>()
               .Where(e => e.Id == id);
            SuperUserEntity superUserEntity = query.Single();
            SuperUser superUser = _mapper.Map<SuperUser>(superUserEntity);
            SuperUserDTO superUserDTO = _mapper.Map<SuperUserDTO>(superUser);
            return superUserDTO;
        }

        public SuperUserDTO GetByUserName(string name)
        {
            var query = _session.Query<SuperUserEntity>()
               .Where(e => e.User.UserName == name);
            SuperUserEntity superUserEntity = query.Single();
            SuperUser superUser = _mapper.Map<SuperUser>(superUserEntity);
            SuperUserDTO superUserDTO = _mapper.Map<SuperUserDTO>(superUser);
            return superUserDTO;
        }

        public async Task Update(SuperUserDTO entity)
        {
            SuperUser superUser = _mapper.Map<SuperUser>(entity);
            SuperUserEntity superUserEntity = _mapper.Map<SuperUserEntity>(superUser);
            _mapperSession.Update(superUserEntity);
        }
    }
}
