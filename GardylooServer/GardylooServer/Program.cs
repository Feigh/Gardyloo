using AutoMapper;
using GardylooServer;
using GardylooServer.Handlers;
using GardylooServer.Hubs;
using GardylooServer.Logging;
using GardylooServer.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json.Serialization;

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins,
					  builder =>
					  {
						  builder.AllowAnyOrigin()
							.AllowAnyMethod()
							.AllowAnyHeader()
							.WithOrigins("http://localhost:3000")
							.AllowCredentials();
					  });
});

builder.Logging.AddDebug();
builder.Logging.AddProvider(new FileLoggerProvider(builder.Configuration.GetSection("ConnectionStrings").GetSection("LogPath").Value));

builder.Services.AddSignalR();

var mapperConfig = new MapperConfiguration(mc =>
{
	mc.AddProfile(new AutoMapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped(typeof(IDataReader<>), typeof(JsonDataReader<>));
builder.Services.AddSingleton<IRoomHandler<RoomEvent>, RoomHandler>();
builder.Services.AddSingleton<IGameHandler, GameHandler>();

builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
		options.JsonSerializerOptions.PropertyNamingPolicy = null;
		options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

var webSocketOptions = new WebSocketOptions()
{
	KeepAliveInterval = TimeSpan.FromSeconds(120),
	ReceiveBufferSize = 4 * 1024
};

app.UseWebSockets(webSocketOptions);

app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
	endpoints.MapHub<PlayersStateHub>("/playerhub");
	endpoints.MapHub<GameStateHub>("/statehub");
});

app.Run();

