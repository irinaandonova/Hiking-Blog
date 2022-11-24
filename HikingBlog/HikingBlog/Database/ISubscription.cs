using NatureBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NatureBlog.Database
{
    public interface ISubscription
    {
        private List<ISubscriber> _subscribers = new List<ISubscriber>();

        public void Attach(ISubscriber subscriber)
        {
            Console.WriteLine("Subject: Attached an subscriber .");
            this._subscribers.Add(subscriber);
        }

        public void Detach(ISubscriber subscriber)
        {
            this._subscribers.Remove(subscriber);
            Console.WriteLine("Subject: Detached an subscriber .");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notifying subscriber s...");

            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(this);
            }
        }



    }
}
