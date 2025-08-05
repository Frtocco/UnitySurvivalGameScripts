using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survival.Assets.Scripts.Models
{
    public class CraftRequirement
    {
        private int amount;
        private string name;

        public CraftRequirement(string name, int amount)
        {
            this.amount = amount;
            this.name = name;
        }

        public int getAmount()
        {
            return amount;
        }

        public string getName()
        {
            return name;
        }
    }   
}