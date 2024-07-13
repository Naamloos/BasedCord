using BasedCord.ExampleBot.Events;
using BasedCord.Gateway;
using BasedCord.Gateway.EventData.Outgoing;
using BasedCord.Interactions;
using BasedCord.Rest;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace BasedCord.ExampleBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Here, we set up the JSON serializer options to be indented for better readability
            var jsonOptions = new JsonSerializerOptions(JsonSerializerOptions.Default)
            {
                WriteIndented = true
            };

            // Ensure settings file exists, if not create one
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
                    // Load settings from settings.json and environment variables
                    config.AddEnvironmentVariables()
                        .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
                        .Build();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging(); // I recommend adding logging. If no loggers are registered, Gateway and Rest will use NullLogger

                    // Adding the DiscordGateway hosted service
                    services.AddDiscordGateway(x =>
                    {
                        // For the example bot, we use all unprivileged intents and message contents
                        x.Intents = Intents.AllUnprivileged | Intents.MessageContents;
                        
                        // Set the token and shard information from the settings
                        x.Token = hostContext.Configuration["discord_token"];
                        x.ShardId = int.Parse(hostContext.Configuration["shard_id"]);
                        x.ShardCount = int.Parse(hostContext.Configuration["shard_count"]);

                        // Our startup activity
                        x.Activity = new Activity() 
                        {
                            Name = "BasedCord",
                            Type = 0,
                            State = "BasedCord"
                        };

                        // Register the event subscriber "ExampleSubscriber". This is how you handle events.
                        x.Subscribe<ExampleSubscriber>();
                    });

                    // Adding the Interaction service
                    services.AddInteractions(config =>
                    {
                        // so far nothing to configure
                    });

                    // Adding the Rest service
                    services.AddDiscordRest(x =>
                    {
                        // Once again, set the token from the settings
                        x.Token = hostContext.Configuration["discord_token"];
                    });
                })
                .Build()
                .Run();
        }
    }
}
