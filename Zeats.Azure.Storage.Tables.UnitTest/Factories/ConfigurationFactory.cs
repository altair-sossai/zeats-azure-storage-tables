using System.IO;
using Microsoft.Extensions.Configuration;

namespace Zeats.Azure.Storage.Tables.UnitTest.Factories;

public static class ConfigurationFactory
{
    public static IConfiguration New()
    {
        var configurationBuilder = new ConfigurationBuilder();

        var builder = configurationBuilder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("local.settings.json", true)
            .AddEnvironmentVariables();

        return builder.Build();
    }
}