using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = {0,1,2,3,4,5,6,7,8,9};
            foreach (int num in numArray){
                Console.WriteLine(num);
            }
            string[] nameArray = {"Tim", "Martin", "Nikki", "Sara"};
            foreach (string name in nameArray){
                Console.WriteLine(name);
            }
            bool[] boolArray = {true, false, true, false, true, true, false, true, false, true};
            foreach (bool state in boolArray){
                System.Console.WriteLine(state);
            }
            List<string> iceCream = new List<string>();

            iceCream.Add("Vanilla");
            iceCream.Add("Chocolate");
            iceCream.Add("Strawberry");
            iceCream.Add("Rocky Road");
            iceCream.Add("Mint Chocolate");

            System.Console.WriteLine(iceCream.Count);
            System.Console.WriteLine(iceCream[2]);

            iceCream.Remove(iceCream[2]);

            System.Console.WriteLine(iceCream.Count);

            Random rnd = new Random();

            Dictionary<string,string> favFlave = new Dictionary<string,string>();
            favFlave.Add(nameArray[0], iceCream[rnd.Next(0, 4)]);
            favFlave.Add(nameArray[1], iceCream[rnd.Next(0, 4)]);
            favFlave.Add(nameArray[2], iceCream[rnd.Next(0, 4)]);
            favFlave.Add(nameArray[3], iceCream[rnd.Next(0, 4)]);
            
            foreach (KeyValuePair<string,string> entry in favFlave){
                System.Console.WriteLine(entry.Key + "-" + entry.Value);
            }

            int sum = 0;
            List<object> myList = new List<object>();
            myList.Add(7);
            myList.Add(28);
            myList.Add(-1);
            myList.Add(true);
            myList.Add("chair");

            foreach (var item in myList){
                if (item is int){
                    sum = sum + (int)item;
                    System.Console.WriteLine(item);
                }
            }
            System.Console.WriteLine(sum);
        }
    }
}
