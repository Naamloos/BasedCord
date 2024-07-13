using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedCord.Gateway.Extensions
{
    public interface IExtension
    {
        public void Register(DiscordGateway gateway);
    }
}
