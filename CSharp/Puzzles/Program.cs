using System;
using System.Linq;

namespace Puzzles
{
    class Program
    {

        static int[] randArray(){
            int[] arr = new int[10];
            Random num = new Random();
            for (int idx = 0; idx < arr.Length; idx++){
                int rnd = num.Next(5,25);
                arr[idx] = rnd;
            }
            int max = arr[0];
            int min = arr[0];
            for (int item = 0; item < arr.Length; item++){
                if (arr[item] > max){
                    max = arr[item];
                }
                if (arr[item] < min){
                    min = arr[item];
                }
            }
            System.Console.WriteLine(max);
            System.Console.WriteLine(min);
            return(arr);
        }

        static void coinToss(int flips){
            Random num = new Random();
            int score = 0;
            int heads = 0;
            for (int count = 1; count <= flips; count++){
                System.Console.WriteLine("Fliping a coin...");
                int flip = num.Next(1,10);
                if (flip > 5){
                    System.Console.WriteLine("Heads");
                    score++;
                    heads++;
                }
                if (flip < 6){
                    System.Console.WriteLine("Tails");
                    score--;
                }
            }
            if (score < 0){
                System.Console.WriteLine("Tails Wins!");
            }
            if (score > 0){
                System.Console.WriteLine("Heads Wins!");
            }
            if (score == 0){
                System.Console.WriteLine("It's a tie.");
            }
            double ratio = (double)heads/flips;
            System.Console.WriteLine("The ratio of heads is:  " + ratio);
        }

        // Random random = new Random();
        
        static void names(){
            Random num = new Random();
            string[] nameArr = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            string[] randArr = new string[nameArr.Length];
            string[] newArr = new string[nameArr.Length-1];
            int idx = num.Next(0, nameArr.Length-1);
            int point = 0;
            for (int item = idx; item < nameArr.Length; item++){
                randArr[point] = nameArr[item];
                point++;
            }
            for (int dot = 0; dot < idx; dot++){
                randArr[point] = nameArr[dot];
                point++;
            }
            point = 0;
            for (int check = 0; check < nameArr.Length; check++){
                if (nameArr[check].Length >= 5){
                    newArr[point] = nameArr[check];
                    point++;
                }
            }
            foreach (string item in newArr){
                System.Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            // randArray();
            // coinToss(10);
            names();
        }
    }
}
