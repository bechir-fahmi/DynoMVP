﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.BusinessModel.UserData
{
    public class ResponsibleFiancier 
    {
        public Guid   Id { get; set; }
        public User User { get; set; }
    }
}
