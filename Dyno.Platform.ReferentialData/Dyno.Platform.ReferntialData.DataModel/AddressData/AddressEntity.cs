using Dyno.Platform.ReferntialData.DataModel.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferntialData.DataModel.AddressData
{
    public class AddressEntity
    {
        public virtual int Id { get; set; }
        public virtual string? AddressName { get; set; }
        public virtual double Longitude { get; set; } 
        public virtual double Latitude { get; set; }
        public virtual string? Street { get; set; }
        public virtual string? City { get; set; }
        public virtual int PostalCode { get; set; }
        public virtual string? Country { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
