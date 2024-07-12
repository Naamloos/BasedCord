using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedCord.Gateway
{
    public abstract class BaseExtension
    {
        public abstract void Register(DiscordGateway gateway);
    }
}
