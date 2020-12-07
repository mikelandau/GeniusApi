using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace GeniusApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeniusApi", Version = "v1" });
            });



            services.AddSingleton<IDockerClient>(x => {
                var client = new DockerClientConfiguration(new Uri(DockerApiUrl())).CreateClient();
                PullDockerImages(client).Wait();
                return client;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GeniusApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private string DockerApiUrl()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return "npipe://./pipe/docker_engine";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return "unix:/var/run/docker.sock";
            }
            throw new System.Exception("Cannot find OS to determine Docker API Url");
        }

        private async Task PullDockerImages(IDockerClient client)
        {
            await client.Images
                .CreateImageAsync(new Docker.DotNet.Models.ImagesCreateParameters
                    {
                        FromImage = "mcr.microsoft.com/dotnet/aspnet",
                        Tag = "5.0"
                    },
                    new AuthConfig(),
                    new Progress<JSONMessage>());
        }
    }
}
