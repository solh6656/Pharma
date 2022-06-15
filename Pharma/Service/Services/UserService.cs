using Pharma.Data.IRepositories;
using Pharma.Data.Repositories;
using Pharma.Domin.Enttes;
using Pharma.Service.DTOs;
using Pharma.Service.Extansions;
using Pharma.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharma.Service.Services
{
    public class UserService :IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }

        public User Create(UserView userDto)
        {
            var users = GetAll();
            bool check = users.Check(userDto.Username, userDto.Password.GetHashCode().ToString());

            if (!check)
                return Update(userDto.Username, userDto);

            return userRepository.Create(userDto.Mapper());

        }


        public UserView Get(string username)
            => GetAll().FirstOrDefault(p => p.Username == username);
         //public UserView Get(string firstname)
         //   => GetAll().FirstOrDefault(p => p.FirstName == firstname);
         //public UserView Get(string lastname)
         //   => GetAll().FirstOrDefault(p => p.LastName == lastname);
         //public UserView Get(string phone)
         //   => GetAll().FirstOrDefault(p => p.Phone == phone);



        public IEnumerable<UserView> GetAll()
            => userRepository.GetAll().Select(p => p.Mapper());


        public User Update(string username, UserView userView)
        {
            var user = userRepository.GetAll().FirstOrDefault(p => p.Username == username);

            User updatedUser = userView.Mapper();
            updatedUser.Id = user.Id;
            updatedUser.CreatedTime = user.CreatedTime;
            updatedUser.UpdatedTime = DateTime.Now;

            userRepository.Update(user.Id, updatedUser);

            return user;
        }


        public bool Delete(string name)
        {
            var user = userRepository.GetAll().FirstOrDefault(p => p.Username == name);

            return userRepository.Delete(user.Id);
        }
    }
}
