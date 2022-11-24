using NatureBlog.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NatureBlog.Models
{
    public interface ISubscriber
    {
        public void Update(ISubscription subject)
        {
            if ((subject as DestinationsList).State == 3)
            {
                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
            }
        }
    }
}
