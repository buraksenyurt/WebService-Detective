using System.Text;

namespace InspectorGadget.Utility
{
    public class StringBuilderNotify
        : INotifyObserver
    {
        private readonly StringBuilder builder = new StringBuilder();

        public void Notify(string message)
        {
            builder.AppendLine(message);
        }

        public string GetText()
        {
            return builder.ToString();
        }
    }
}
