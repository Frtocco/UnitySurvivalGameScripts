using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survival.Assets.Scripts.Models;


namespace Survival.Assets.Scripts.Models
{
    public abstract class Tools
    {   
        protected string name;
        protected string description;
        protected List<CraftRequirement> requirements;

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