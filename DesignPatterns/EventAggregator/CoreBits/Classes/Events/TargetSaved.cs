using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.CoreBits.Classes.Events
{
    public class TargetSaved
    {
        public Target target { get; set; }

        public TargetSaved(Target target)
        {
            this.target = target;
        }
        public TargetSaved() : this(new Target()) { }
    }
}
