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

            /* for (int fillKinoTable = 0; fillKinoTable < Constants.numbersInArray; fillKinoTable++)
             {
                 kinoTable[fillKinoTable] = 0;
                 if ( fillKinoTable == 10 || fillKinoTable == 20 || fillKinoTable == 30 || fillKinoTable == 40 || fillKinoTable == 50 || fillKinoTable==60 || fillKinoTable == 70 ||fillKinoTable == 80)
                 {
                     Console.Write("\n");
                 }
                 //Console.WriteLine(fillKinoTable); | Checks if we did it 
                 Console.Write($"| {kinoTable[fillKinoTable]} |");
             }*/

            // Ask User to Play
            Console.WriteLine("Let's start playing \n");
            Console.WriteLine("Pick a Number from 1 to 12 - (this will the amount of numbers you will choose)");

            int howManyNumbers = Convert.ToInt32(Console.ReadLine());
            int[] numberUser = new int[howManyNumbers]; //creates an ARRAY with x elements -- number of elements chosen by the user too.

            for(int i = 0; i < howManyNumbers; i++)
            {
                //Lets fill the array with user's numbers
                Console.WriteLine("Pick a number from 1 to 80 \n"); // ? Problem - the user may not listen print and choose another number ? 
                int numberPicked = Convert.ToInt32(Console.ReadLine());
                numberUser[i] = numberPicked;
                Console.WriteLine($"The number {numberPicked} - was added to your List \n");
            }
            Console.WriteLine("|Yours Numbers are| \n");
            for (int y = 0; y < howManyNumbers; y++)
            {
                Console.Write($" |{numberUser[y]}|");
            }


                Console.Write("\n \n"); //SKIP LINES
            var generator = new RandomGenerator();
            for (int choosingLoop=0; choosingLoop< Constants.computerChoose; choosingLoop++)
            {
                //var generator = new RandomGenerator();
                var randomNumber = generator.RandomNumber(1, 80); //problem -- the random numbers array may contain same numbers ! 
                Console.WriteLine($"The machine picked the number: {randomNumber}");
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

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
