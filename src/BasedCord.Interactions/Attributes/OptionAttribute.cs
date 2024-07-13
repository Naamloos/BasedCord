using BasedCord.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedCord.Interactions.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class OptionAttribute : Attribute
    {
        public string Name { get; }
        public string Description { get; }
        public ApplicationCommandOptionType Type { get; }

        public OptionAttribute(string name, string description, ApplicationCommandOptionType type)
        {
            Name = name;
            Description = description;
            Type = type;
            // TODO implement the other fields
        }
    }
}
