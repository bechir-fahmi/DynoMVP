using Dyno.Platform.ReferentialData.DTO.TicketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices
{
    public interface ITicketService
    {
        IList<TicketDTO> GetAll();
        TicketDTO GetById(Guid id);
        void Create(TicketDTO entity);
        void Update(TicketDTO entity);
        void Delete(Guid id);
    }
}
