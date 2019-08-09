using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TaskApp.API.Data;
using TaskApp.API.Models;

namespace TaskApp.API
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
			services.AddCors();
			services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
			services.AddScoped<IHomeRepository, HomeRepository>();
			services.AddAutoMapper();
			services.AddSignalR();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// I work in development mode and in part of application so i think that i donot need to use Hsts in this level
				// app.UseHsts();
			}

			
			// app.UseHttpsRedirection();
			// i work with development so its better to allow any header ,origin, Method and Credentials that is because 
			// i didnot have full image about all th app which i add this task to it i know the info about this task only  
			app.UseCors(x =>x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
			app.UseSignalR(route => { route.MapHub<TaskHub>("/data"); });
			app.UseMvc();
		}
	}
}
