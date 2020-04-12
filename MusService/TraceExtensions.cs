using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace MusWinService
{
    public static class TraceExtensions
    {
        /// <summary>
        /// Add trace adding the current time
        /// </summary>
        public static void TraceMessage(this TraceSource traceSource, TraceEventType eventType, int id, string message)
        {
            if (traceSource.Switch.ShouldTrace(eventType))
            {
                string client = GetClientIP();
                string tracemessage = $"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}: {(!string.IsNullOrEmpty(client) ? $"({client}) " : "")}{message}";
                foreach (TraceListener listener in traceSource.Listeners)
                {
                    listener.WriteLine(tracemessage);
                    listener.Flush();
                }
            }
        }

        static string GetClientIP()
        {
            string address = string.Empty;
            try
            {
                OperationContext context = OperationContext.Current;
                MessageProperties properties = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                if (properties.Keys.Contains(HttpRequestMessageProperty.Name))
                {
                    HttpRequestMessageProperty endpointLoadBalancer = properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                    if (endpointLoadBalancer != null && endpointLoadBalancer.Headers["X-Forwarded-For"] != null)
                        address = endpointLoadBalancer.Headers["X-Forwarded-For"];
                }
                if (string.IsNullOrEmpty(address))
                {
                    address = endpoint.Address;
                }
            }
            catch { } // do nothing
            return address;
        }
    }
}
