using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class player
    {
        public string name { get; private set; }
        private List<Card> deck;
        public Card[] board { get; private set; }
        public player(string name, List<Card> deck)
        {
            this.name = name;
            this.deck = deck;
            board = new Card[5];
        }
        public void AddFromDeckToBoard()
        {
            Console.WriteLine($"Pick which card should be placed on the board. (1-{deck.Count})");
            ShowDeck();
            int card_index_choice = Int32.Parse(Console.ReadLine()) - 1;
            Console.WriteLine($"Pick where should the card be placed. (1-5)");
            int card_placement_choice = Int32.Parse(Console.ReadLine()) - 1;
            AddToBoard(deck[card_index_choice],  card_placement_choice);
        }
        private void AddToBoard(Card card, int position)
        {
            board[position] = card;
            deck.Remove(card);
        }
        public void DeleteCardFromBoard(int index)
        {
            board[index] = null;
        }
        public void ShowDeck()
        {
            Console.WriteLine($"{name}'s deck");
            int count = 1;
            foreach(Card i in deck)
            {
                Console.Write($"{count} : ");
                i.Info();
                count++;
            }
        }
        public void ShowBoard()
        {
            Console.WriteLine($"{name}'s current board");
            foreach (Card i in board)
            {
                if (i == null) Console.WriteLine("[/]");
                else i.Status();
            }
        }
        public Card WhoShouldAttack()
        {
            Console.WriteLine("Pick your attacker (1-5) :");
            int choice = Int32.Parse(Console.ReadLine()) - 1;
            return board[choice];
        }
        private bool hasTaunt(Card[] b)
        {
            foreach(Card i in b)
            {
                if (i is TauntCard) return true;
            }return false;
        }
        public Card WhatToAttack(player enemy, Card type)
        {
            bool taunt = hasTaunt(enemy.board);
            Console.WriteLine("Pick who to attack (1-5)");
            for(int i = 0; i < 5; i++)
            {
                if((taunt && enemy.board[i] is TauntCard) || (!taunt && enemy.board[i] is not null) || (type.GetType() == typeof(RangedCard) && enemy.board[i] is not null))
                {
                    Console.WriteLine($"{i+1} - {enemy.board[i].StatusString()}");
                }
            }
            int choice = Int32.Parse(Console.ReadLine()) - 1;
            return enemy.board[choice];
        }
    }
}
