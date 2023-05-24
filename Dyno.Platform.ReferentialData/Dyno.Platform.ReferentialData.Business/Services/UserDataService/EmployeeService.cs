using AutoMapper;
using Dyno.Platform.ReferentialData.Business.IServices;
using Dyno.Platform.ReferentialData.Business.IServices.IUserDataService;
using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using FluentNHibernate.Data;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static NHibernate.Engine.Query.CallableParser;

namespace Dyno.Platform.ReferentialData.Business.Services.UserDataService
{
    public class EmployeeService : IEmployeeService
    {

        public readonly IMapperSession<EmployeeEntity> _mapperSession;
        public readonly IMapper _mapper;
        private readonly ISession _session;


        public EmployeeService(IMapperSession<EmployeeEntity> mapperSession,
            IMapper mapper, ISession session)

        {
            _mapperSession = mapperSession;
            _mapper = mapper;
            _session = session;



        }


        public async Task Create(EmployeeDTO employeeDTO)
        {
            Employee employee = _mapper.Map<Employee>(employeeDTO);
            EmployeeEntity userEntity = _mapper.Map<EmployeeEntity>(employee);

            _mapperSession.Add(userEntity);

        }

        public void Delete(Guid id)
        {
            EmployeeEntity employeeEntity = _mapperSession.GetById(id);
            if (employeeEntity != null)
            {
                _mapperSession.Delete(employeeEntity);

            }



        }

        public IList<EmployeeDTO> GetAll()
        {


            var query = _session.QueryOver<EmployeeEntity>();

            IList<EmployeeEntity> employeeEntities = query.List<EmployeeEntity>();
            foreach (var entity in employeeEntities)
            {
                foreach (var employer in entity.Employers) { employer.Employees = null; }
            }

            IList<Employee> employees = _mapper.Map<IList<Employee>>(employeeEntities);
            IList<EmployeeDTO> employeeDTOs = _mapper.Map<IList<EmployeeDTO>>(employees);

            return (List<EmployeeDTO>)employeeDTOs;


        }

        public EmployeeDTO GetByEmail(string email)
        {
            var query = _session.Query<EmployeeEntity>()
                         .Where(e => e.User.Email == email);
            EmployeeEntity employeeEntity = query.SingleOrDefault();
            foreach (var employer in employeeEntity.Employers) { employer.Employees = null; }
            Employee employee = _mapper.Map<Employee>(employeeEntity);
            EmployeeDTO employeeDTO = _mapper.Map<EmployeeDTO>(employee);

            return employeeDTO;

        }

        public EmployeeDTO GetById(Guid id)
        {
            var query = _session.Query<EmployeeEntity>()
                         .Where(e => e.Id == id);
            EmployeeEntity employeeEntity = query.Single();
            foreach (var employer in employeeEntity.Employers) { employer.Employees = null; }

            Employee employee = _mapper.Map<Employee>(employeeEntity);
            EmployeeDTO employeeDTO = _mapper.Map<EmployeeDTO>(employee);

            return employeeDTO;
        }


        public EmployeeDTO GetByUserName(string name)
        {
            var query = _session.Query<EmployeeEntity>()
                         .Where(e => e.User.UserName == name);
            EmployeeEntity employeeEntity = query.SingleOrDefault();
            foreach (var employer in employeeEntity.Employers) { employer.Employees = null; }
            Employee employee = _mapper.Map<Employee>(employeeEntity);
            EmployeeDTO employeeDTO = _mapper.Map<EmployeeDTO>(employee);

            return employeeDTO;
        }

        public Task Update(EmployeeDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
