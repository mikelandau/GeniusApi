using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeniusApi.Models;
using GeniusApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeniusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        // GET: api/Exercise
        [HttpGet]
        public async Task<IEnumerable<Exercise>> Get()
        {
            return await _exerciseRepository.GetAll();
        }

        // GET: api/Exercise/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Exercise> Get(string id)
        {
            return await _exerciseRepository.GetById(id);
        }
    }
}
