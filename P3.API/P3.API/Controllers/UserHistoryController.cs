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
    public class UserHistoryController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(statusCode: 200, Type = typeof(List<Plan>))]
        public ActionResult<IEnumerable<UserHistory>> Get()
        {
            var ListUserHistory = UserHistoryList.GetListUserHistory();
            if (ListUserHistory == null)
            {
                return BadRequest();
            }
            return Ok(ListUserHistory);
        }
    }
}
