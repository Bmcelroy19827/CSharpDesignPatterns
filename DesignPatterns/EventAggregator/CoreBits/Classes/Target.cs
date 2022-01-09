using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.CoreBits.Classes
{
    public class Target
    {
        private static int _Counter = 1;
        public static int Counter { get { return _Counter; } }

        public Target(string description)
        {
            Id = _Counter++;
            Description = description;
        }
        public Target(): this(""){}

        public int Id { get; private set; }
        public string Description { get; set; }
    }
}
