using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survival.Assets.Scripts.Models
{
    public abstract class Craftable
    {   
        protected string name;
        protected string description;
        protected List<CraftRequirement> requirements;
        protected static int itemId = 0;

        public string getName()
        {
            return name;
        }

        public List<CraftRequirement> getRequirements()
        {
            return requirements;
        }

        public string getDescription()
        {
            return description;
        }
    }
}