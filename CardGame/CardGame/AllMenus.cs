using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CardGame
{
    class Menu
    {
        //These are all the cards and decks that contain them
        public static List<Card> AllCards = Program.GenerateBasicCards();
        public static List<deck> Decks = Program.GenerateBasicDecks();
        public static void MainMenu()
        {
            Console.Clear();
            Console.Write("====> The Placeholder Name <====\n" +
                  "1: Start Game\n" +
                  "2: Configure Decks\n" +
                  "3: How to play\n\n" +
                  "Input number and press enter\n");
            switch (Console.ReadLine())
            {
                case "1":
                    game.StartGame();
                    break;
                case "2":
                    DeckMenu();
                    break;
                case "3":
                    TutorialMenu();
                    break;
                default:
                    MainMenu();
                    break;
            }
        }
        public static void CardsMenu()
        {
            Console.Clear();
            Console.WriteLine("#=== Card edition ===#");
            Console.WriteLine("1. Add new card");
            Console.WriteLine("2. Remove a card");
            Console.WriteLine("3. List all cards");
            Console.WriteLine("4. Back<");
            switch (Console.ReadLine())
            {
                case "1":
                    AddNewCard();
                    break;
                case "2":
                    Console.WriteLine("Not added yet.");
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("#=== List of All Available Cards ===#");
                    for (int i = 0; i < AllCards.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {AllCards[i].StatusString()}");
                    }
                    Console.WriteLine("There will be search, filter and sort functions.");
                    Console.ReadLine();
                    CardsMenu();
                    break;
                default:
                    DeckMenu();
                    break;
            }
        }
        private static void AddNewCard()
        {
            Console.WriteLine("Not added yet.");
        }
        static void DeckMenu()
        {
            Console.Clear();
            Console.WriteLine("===> Deck Editor <===");
            Console.WriteLine("1. List and edit decks");
            Console.WriteLine("2. List and edit cards");
            Console.WriteLine("3. Back<");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    foreach (deck d in Decks)
                    {
                        Console.WriteLine("## "+d.Name+" :");
                        foreach (Card c in d.Cards)
                        {
                            c.Info();
                        }
                    }Console.ReadLine();
                    DeckMenu();
                    break;
                case "2":
                    CardsMenu();
                    break;
                default:
                    MainMenu();
                    break;
            }
        }
        static void OpenTutorialMessage()
        {
            string filePath = @"../../../tutorial.txt";
            try
            {
                string[] file = File.ReadAllLines(filePath);
                foreach (string i in file)
                {
                    Console.WriteLine(i);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        static void TutorialMenu()
        {
            Console.Clear();
            Console.WriteLine("For more graphicly pleasing version head here :");
            Console.WriteLine("https://github.com/Neten1 (Not yet released)");
            OpenTutorialMessage();
            Console.ReadLine();
            MainMenu();
        }
    }
}
