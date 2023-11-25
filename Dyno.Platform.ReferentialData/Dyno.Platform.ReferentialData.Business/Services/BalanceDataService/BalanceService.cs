using AutoMapper;
using Dyno.Platform.ReferentialData.Business.IServices.IBalanceDataService;
using Dyno.Platform.ReferentialData.BusinessModel.BalanceData;
using Dyno.Platform.ReferentialData.DTO.BalanceData;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferntialData.DataModel.BalanceData;
using Platform.Shared.Mapper;
using Platform.Shared.Result;
using Platform.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.Services.BalanceDataService
{
    public class BalanceService : IBalanceService
    {
        public readonly IMapper _mapper;
        public readonly IMapperSession<BalanceEntity> _mapperSession;
        public BalanceService(IMapper mapper, 
            IMapperSession<BalanceEntity> mapperSession)
        {
            _mapper = mapper;
            _mapperSession = mapperSession;
        }

        #region Get
        public List<BalanceDTO> GetAll()
        {
            IList<BalanceEntity> balanceEntities = _mapperSession.GetAll();
            IList<Balance> balances = _mapper.Map<IList<Balance>>(balanceEntities);
            IList<BalanceDTO> balanceDTOs = _mapper.Map<IList<BalanceDTO>>(balances);
            return (List<BalanceDTO>)balanceDTOs;
        }

        public BalanceDTO GetById(Guid id)
        {
            BalanceEntity balanceEntity = _mapperSession.GetById(id);
            Balance balance = _mapper.Map<Balance>(balanceEntity);
            BalanceDTO balanceDTO = _mapper.Map<BalanceDTO>(balance);
            return balanceDTO;
        }

        public List<BalanceDTO> GetBalanceByUserId(string userId)
        {
            IList<BalanceEntity> balanceEntities = _mapperSession.GetAllByExpression(balance => balance.User.Id == userId);
            IList<Balance> balances = _mapper.Map<IList<Balance>>(balanceEntities);
            IList<BalanceDTO> balanceDTOs = _mapper.Map<IList<BalanceDTO>>(balances);
            return (List<BalanceDTO>)balanceDTOs;
        }
        #endregion

        #region Create
        public OperationResult<BalanceDTO> Create(BalanceDTO balanceDTO)
        {
            Balance balance = _mapper.Map<Balance>(balanceDTO);
            BalanceEntity balanceEntity = _mapper.Map<BalanceEntity>(balance);
            _mapperSession.Add(balanceEntity);
            return new OperationResult<BalanceDTO>
            {
                Result = QueryResult.IsSucced,
                ExceptionMessage = "Balance create it successfully !"
            };
        }
        #endregion

        #region Update
        public OperationResult<BalanceDTO> Update(BalanceDTO balanceDTO)
        {
            Balance balance = _mapper.Map<Balance>(balanceDTO);
            BalanceEntity balanceEntity = _mapper.Map<BalanceEntity>(balance);
            _mapperSession.Update(balanceEntity);
            return new OperationResult<BalanceDTO>
            {
                Result = QueryResult.IsSucced,
                ExceptionMessage = "Balance update it successfully !"
            };
        }
        #endregion

        #region Delete
        public OperationResult<BalanceDTO> Delete(Guid id)
        {
            BalanceEntity balanceEntity = _mapperSession.GetById(id);
            if(balanceEntity == null)
            {
                return new OperationResult<BalanceDTO>
                {
                    Result = QueryResult.UnAuthorized,
                    ExceptionMessage = "Balance Unfound"
                };
            }
            _mapperSession.Delete(balanceEntity);
            return new OperationResult<BalanceDTO>
            {
                Result = QueryResult.IsSucced,
                ExceptionMessage = "Balance delete it successfully"
            };
        }

        #endregion

    }
}
