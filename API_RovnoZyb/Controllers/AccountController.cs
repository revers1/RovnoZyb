using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RovnoZyb;
using RovnoZyb.Entity;
using Zyb.DTO.Models;
using Zyb.DTO.Models.Results;
using Zyb_Domain;
using API_RovnoZyb.Helper;
using API_RovnoZyb.Helper.CustomValidator;

namespace API_RovnoZyb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly EFContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtTokenService _iJwtTokenService;
        private readonly IConfiguration _iConfiguration;

        public AccountController(


        EFContext context,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
         JwtTokenService iJwtTokenService,
         IConfiguration iConfiguration)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _iJwtTokenService = iJwtTokenService;
            _iConfiguration = iConfiguration;
            _context = context;
        }

        //POST :api/account/register
        [HttpPost("register")]
        public async Task<ResultDTO> Register([FromBody] UserRegisterDTO model)
        {

            if (!ModelState.IsValid)
            {
                //ВАЛІДАЦІЯ
                return new ResultDTO
                {
                    Status = 500,
                    Message = "ERROR",
                    errors = CustomValidator.GetErrorsByModel(ModelState)
                };
            }
            else
            {
                var user = new User()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                var userMoreInfo = new UserMoreInfo()
                {
                    id = user.Id,
                    FullName = model.FullName,
                    Address = model.Address,
                    Age = model.Age
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    //TYT БУде валідація
                    return new ResultDTO
                    {
                        Status = 500,
                        Message = "Error",
                        errors = CustomValidator.GetErrorsByIdentityResult(result)
                    };
                }
                else if (result.Succeeded)
                {
                    result = _userManager.AddToRoleAsync(user, "User").Result;
                    _context.userMoreInfos.Add(userMoreInfo);
                    _context.SaveChanges();
                }

                return new ResultDTO
                {
                    Status = 200,
                    Message = "OK"
                };


            }
        }


    }
}