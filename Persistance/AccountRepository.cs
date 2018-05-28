using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechAche.Controllers.Repository;
using TechAche.Extensions;
using TechAche.Models;

namespace TechAche.Persistance
{
    public class AccountRepository: IAccountRepository
    {
        private readonly TechAcheDbContext context;
        public AccountRepository(TechAcheDbContext context)
        {
            this.context = context;
        }
  
        public async Task<bool> AccountExists(SaveUserResource user){
            
            User userExists = await context.Users.FirstOrDefaultAsync(u => u.Auth0Id == user.Id);

            if(userExists != null) return true;
            return false;
        }

        public void AddAccount(SaveUserResource saveUser){
            User user = new User();
            user.FirstName = saveUser.FirstName;
            user.LastName = saveUser.LastName;
            user.Auth0Id = saveUser.Id;
            user.Email = saveUser.Email;
            user.Enabled = true;       

            context.Users.Add(user);

            return;
        }
    }
}