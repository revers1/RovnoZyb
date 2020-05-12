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

namespace API_RovnoZyb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnketaController : ControllerBase
    {
        private readonly EFContext _context;
        private readonly UserManager<User> _userManager;
      
        public AnketaController(EFContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
          
        }


        //[HttpGet]
        //public IEnumerable<AnketaDTO> getAnketa()
        //{
        //    List<AnketaDTO> data = new List<AnketaDTO>();

        //    var dataFromDB = _context.anketa.Where(t=>t.==false).ToList();

        //    foreach (var item in dataFromDB)
        //    {
        //        AnketaDTO temp = new AnketaDTO();
               
        //        temp.FullName = item.FullName;
        //        temp.Title = item.Title;
        //        temp.Text = item.Text;
        //        temp.Phone = item.Phone;
        //        temp.Servant = item.Servant;
        //        temp.isClose = item.isclose;



        //        data.Add(temp);
        //    }
        //    return data;
        //}


        //[HttpPost("RemoveUser/{id}")]
        //public ResultDTO RemoveUser([FromRoute]string id)
        //{
        //    try
        //    {
        //        var user = _context.Users.FirstOrDefault(t => t.Id == id);
        //        var userMoreInfo = _context.userMoreInfos.FirstOrDefault(t => t.id == id);

        //        _context.Users.Remove(user);
        //        if (userMoreInfo != null)
        //        {
        //            _context.userMoreInfos.Remove(userMoreInfo);
        //        }
        //        _context.SaveChanges();

        //        return new ResultDTO
        //        {
        //            Status = 200,
        //            Message = "Ok"
        //        };

        //    }
        //    catch (Exception e)
        //    {
        //        List<string> temp = new List<string>();
        //        temp.Add(e.Message);

        //        return new ResultDTO
        //        {
        //            Status = 500,
        //            Message = "Error",
        //            Errors = temp
        //        };

        //    }
        //}
    }
}