using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using API_RovnoZyb.Helper;
using RovnoZyb;
using RovnoZyb.Entity;
using Zyb.DTO.Models;
using Zyb.DTO.Models.Results;
using Zyb_Domain;
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

                };
                var userMoreInfo = new UserMoreInfo()
                {
                    id = user.Id,
                    FullName = model.FullName,
                    Address = model.Address,
                    Age = model.Age,
                    Phone = model.PhoneNumber
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

        [HttpPost("login")]
        public async Task<ResultDTO> Login([FromBody] UserLoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultDTO
                {
                    Status = 400,
                    Message = "ErroR",
                    errors = CustomValidator.GetErrorsByModel(ModelState)
                };
            }
            else
            {

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (!result.Succeeded)
                {
                    List<string> error = new List<string>();
                    error.Add("User not fount, password or email incorrect");


                    return new ResultDTO
                    {
                        Status = 400,
                        Message = "User not found"
                    };
                }
                else
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    await _signInManager.SignInAsync(user, false);

                    return new ResultDTO
                    {
                        Status = 200,
                        Message = "Ok",
                        Token = _iJwtTokenService.CreateToken(user)
                    };
                }

            }


        }
    }
}