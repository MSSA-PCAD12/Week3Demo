using Spectre.Console;
using System.Text;

namespace LearnSpectreUI
{
    internal class Program
    {
       static string rock = "✊";
        static string scissor = "✌";
        static string paper = "✋";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            do
            {
                var myHand = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                 .Title("Pick your hand!")
                 .PageSize(10)
                 .AddChoices(new[] {
                    rock,paper,scissor
                 }));

                string computerHand = GetComputerHand();

               string whoWins = CompareHand(myHand, computerHand);
                // Echo the hand back to the terminal
                AnsiConsole.WriteLine($"You hand: {myHand} vs {computerHand} ");
                
                AnsiConsole.MarkupInterpolated($"[bold yellow on blue]{whoWins}[/]\n");
                //AnsiConsole.WriteLine($"{whoWins}");
            } while (AnsiConsole.Confirm("Pick Again?"));
        }

        private static string CompareHand(string myHand, string computerHand)
        {
            if (myHand == computerHand) { return "Its a tie."; }
            if (myHand == rock && computerHand == scissor) { return "You win"; }
            if (myHand == scissor && computerHand == paper) { return "You win"; }
            if (myHand == paper && computerHand == rock) { return "You win"; }
            return "Computer wins";
        }

        private static string GetComputerHand()
        {
            string[] hands = { rock, paper, scissor };
            Random rnd = new Random();
            return hands[rnd.Next(hands.Length)];
        }
    }
}
