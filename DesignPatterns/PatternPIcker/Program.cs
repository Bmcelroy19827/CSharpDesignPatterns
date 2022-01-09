// See https://aka.ms/new-console-template for more information
using HelpingHand;
HConsole.StarRow();
Console.WriteLine("Hello Patter Picker!!!!");
Console.WriteLine("Pick a pattern (q to quit):");
Console.WriteLine("*\tEvent Aggregator: aggregator");
Console.WriteLine("*\tObject Pool: object pool");
HConsole.StarRow();

bool keepGoBro = true;
while (keepGoBro)
{
    string userResponse = Console.ReadLine()?? "";

    switch (userResponse.ToLower())
    {
        case "aggregator":
            //new up aggregator
            break;
        case "object pool":
            //new up object pool
            break;
        case "q":
            keepGoBro = false;
            break;
        default:
            break;

    }
}
