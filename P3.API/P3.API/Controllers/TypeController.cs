using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P3.API.Control;
using P3.API.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P3.API.Controllers
{
    [Route("api/[controller]")]
    public class TypeController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(statusCode: 200, Type = typeof(List<Typee>))]
        public ActionResult<IEnumerable<Typee>> Get()
        {
            var ListType = TypeList.GetListType();
            if (ListType == null)
            {
                return BadRequest();
            }
            return Ok(ListType);
        }

        // GET api/<controller>/5
        [HttpGet("{IdP}")]
        public ActionResult<Type> Get(int IdP)
        {
            try
            {
                var TypeAux = TypeList.GetType(IdP).First();
                if (TypeAux == null)
                {
                    return BadRequest();
                }
                return Ok(TypeAux);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] Typee TypeP)
        {
            if (ModelState.IsValid)
            {
                if (!TypeList.AddType(TypeP))
                {
                    return BadRequest();
                }
                return Created(Url.Action("Post", TypeP), TypeP);
            }
            return BadRequest();
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Put([FromBody] Typee TypeP)
        {
            if (ModelState.IsValid)
            {
                if (!TypeList.UpdateType(TypeP))
                {
                    return BadRequest();
                }
                return Ok(TypeP);
            }
            return BadRequest();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int IdP)
        {
            var TypeAux = TypeList.GetType(IdP);
            if (TypeAux == null)
            {
                return NotFound();
            }
            if (!TypeList.RemoveType(IdP))
            {
                return BadRequest();
            }
            return Ok("Type removed!");
        }
    }
}
