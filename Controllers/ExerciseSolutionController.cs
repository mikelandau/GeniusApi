using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Docker.DotNet;
using GeniusApi.Models;
using GeniusApi.TestRunners;
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
        public async Task<IActionResult> PostAsync([FromBody] ExerciseSolution exerciseSolution, [FromServices] IDockerClient dockerClient)
        {
            var runner = new NUnitTestRunner(dockerClient);
            var result = await runner.Run(exerciseSolution);
            return Ok(result);
        }
    }
}
