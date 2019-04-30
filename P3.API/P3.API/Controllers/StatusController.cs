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
    public class StatusController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(statusCode: 200, Type = typeof(List<Status>))]
        public ActionResult<IEnumerable<Status>> Get()
        {
            var ListStatus = StatusList.GetListStatus();
            if (ListStatus == null)
            {
                return BadRequest();
            }
            return Ok(ListStatus);
        }

        // GET api/<controller>/5
        [HttpGet("{IdP}")]
        public ActionResult<Status> Get(int IdP)
        {
            try
            {
                var StatusAux = StatusList.GetStatus(IdP).First();
                if (StatusAux == null)
                {
                    return BadRequest();
                }
                return Ok(StatusAux);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] Status StatusP)
        {
            if (ModelState.IsValid)
            {
                if (!StatusList.AddStatus(StatusP))
                {
                    return BadRequest();
                }
                return Created(Url.Action("Post", StatusP.id), StatusP);
            }
            return BadRequest();
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Put([FromBody] Status StatusP)
        {
            if (ModelState.IsValid)
            {
                if (!StatusList.UpdateStatus(StatusP))
                {
                    return BadRequest();
                }
                return Ok(StatusP);
            }
            return BadRequest();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{IdP}")]
        public IActionResult Delete(int IdP)
        {
            var TypeAux = StatusList.GetStatus(IdP);
            if (TypeAux == null)
            {
                return NotFound();
            }
            if (!StatusList.RemoveStatus(IdP))
            {
                return BadRequest();
            }
            return Ok("Type removed!");
        }
    }
}
