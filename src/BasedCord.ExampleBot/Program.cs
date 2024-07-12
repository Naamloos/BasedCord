using BasedCord.ExampleBot.Events;
using BasedCord.Gateway;
using BasedCord.Gateway.EventData.Outgoing;
using BasedCord.Rest;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BasedCord.ExampleBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jsonOptions = new JsonSerializerOptions(JsonSerializerOptions.Default)
            {
                WriteIndented = true
            };

            if (!File.Exists("settings.json"))
            {
                File.Create("settings.json").Close();
                File.WriteAllText("settings.json", JsonSerializer.Serialize(new Settings(), jsonOptions));
                Console.WriteLine("Settings file not found. Created one. Please fill with required values!");
                Console.ReadKey();
                return;
            }
            else
            {
                // ensure new config values are written
                var contents = File.ReadAllText("settings.json");
                var settings = JsonSerializer.Deserialize<Settings>(contents);
                File.WriteAllText("settings.json", JsonSerializer.Serialize(settings, jsonOptions));
            }

            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                {
                    config.AddEnvironmentVariables()
                        .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
                        .Build();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging(); // I recommend hooking this if you want logs

                    services.AddDiscordGateway(x =>
                    {
                        x.Intents = Intents.AllUnprivileged | Intents.MessageContents;

                        x.Token = hostContext.Configuration["discord_token"];
                        x.ShardId = int.Parse(hostContext.Configuration["shard_id"]);
                        x.ShardCount = int.Parse(hostContext.Configuration["shard_count"]);

                        x.Activity = new Activity() 
                        {
                            Name = "BasedCord",
                            Type = 0,
                            State = "BasedCord"
                        };

                        x.Subscribe<ExampleSubscriber>();
                    });

                    services.AddDiscordRest(x =>
                    {
                        x.Token = hostContext.Configuration["discord_token"];
                    });
                })
                .Build()
                .Run();
        }
    }
}
