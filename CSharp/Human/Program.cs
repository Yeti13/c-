using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human player1 = new Human("Scallion");
            Human player2 = new Human("Joseph");
            System.Console.WriteLine(player1.health);
            player2.attack(player1);
            System.Console.WriteLine(player1.health);
        }
    }
}
