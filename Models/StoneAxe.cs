using System;
using System.Collections.Generic;

namespace Survival.Assets.Scripts.Models
{
    public class StoneAxe : Tools, Axe
    {

        public StoneAxe()
        {   
            name = "Stone Axe";
            requirements = new List<string> { "Stone", "Stick" };
            description = "A basic axe made from stone and wood.";
        }


        public void Chop()
        {
            Console.WriteLine("Chopping with a stone axe!");
        }
    }
}
