using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    // En - if a card attacks another card from the same origin (except None) it recieves 1 less damage.
    // Pl - jeśli zaatakujesz drugą kartę tego samego pochodzenia (poza None) to otrzymasz 1 obrażeń mniej.
    public enum Origin
    {
        None,
        OldCamp,
        NewCamp,
        SectCamp,
        Monster,
        Undead
    }
    // En - main class from which derives all other card classes. Contains all main functions
    // Pl - główna klasa, która słuzy jako baza dla wszystkich pozostałych. Posiada wszystkie główne funkcje.
    public abstract class Card
    {
        protected int health, cost;
        public int currentHealth { get; private set; }
        public int damage { get; private set; }
        public string name { get; private set; }
        public Origin origin { get; private set; }
        public Card(string name, int health, int damage, int cost, Origin origin)
        {
            this.health = health;
            currentHealth = health;
            this.damage = damage;
            this.cost = cost;
            this.name = name;
            this.origin = origin;
        }
        // En - Info returns base card stats and Status gives information about an already placed card.
        public virtual void Info()
        {
            Console.WriteLine($"{name} ({cost}) - HP {health} || DMG {damage} || {origin}");
        }
        public virtual void Status()
        {
            Console.WriteLine($"{name} : HP {currentHealth}/{health}|| DMG {damage}");
        }
        public virtual string StatusString()
        {
            return $"{name} : {currentHealth}/{health} || {damage}";
        }
        // En - main attack functionality. Most basic formula - attacker attacks and deals damage to defender.
        // Defender recieves damage and deals damage back (lowered by 1 if from same origin)
        // Other card types may have altered attack / defend formulas.
        protected void ChangeHealth(int dmg)
        {
            currentHealth -= dmg;
        }
        public virtual void Attack(Card defender)
        {
            defender.Defend(this);
            Console.WriteLine($"{this.name} attacked {defender.name}!");
            if (defender.origin == origin && origin != Origin.None)
            {
                ChangeHealth(defender.damage - 1);
            }
            else { ChangeHealth(defender.damage); }
        }
        public virtual void Defend(Card attacker)
        {
            ChangeHealth(attacker.damage);
        }
    }
    public class StandardCard : Card
    {
        public StandardCard(string name, int health, int damage, int cost, Origin origin) : base(name, health, damage, cost, origin)
        {
        }
    }
    public class TauntCard : Card
    {
        public TauntCard(string name, int health, int damage, int cost, Origin origin) : base(name, health, damage, cost, origin)
        {
        }
        public override void Info()
        {
            Console.WriteLine($"{name} ({cost}) : HP {health} || DMG {damage} || {origin} || #TAUNT#");
        }
        public override string StatusString()
        {
            return $"#TAUNT# {name} : HP {currentHealth}/{health} || DMG {damage}";
        }
        public override void Status() //returns current information about the card
        {
            Console.WriteLine($"#TAUNT# {name} : HP {currentHealth}/{health} || DMG {damage}");
        }
        // En - Taunt cards take priority when attacked and also take less damage from
        // same origin attackers.
        public override void Defend(Card attacker)
        {
            if (attacker.origin == origin && origin != Origin.None)
            {
                ChangeHealth(attacker.damage - 1);
            }
            else { ChangeHealth(attacker.damage); }
        }
    }
    public class PoisonCard : Card
    {
        public PoisonCard(string name, int health, int damage, int cost, Origin origin) : base(name, health, damage, cost, origin)
        {
        }
        public override void Info()
        {
            Console.WriteLine($"{name} ({cost}) : HP {health} || DMG {damage} || {origin} || <<LETHAL>>");
        }
        public override string StatusString()
        {
            return $"!LETHAL! {name} : HP {currentHealth}/{health} || DMG {damage}";
        }
        public override void Status()
        {
            Console.WriteLine($"!LETHAL! {name} : HP  {currentHealth} / {health}  || DMG {damage}");
        }
        // En - lethal cards kill any attacked card in 1 hit
        // This doesn't work as it defends!
        public override void Attack(Card defender)
        {
            StandardCard tmp = new StandardCard("one-shot", 1, 999, 0, Origin.None);
            defender.Defend(tmp);
            if (defender.origin == origin)
            {
                ChangeHealth(defender.damage - 1);
            }
            else { ChangeHealth(defender.damage); }
        }
    }
}
