using System;
using System.Threading.Tasks;
using TechAche.Controllers.Repository;

namespace TechAche.Persistance
{
    public interface IAccountRepository
    {
        Task<bool> AccountExists(SaveUserResource user);
        void AddAccount(SaveUserResource user);
    }
}