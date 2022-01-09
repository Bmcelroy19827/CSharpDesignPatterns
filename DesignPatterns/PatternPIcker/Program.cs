// See https://aka.ms/new-console-template for more information
using HelpingHand;
using ObjectPool;
using EventAggregator;


OPMain? oPool = null;
EAMain aggregator = new EAMain();

bool keepGoBro = true;
while (keepGoBro)
{
    displayGreeting();

    string userResponse = Console.ReadLine()?? "";

    switch (userResponse.ToLower())
    {
        case "aggregator":
            //start Aggregator
            aggregator.Start();
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
            displayCommands();
            break;

    }
}

void displayGreeting()
{
    HConsole.StarRow();
    Console.WriteLine("Hello Pattern Picker!!!!");
    displayCommands();
    HConsole.StarRow();
}
void displayCommands()
{
    Console.WriteLine("*\tPick a pattern (q to quit):");
    Console.WriteLine("*\tEvent Aggregator: aggregator");
    Console.WriteLine("*\tObject Pool: object pool");
}
