using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechAche.Controllers.Repository;
using TechAche.Persistance;

namespace TechAche.Controllers
{
    public class AccountController : Controller
    {        
        private readonly IAccountRepository repository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly TechAcheDbContext context;

        public AccountController(IMapper mapper, IAccountRepository repository, TechAcheDbContext context, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpPost("/api/login")]
        public async Task<IActionResult> ValidateAccount([FromBody]SaveUserResource user)
        {
            if(await repository.AccountExists(user)) {
                return Ok(user);
            } else {
                repository.AddAccount(user);
                await unitOfWork.CompleteAsync();
                return Ok(user);
            }
        }
    }
}