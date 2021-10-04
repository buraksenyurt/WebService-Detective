using System.Collections.Generic;

namespace InspectorGadget.Utility
{
    public class ProcessNotifier
    {
        public List<INotifyObserver> Observers { get; set; } = new List<INotifyObserver>();

        public void Add(INotifyObserver observer)
        {
            Observers.Add(observer);
        }

        public void Remove(INotifyObserver observer)
        {
            Observers.Remove(observer);
        }

        public void Publish(string message)
        {
            foreach (var o in Observers)
            {
                o.Notify(message);
            }
        }
    }
}
