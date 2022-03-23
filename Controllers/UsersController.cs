using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<User> Users = new List<User>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                // LINQ [Obj] Query
                var user1 = Users.SingleOrDefault(u => u.Id == Guid.Parse(id));
                if (user1 == null)
                {
                    return NotFound();
                }
                return Ok(user1);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            var user1 = new User
            {
                Id = Guid.NewGuid(),
                Email = user.Email,
                Password = user.Password,
                Name = user.Name
            };
            Users.Add(user1);
            return Ok(new {
                Success = true,
                Data = user1
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, User useredit)
        {
            try
            {
                // LINQ [Obj] Query
                var user1 = Users.SingleOrDefault(u => u.Id == Guid.Parse(id));
                if (user1 == null)
                {
                    return NotFound();
                }
                if (id != user1.Id.ToString())
                {
                    return BadRequest();
                }
                // Update
                user1.Email = useredit.Email;
                user1.Password = useredit.Password;
                user1.Name = useredit.Name;

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                // LINQ [Obj] Query
                var user1 = Users.SingleOrDefault(u => u.Id == Guid.Parse(id));
                if (user1 == null)
                {
                    return NotFound();
                }
                if (id != user1.Id.ToString())
                {
                    return BadRequest();
                }
                // Update
                Users.Remove(user1);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
