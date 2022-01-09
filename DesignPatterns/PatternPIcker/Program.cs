// See https://aka.ms/new-console-template for more information
using HelpingHand;
using ObjectPoolCL;

OPMain oPool = new OPMain();

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
            //start object pool
            oPool.Start();
            break;
        case "q":
            keepGoBro = false;
            break;
        default:
            break;

    }
}
