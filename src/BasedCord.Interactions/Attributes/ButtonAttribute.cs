using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedCord.Interactions.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ButtonAttribute : Attribute
    {
        public string CustomId { get; }

        public ButtonAttribute(string customId) 
        {
            if (customId.Length > 100)
                throw new ArgumentException("Custom ID must be less than 100 characters", nameof(customId));
            CustomId = customId;
        }
    }
}
