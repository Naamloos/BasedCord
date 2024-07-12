using BasedCord.Entities.Enums;

namespace BasedCord.Entities
{
    public record Entitlement
    {
        public Snowflake Id { get; set; }

        public Snowflake SkuId { get; set; }

        public Optional<Snowflake> UserId { get; set; }

        public Optional<Snowflake> GuildId { get; set; }

        public Snowflake ApplicationId { get; set; }

        public EntitlementType Type { get; set; }

        public bool Consumed { get; set; }

        public Optional<DateTimeOffset> StartsAt { get; set; }

        public Optional<DateTimeOffset> EndsAt { get; set; }
    }
}