using Repository.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Send.Services
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();
        public UserService()
        {

        }
        public Users IsValidUser(string userEmail)
        {
            return userRepository.IsValidUser(userEmail);
        }

    }
}
