using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multibingowithcash
{
    internal class Program
    {
        public static int cash = 0;
        public static int bingoCard = 100;
        public static bool enoughcash = false;
        public static int[,] card = new int[5, 5];
        public static Random rnd = new Random();
        public static HashSet<int> used = new HashSet<int>();
        public static int[] columns = { 1, 16, 31, 46, 61 };

        static void Main(string[] args)
        {
            Console.WriteLine("HELLO! WELCOME TO BINGO GENERATOR :>");
            Console.WriteLine("1 bingo card = 100");
            Console.WriteLine($"credits: {cash}");
            while (cash < 100)
            {
                topUp();
            }
            generating();
        }
        public static void generating()
        {
            if (cash >= bingoCard)
            {
                for (int j = 0; j < columns.Length; j++)
                {
                    string question1;
                    Console.Write("Do you want to create cards?: y/n: ");
                    question1 = Console.ReadLine().ToLower();
                    if (question1 == "y")
                    {
                        int createmoreCards;
                        Console.Write("how many cards do you want?: ");
                        createmoreCards = int.Parse(Console.ReadLine());
                        for (int x = 0; x < createmoreCards; x++)
                        {
                            used.Clear();
                            Array.Clear(card, 0, card.Length);
                            printoutput();
                            cash -= bingoCard;
                            Console.WriteLine($"credits: {cash}");
                            if (cash < bingoCard)
                            {
                                Console.WriteLine("you run out of credits do you want to top up (y/n): ");
                                string runoutofcash = Console.ReadLine().ToLower();
                                if (runoutofcash == "y")
                                {
                                    while (cash < 100)
                                    {
                                        topUp();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("you poor");
                                    Environment.Exit(0);
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Thank you for generating BINGO Cards!");
                        break;
                    }
                }
            }
            else
            {
                topUp();
            }

        }

        public static void printoutput()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int rangeStart = columns[j];
                    int num;
                    do
                    {
                        num = rnd.Next(rangeStart, rangeStart + 15);
                    } while (!used.Add(num));
                    card[i, j] = num;
                    if (i == 2 && j == 2)
                    {
                        card[i, j] = 0;
                    }
                }

            }
            Console.WriteLine("--------------------------");
            Console.WriteLine("| B  | I  | N  | G  | O  |");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("--------------------------");
                for (int j = 0; j < 5; j++)
                {
                    if (card[i, j] == 0)
                    {
                        Console.Write("|FREE");
                    }
                    else
                    {
                        Console.Write($"| {card[i, j]:D2} ");
                    }
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("--------------------------");
            Console.WriteLine();
        }

        public static void topUp()
        {
            string topup;
            int tempcash;
            if (cash < 100)
            {
                Console.WriteLine("please top up to generate cards");
                Console.Write("do you want to top up? (y/n): ");
                topup = Console.ReadLine().ToLower();
                if (topup == "y")
                {
                    Console.Write("enter amount: ");
                    tempcash = int.Parse(Console.ReadLine());
                    cash += tempcash;
                    Console.WriteLine($"Credits: {cash}");
                    return;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                return;
            }
        }
    }
}