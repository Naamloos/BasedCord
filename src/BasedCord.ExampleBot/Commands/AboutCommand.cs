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
    // This command is a simple example of a command that sends an ephemeral message to the calling user.
    [Command("about", "Get information about the bot", dmPermission: true)]
    public class AboutCommand : ICommand
    {
        private DiscordRest restClient;

        // Commands support dependency injection through constructor parameters.
        public AboutCommand(DiscordRest restClient)
        {
            this.restClient = restClient;
        }

        // The InvokeCommand attribute is used to mark the method that will be called when the command is invoked.
        // This is so subcommands can still be defined in the same class.
        [InvokeCommand]
        public async ValueTask InvokeAsync(CommandContext context)
        {
            // We use the injected rest client to send an ephemeral message back to the user.
            await restClient.CreateInteractionResponseAsync(context.EventData.Id, context.EventData.Token,
                InteractionResponseType.ChannelMessageWithSource, new InteractionMessageResponse()
                {
                    Content = "BasedCord Example Bot!",
                    Flags = MessageFlags.Ephemeral
                });
        }
    }
}
