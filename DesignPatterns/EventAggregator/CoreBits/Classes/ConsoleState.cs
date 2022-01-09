using EventAggregator.CoreBits.Classes.Events;
using EventAggregator.CoreBits.Classes.Subscribers;
using EventAggregator.CoreBits.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.CoreBits.Classes
{
    public class ConsoleState
    {
        private IEventAggregator _ea;
        private SelectedSavedSubscriber _sub1;
        private List<Target> _targets;

        public ConsoleState(IEventAggregator ea)
        {
            _ea = ea;
            //Note: Instantiate Subscribers here with passed in aggregator
            _sub1 = new SelectedSavedSubscriber(_ea);
            _targets = new List<Target>();
            LoadTargets(_targets);
        }

        private void LoadTargets(List<Target> targets)
        {
            targets.Add(new Target("First Target"));
            targets.Add(new Target("Second Target"));
            targets.Add(new Target("Third Target"));
        }

        public void CreateNewTarget(string Description)
        {
            var target = new Target(Description);
            _targets.Add(target);
            _ea.Publish(new TargetCreated(target));
        }

        public Target? FindTarget(string description = "", int id = 0)
        {
            Target? target;
            if(id == 0)
            {
                target = _targets.Where( t => t.Description == description ).FirstOrDefault();
            }
            else
            {
                target = _targets.Where(t => t.Id == id).FirstOrDefault();
            }
            if(target != null)
            {
                _ea.Publish(new TargetSelected(target));
            }

            return target;
        }

        public void SaveTarget(Target target)
        {
            var result = _targets.FirstOrDefault(target);
            result = target;
            _ea.Publish(new TargetSaved(result));
        }

        public void ListTargets()
        {

            Console.WriteLine("**********************************************");
            foreach(var target in _targets)
            {
                Console.WriteLine($"*\tID: {target.Id}\n*\tDescription: {target.Description}");
            }
            Console.WriteLine("**********************************************");
        }

        public void DeleteTarget(Target target)
        {
            _targets.Remove(target);
            _ea.Publish(new TargetDeleted(target));
        }
    }
}
