using Dyno.Platform.ReferentialData.DTO.AddressData;
using Dyno.Platform.ReferentialData.DTO.BalanceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices.IBalanceDataService
{
    public interface IBalanceService
    {
        IList<BalanceDTO> GetAllBalance();
        IList<BalanceDTO> GetBalanceByUserId(string userId);
       
        void CreateBalance(BalanceDTO balanceDTO);
        void UpdateBalance(BalanceDTO balanceDTO);
        void DeleteBalance(int id);
    }
}
