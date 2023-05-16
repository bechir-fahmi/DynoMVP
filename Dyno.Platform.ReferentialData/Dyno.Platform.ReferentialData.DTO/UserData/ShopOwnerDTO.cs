﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.DTO.UserData
{
    public class ShopOwnerDTO
    {
        public Guid Id { get; set; }
        public UserDTO User { get; set; }
        public String? CodeTVA { get; set; }
        public String? Adress { get; set; }
        public String? PayementMethod { get; set; }
        public String? AdressFacturation { get; set; }
        public float Balance { get; set; }

    }
}
