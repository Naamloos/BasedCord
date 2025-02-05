﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BasedCord.Entities;
using BasedCord.Entities.Channels;
using BasedCord.Entities.Enums;
using BasedCord.Entities.Guilds;
using BasedCord.Entities.Interactions;
using BasedCord.Entities.Messages;
using BasedCord.Entities.Serializer;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging.Abstractions;

namespace BasedCord.Rest
{
    // TODO fix rate limit routes, I don't think they're correct yet

    // top levels are channel, guild, webhook. Routes have only ONE top level resource
    public class DiscordRest
    {
        private DiscordRestConfiguration Configuration;
        private RateLimitedRest RatelimitedRest;
        private JsonSerializerOptions JsonSerializerOptions;
        private ILogger _logger;

        internal DiscordRest(Action<DiscordRestConfiguration> configure, IServiceProvider services)
        {
            Configuration = new DiscordRestConfiguration();
            configure(Configuration);
            JsonSerializerOptions = new JsonSerializerOptions(JsonSerializerOptions.Default)
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                Converters = { new OptionalJsonSerializerFactory() }
            };

            RatelimitedRest = new RateLimitedRest(Configuration, Configuration.Token, JsonSerializerOptions);

            _logger = services.GetService<ILogger<DiscordRest>>() ?? new Logger<DiscordRest>(NullLoggerFactory.Instance);
        }

        public ValueTask<RestResponse<User>> GetCurrentUserAsync()
        {
            string route = "users/@me";
            string url = "users/@me";
            return makeRequestAsync<User>(HttpMethod.Get, url, route);
        }

        public ValueTask<RestResponse<User>> GetUserAsync(Snowflake userId)
        {
            string route = "users/:user_id";
            string url = $"users/{userId}";
            return makeRequestAsync<User>(HttpMethod.Get, url, route);
        }

        public ValueTask<RestResponse<Application>> GetApplicationAsync(Snowflake applicationId)
        {
            string route = "applications/:application_id";
            string url = $"applications/{applicationId}";
            return makeRequestAsync<Application>(HttpMethod.Get, url, route);
        }

        // TODO this sucks, properly implement. this is jsut here for "ayo it work" atm.
        public ValueTask<RestResponse<Message>> CreateMessageAsync(Snowflake channelId, CreateMessage content)
        {
            string route = $"channels/{channelId}/messages";
            string url = $"channels/{channelId}/messages";
            return makeRequestAsync<Message>(HttpMethod.Post, url, route, content);
        }

        public ValueTask<RestResponse<Message>> ModifyMessageAsync(Snowflake channelId, Snowflake messageId, CreateMessage content)
        {
            string route = $"channels/{channelId}/messages/:message_id";
            string url = $"channels/{channelId}/messages/{messageId}";
            return makeRequestAsync<Message>(HttpMethod.Patch, url, route, content);
        }

        public ValueTask<RestResponse<ApplicationCommand[]>> BulkOverwriteGlobalApplicationCommandsAsync(Snowflake applicationId, params ApplicationCommand[] commands)
        {
            string route = "applications/:application_id/commands";
            string url = $"applications/{applicationId}/commands";
            return makeRequestAsync<ApplicationCommand[]>(HttpMethod.Put, url, route, commands);
        }

        public ValueTask<RestResponse<ApplicationCommand[]>> GetGlobalApplicationCommandsAsync(Snowflake applicationId, bool withLocalizations = true)
        {
            string route = "applications/:application_id/commands";
            string url = $"applications/{applicationId}/commands?with_localizations=" + withLocalizations;
            return makeRequestAsync<ApplicationCommand[]>(HttpMethod.Get, url, route);
        }

        public ValueTask<RestResponse<object>> CreateInteractionResponseAsync(Snowflake interactionId, string interationToken,
            InteractionResponseType type, InteractionResponseData data)
        {
            string route = "interactions/:interaction_id/:interaction_token/callback";
            string url = $"interactions/{interactionId}/{interationToken}/callback";
            return makeRequestAsync<object>(HttpMethod.Post, url, route, new InteractionResponse()
            {
                Type = type,
                Data = data
            });
        }

        public ValueTask<RestResponse<Channel>> CreateDMChannelAsync(Snowflake recipientId)
        {
            string route = "users/@me/channels";
            string url = "users/@me/channels";

            return makeRequestAsync<Channel>(HttpMethod.Post, url, route, new CreateDMChannel()
            {
                RecipientId = recipientId
            });
        }

        public ValueTask<RestResponse<Guild>> GetGuildAsync(Snowflake guildId, bool withCounts = false)
        {
            string route = $"guilds/{guildId}";
            string url = $"guilds/{guildId}?with_counts={withCounts}";

            return makeRequestAsync<Guild>(HttpMethod.Get, url, route);
        }

        public ValueTask<RestResponse<object>> CreateGuildBanAsync(Snowflake guildId, Snowflake userId, 
            int? delete_message_days = null, int? delete_message_seconds = null)
        {
            string route = $"guilds/{guildId}/bans/:user_id";
            string url = $"guilds/{guildId}/bans/{userId}";

            return makeRequestAsync<object>(HttpMethod.Put, url, route, new CreateGuildBan()
            {
                DeleteMessageDays = delete_message_days == null? Optional<int>.None : delete_message_days.Value,
                DeleteMessageSeconds = delete_message_seconds == null? Optional<int>.None : delete_message_seconds.Value
            });
        }

        private async ValueTask<RestResponse<T>> makeRequestAsync<T>(HttpMethod method, string url, string route, object? body = null, bool retry = false)
        {
            HttpResponseMessage response = await RatelimitedRest.RequestAsync(method, route, url, body);
            T? deserializedResponse = default(T);
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                if (stream.Length > 0)
                {
                    deserializedResponse = await JsonSerializer.DeserializeAsync<T>(stream, JsonSerializerOptions);
                }
            }
            else
            {
                if(response.StatusCode == System.Net.HttpStatusCode.TooManyRequests && !retry)
                {
                    // rate limited so....
                    _logger.LogWarning("Rate limit hit! Retrying request.");
                    // TODO parse retry_after from body
                    return await makeRequestAsync<T>(method, url, route, body, true);
                }
                _logger.LogError(await response.Content.ReadAsStringAsync());
                _logger.LogError(await response.RequestMessage.Content.ReadAsStringAsync());
            }

            return new RestResponse<T>(deserializedResponse, response);
        }
    }
}
