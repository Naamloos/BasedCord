using BasedCord.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedCord.Interactions.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandAttribute : Attribute
    {
        public string Name { get; }
        public string Description { get; }
        public bool Nsfw { get; }
        public Permissions Permissions { get; }
        public bool DmPermission { get; }

        public CommandAttribute(string name, string description, bool nsfw = false, 
            Permissions permissions = Permissions.None, bool dmPermission = false)
        {
            Name = name;
            Description = description;
            Nsfw = nsfw;
            Permissions = permissions;
            DmPermission = dmPermission;
        }
    }
}
