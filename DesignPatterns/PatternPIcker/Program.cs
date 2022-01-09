// See https://aka.ms/new-console-template for more information
using HelpingHand;
using ObjectPool;

OPMain? oPool = null;

bool keepGoBro = true;
while (keepGoBro)
{
    displayGreeting();

    string userResponse = Console.ReadLine()?? "";

    switch (userResponse.ToLower())
    {
        case "aggregator":
            //new up aggregator
            break;
        case "object pool":
            //start object pool
            if (oPool == null)
            {
                oPool = new OPMain();
            }
            oPool.Start();
            break;
        case "q":
            keepGoBro = false;
            break;
        default:
            break;

    }
}

void displayGreeting()
{
    HConsole.StarRow();
    Console.WriteLine("Hello Pattern Picker!!!!");
    Console.WriteLine("Pick a pattern (q to quit):");
    Console.WriteLine("*\tEvent Aggregator: aggregator");
    Console.WriteLine("*\tObject Pool: object pool");
    HConsole.StarRow();
}
