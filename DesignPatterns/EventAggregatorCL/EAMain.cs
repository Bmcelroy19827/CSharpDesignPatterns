using EventAggregator.CoreBits.Classes;
using HelpingHand;

namespace EventAggregator
{
    public class EAMain
    {
        private TargetHandler _handler;
        public EAMain()
        {
            _handler = new TargetHandler(new EventAggregatorClass());
        }

        public void Start()
        {
            /* Console.WriteLine("Hello, Aggregator!");

             HConsole.StarRow();
             DisplayCommands();
             HConsole.StarRow();*/
           
            bool keepGoBro = true;
            string[] opt =
             {
                    "Create Target",
                    "Delete Target",
                    "List Targets",
                    "Update Target"
             };
            string greetings = "Hello, Aggregator!";
            string instruction = "(Up or Down arrow to navigate or press any number on menu to select.Enter q to quit.)";
            while (keepGoBro)
            {
              
                /*string response = Console.ReadLine() ?? "";*/

                string response = HMenuPicker.MenuPicker(opt, greetings, instruction);
                if (response.Length <= 1)
                {
                    response += Console.ReadLine() ?? "";
                }
                /* Console.WriteLine(response);*/
                switch (response.ToLower())
                {
                    case "1":
                    case "create target":
                        //Add
                        Console.WriteLine("Please provide a description for the new item");
                        string? des = Console.ReadLine();
                        if (!String.IsNullOrEmpty(des))
                        {
                            _handler.CreateNewTarget(des);
                        }
                        
                        break;
                    case "2":
                    case "delete target":
                        //Delete
                        Find(_handler.DeleteTarget, _handler);
                        break;
                    case "3":
                    case "list targets":
                        _handler.ListTargets();
                        Console.ReadKey(true);
                        break;
                    case "4":
                    case "update target":
                        Find(_handler.SaveTarget, _handler, true);
                        Console.ReadKey(true);
                        break;
                    case "q":
                        keepGoBro = false;
                        break;
                    default:
                        /* DisplayCommands()*/
                        break;
                }
               
            }        
        }

        private static void Find(Action<Target> action, TargetHandler handler, bool askDesc = false)
        {
            Console.WriteLine("Please Provide the Id or Description of the Target");
            string? idDesc = Console.ReadLine();
            int idResult = 0;
            int.TryParse(idDesc, out idResult);
            Target? resultTarget = null;
            if (idResult != 0)
            {
                resultTarget = handler.FindTarget(id: idResult);
            }
            else if (!String.IsNullOrEmpty(idDesc))
            {
                resultTarget = handler.FindTarget(description: idDesc ?? "");
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

        /*private static void DisplayCommands()
        {
            Console.WriteLine("*\tPick an action (q to quit):");
            Console.WriteLine("*\tCreate Target: a\n*\tDelete Target: r\n*\tList Targets: l\n*\tUpdate Target: u");
        }*/
    }
}