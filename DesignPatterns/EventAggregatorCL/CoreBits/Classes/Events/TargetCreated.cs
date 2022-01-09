using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.CoreBits.Classes.Events
{
    public class TargetCreated
    {
        public Target target { get; set; }

        public TargetCreated() : this(new Target()) { }
        public TargetCreated(Target target)
        {
            this.target = target;
        }
    }
}
