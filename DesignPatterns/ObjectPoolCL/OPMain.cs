using ObjectPoolCL.CoreBits;
using HelpingHand;

namespace ObjectPoolCL
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


            Console.WriteLine("Hello, Object Pool!!!");

            HConsole.StarRow();
            Console.WriteLine("*\tEnter a keyboard shortcut to perform an action");
            Console.WriteLine("*\tAdd Object: a\n*\tRelease Object: r\n*\tCheck Last Method Calls in pool: p\n*\tCheck Last Method Calls in Console: c\n*\tQuit: q");
            HConsole.StarRow();
            bool keepGoBro = true;
            while (keepGoBro)
            {
                string userResponse = Console.ReadLine() ?? "";

                switch (userResponse.ToLower())
                {
                    case "a":
                        AddObject();
                        break;
                    case "r":
                        RemoveObject();
                        break;
                    case "p":
                        objPool.showLastMethodOnAllStoredObjects();
                        break;
                    case "c":
                        ShowLastMethodsCalled();
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