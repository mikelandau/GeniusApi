using System;
using System.Collections.Generic;
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
            var createContainerParameters = new CreateContainerParameters 
            {
                Image = "mcr.microsoft.com/dotnet/aspnet",
                ExposedPorts = new Dictionary<string, EmptyStruct> 
                {
                    {
                        "8000", default(EmptyStruct)
                    }
                },
                HostConfig = new HostConfig
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        {
                            "8000", new List<PortBinding> { new PortBinding { HostPort = "8000" } }
                        }
                    }
                }
            };

            var response = await _dockerClient.Containers.CreateContainerAsync(createContainerParameters);
        }

        public async Task<ExerciseResult> Run(ExerciseSolution userSolution)
        {
            return null;
        }
    }
}