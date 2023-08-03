using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.BusinessModel.AddressData
{
    public class Address
    {
        public int Id { get; set; }
        public string? AddressName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string? street { get; set; }
        public string? City { get; set; }
        public int PostalCode { get; set; }
        public string? Country { get; set; }
        public User User { get; set; }

    }
}
