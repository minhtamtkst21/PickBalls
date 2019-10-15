using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePickBallsPvP
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int rand1=0,rand2=0,rand3=0;
            while (true)
            {
                if (rand1 == rand2 && rand2 == rand3 && rand1 == rand3)
                {
                    rand1 = rand.Next(3, 10);
                    rand2 = rand.Next(3, 10);
                    rand3 = rand.Next(3, 10);
                }
                else
                {
                    break;
                }
                 
            }
            int[] game = new int[] { 0, rand1, rand2, rand3 };
            PrintGame(game);
            while (true)
            {
                Console.WriteLine("Player 1 pick Balls............");
                HumanMove(game);
                PrintGame(game);
                if (has0Group(game))
                {
                    Console.WriteLine("Player 2 Win!!");
                    break;
                }
                Console.WriteLine("Player 2 pick balls............");
                HumanMove(game);
                PrintGame(game);
                if (has0Group(game))
                {
                    Console.WriteLine("Player 1 Win!!");
                    break;
                }
            }
        }
        static void PrintGame(int[] game)
        {
            Console.Write("Group 1:");
            for (int i = 0; i < game[1]; i++)
            {
                Console.Write("o");
            }
            Console.WriteLine();
            Console.Write("Group 2:");
            for (int i = 0; i < game[2]; i++)
            {
                Console.Write("o");
            }
            Console.WriteLine();
            Console.Write("Group 3:");
            for (int i = 0; i < game[3]; i++)
            {
                Console.Write("o");
            }
            Console.WriteLine();
        }
        static bool has0Group(int[] game)
        {
            if (game[1] == 0 && game[2] == 0 && game[3] == 0)
            {
                return true;
            }
            return false;
        }
        static void HumanMove(int[] game)
        {
            Console.Write("Which group do you choose? ");
            int g = int.Parse(Console.ReadLine());
            Console.Write("How many ball will you pick?");
            int b = int.Parse(Console.ReadLine());
            PickBalls(game, g, b);
        }
        static void PickBalls(int[] game, int g, int b)
        {
            game[g] -= b;
        }
    }
}
