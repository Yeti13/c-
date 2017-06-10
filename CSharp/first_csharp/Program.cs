using System;

namespace first_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++){
                if (i % 3 == 0){
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0){
                    Console.WriteLine("Buzz");
                }
                if (i % 15 == 0){
                    Console.WriteLine("FizzBuzz");
                }
            }
        }
    }
}
