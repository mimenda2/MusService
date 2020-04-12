using System.Diagnostics;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading;

namespace MusWinService
{
    public class MusWinService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public MusWinService()
        {
            // Name the Windows Service
            ServiceName = "MusService";
        }
        public static void Main()
        {
            ServiceBase.Run(new MusWinService());
        }
        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            // Create a ServiceHost for the MusService type and 
            // provide the base address.
            serviceHost = new ServiceHost(typeof(MusService));

            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();

            MusService.StartTraces();
        }

        protected override void OnStop()
        {
            MusService.StopTraces();
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
