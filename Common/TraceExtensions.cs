using System;
using System.Diagnostics;

namespace MusClient
{
    public static class TraceClientExtensions
    {
        /// <summary>
        /// Add trace adding the current time
        /// </summary>
        public static void TraceMessage(TraceEventType eventType, int id, string message)
        {
            if (mySource.Switch.ShouldTrace(eventType))
            {
                string tracemessage = $"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}: {message}";
                foreach (TraceListener listener in mySource.Listeners)
                {
                    listener.WriteLine(tracemessage);
                    listener.Flush();
                }
            }
        }

        private static TraceSource mySource = null;
        public static void StartTraces(string idName)
        {
            try
            {
                if (mySource == null)
                    mySource = new TraceSource(idName);
                TraceMessage(TraceEventType.Information, 57, "Arrancando app cliente de mus");
                mySource?.Close();
            }
            catch { }
        }
        public static void StopTraces()
        {
            try
            {
                TraceMessage(TraceEventType.Information, 58, "Parando app cliente de mus");
                mySource?.Close();
            }
            catch { }
        }
    }
}
