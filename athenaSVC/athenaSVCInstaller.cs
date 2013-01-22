using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


namespace athena.AR.SVC
{
    [RunInstaller(true)]
    public partial class athenaSVCInstaller : System.Configuration.Install.Installer
    {
        private System.ServiceProcess.ServiceProcessInstaller _serviceProcess;
        private System.ServiceProcess.ServiceInstaller _serviceInstaller;
        public athenaSVCInstaller()
        {
            InitializeComponent();
            _serviceProcess = new System.ServiceProcess.ServiceProcessInstaller();
            _serviceInstaller = new System.ServiceProcess.ServiceInstaller();

            //Service Process
            _serviceProcess.Account = System.ServiceProcess.ServiceAccount.LocalService;
           

            //Service Installer
            _serviceInstaller.ServiceName = "athenaSVC";
            _serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            _serviceInstaller.DisplayName = "athenaSVC";
            _serviceInstaller.Description = "schedule post athena account receivables";

            this.Installers.AddRange(new Installer[]
            {
                _serviceProcess,
                _serviceInstaller
            });
        }
    }
}
