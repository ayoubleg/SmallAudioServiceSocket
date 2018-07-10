using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace SmallAudioManagerServiceVersion
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void ServiceSmallAudioManagerInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            new ServiceController(ServiceSmallAudioManager.ServiceName).Start();
        }

        //private void ServiceSmallAudioManagerInstaller_AfterUninstall(object sender, InstallEventArgs e)
        //{
        //    new ServiceController(ServiceSmallAudioManager.ServiceName).Stop();
        //}
    }
}
