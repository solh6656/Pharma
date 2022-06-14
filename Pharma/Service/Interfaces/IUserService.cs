using Pharma.Domin.Enttes;
using Pharma.Service.DTOs;
using System.Collections.Generic;

namespace Pharma.Service.Interfaces
{
    public interface IUserService
    {
        User Create(UserView user);

        UserView Get(string username);

        IEnumerable<UserView> GetAll();

        User Update(string username, UserView user);

        bool Delete(string username);
    }
}
