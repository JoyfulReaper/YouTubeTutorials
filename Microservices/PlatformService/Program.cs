using Microsoft.EntityFrameworkCore;
using PlatformService.AsyncDataServices;
using PlatformService.Data;
using PlatformService.SynDataServices.Grpc;
using PlatformService.SynDataServices.Http;

var builder = WebApplication.CreateBuilder(args);
{
    if (builder.Environment.IsProduction())
    {
        Console.WriteLine("--> Using SQL Server Db");
        builder.Services.AddDbContext<AppDbContext>(opt => 
            opt.UseSqlServer(builder.Configuration.GetConnectionString("PlatformsConn"))
        );
    }
    else
    {
        Console.WriteLine("--> Using In Memory Db");
        builder.Services.AddDbContext<AppDbContext>(opt =>
                opt.UseInMemoryDatabase("InMem"));
    }


    builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();

    builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
    builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();
    builder.Services.AddGrpc();

    builder.Services.AddControllers();
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    Console.WriteLine($"--> CommandService Endpoint {builder.Configuration["CommandService"]}");
}

var app = builder.Build();
{

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.MapGrpcService<GrpcPlatformService>();
    app.MapGet("/protos/platforms.proto", async context => 
    {
        await context.Response.WriteAsync(File.ReadAllText("Protos/platforms.proto"));
    });

    PrepDb.PrepPopulation(app, app.Environment.IsProduction());

    app.Run();
}