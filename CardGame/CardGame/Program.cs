using System;
using System.Collections.Generic;
using System.Threading;

namespace CardGame
{
    class Program
    {
        // En - Deck1 and Deck2 are temporary functions that generate premade decks made by me
        // Pl - Dwie tymczasowe funkcje, które generują 2 talie kart stworzone przeze mnie
        public static List<Card> GenerateBasicCards()
        {
            List<Card> list = new List<Card>();
            list.Add(new StandardCard("Kopacz", 2, 1, 1, Origin.None));
            list.Add(new StandardCard("Strażnik", 3, 3, 2, Origin.OldCamp));
            list.Add(new StandardCard("Najemnik", 2, 4, 2, Origin.NewCamp));
            list.Add(new StandardCard("Sekciarz", 4, 2, 2, Origin.SectCamp));
            list.Add(new TauntCard("Thorus", 6, 2, 3, Origin.OldCamp));
            list.Add(new RangedCard("Wilk", 2, 3, 3, Origin.NewCamp));
            list.Add(new PoisonCard("Cor'Angar", 4, 2, 3, Origin.SectCamp));
            list.Add(new StandardCard("Ork", 5, 5, 4, Origin.Monster));
            list.Add(new RangedCard("Ork Szaman", 6, 3, 5, Origin.Monster));
            list.Add(new StandardCard("Szkielet", 4, 8, 4, Origin.Undead));
            list.Add(new TauntCard("Szkielet Wojownik", 8, 4, 4, Origin.Undead));
            return list;
        }
        public static List<deck> GenerateBasicDecks()
        {
            int[] card_index1 = new int[] { 0, 1, 1, 4, 7 };
            int[] card_index2 = new int[] { 0, 2, 4, 5, 10 };
            List<Card> cards1 = new List<Card>();
            List<Card> cards2 = new List<Card>();
            for(int i = 0; i<5; i++)
            {
                cards1.Add((Card)Menu.AllCards[card_index1[i]].Clone());
                cards2.Add((Card)Menu.AllCards[card_index2[i]].Clone());
            }
            deck deck1 = new deck("Gomez nie wiedział", cards1);
            deck deck2 = new deck("Ten co nienawidził króla", cards2);
            return new List<deck>() { deck1, deck2 };
        }
        // The main loop of the game. Right now it allows both premade players
        // to place cards and attack. There's no winning condition right now.
        // Game ends after 5 rounds.
        // Główna pętla gry. Na ten moment mamy 2 graczy z gotowymi taliami kart.
        // Gracze mogą stawiać karty na stole oraz atakować.
        static void Main(string[] args)
        {
            Menu.MainMenu();
        }
    }
}
