// See https://aka.ms/new-console-template for more information
using HelpingHand;
using ObjectPool;
using EventAggregator;


OPMain? oPool = null;
EAMain aggregator = new EAMain();

bool keepGoBro = true;
while (keepGoBro)
{
    /*displayGreeting();*/
    /*string userResponse = Console.ReadLine() ?? "";*/
    string[] opt =
    {
    "aggregator",
    "object pool"
    };
    string greetings = "Hello pattern picker";
    string instruction = "(Up or Down arrow to navigate or press any number on menu to select.Enter q to quit.)";
    string userResponse = HMenuPicker.MenuPicker(opt, greetings, instruction);

    //if the last input retured has length of 1 
    if (userResponse.Length <= 1)
    {
        userResponse += Console.ReadLine() ?? "";
    }
    switch (userResponse.ToLower())
    {
        case "1":
        case "aggregator":
            //start Aggregator
            aggregator.Start();
            break;
        case "2":
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
            /*displayCommands();*/
            break;

    }
}

/*void displayGreeting()
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
}*/
