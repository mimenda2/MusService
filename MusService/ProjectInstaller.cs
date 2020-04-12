using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.ServiceProcess;

namespace MusWinService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;
        string ServiceName = "MusService";
        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();

            // Service will run under system account
            process.Account = ServiceAccount.LocalSystem;
            process.Username = null;
            process.Password = null;

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            // Service will have Start Type of Manual
            service.ServiceName = ServiceName;
            service.DisplayName = $"MiMenda MusService";
            service.Description = "Mi tesoro";
            service.StartType = ServiceStartMode.Automatic;
            Installers.Add(process);
            Installers.Add(service);

            this.AfterInstall += new InstallEventHandler(ProjectInstaller_AfterInstall);
            this.Committed += new InstallEventHandler(ProjectInstaller_AfterInstall);
        }
        void ProjectInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            try
            {
                using (ServiceController sc = new ServiceController(ServiceName))
                {
                    sc.Start();
                }
            }
            catch { } // do nothing
        }
    }
}
