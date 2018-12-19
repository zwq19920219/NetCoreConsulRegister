using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsulCommon.Extension;
using ConsulCommon.Helper;
using ConsulCommon.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsulClientService
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            // register this service
            ServiceEntity serviceEntity = new ServiceEntity
            {
                IP = Configuration["Service:address"],//NetworkHelper.LocalIPAddress,
                Port = Convert.ToInt32(Configuration["Service:port"]),
                ServiceName = Configuration["Service:name"],
                ConsulIP = Configuration["Consul:ip"],
                ConsulPort = Convert.ToInt32(Configuration["Consul:port"])
            };
            app.RegisterConsul(lifetime, serviceEntity);
        }
    }
}
