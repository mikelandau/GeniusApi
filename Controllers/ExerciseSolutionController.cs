using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeniusApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeniusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseSolutionController : ControllerBase
    {
        // POST: api/ExerciseSolution
        [HttpPost]
        public void Post([FromBody] ExerciseSolution exerciseSolution)
        {
        }
    }
}
