using System.Text.Json.Serialization;

namespace BasedCord.Entities.Interactions
{
    [JsonDerivedType(typeof(InteractionMessageResponse))]
    public abstract record InteractionResponseData
    {
    }
}