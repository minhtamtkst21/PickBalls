using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePickBallsVsComputer
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] game = new int[] { 0, 3, 4, 6 };
            PrintGame(game);
            while (true)
            {
                HumanMove(game);
                PrintGame(game);
                if (has0Group(game))
                {
                    Console.WriteLine("You Lose!");
                    break;
                }
                Console.WriteLine("Computer is thinking.........");
                ComputerMove(game);
                PrintGame(game);
                if (has0Group(game))
                {
                    Console.WriteLine("You Win!!");
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
        static void ComputerMove(int[] game)
        {
            if (has1Group(game))
            {
                int g = 0;
                get1Group(game, out g);
                if (game[g] > 1)
                {
                    Console.WriteLine("Computer pick {0} balls in groups {1} ", game[g]-1, g);

                    PickBalls(game, g, game[g] - 1);
                }
                else
                {
                    Console.WriteLine("Computer pick {0} balls in groups {1} ", 1, g);

                    PickBalls(game, g, 1);
                }
            }
            else if (has2Group(game))
            {
                int a= 0, b = 0;
                get2Groups(game, out a, out b);
                
                if (a != b)
                {
                    if (game[a] == 1)
                    {
                        Console.WriteLine("Computer pick {0} balls in groups {1} ", game[b], b);
                        PickBalls(game, b, game[b]);
                    }
                    else if(game[a] == 1)
                    {
                        Console.WriteLine("Computer pick {0} balls in groups {1} ", game[a], a);
                        PickBalls(game, a, game[a]);
                    }
                    else if (game[a] > game[b])
                    {
                        Console.WriteLine("Computer pick {0} balls in groups {1} ", game[a] - game[b], a);
                        PickBalls(game, a, game[a] - game[b]);
                    }
                    else
                    {
                        Console.WriteLine("Computer pick {0} balls in groups {1} ", game[b] - game[a], b);
                        PickBalls(game, b, game[b] - game[a]);
                    }
                }
                else
                {
                    Console.WriteLine("Computer pick {0} balls in groups {1} ", 1, a);
                    PickBalls(game, a, 1);
                }
            }
            else
            {
                Random rand = new Random();
                int g = rand.Next(1, 3);
                int b = rand.Next(1, game[g]);
                Console.WriteLine("Computer pick {0} balls in groups {1} ", b, g);

                PickBalls(game, g, b);
            }
        }
        static bool has1Group(int[] game)
        {
            if (game[1] > 0 && game[2] <= 0 && game[3] <= 0)
            {
                return true;
            }
            if (game[1] <= 0 && game[2] > 0 && game[3] <= 0)
            {
                return true;
            }
            if (game[1] <= 0 && game[2] <= 0 && game[3] > 0)
            {
                return true;
            }
            return false;
        }
        static bool has2Group(int[] game)
        {
            if (game[1] > 0 && game[2] > 0 && game[3] <= 0)
            {
                return true;
            }
            if (game[1] <= 0 && game[2] > 0 && game[3] > 0)
            {
                return true;
            }
            if (game[1] > 0 && game[2] <= 0 && game[3] > 0)
            {
                return true;
            }
            return false;
        }
        static void get1Group(int[] game,out int g)
        {
            g = 0;
            if (game[1] > 0 && game[2] <= 0 && game[3] <= 0)
            {
                g = 1;
            }
            if (game[1] <= 0 && game[2] > 0 && game[3] <= 0)
            {
                g = 2;
            }
            if (game[1] <= 0 && game[2] <= 0 && game[3] > 0)
            {
                g = 3;
            }
        }
        static void get2Groups(int[] game, out int a, out int b)
        {
            a = 0;
            b = 0;
            if (game[1] > 0 && game[2] > 0 && game[3] <= 0)
            {
                a = 1;
                b = 2;
            }
            if (game[1] <= 0 && game[2] > 0 && game[3] > 0)
            {
                a = 2;
                b = 3;
            }
            if (game[1] > 0 && game[2] <= 0 && game[3] > 0)
            {
                a = 1;
                b = 3;
            }
        }
    }
}
