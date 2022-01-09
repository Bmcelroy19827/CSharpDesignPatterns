using HelpingHand;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPoolCL.CoreBits
{
    // https://www.infoworld.com/article/3221392/how-to-use-the-object-pool-design-pattern-in-c.html
    // Used to help improve performance by queuing up to a (configurable) maximum number of expensive classes (one class type)
    public class ObjectPool<T> where T : ISharedObject, new()
    {
        //ConcurrentBack:- lock-free, thread-safe, unordered collection of elements, inserting and removing elements from this is very fast
        private readonly ConcurrentBag<T> items = new ConcurrentBag<T>();

        //Counter/max used to control how objects are created 
        // If user asks for a new object and the Max is already hit you can handle as you see fit
        // some common options: 1. Return null or throw exception, 2. Block the call until an object is available, 3. Increase the pool size to accomodate more objects
        private int counter = 0;
        private int max = 10;
        public ObjectPool(int numberToCache)
        {
            if (numberToCache > 0)
            {
                for (int i = 0; i < Math.Min(numberToCache, max); i++)
                {
                    items.Add(new T());
                    counter++;
                }
            }
        }
        public ObjectPool() : this(0)
        {

        }

        //used to release objects that are no longer needed back to the object pool
        public void Release(T item)
        {
            if (items.Count < max)
            {
                item.Reset();
                items.Add(item);
                Console.WriteLine($"Item added to bag\nTotal items in bag: {items.Count}");
                // removed below as it does not keep track of the total objects in the object pool anymore
                //counter++;
            }
            else
            {
                Console.WriteLine($"Bag full\nTotal items in bag: {items.Count}");
            }
            Console.WriteLine($"Counter: {counter}");
        }

        // returns an instance from the object pool if one is available, otherwise a new object is created and returned
        public T? Get()
        {
            T? item;
            if (items.TryTake(out item))
            {
                // removed this so we can keep track of the total objects made
                //counter--;
                Console.WriteLine($"Item taken from bag\nTotal items in bag: {items.Count}");
                Console.WriteLine($"Counter: {counter}");
                return item;
            }
            else
            {
                if (counter < max)
                {
                    T obj = new T();
                    //Note: Removed the next line as it allows for duplicate references on an object. Left counter increment so we could use it to limit the number of objects
                    //items.Add(obj);
                    counter++;
                    Console.WriteLine($"Item added to bag\nTotal items in bag: {items.Count}");
                    Console.WriteLine($"Counter: {counter}");
                    return obj;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public void showLastMethodOnAllStoredObjects()
        {
            HConsole.StarRow();
            foreach (var item in items)
            {
                item?.LastMethodCalled();
            }
            HConsole.StarRow();
        }
    }
}
