using AutoMapper;
using Dyno.Platform.ReferentialData.Business.IServices;
using Dyno.Platform.ReferentialData.BusinessModel;
using Dyno.Platform.ReferentialData.DTO;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferntialData.DataModel;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.Services
{
    public class TestService : ITestService

    {
        public readonly IMapperSession<TestData> _mapperSession;
        public readonly IMapper _mapper;

        public TestService(IMapperSession<TestData> mapperSession, IMapper mapper)
        {
            _mapperSession = mapperSession;
            _mapper = mapper;
        }

        public void Save(TestDTO testDTO)
        {
            Test test = _mapper.Map<Test>(testDTO);
            TestData testData = _mapper.Map<TestData>(test);
            
            _mapperSession.Add(testData);
        }
    }
}
