using Dyno.Platform.ReferentialData.DTO.TicketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices
{
    public interface IPayementService
    {
        IList<PayementDTO> GetAll();
        PayementDTO GetById(Guid id);
        void Create(PayementDTO entity);
        void Update(PayementDTO entity);
        void Delete(Guid id);
    }
}
