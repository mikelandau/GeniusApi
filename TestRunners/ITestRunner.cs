using System.Threading.Tasks;
using GeniusApi.Models;

namespace GeniusApi.TestRunners {
    interface ITestRunner
    {
        Task<ExerciseResult> Run(ExerciseSolution userSolution);
    }
}