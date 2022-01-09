using EventAggregator.CoreBits.Classes.Events;
using EventAggregator.CoreBits.Interfaces;
using HelpingHand;
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
            HConsole.StarRow();
            Console.WriteLine($"*\tSelectedSubscriber Response!!!!\n*\tID: {e.target.Id}\n*\tDescription: {e.target.Description}");
            HConsole.StarRow();
        }

        public void OnEvent(TargetSaved e)
        {
            HConsole.StarRow();
            Console.WriteLine($"*\tSavedSubscriber Response!!!!\n*\tID: {e.target.Id}\n*\tDescription: {e.target.Description}");
            HConsole.StarRow();
        }
    }
}
