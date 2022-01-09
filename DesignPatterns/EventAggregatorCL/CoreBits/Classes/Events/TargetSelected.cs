using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.CoreBits.Classes.Events
{
    public class TargetSelected
    {
        public Target target { get; set; }

        public TargetSelected(Target target)
        {
            this.target = target;
        }
        public TargetSelected() : this(new Target()) { }
    }
}
