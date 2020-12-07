using System.Collections.Generic;
using System.Threading.Tasks;
using GeniusApi.Models;

namespace GeniusApi.Repositories
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetAll();
        Task<Exercise> GetById(string id);
    }
}