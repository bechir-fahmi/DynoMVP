using AutoMapper;
using Dyno.Platform.ReferentialData.Business.IServices;
using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using Newtonsoft.Json;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.Services
{
    public class CasierService : ICasierService
    {
        public readonly IMapperSession<CasierEntity> _mapperSession;
        public readonly IMapper _mapper;
        private readonly ISession _session;


        public CasierService(IMapperSession<CasierEntity> mapperSession,
            IMapper mapper, ISession session)

        {
            _mapperSession = mapperSession;
            _mapper = mapper;
            _session = session;



        }


        public void Create(CasierDTO casierDTO)
        {
            Casier casier = _mapper.Map<Casier>(casierDTO);
            CasierEntity casierEntity = _mapper.Map<CasierEntity>(casier);

            _mapperSession.Add(casierEntity);

        }

        public void Delete(Guid id)
        {
            CasierEntity casierEntity = _mapperSession.GetById(id);
            if (casierEntity != null)
            {
                _mapperSession.Delete(casierEntity);

            }



        }

        public IList<CasierDTO> GetAll()
        {
            UserEntity userEntity = null;
            var query = _session.QueryOver<CasierEntity>();
            IList<CasierEntity> casierEntities = query.List<CasierEntity>();

            IList<Casier> casiers = _mapper.Map<IList<Casier>>(casierEntities);
            IList<CasierDTO> casierDTOs = _mapper.Map<IList<CasierDTO>>(casiers);
            
            return casierDTOs;


        }

        public CasierDTO GetByEmail(string email)
        {
            var query = _session.QueryOver<CasierEntity>()
                         .Where(e => e.User.Email == email)
                         .SingleOrDefault();
            Casier casier = _mapper.Map<Casier>(query);
            CasierDTO casierDTO = _mapper.Map<CasierDTO>(casier);
           
            return casierDTO;

        }

        public CasierDTO GetById(Guid id)
        {
            var query = _session.Query<CasierEntity>()
                         .Where(e => e.Id == id)
                         .SingleOrDefault();
            Casier casier = _mapper.Map<Casier>(query);
            CasierDTO casierDTO = _mapper.Map<CasierDTO>(casier);
           
            return casierDTO;
        }


        public CasierDTO GetByUserName(string name)
        {
            var query = _session.QueryOver<CasierEntity>()
                         .Where(e => e.User.UserName == name)
                         .SingleOrDefault();
            Casier casier = _mapper.Map<Casier>(query);
            CasierDTO casierDTO = _mapper.Map<CasierDTO>(casier);
            
            return casierDTO;
        }

        public void Update(CasierDTO userDTO)
        {
            throw new NotImplementedException();
        }

    }
}
