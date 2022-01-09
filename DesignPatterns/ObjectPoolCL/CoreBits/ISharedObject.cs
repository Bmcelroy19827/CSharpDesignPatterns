using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPoolCL.CoreBits
{
    public interface ISharedObject
    {
        void LastMethodCalled();
        void MethodA();
        void MethodB();
        //Note: This Reset method seems pretty important- even though the reference to the object is removed when placed in the stack
        // We don't want to give this object later with altered data or that could have unforeseen consequences
        void Reset();
    }
}
