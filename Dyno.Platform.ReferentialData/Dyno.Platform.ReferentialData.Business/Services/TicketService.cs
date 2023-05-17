using AutoMapper;
using Dyno.Platform.ReferentialData.Business.IServices;
using Dyno.Platform.ReferentialData.BusinessModel.TicketData;
using Dyno.Platform.ReferentialData.DTO.TicketData;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferntialData.DataModel.PayementData;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.Services
{
    public class TicketService : ITicketService

    {
        public readonly IMapperSession<TicketEntity> _mapperSession;
        public readonly IMapper _mapper;
       
        public TicketService(IMapperSession<TicketEntity> mapperSession, IMapper mapper) { 
        
            _mapperSession = mapperSession;
            _mapper = mapper;
           
        
        }
        public void Create(TicketDTO entity)
        {
            Ticket ticket = _mapper.Map<Ticket>(entity);
            TicketEntity ticketEntity=_mapper.Map<TicketEntity>(ticket);
            _mapperSession.Add(ticketEntity);
                       
        }

        public void Delete(Guid id)
        {
            TicketEntity ticketEntity=_mapperSession.GetById(id);
            _mapperSession.Delete(ticketEntity);
        }

        public IList<TicketDTO> GetAll()
        {
            IList<TicketEntity> ticketEntities = _mapperSession.GetAll();
            IList<Ticket> tickets = _mapper.Map<IList<Ticket>>(ticketEntities);
            IList<TicketDTO> ticketDTOs=_mapper.Map<IList<TicketDTO>>(tickets);
            return ticketDTOs;
        }

        public TicketDTO GetById(Guid id)
        {
            TicketEntity ticketEntity = _mapperSession.GetById(id);
            Ticket ticket = _mapper.Map<Ticket>(ticketEntity);
            TicketDTO ticketDTO=_mapper.Map<TicketDTO>(ticket);
            return ticketDTO;
        }

        public void Update(TicketDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
