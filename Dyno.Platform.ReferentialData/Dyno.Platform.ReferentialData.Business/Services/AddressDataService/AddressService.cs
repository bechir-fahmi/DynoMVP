using AutoMapper;
using Dyno.Platform.ReferentialData.Business.IServices.IAddressDataService;
using Dyno.Platform.ReferentialData.BusinessModel.AddressData;
using Dyno.Platform.ReferentialData.DTO.AddressData;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferntialData.DataModel.AddressData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.Services.AddressDataService
{
    public class AddressService : IAddressService
    {
        public readonly IMapper _mapper;
        public readonly IMapperSession<AddressEntity> _mapperSession;
        public AddressService(IMapper mapper, IMapperSession<AddressEntity> mapperSession) 
        {
            _mapper = mapper;
            _mapperSession = mapperSession;
        }
        public void CreateAddress(AddressDTO addressDTO)
        {
            Address address = _mapper.Map<Address>(addressDTO);
            AddressEntity addressEntity = _mapper.Map<AddressEntity>(address);
            _mapperSession.Add(addressEntity);
        }

        public void DeleteAddress(int id)
        {
            AddressEntity addressEntity = _mapperSession.GetById(id);
            _mapperSession.Delete(addressEntity);
        }

        public AddressDTO GetAddressByName(string adressName)
        {
            AddressEntity addressEntity = _mapperSession.GetByExpression(address => address.AddressName == adressName);
            Address address = _mapper.Map<Address>(addressEntity);
            AddressDTO addressDTO = _mapper.Map<AddressDTO>(address);
            return addressDTO ;
        }

        public IList<AddressDTO> GetAddressByUserId(string userId)
        {
            IList<AddressEntity> addressEntities = _mapperSession.GetAllByExpression(address => address.User.Id  == userId);
            foreach (var address in addressEntities)
            {
                address.User = null;

            }
            IList<Address> addresses = _mapper.Map<IList<Address>>(addressEntities);    
            IList<AddressDTO> addressDTOs = _mapper.Map<IList<AddressDTO>>(addresses);
            return addressDTOs;
        }

        public IList<AddressDTO> GetAllAddresses()
        {
            IList<AddressEntity> addressEntities = _mapperSession.GetAll();
            foreach (var address in addressEntities)
            {
                address.User = null;

            }
            IList<Address> addresses = _mapper.Map<IList<Address>>(addressEntities);
            IList<AddressDTO> addressDTOs = _mapper.Map<IList<AddressDTO>>(addresses) ;
            return addressDTOs;
        }

        public void UpdateAddress(AddressDTO addressDTO)
        {
            Address address = _mapper.Map<Address>(addressDTO);
            AddressEntity addressEntity = _mapper.Map<AddressEntity>(address);
            _mapperSession.Update(addressEntity);
        }
    }
}
