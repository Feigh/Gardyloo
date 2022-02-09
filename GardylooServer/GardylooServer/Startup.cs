using AutoMapper;
using GardylooServer.Entities;
using GardylooServer.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GardylooServer
{
	public class Startup
	{
		readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy(name: MyAllowSpecificOrigins,
								  builder =>
								  {
									  builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
										.WithOrigins("http://localhost:19077")
										.AllowCredentials();
								  });
			});
			services.AddSignalR();

			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});

			services.AddSingleton<IConfiguration>(Configuration);
			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);

			services.AddSingleton<IRoomHandler<Room>, RoomHandler>();
			services.AddControllers()
				.AddJsonOptions(options =>
				 {
					 options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
					 options.JsonSerializerOptions.PropertyNamingPolicy = null;
					 options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
				 });
			services.AddSwaggerGen();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
				app.UseDeveloperExceptionPage();
			}

			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
				options.RoutePrefix = string.Empty;
			});


			app.UseHttpsRedirection();

			app.UseRouting();

			var webSocketOptions = new WebSocketOptions()
			{
				KeepAliveInterval = TimeSpan.FromSeconds(120),
				ReceiveBufferSize = 4 * 1024
			};

			app.UseWebSockets(webSocketOptions);

			app.UseAuthorization();

			app.UseCors(MyAllowSpecificOrigins);

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
	//			endpoints.MapControllerRoute(
	//name: "default",
	//pattern: "{controller}/{action=Index}/{id?}");
	//			endpoints.MapHub<StateHub>("/hubs/state");
	//			endpoints.MapHub<PlayerHub>("/hubs/player");
			});
		}
	}
}
