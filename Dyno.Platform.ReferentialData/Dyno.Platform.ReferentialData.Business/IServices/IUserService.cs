using Dyno.Platform.ReferentialData.DTO.UserData;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices
{
    public interface IUserService
    {
        List<UserDTO> GetAll(); 
        Task<UserDTO> GetById(string id);    
        Task<UserDTO> GetByUserName(string name);
        Task<UserDTO> GetByEmail(string email);
        Task Create(UserDTO entity);
        Task Update(UserDTO entity);
        void Delete(string id);

    }
}
