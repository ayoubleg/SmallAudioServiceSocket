namespace SmallAudioManagerServiceVersion
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.SmallAudioManagerInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.ServiceSmallAudioManager = new System.ServiceProcess.ServiceInstaller();
            // 
            // SmallAudioManagerInstaller
            // 
            this.SmallAudioManagerInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.SmallAudioManagerInstaller.Username = null;
            this.SmallAudioManagerInstaller.Password = null;
            // 
            // ServiceSmallAudioManager
            // 
            this.ServiceSmallAudioManager.DisplayName = "ServiceSmallAudioManager";
            this.ServiceSmallAudioManager.ServiceName = "SmallAudioManagerService";
            this.ServiceSmallAudioManager.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.ServiceSmallAudioManager.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.ServiceSmallAudioManagerInstaller_AfterInstall);
            //this.ServiceSmallAudioManager.AfterUninstall += new System.Configuration.Install.InstallEventHandler(this.ServiceSmallAudioManagerInstaller_AfterUninstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.ServiceSmallAudioManager,
            this.SmallAudioManagerInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller SmallAudioManagerInstaller;
        private System.ServiceProcess.ServiceInstaller ServiceSmallAudioManager;
    }
}