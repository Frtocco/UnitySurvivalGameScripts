using System;
using System.Collections.Generic;

namespace Survival.Assets.Scripts.Models
{
    public interface Axe
    {
        
        public virtual void Chop()
        {
            Console.WriteLine("Chopping...");
        }
    }
}
