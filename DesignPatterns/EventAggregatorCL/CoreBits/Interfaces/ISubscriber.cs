using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.CoreBits.Interfaces
{
    public interface ISubscriber<T>
    {
        void OnEvent(T e);
    }
}
