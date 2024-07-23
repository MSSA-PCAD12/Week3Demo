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
        static void Main(string[] args)
        {
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

                // Echo the hand back to the terminal
                AnsiConsole.WriteLine($"You hand: {myHand} vs {computerHand} ");

                // Show who wins with Markup
                AnsiConsole.MarkupInterpolated($"[bold yellow on blue]{whoWins}[/]\n");

            } while (AnsiConsole.Confirm("Pick Again?")); //loop to start another game with Confirm Prompt
        }

        private static string CompareHand(string myHand, string computerHand)
        {
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
