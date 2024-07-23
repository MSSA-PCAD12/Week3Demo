using Spectre.Console;

namespace LearnSpectreUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //char rock = '✊';
            //char scissor = '✌';
            //char paper = '✋';
            do
            {
                var myHand = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                 .Title("Pick your hand!")
                 .PageSize(10)
                 .AddChoices(new[] {
                    "Rock","Paper","Scissor"
                 }));

                string computerHand = GetComputerHand();

               string whoWins = CompareHand(myHand, computerHand);
                // Echo the hand back to the terminal
                AnsiConsole.WriteLine($"You chose: {myHand} ");
                AnsiConsole.WriteLine($"Computer chose: {computerHand} ");
                AnsiConsole.WriteLine($"{whoWins}");
            } while (AnsiConsole.Confirm("Pick Again?"));
        }

        private static string CompareHand(string myHand, string computerHand)
        {
            if (myHand == computerHand) { return "Its a tie."; }
            if (myHand == "Rock" && computerHand == "Scissor") { return "You win"; }
            if (myHand == "Scissor" && computerHand == "Paper") { return "You win"; }
            if (myHand == "Paper" && computerHand == "Rock") { return "You win"; }
            return "Computer wins";
        }

        private static string GetComputerHand()
        {
            string[] hands = { "Rock", "Paper", "Scissor" };
            Random rnd = new Random();
            return hands[rnd.Next(hands.Length)];
        }
    }
}
