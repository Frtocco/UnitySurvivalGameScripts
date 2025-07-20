using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survival.Assets.Scripts.Models
{
    public abstract class Tools
    {   
        protected string name;
        protected string description;
        protected List<string> requirements;

        public string getName()
        {
            return name;
        }

        public List<string> getRequirements()
        {
            return requirements;
        }
        public string getDescription()
        {
            return description;
        }
    }
}