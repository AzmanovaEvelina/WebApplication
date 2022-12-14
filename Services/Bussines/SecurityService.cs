using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;
using WebApplication.Services.Data;

namespace WebApplication.Services.Bussines
{
    public class SecurityService
    {
        SecurityDAO daoService = new SecurityDAO();

        public bool Authenticate(UserModel user)
        {
            return daoService.FindByUser(user);
        }
        public string AuthenticateGROUP(UserModel user)
        {
            return daoService.FindByUserGROUP(user);
        }
    }

}