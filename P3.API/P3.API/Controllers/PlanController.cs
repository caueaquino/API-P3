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
    public class PlanController : Controller
    {
        // GET api/plan
        [HttpGet]
        [ProducesResponseType(statusCode: 200, Type = typeof(List<Plan>))]
        public ActionResult<IEnumerable<Plan>> Get()
        {
            var ListPlan = PlanList.GetListPlan();
            if (ListPlan == null)
            {
                return BadRequest();
            }
            return Ok(ListPlan);
        }

        // GET api/plan/5
        [HttpGet("{IdP}")]
        public ActionResult<Plan> Get(int IdP)
        {
            try
            {
                var PlanAux = PlanList.GetPlan(IdP).First();
                if (PlanAux == null)
                {
                    return BadRequest();
                }
                return Ok(PlanAux);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        // POST api/plan
        [HttpPost]
        public IActionResult Post([FromBody] Plan PlanP)
        {
            if (ModelState.IsValid)
            {
                if (!PlanList.AddPlan(PlanP))
                {
                    return BadRequest();
                }
                return Created(Url.Action("Post", PlanP.id), PlanP);
            }
            return BadRequest();
        }

        // PUT api/plan/5
        [HttpPut]
        public IActionResult Put([FromBody] Plan PlanP)
        {
            if (ModelState.IsValid)
            {
                if (!PlanList.UpdatePlan(PlanP))
                {
                    return BadRequest();
                }
                return Ok(PlanP);
            }
            return BadRequest();
        }

        // DELETE api/plan/5
        [HttpDelete("{IdP}")]
        public IActionResult Delete(int IdP)
        {
            var PlanAux = PlanList.GetPlan(IdP);
            if (PlanAux == null)
            {
                return NotFound();
            }
            if (!PlanList.RemovePlan(IdP))
            {
                return BadRequest();
            }
            return Ok("Plan removed!");
        }
    }
}
