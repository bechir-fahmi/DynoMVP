using Dyno.Platform.ReferentialData.DTO.AddressData;
using Dyno.Platform.ReferentialData.DTO.BalanceData;
using Dyno.Platform.ReferntialData.DataModel.BalanceData;
using Platform.Shared.GenericService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices.IBalanceDataService
{
    public interface IBalanceService : IGenericSyncService<BalanceDTO, BalanceEntity, Guid, BalanceDTO>
    {
        List<BalanceDTO> GetBalanceByUserId(string userId);
    }
}
