using System;

namespace InspectorGadget.Utility
{
    public class ConsoleNotify
        : INotifyObserver
    {
        public void Notify(string message)
        {
            Console.WriteLine(message);
        }
    }
}
