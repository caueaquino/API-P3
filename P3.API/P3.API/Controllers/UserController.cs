using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P3.API.Control;
using P3.API.Model;

namespace P3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET api/user
        [HttpGet]
        [ProducesResponseType(statusCode: 200, Type = typeof(List<User>))]
        public ActionResult<IEnumerable<User>> Get()
        {
            var ListUser = UserList.GetListUser();
            if (ListUser == null)
            {
                return BadRequest();
            }
            return Ok(ListUser);
        }

        // GET api/user/{id}
        [HttpGet("{IdP}")]
        public ActionResult<User> Get(int IdP)
        {
            try
            { 
                var UserAux = UserList.GetUser(IdP).First();
                if (UserAux == null)
                {
                    return BadRequest();
                }
                return Ok(UserAux);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        // POST api/user
        [HttpPost]
        public IActionResult Post([FromBody] User UserP)
        {
            if (ModelState.IsValid)
            {
                if (!UserList.AddUser(UserP))
                {
                    return BadRequest();
                }
                return Created(Url.Action("Post", UserP.id), UserP);
            }
            return BadRequest();
        }

        // PUT api/user
        [HttpPut]
        public IActionResult Put([FromBody]  User UserP)
        {
            if (ModelState.IsValid)
            {
                if (!UserList.UpdateUser(UserP))
                {
                    return BadRequest();
                }
                return Ok(UserP);
            }
            return BadRequest();
        }

        // DELETE api/user/{id}
        [HttpDelete("{IdP}")]
        public IActionResult Delete(int IdP)
        {
            var UserAux = UserList.GetUser(IdP);
            if (UserAux == null)
            {
                return NotFound();
            }
            if (!UserList.RemoveUser(IdP))
            {
                return BadRequest();
            }
            return Ok("User removed!");
        }
    }
}
