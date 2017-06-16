using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Person player1 = new Person("Scallion");
            Person player2 = new Person("Joseph");
            // System.Console.WriteLine(player1.health);
            // player2.attack(player1);
            // System.Console.WriteLine(player1.health);
            Wizard player3 = new Wizard();
            Ninja ninja = new Ninja();
            Samurai samurai = new Samurai();
            // System.Console.WriteLine(player3.playerName);
            // System.Console.WriteLine(player3.health);
            // System.Console.WriteLine(player3.intel);
            // System.Console.WriteLine(player1.health);
            // player3.fireball(player1);
            // System.Console.WriteLine(player1.health);
            // player1.attack(player3);
            // System.Console.WriteLine(player3.health);
            // player3.heal();
            // System.Console.WriteLine(player3.health);
            ninja.attack(samurai);
            samurai.attack(ninja);
            samurai.deathBlow(player3);
            System.Console.WriteLine(player3.health);
        }
    }
}
