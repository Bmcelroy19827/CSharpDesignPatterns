using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool.CoreBits
{
    public class SharedObject : ISharedObject
    {
        string lastMethodCalled;
        public SharedObject()
        {
            Console.WriteLine("Creating New Expensive Shared object....");
            lastMethodCalled = "";
            Thread.Sleep(2000);
            Console.WriteLine("Object Created!");
        }
        public void MethodA()
        {
            this.lastMethodCalled = "MethodA";
            LastMethodCalled();
        }
        public void MethodB()
        {
            this.lastMethodCalled = "MethodB";
            LastMethodCalled();
        }
        public void Reset()
        {
            LastMethodCalled();
            Console.WriteLine("Resetting the state");
            this.lastMethodCalled = "";
            LastMethodCalled();
        }

        public void LastMethodCalled()
        {
            Console.WriteLine("*\tLast method called on object was: " + this.lastMethodCalled);
        }
    }
}
