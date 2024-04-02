using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class game
    {
        private player p1, p2;
        public uint round { get; private set; }
        public game(player p1, player p2)
        {
            this.p1 = p1;
            this.p2 = p2;
            round = 0;
        }
        public static void StartGame()
        {
            Console.Clear();
            Console.WriteLine("$$$ STARTING GAME $$$");
            Console.WriteLine("Player 1 name :");
            string name1 = Console.ReadLine();
            Console.WriteLine("Player 2 name :");
            string name2 = Console.ReadLine();
            Console.WriteLine("Choose your decks");
            for(int i = 0; i < Menu.Decks.Count; i++)
            {
                Console.WriteLine($"{i+1}: {Menu.Decks[i].Name}");
            }
            Console.WriteLine($"{name1} choose your deck :");
            player player1 = new player(name1, Menu.Decks[Int32.Parse(Console.ReadLine())-1].GetDeck());
            Console.WriteLine($"{name2} choose your deck :");
            player player2 = new player(name2, Menu.Decks[Int32.Parse(Console.ReadLine())-1].GetDeck());
            game game = new game(player1, player2);
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                game.Round();
            }
        }
        public void Round()
        {
            Console.WriteLine($"<<< Round {round} has starded! >>>");
            PlayerRound(p1, p2);
            CheckBoard();
            Console.Clear();
            PlayerRound(p2, p1);
            CheckBoard();
            Console.Clear();
            round++;
        }
        private void PlayerRound(player current, player waiting)
        {
            Console.WriteLine($"Round {round} - {current.name}'s move");
            if (round == 0)
            {
                current.AddFromDeckToBoard();
            }
            else
            {
                current.ShowBoard();
                waiting.ShowBoard();
                current.AddFromDeckToBoard();
                Console.Clear();
                current.ShowBoard();
                Card attacker = current.WhoShouldAttack();
                attacker.Attack(current.WhatToAttack(waiting, attacker));
                Console.Clear();
            }
            current.ShowBoard();
            waiting.ShowBoard();
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
        }
        private void CheckBoard()
        {
            for(int i = 0; i < p1.board.Length; i++)
            {
                if(p1.board[i] != null)
                {
                    if (p1.board[i].currentHealth <= 0) p1.DeleteCardFromBoard(i);
                }
                if (p2.board[i] != null)
                {
                    if (p2.board[i].currentHealth <= 0) p2.DeleteCardFromBoard(i);
                }
            }
        }
    }
}
