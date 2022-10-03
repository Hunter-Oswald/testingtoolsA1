using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame_B
{
    public static class BattleSystem
    {
        //You will need to replace anything in <these> with the proper datatypes
        //and variable names that work for your implementation

        static public void Main(String[] args)
        {
            //
            int bossHP = 300;
            while (bossHP > 0)
            {
                Console.WriteLine("The Boss has " + bossHP + " HP Remaining!");
                Console.WriteLine("Enter your next attack type (1 = F, 2 = W, 3 = G: ");
                String attackTypeS = Console.ReadLine();

                int attackType = 1;

                if (int.TryParse(attackTypeS, out attackType))
                {

                }
                else
                {
                    // make sure the input is valid. if not, assign it to fire.
                    Console.WriteLine("Invalid input. Attack type automatically set to Fire.");
                }


                if (attackType <= 0 || attackType > 3)
                {
                    Console.WriteLine("Invalid input.");
                }
                else
                {
                    int damage = RunBattle(attackType);
                    bossHP = bossHP - damage;
                }
            }
            Console.WriteLine("Boss has been defeated!");
            Environment.Exit(0);
        }

        public static int RunBattle(int attackType)
        {
            // 1 = fire, 2 = water, 3 = grass
            int defense = GenerateDefense();

            int att = GenerateAttack(defense, attackType);
            Console.WriteLine($"Attack's damage: {att}");

            return att;
        }

        private static int GenerateDefense()
        {
            // 1 = fire, 2 = water, 3 = grass
            Random rnd = new Random();
            int defenseType = rnd.Next(1, 4);
            return defenseType;

        }



        private static int GenerateAttack(int defenseType, int attackType)
        {
            // attack power random from 1-20
            Random rnd = new Random();
            int attackPow = rnd.Next(1, 21);

            double elementMult = 1;

            // 1 = fire, 2 = water, 3 = grass
            if (attackType == 1 && defenseType == 3)
            {
                elementMult = 2;
            }
            else if (attackType == 1 && defenseType == 2)
            {
                elementMult = 0.5;
            }
            else if (attackType == 1 && defenseType == 1)
            {
                elementMult = 1;
            }
            else if (attackType == 2 && defenseType == 1)
            {
                elementMult = 2;
            }
            else if (attackType == 2 && defenseType == 2)
            {
                elementMult = 1;
            }
            else if (attackType == 2 && defenseType == 3)
            {
                elementMult = 0.5;
            }
            else if (attackType == 3 && defenseType == 1)
            {
                elementMult = 0.5;
            }
            else if (attackType == 3 && defenseType == 2)
            {
                elementMult = 2;
            }
            else if (attackType == 3 && defenseType == 3)
            {
                elementMult = 1;
            }
            else
            {
                elementMult = 1;
            }

            // critical strike chance
            int crit = 1;
            int critChance = rnd.Next(1, 21);

            if (critChance == 20)
            {
                crit = 3;
                Console.WriteLine("Critical Hit!");
            }

            if (elementMult == 2)
            {
                Console.WriteLine("Attack was super effective!");
            }
            else if (elementMult == 0.5)
            {
                Console.WriteLine("Attack was not very effective.");
            }
            else
            {

            }

            int finalAttackPow = (int)((int)attackPow * elementMult * crit);
            return finalAttackPow;


        }

    }
}
