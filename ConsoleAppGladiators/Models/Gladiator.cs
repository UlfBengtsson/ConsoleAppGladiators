using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppGladiators.Models
{
    public class Gladiator
    {
        private static Random rng = new Random();
        private readonly string[] npcNames = { "Maximus", "Tetraites", "Priscus", "Spiculus" };//new string[] { }

        int str;
        int dex;
        int vit;
        int hp;
        bool alive;

        string name;

        public int Str { get { return str; } }
        public int Dex { get { return dex; } }
        public int Vit { get { return vit; } }
        public int HP 
        { 
            get { return hp; } 
            private set 
            { 
                hp -= value;
                if (hp <= 0)
                {
                    alive = false;
                }
            }
        }
        public bool Alive { get {return alive; } }
        public string Name { 
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
                }

                this.name = value;
            }
        }

        public Gladiator()
        {
            str = rng.Next(1, 13);//rng.Next(12)+1;
            dex = rng.Next(1, 13); ;
            vit = rng.Next(1, 13); ;
            hp = vit * 10;
            alive = true;
            name = npcNames[rng.Next(npcNames.Length)];
        }

        public Gladiator(string name, int str, int dex, int vit)
        {
            this.str = str;
            this.dex = dex;
            this.vit = vit;
            this.hp = vit * 10;
            alive = true;
            this.Name = name;
        }

        public bool TakeDamage(int dmg)
        {
            if (alive && dmg > 0)
            {
                HP = dmg;
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
