using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppGladiators.Models
{
    public class Coloseum
    {
        private Gladiator[] fighters = new Gladiator[0];
        

        public Gladiator[] AllFighters()
        {
            return fighters;
        }

        public void AddGladiator(Gladiator gladiator)
        {
            Array.Resize(ref fighters, fighters.Length + 1);//incress the size of array by 1
            fighters[fighters.Length - 1] = gladiator;
            //fighters[0] = gladiator;//not correct way to add in this case
        }

        public bool RemoveGladiator(int id)
        {
            bool foundGladiator = false;
            for (int index = 0; index < fighters.Length; index++)
            {
                if (fighters[index].id == id)
                {
                    foundGladiator = true;
                    for (int offset = index+1; offset < fighters.Length; offset++, index++)
                    {
                        fighters[index] = fighters[offset];
                    }
                    Array.Resize(ref fighters, fighters.Length - 1);//decress the size of array by 1
                    break;
                }
            }

            return foundGladiator;
        }

    }
}
