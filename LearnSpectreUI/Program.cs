
using Spectre.Console;
using System.Text;

namespace LearnSpectreUI
{
    internal class Program
    {
        //declare these emoji at class level so all static method can access them
        //if declared in Main, other methods such as GetComputerHand and CompareHands won't see them
        //becaus stack
        static string rock = "✊";
        static string scissor = "✌";
        static string paper = "✋";

        static FileInfo logFile= 
            new FileInfo(
                 System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + Path.DirectorySeparatorChar + "rpslog.txt");
        static StreamWriter? logger=null;


        static void Main(string[] args)
        {
            Dictionary<string,int> gameRecords = new Dictionary<string,int>(); //initialize dictionary to store game records
            //gameRecords uses "You win","Computer wins","Its a tie" as key, int value to record number of occurence.

            //ensure our text exists and the logger (StreamWriter) is using the file as destination
            if (!logFile.Exists) {
                logger =logFile.CreateText();}
            else
                logger = new StreamWriter(logFile.FullName);

            logger.WriteLine($"{DateTime.Now.ToLongTimeString()} - Log file initialized");//StreamWriter is like Console, use WriteLine

            Console.OutputEncoding = Encoding.UTF8;//turns on emoji support
            do
            {
                var myHand = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                 .Title("Pick your hand!")
                 .PageSize(10)
                 .AddChoices(new[] {
                    rock,paper,scissor
                 }));
                //Use a seperate static method to generate a random computer hand, reduce Main clutter
                string computerHand = GetComputerHand();

                //Use a seperate static method to compare hands, reduce Main clutter
                string whoWins = CompareHand(myHand, computerHand);
                logger?.WriteLine($"{DateTime.Now.ToLongTimeString()} - {whoWins}");
                //check if dictionary key exists, if not initialize the new key to 0
                if (!gameRecords.ContainsKey(whoWins)) gameRecords[whoWins] = 0;
                gameRecords[whoWins]++; //increment the game stat

                // Echo the hand back to the terminal
                AnsiConsole.WriteLine($"You hand: {myHand} vs {computerHand} ");

                // Show who wins with Markup
                AnsiConsole.MarkupInterpolated($"[bold yellow on blue]{whoWins}[/]\n");

            } while (AnsiConsole.Confirm("Pick Again?")); //loop to start another game with Confirm Prompt
            //log when game finishes
            logger?.WriteLine($"{DateTime.Now.ToLongTimeString()} - Game finished");
            
            //print game stats
            foreach (var gameRecord in gameRecords) { 
                logger?.WriteLine($"{gameRecord.Key} - {gameRecord.Value} times" );
            }
            logger?.Flush();
            logger?.Close();//release file lock
        }

        private static string CompareHand(string myHand, string computerHand)
        {
            logger?.WriteLine($"{DateTime.Now.ToLongTimeString()} - your hand {myHand} vs {computerHand}");
            //logic to determin winner, tie condition
            if (myHand == computerHand) { return "Its a tie."; }
            //win conditions
            if (myHand == rock && computerHand == scissor) { return "You win"; }
            if (myHand == scissor && computerHand == paper) { return "You win"; }
            if (myHand == paper && computerHand == rock) { return "You win"; }
            //if none of the three conditions is true, then the final return is computer wins
            
            return "Computer wins";
        }

        private static string GetComputerHand()
        {
            string[] hands = { rock, paper, scissor };
            Random rnd = new Random();//create a new instance to generate random number
            return hands[rnd.Next(hands.Length)]; // pick a random hand
        }
    }
}
