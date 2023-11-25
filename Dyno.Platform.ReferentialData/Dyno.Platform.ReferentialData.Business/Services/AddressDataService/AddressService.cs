using AutoMapper;
using Dyno.Platform.ReferentialData.Business.IServices.IAddressDataService;
using Dyno.Platform.ReferentialData.BusinessModel.AddressData;
using Dyno.Platform.ReferentialData.DTO.AddressData;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferntialData.DataModel.AddressData;
using Platform.Shared.Mapper;
using Platform.Shared.Result;
using Platform.Shared.Enum;
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

        

        #region Get
        public List<AddressDTO> GetAll()
        {
            IList<AddressEntity> addressEntities = _mapperSession.GetAll();
            foreach (var address in addressEntities)
            {
                address.User = null;

            }
            IList<Address> addresses = _mapper.Map<IList<Address>>(addressEntities);
            IList<AddressDTO> addressDTOs = _mapper.Map<IList<AddressDTO>>(addresses);
            return (List<AddressDTO>)addressDTOs;
        }
        public AddressDTO GetById(Guid id)
        {
            AddressEntity addressEntity = _mapperSession.GetById(id);
            Address address = _mapper.Map<Address>(addressEntity);
            AddressDTO addressDTO = _mapper.Map<AddressDTO>(address);
            return addressDTO;
        }
        public AddressDTO GetAddressByName(string adressName)
        {
            AddressEntity addressEntity = _mapperSession.GetByExpression(address => address.AddressName == adressName);
            Address address = _mapper.Map<Address>(addressEntity);
            AddressDTO addressDTO = _mapper.Map<AddressDTO>(address);
            return addressDTO;
        }

        public List<AddressDTO> GetAddressByUserId(string userId)
        {
            IList<AddressEntity> addressEntities = _mapperSession.GetAllByExpression(address => address.User.Id == userId);
            foreach (var address in addressEntities)
            {
                address.User = null;

            }
            IList<Address> addresses = _mapper.Map<IList<Address>>(addressEntities);
            IList<AddressDTO> addressDTOs = _mapper.Map<IList<AddressDTO>>(addresses);
            return (List<AddressDTO>)addressDTOs;
        }

        #endregion

        #region Create
        public OperationResult<AddressDTO> Create(AddressDTO addressDTO)
        {
            Address address = _mapper.Map<Address>(addressDTO);
            AddressEntity addressEntity = _mapper.Map<AddressEntity>(address);
            _mapperSession.Add(addressEntity);
            return new OperationResult<AddressDTO>
            {
                Result = QueryResult.IsSucced,
                ExceptionMessage = "Address Added successfully"
            };
        }

        #endregion

        #region Update
        public OperationResult<AddressDTO> Update(AddressDTO addressDTO)
        {
            Address address = _mapper.Map<Address>(addressDTO);
            AddressEntity addressEntity = _mapper.Map<AddressEntity>(address);
            _mapperSession.Update(addressEntity);
            return new OperationResult<AddressDTO>
            {
                Result = QueryResult.IsSucced,
                ExceptionMessage = "Address Updated"
            };
        }
        #endregion



        #region Delete
        public OperationResult<AddressDTO> Delete(Guid id)
        {
            AddressEntity addressEntity = _mapperSession.GetById(id);
            if(addressEntity == null)
            {
                return new OperationResult<AddressDTO>
                {
                    Result = QueryResult.UnAuthorized,
                    ExceptionMessage = "Address Unfound"
                };
            }
            _mapperSession.Delete(addressEntity);
            return new OperationResult<AddressDTO>
            {
                Result = QueryResult.IsSucced,
                ExceptionMessage = "Address deleted Successfully"
            };
        }
        #endregion




    }
}
