﻿using Dyno.Platform.ReferntialData.DataModel.UserData;
using NHibernate.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferntialData.DataModel.UserRole
{
    public class RoleEntity : IdentityRole
    {
        public virtual IList<UserEntity> Users { get; set; }
    }
}
