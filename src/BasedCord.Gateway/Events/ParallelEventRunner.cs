using CommunityToolkit.HighPerformance.Helpers;

namespace BasedCord.Gateway.Events
{
    internal readonly struct ParallelEventRunner<T> : IRefAction<ISubscriber> where T : IPublishable
    {
        private readonly DiscordGateway Gateway;
        private readonly T Data;

        public ParallelEventRunner(DiscordGateway gateway, T data)
        {
            this.Gateway = gateway;
            this.Data = data;
        }

        public void Invoke(ref ISubscriber item)
        {
            if (item is ISubscriber<T> qualifiedItem)
            {
                _ = Gateway.runEventHandlerAsync(qualifiedItem, Data);
            }
        }
    }
}
