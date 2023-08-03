using Dyno.Platform.ReferentialData.DTO.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.DTO.AddressData
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string? AddressName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string? street { get; set; }
        public string? City { get; set; }
        public int PostalCode { get; set; }
        public string? Country { get; set; }
        public UserDTO User { get; set; }
    }
}
