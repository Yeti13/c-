using System.Collections.Generic;
using System;

namespace DeckOfCards{
    public class Player{
        public List<object> hand = new List<object>();
        public string name;

        public Player(string pName){
            name = pName;
        }

        public void draw(Deck drawDeck){
            hand.Add(drawDeck.cards[0]);
            drawDeck.cards.Remove(drawDeck.cards[0]);
        }

        public void showHand(){
            for(int card = 0; card < hand.Count; card++){
                System.Console.WriteLine(hand[card]);
            }
        }
        public void discard(int cardIdx){
            hand.Remove(hand[cardIdx-1]);
        }
    }
    public class Card{
        public string stringVal;
        public string suit;
        public int val;

        public Card(string strVal, string sut, int value){
            stringVal = strVal;
            suit = sut;
            val = value;
        }
        public override string ToString(){
            return stringVal + "  of  " + suit;
        }
    }
    public class Deck{
        public List<object> cards = new List<object>();
        
        public Deck(){
            initDeck();
        }
        public void initDeck(){
            string[] cardVal = {"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
            for (int idx = 1; idx <= 4; idx++){
                for (int card = 0; card < 13; card++){
                    if(idx == 1){
                        cards.Add(new Card(cardVal[card], "Spades", card+1));
                    }

                    if(idx == 2){
                        cards.Add(new Card(cardVal[card], "Clubs", card+1));
                    }

                    if(idx == 3){
                        cards.Add(new Card(cardVal[card], "Diamonds", card+1));
                    }

                    if(idx == 4){
                        cards.Add(new Card(cardVal[card], "Hearts", card+1));
                    }
                }
            }
        }
        public object deal(){
            object yourCard = this.cards[0];
            this.cards.Remove(yourCard);
            return(yourCard);
        }
        public void showAll(){
            for(int card = 0; card < cards.Count; card++){
                System.Console.WriteLine(cards[card]);
            }
        }
        public void shuffle(){
            Random rand = new Random();
            for (int i = cards.Count - 1; i > 0; i--){
                int first = rand.Next(i + 1);
                object temp = cards[i];
                cards[i] = cards[first];
                cards[first] = temp;
            }
        }
        public void reset(){
            cards.Clear();
            initDeck();
        }
    }
}