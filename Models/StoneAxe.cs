using System;
using System.Collections.Generic;

namespace Survival.Assets.Scripts.Models
{
    public class StoneAxe : Craftable, Axe
    {

        public StoneAxe()
        {
            name = "Stone Axe";
            requirements = new List<CraftRequirement>();
            requirements.Add(new CraftRequirement("Stone", 2));
            requirements.Add(new CraftRequirement("Stick", 2));
            description = "A basic axe made from stone and wood.";
            itemId = itemId++;
        }
    

        public void Chop()
        {
            Console.WriteLine("Chopping with a stone axe!");
        }
    }
}
