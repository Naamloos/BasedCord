using Microsoft.Extensions.DependencyInjection;
using BasedCord.Entities;
using BasedCord.Gateway.EventData.Outgoing;
using BasedCord.Gateway.Events;

namespace BasedCord.Gateway
{
    public record GatewayConfiguration
    {
        public Intents Intents { get; set; } = Intents.AllUnprivileged;
        public string GatewayUrl { get; set; } = "gateway.discord.gg";
        public IServiceProvider Services { get; set; } = new ServiceCollection().BuildServiceProvider(); // placeholder dummy
        public Optional<Activity> Activity { get; set; } = Optional<Activity>.None;

        public string Token { get; set; } = "";
        public int ShardId { get; set; } = 0;
        public int ShardCount { get; set; } = 1;

        internal List<Type> subscribers { get; set; } = new List<Type>();
        public void Subscribe<T>() where T : ISubscriber
        {
            var type = typeof(T);
            subscribers.Add(type);
        }
    }
}
