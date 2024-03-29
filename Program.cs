using System;
using System.Collections.Generic;

namespace CardGame
{
    class Program
    {
        // En - Deck1 and Deck2 are temporary functions that generate premade decks made by me
        // Pl - Dwie tymczasowe funkcje, które generują 2 talie kart stworzone przeze mnie
        static List<Card> Deck1()
        {
            StandardCard card1 = new StandardCard("Miner", 2, 1, 1, Origin.None);
            StandardCard card2 = new StandardCard("Camp Guard", 3, 3, 2, Origin.OldCamp);
            StandardCard card3 = new StandardCard("Camp Guard", 3, 3, 2, Origin.OldCamp);
            TauntCard card4 = new TauntCard("Beetle", 1, 0, 1, Origin.Monster);
            PoisonCard card5 = new PoisonCard("Diego", 2, 2, 3, Origin.OldCamp);
            TauntCard card6 = new TauntCard("Thorus", 5, 2, 3, Origin.OldCamp);
            StandardCard card7 = new StandardCard("Orc", 5, 5, 4, Origin.Monster);
            StandardCard card8 = new StandardCard("Orc Shaman", 4, 8, 5, Origin.Monster);
            List<Card> deck = new List<Card>() { card1, card2, card3, card4, card5, card6, card7, card8};
            return deck;
        }
        static List<Card> Deck2()
        {
            StandardCard card1 = new StandardCard("Miner", 2, 1, 1, Origin.None);
            StandardCard card2 = new StandardCard("Cultist", 4, 2, 2, Origin.SectCamp);
            StandardCard card3 = new StandardCard("Cultist", 4, 2, 2, Origin.SectCamp);
            TauntCard card4 = new TauntCard("Beetle", 1, 0, 1, Origin.Monster);
            StandardCard card5 = new StandardCard("Guru", 3, 5, 3, Origin.SectCamp);
            TauntCard card6 = new TauntCard("Thorus", 5, 2, 3, Origin.OldCamp);
            StandardCard card7 = new StandardCard("Orc", 5, 5, 4, Origin.Monster);
            StandardCard card8 = new StandardCard("Skeleton", 6, 6, 5, Origin.Undead);
            List<Card> deck = new List<Card>() { card1, card2, card3, card4, card5, card6, card7, card8 };
            return deck;
        }
        // The main loop of the game. Right now it allows both premade players
        // to place cards and attack. There's no winning condition right now.
        // Game ends after 5 rounds.
        // Główna pętla gry. Na ten moment mamy 2 graczy z gotowymi taliami kart.
        // Gracze mogą stawiać karty na stole oraz atakować.
        // Kończy się po 5 rundach.
        static void Main(string[] args)
        {
            player player1 = new player("Neten2115", Deck1());
            player player2 = new player("Atrix231", Deck2());
            game game = new game(player1, player2);
            for(int i = 0; i < 5; i++)
            {
                game.Round();
            }
        }
    }
}
