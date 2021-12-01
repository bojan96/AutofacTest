using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutofacTest.Autofac.Modules;
using AutofacTest.MediatR.Behavior;
using AutofacTest.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AutofacTest
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
            services.AddHttpClient("IpInfo", config =>
            {
                config.BaseAddress = new Uri("http://ip-api.com");
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<DelayService>().As<IDelayService>().SingleInstance();
            builder.RegisterModule<MediatrModule>();
            builder.RegisterType<LogIpInfoResponseBehavior>().AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(ExecutionTimeBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
