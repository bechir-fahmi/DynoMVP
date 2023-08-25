using Dyno.Platform.ReferentialData.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices
{
    public interface ITestService
    {
        void Save (TestDTO testDTO);
    }
}
