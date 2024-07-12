namespace BasedCord.Gateway.Events
{
    public interface ISubscriber<T> : ISubscriber where T : IPublishable
    {
        public ValueTask HandleEvent(T data);
    }

    public interface ISubscriber 
    {
        DiscordGateway Gateway { get; set; }
    }
}
