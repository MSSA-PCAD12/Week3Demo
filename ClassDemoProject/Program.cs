using System.Collections;
using VictorDemo;



namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("Victor",FuelType.Hybrid,4);
            Car bobCar = new Car("Bob", FuelType.Diesel, 3);
            myCar.Drive(15085);
            bobCar.Drive(3234);
            Console.WriteLine($"{myCar.VIN} has {myCar.OdometerInMiles} miles.");
            Console.WriteLine($"{bobCar.VIN} has {bobCar.OdometerInKM} KM.");

            //System.Environment
            Console.WriteLine($"Program is running from {System.Environment.CurrentDirectory}");
            Console.WriteLine($"Your username is {System.Environment.UserName}");
            Console.WriteLine($"Computer has {System.Environment.ProcessorCount} processors");
            Console.WriteLine($"Your document folder is {System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}" );
            Console.WriteLine($"Your PC is named:{System.Environment.MachineName}");

            //Print out ALL Environment Variables
            //System.Environment.GetEnvironmentVariables()

            Console.WriteLine($"{new String('=', 40)}");
            foreach (DictionaryEntry dictionaryEntry in System.Environment.GetEnvironmentVariables())
            {   
                Console.WriteLine($"{dictionaryEntry.Key,20}={dictionaryEntry.Value,-20}");
            }

            Console.WriteLine($"{new String('=', 40)}");

            Random rnd = Random.Shared; // single instance that shared across method and threads.
            Random rnd2 = new Random(); //every unique instance has a different seed
            string[] rps = ["rock", "paper", "scissor"];

            for (int i = 0; i < 50; i++) {
                Console.WriteLine($"computer throws : {rps[rnd.Next(3)]}");
            }
            
        }
    }
}

