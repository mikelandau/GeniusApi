using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeniusApi.Models;
using GeniusApi.Repositories;

namespace GeniusApi.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        public ExerciseRepository()
        {
        }

        public async Task<IEnumerable<Exercise>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Exercise> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}