using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RovnoZyb;
using RovnoZyb.Entity;
using Zyb.DTO.Models;
using Zyb.DTO.Models.Results;

namespace API_RovnoZyb.Controllers
{
    [Route("api/UserManager")]
    [ApiController]
    public class UserManagerController : ControllerBase
    {
        private readonly EFContext _context;
        private readonly UserManager<User> _userManager;
        public UserManagerController(EFContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        [HttpGet]
        public IEnumerable<UserItemDTO> getUsers()
        {
            List<UserItemDTO> data = new List<UserItemDTO>();

            var dataFromDB = _context.Users.Where(t => t.Email != "admin@gmail.com").ToList();
            foreach (var item in dataFromDB)
            {
                UserItemDTO temp = new UserItemDTO();
                var moreInfo = _context.userMoreInfos.FirstOrDefault(t => t.id == item.Id);
                temp.Email = item.Email;
                temp.Id = item.Id;
                if (moreInfo != null)
                {
                    temp.fullName = moreInfo.FullName;
                    temp.Age = moreInfo.Age;
                    temp.Address = moreInfo.Address;
                temp.Phone = moreInfo.Phone;
                }


                data.Add(temp);
            }
            return data;
        }


        [HttpPost("editUser/{id}")]
        public ResultDTO EditUser([FromRoute] string id, [FromBody]UserItemDTO model)
        {
            var user = _context.Users.FirstOrDefault(t => t.Id == id);
            var userMoreInfo = _context.userMoreInfos.FirstOrDefault(t => t.id == id);

            user.Email = model.Email;
            user.Id = model.Id;

            userMoreInfo.FullName = model.fullName;
            userMoreInfo.Age = model.Age;
            userMoreInfo.Address = model.Address;
            user.PhoneNumber = model.Phone;

            _context.SaveChanges();

            return new ResultDTO
            {
                Status = 200,
                Message = "OK"
            };
        }


        [HttpPost("RemoveUser/{id}")]
        public ResultDTO RemoveUser([FromRoute]string id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(t => t.Id == id);
                var userMoreInfo = _context.userMoreInfos.FirstOrDefault(t => t.id == id);

                _context.Users.Remove(user);
                if (userMoreInfo != null)
                {
                    _context.userMoreInfos.Remove(userMoreInfo);
                }
                _context.SaveChanges();

                return new ResultDTO
                {
                    Status = 200,
                    Message = "Ok"
                };

            }
            catch (Exception e)
            {
                List<string> temp = new List<string>();
                temp.Add(e.Message);

                return new ResultDTO
                {
                    Status = 500,
                    Message = "Error",
                    Errors = temp
                };

            }
        }
    }
}