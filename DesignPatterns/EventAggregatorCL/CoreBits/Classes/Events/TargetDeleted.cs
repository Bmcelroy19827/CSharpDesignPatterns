using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.CoreBits.Classes.Events
{
    public class TargetDeleted
    {
        public Target target { get; set; }

        public TargetDeleted(Target target)
        {
            this.target = target;
        }
        public TargetDeleted() : this(new Target()) { }
    }
}
