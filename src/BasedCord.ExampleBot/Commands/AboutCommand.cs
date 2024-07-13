using BasedCord.Entities.Enums;
using BasedCord.Entities.Interactions;
using BasedCord.Interactions;
using BasedCord.Interactions.Attributes;
using BasedCord.Interactions.Contexts;
using BasedCord.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedCord.ExampleBot.Commands
{
    [Command("about", "Get information about the bot", dmPermission: true)]
    public class AboutCommand : ICommand
    {
        private DiscordRest restClient;

        public AboutCommand(DiscordRest restClient)
        {
            this.restClient = restClient;
        }

        [InvokeCommand]
        public async ValueTask InvokeAsync(CommandContext context)
        {
            // Invoke command
            await restClient.CreateInteractionResponseAsync(context.EventData.Id, context.EventData.Token,
                InteractionResponseType.ChannelMessageWithSource, new InteractionMessageResponse()
                {
                    Content = "BasedCord Example Bot!",
                    Flags = MessageFlags.Ephemeral
                });
        }
    }
}
