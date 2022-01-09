// See https://aka.ms/new-console-template for more information
using EventAggregator.CoreBits.Classes;

ConsoleState state = new ConsoleState(new EventAggregatorClass());

Console.WriteLine("Hello, Aggregator!");

Console.WriteLine("*******************************************************************");
Console.WriteLine("*\tEnter a keyboard shortcut to perform an action");
Console.WriteLine("*\tCreate Target: a\n*\tDelete Target: r\n*\tList Targets: l\n*\tUpdate Target: u\n*\tQuit: q");
Console.WriteLine("*******************************************************************");
bool keepGoBro = true;
while (keepGoBro)
{
    string response = Console.ReadLine()?? "";

    switch (response.ToLower())
    {
        case "a":
            //Add
            Console.WriteLine("Please provide a description for the new item");
            string? des = Console.ReadLine();
            if(!String.IsNullOrEmpty(des))
            {
                state.CreateNewTarget(des);
            }
            break;
        case "r":
            //Delete
            find(state.DeleteTarget);
            break;
        case "l":
            state.ListTargets();
            break;
        case "u":
            find(state.SaveTarget, true);
            break;
        case "q":
            keepGoBro = false;
            break;
        default:
            break;
    }
}

void find(Action<Target> action, bool askDesc = false)
{
    Console.WriteLine("Please Provide the Id or Description of the Target");
    string? idDesc = Console.ReadLine();
    int idResult = 0;
    int.TryParse(idDesc, out idResult);
    Target? resultTarget = null;
    if (idResult != 0)
    {
        resultTarget = state.FindTarget(id: idResult);
    }
    else if (!String.IsNullOrEmpty(idDesc))
    {
        resultTarget = state.FindTarget(description: idDesc ?? "");
    }
    if (resultTarget != null)
    {
        if (askDesc)
        {
            Console.WriteLine("Please Enter a new Description");
            string? newDescription = Console.ReadLine();
            resultTarget.Description = newDescription ?? "Not Valid";
        }
        action(resultTarget);
    }
}
