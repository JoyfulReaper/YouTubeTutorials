using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
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

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    PrepDb.PrepPopulation(app);

    app.Run();
}