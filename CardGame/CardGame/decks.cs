using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class deck : ICloneable
    {
        public string Name { get; private set; }
        public List<Card> Cards { get; private set; }
        public deck(string name, List<Card> cards)
        {
            Name = name;
            Cards = cards;
        }
        public List<Card> GetDeck()
        {
            /* For future 
            List<Card> oldList = new List<Card>();
            List<Card> newList = new List<Card>(oldList.Count);

            oldList.ForEach((item) =>
            {
                newList.Add(new StandardCard(item));
            });
            return newList;
            */
            return new List<Card>(Cards);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
