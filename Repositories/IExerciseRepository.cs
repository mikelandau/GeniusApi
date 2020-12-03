using System.Collections.Generic;
using GeniusApi.Models;

namespace GeniusApi.Repositories
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> GetAll();
        Exercise GetById(string id);
    }
}