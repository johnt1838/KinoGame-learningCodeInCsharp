using System;
using System.Data;

namespace Kino
{

    static class Constants
    {
        public const int numbersInArray = 80;
        public const int computerChoose = 20;
    }

    class Program
    {

        static void Main(string[] args)
        {
            int[] kinoTable = new int[Constants.numbersInArray];
            int[] computerNumbersTable = new int[Constants.computerChoose];

            // Ask User to Play
            Console.WriteLine("Let's Start !\n");
            Console.WriteLine("Pick a Number from 1 to 12 - (this will the amount of numbers you will choose)");

            int howManyNumbers = Convert.ToInt32(Console.ReadLine());
            int[] numberUser = new int[howManyNumbers]; //creates an ARRAY with x elements -- number of elements chosen by the user too.

            int counter = 0;
            while (counter < howManyNumbers){
                Console.WriteLine("Pick a number from 1 to 80 \n"); // ? Problem - the user may not listen print and choose another number ? 
                int numberPicked = Convert.ToInt32(Console.ReadLine());
                if (numberPicked < 1 || numberPicked > 80)
                {
                    Console.WriteLine("Invalid number. Please choose a number between 1 and 80.");
                    continue;
                }
                if (Array.IndexOf(numberUser, numberPicked) != -1)
                {
                    Console.WriteLine("This number is already in your list. Try again.");
                    continue;
                }
                numberUser[counter] = numberPicked;
                counter++;
                Console.WriteLine($"The number {numberPicked} - was added to your List \n");
            }




            Console.WriteLine("|Yours Numbers are| \n");
            for (int y = 0; y < howManyNumbers; y++)
            {
                Console.Write($" |{numberUser[y]}|");
            }


            Console.Write("\n \n"); //SKIP LINES
            var generator = new RandomGenerator();
            Console.WriteLine($"The machine picked the numbers: \n");
            for (int choosingLoop = 0; choosingLoop < Constants.computerChoose; choosingLoop++)
            {
                //var generator = new RandomGenerator();
                var randomNumber = generator.RandomNumber(1, 80); //todo: problem -- the random numbers array may contain same numbers ! 
                for (int i = 0; i < Constants.computerChoose; i++)
                {
                    if (computerNumbersTable[i] == randomNumber)
                    {
                        i = 0; // Re - DO the for loop to Re-CHECK. 
                        randomNumber = generator.RandomNumber(1, 80);  // Assign New Random Number
                    }
                }
                Console.Write($"({randomNumber}) ");
                computerNumbersTable[choosingLoop] = randomNumber;
                kinoTable[randomNumber - 1]++;
            }


        }
    }



    public class RandomGenerator
    {
        // Instantiate random number generator.  
        // It is better to keep a single Random instance 
        // and keep using Next on the same instance.  
        private readonly Random _random = new Random();

        // Generates a random number within specified range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
