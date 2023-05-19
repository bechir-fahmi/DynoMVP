using AutoMapper;
using Dyno.Platform.ReferentialData.Business.IServices;
using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static NHibernate.Engine.Query.CallableParser;

namespace Dyno.Platform.ReferentialData.Business.Services
{
    public class ShopOwnerService : IShopOwnerService
    {

        public readonly IMapperSession<ShopOwnerEntity> _mapperSession;
        public readonly IMapper _mapper;
        private readonly ISession _session;


        public ShopOwnerService(IMapperSession<ShopOwnerEntity> mapperSession,
            IMapper mapper, ISession session)

        {
            _mapperSession = mapperSession;
            _mapper = mapper;
            _session = session;



        }


        public async Task Create(ShopOwnerDTO shopOwnerDTO)
        {
            ShopOwner shopOwner = _mapper.Map<ShopOwner>(shopOwnerDTO);
            ShopOwnerEntity shopOwnerEntity = _mapper.Map<ShopOwnerEntity>(shopOwner);

            _mapperSession.Add(shopOwnerEntity);

        }

        public void Delete(Guid id)
        {
            ShopOwnerEntity shopOwner = _mapperSession.GetById(id);
            if (shopOwner != null)
            {
                _mapperSession.Delete(shopOwner);

            }



        }

        public IList<ShopOwnerDTO> GetAll()
        {

            var query = _session.QueryOver<ShopOwnerEntity>();
                         
            IList<ShopOwnerEntity> shopOwnerEntities = query.List<ShopOwnerEntity>();

            IList<ShopOwner> shopOwners = _mapper.Map<IList<ShopOwner>>(shopOwnerEntities);
            IList<ShopOwnerDTO> shopOwnerDTOs = _mapper.Map<IList<ShopOwnerDTO>>(shopOwners);

            
            return shopOwnerDTOs;


        }

        public ShopOwnerDTO GetByEmail(string email)
        {
            var query = _session.QueryOver<ShopOwnerEntity>()
                         .Where(e => e.User.Email == email)
                         .SingleOrDefault();
            ShopOwner shopOwner = _mapper.Map<ShopOwner>(query);
            ShopOwnerDTO shopOwnerDTO = _mapper.Map<ShopOwnerDTO>(shopOwner);
            
            return shopOwnerDTO;

        }

        public ShopOwnerDTO GetById(Guid id)
        {
            var query = _session.Query<ShopOwnerEntity>()
                         .Where(e => e.Id == id)
                         .SingleOrDefault();
            ShopOwner shopOwner = _mapper.Map<ShopOwner>(query);
            ShopOwnerDTO shopOwnerDTO = _mapper.Map<ShopOwnerDTO>(shopOwner);
           
            return shopOwnerDTO;
        }


        public ShopOwnerDTO GetByUserName(string name)
        {
            var query = _session.QueryOver<ShopOwnerEntity>()
                         .Where(e => e.User.UserName == name)
                         .SingleOrDefault();
            ShopOwner shopOwner = _mapper.Map<ShopOwner>(query);
            ShopOwnerDTO shopOwnerDTO = _mapper.Map<ShopOwnerDTO>(shopOwner);
            
            return shopOwnerDTO;
        }

        
        public void Update(ShopOwnerDTO entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
