using ObjectPool.CoreBits;
using HelpingHand;

namespace ObjectPool
{
    public class OPMain
    {
        private bool callMethodA;
        private ObjectPool<SharedObject> objPool;
        private Stack<SharedObject> sOStack;

        public OPMain()
        {
            callMethodA = true;
            objPool = new ObjectPool<SharedObject>(5);
            sOStack = new Stack<SharedObject>();
        }

        public void Start()
        {


           /* Console.WriteLine("Hello, Object Pool!!!");

            HConsole.StarRow();
            Console.WriteLine("*\tEnter a keyboard shortcut to perform an action");
            Console.WriteLine("*\tAdd Object: a\n*\tRelease Object: r\n*\tCheck Last Method Calls in pool: p\n*\tCheck Last Method Calls in Console: c\n*\tQuit: q");
            HConsole.StarRow();*/
            bool keepGoBro = true;
            string[] opt =
            {
                    "Add Object",
                    "Release Object",
                    "Check Last Method Calls in pool",
                    "Check Last Method Calls in Console"
             };
            string greetings = "Hello, Object Pool!!!";
            string instruction = "(Up or Down arrow to navigate or press any number on menu to select.Enter q to quit.)";
            while (keepGoBro)
            {
                /*string userResponse = Console.ReadLine() ?? "";*/
                string userResponse = HMenuPicker.MenuPicker(opt, greetings, instruction);
                if (userResponse.Length <= 1)
                {
                    userResponse += Console.ReadLine() ?? "";
                }
                switch (userResponse.ToLower())
                {
                    case "1":
                    case "add object":
                        AddObject();
                        Console.ReadLine();
                        break;
                    case "2":
                    case "release object":
                        RemoveObject();
                        Console.ReadLine();
                        break;
                    case "3":
                    case "check last method calls in pool":
                        objPool.showLastMethodOnAllStoredObjects();
                        Console.ReadLine();
                        break;
                    case "4":
                    case "check last method calls in console":
                        ShowLastMethodsCalled();
                        Console.ReadLine();
                        break;
                    case "q":
                        keepGoBro = false;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Good Bye Object Pool!!!!");
            HConsole.StarRow();
            Console.WriteLine();
            Console.ReadLine();
            void AddObject()
            {
                SharedObject? obj = objPool.Get();
                if (obj != null)
                {
                    if (callMethodA)
                    {
                        obj.MethodA();
                    }
                    else
                    {
                        obj.MethodB();
                    }
                    callMethodA = !callMethodA;
                    sOStack.Push(obj);
                }
                else
                {
                    Console.WriteLine("Could not create new object, limit is hit");
                }
                Console.WriteLine($"Total objects in console: {sOStack.Count}");
            }

            void RemoveObject()
            {
                if (sOStack.Count > 0)
                {
                    var toRemove = sOStack.Pop();
                    toRemove.LastMethodCalled();
                    objPool.Release(toRemove);
                }
                else
                {
                    Console.WriteLine("No Objects to release!");
                }
                Console.WriteLine($"Total objects in console: {sOStack.Count}");
            }

            void ShowLastMethodsCalled()
            {
                HConsole.StarRow();
                foreach (var obj in sOStack)
                {
                    obj.LastMethodCalled();
                }
                HConsole.StarRow();
            }
        }

    }
}