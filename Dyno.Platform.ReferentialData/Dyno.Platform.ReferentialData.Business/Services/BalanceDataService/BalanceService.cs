using AutoMapper;
using Dyno.Platform.ReferentialData.Business.IServices.IBalanceDataService;
using Dyno.Platform.ReferentialData.BusinessModel.BalanceData;
using Dyno.Platform.ReferentialData.DTO.BalanceData;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferntialData.DataModel.BalanceData;
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
        public BalanceService(IMapper mapper, IMapperSession<BalanceEntity> mapperSession)
        {
            _mapper = mapper;
            _mapperSession = mapperSession;
        }

        public void CreateBalance(BalanceDTO balanceDTO)
        {
            Balance balance = _mapper.Map<Balance>(balanceDTO);
            BalanceEntity balanceEntity = _mapper.Map<BalanceEntity>(balance);
            _mapperSession.Add(balanceEntity);
        }

        public void DeleteBalance(int id)
        {
            BalanceEntity balanceEntity = _mapperSession.GetById(id);
            _mapperSession.Delete(balanceEntity);
        }

        public IList<BalanceDTO> GetAllBalance()
        {
            IList<BalanceEntity> balanceEntities = _mapperSession.GetAll();
            IList<Balance> balances = _mapper.Map<IList<Balance>>(balanceEntities);
            IList<BalanceDTO> balanceDTOs = _mapper.Map<IList<BalanceDTO>>(balances);
            return balanceDTOs;
        }

        public IList<BalanceDTO> GetBalanceByUserId(string userId)
        {
            IList<BalanceEntity> balanceEntities = _mapperSession.GetAllByExpression(balance => balance.User.Id == userId);
            IList<Balance> balances = _mapper.Map<IList<Balance>>(balanceEntities);
            IList<BalanceDTO> balanceDTOs = _mapper.Map<IList<BalanceDTO>>(balances);
            return balanceDTOs;
        }

        public void UpdateBalance(BalanceDTO balanceDTO)
        {
            Balance balance = _mapper.Map<Balance>(balanceDTO);
            BalanceEntity balanceEntity = _mapper.Map<BalanceEntity>(balance);
            _mapperSession.Update(balanceEntity);
        }
    }
}
