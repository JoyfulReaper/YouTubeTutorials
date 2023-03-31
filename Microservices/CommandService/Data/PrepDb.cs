using CommandService.Models;
using CommandService.SyncDataServices.Grpc;

namespace CommandService.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var grcpClient = serviceScope.ServiceProvider.GetRequiredService<IPlatformDataClient>();
        var platforms = grcpClient.ReturnAllPlatforms() ??
            throw new Exception("platforms was unexpectly null");

        SeedData(serviceScope.ServiceProvider.GetRequiredService<ICommandRepo>(), platforms);
    }

    private static void SeedData(ICommandRepo repo, IEnumerable<Platform> platforms)
    {
        Console.WriteLine("--> Seeding new platforms");

        foreach(var platform in platforms)
        {
            if(!repo.ExternalPlatformExists(platform.ExternalId))
            {
                repo.CreatePlatform(platform);
            }
            repo.SaveChanges();
        }
    }
}