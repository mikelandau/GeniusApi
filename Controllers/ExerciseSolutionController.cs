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
        public ExerciseResult Post([FromBody] ExerciseSolution exerciseSolution)
        {

            return new ExerciseResult {
                Success = true,
                Message = "Success! You've completed the exercise."
            };
          }
    }
}
