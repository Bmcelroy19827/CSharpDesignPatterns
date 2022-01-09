using EventAggregator.CoreBits.Classes.Events;
using EventAggregator.CoreBits.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.CoreBits.Classes.Subscribers
{
    public class SelectedSavedSubscriber : 
        ISubscriber<TargetSelected>, ISubscriber<TargetSaved>
    {
        public SelectedSavedSubscriber(IEventAggregator ea)
        {
            ea.Subscribe(this);
        }

        public void OnEvent(TargetSelected e)
        {
            Console.WriteLine("**********************************************************");
            Console.WriteLine($"*\tSelectedSubscriber Response!!!!\n*\tID: {e.target.Id}\n*\tDescription: {e.target.Description}");
            Console.WriteLine("**********************************************************");
        }

        public void OnEvent(TargetSaved e)
        {
            Console.WriteLine("**********************************************************");
            Console.WriteLine($"*\tSavedSubscriber Response!!!!\n*\tID: {e.target.Id}\n*\tDescription: {e.target.Description}");
            Console.WriteLine("**********************************************************");
        }
    }
}
