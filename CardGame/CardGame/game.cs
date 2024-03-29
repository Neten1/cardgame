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
                current.WhoShouldAttack().Attack(current.WhatToAttack(waiting));
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
