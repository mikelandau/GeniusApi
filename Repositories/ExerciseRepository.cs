using System;
using System.Collections.Generic;
using GeniusApi.Models;
using GeniusApi.Repositories;

namespace GeniusApi.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        public ExerciseRepository()
        {
        }

        public IEnumerable<Exercise> GetAll()
        {
            throw new NotImplementedException();
        }

        public Exercise GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}