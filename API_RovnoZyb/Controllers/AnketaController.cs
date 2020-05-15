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


        [HttpGet]
        public IEnumerable<AnketaDTO> getAnketa()
        {
            List<AnketaDTO> data = new List<AnketaDTO>();

            var dataFromDB = _context.anketa.Where(t => t.isClose == false).ToList();

            foreach (var item in dataFromDB)
            {
                AnketaDTO temp = new AnketaDTO();

                temp.FullName = item.FullName;
                temp.Title = item.Title;
                temp.Text = item.Text;
                temp.Phone = item.Phone;
                temp.Servant = item.Servant;
                temp.isClose = item.isClose;
                temp.id = item.id;
               

                data.Add(temp);
            }
            return data;
        }


        [HttpPost("RemoveAnketas/{id}")]
        public ResultDTO RemoveUser([FromRoute]string id)
        {
            try
            {
                var anketa = _context.anketa.FirstOrDefault(t => t.AnketaId == id);
                
                _context.anketa.Remove(anketa);
            
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

        [HttpPost("editAnketas/{id}")]
        public ResultDTO EditUser([FromRoute]string id, [FromBody]AnketaDTO model)
        {
            var anketas = _context.anketa.FirstOrDefault(t => t.AnketaId == id);

            anketas.FullName = model.FullName;
            anketas.Title = model.Title;
            anketas.Text = model.Text;
            anketas.Phone = model.Phone;
            anketas.Servant = model.Servant;
            anketas.isClose = model.isClose;
            anketas.id = model.id;

          

            _context.SaveChanges();

            return new ResultDTO
            {
                Status = 200,
                Message = "OK"
            };

        }


        [HttpPost("addanketas")]
        public ResultDTO AddAnketas([FromBody]AnketaDTO model)
        {
            Anketa anketas = new Anketa();

            anketas.AnketaId = Guid.NewGuid().ToString();
            anketas.FullName = model.FullName;
            anketas.Title = model.Title;
            anketas.Text = model.Text;
            anketas.Phone = model.Phone;
            anketas.Servant = model.Servant;
            anketas.isClose = model.isClose;
            anketas.id = model.id;
            anketas.Time = DateTime.Now + "";



            _context.SaveChanges();

            return new ResultDTO
            {
                Status = 200,
                Message = "OK"
            };

        }
    }
}