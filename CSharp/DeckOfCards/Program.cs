using System;
using System.Reflection;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Card card1 = new Card("Ace", "Spades", 1);
            Deck myDeck = new Deck();
            Player player1 = new Player("Yeti");
            System.Console.WriteLine(player1.name);
            player1.draw(myDeck);
            player1.draw(myDeck);
            player1.draw(myDeck);
            player1.draw(myDeck);
            player1.draw(myDeck);
            player1.draw(myDeck);
            player1.showHand();
            System.Console.WriteLine("*********");
            player1.discard(1);
            player1.showHand();
        }
    }
}
