using Platform.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Shared.Result
{
    public class OperationResult
    {
        public QueryResult Result { get; set; }

        public string? ExceptionMessage { get; set; }

        public Dictionary<string, object>? ExtendedProperties { get; set; }
    }
}
