using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;
using GeniusApi.Models;

namespace GeniusApi.TestRunners
{
    public class NUnitTestRunner : ITestRunner
    {
        private readonly IDockerClient _dockerClient;

        public NUnitTestRunner(IDockerClient dockerClient)
        {
            _dockerClient = dockerClient;
        }

        private async Task StartContainer()
        {

        }

        public async Task<ExerciseResult> Run(ExerciseSolution userSolution)
        {
            return null;
        }
    }
}