using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Configuration;
using System.Configuration.Install;
using System.Threading;

namespace SmallAudioManagerServiceVersion
{

    public partial class SmallAudioManagerService : ServiceBase
    {
        static public SmallAudioManager Server = new SmallAudioManager();
        static public Thread myThread = null ;

        public SmallAudioManagerService()
        {
            InitializeComponent();
        }
        
        public void OnDebug()
        {
            this.OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            if (myThread == null)
            {
                myThread = new Thread(new ThreadStart(AsynchronousSocketListener.StartListening));
                myThread.Start();
            }                
        }

        protected override void OnStop()
        {
            if (myThread != null)
            {
                myThread.Abort();
            }
        }

        protected override void OnPause()
        {
            if (myThread != null)
            {
                myThread.Suspend();
            }
        }

        protected override void OnContinue()
        {
            if (myThread != null)
            {
                myThread.Resume();
            }
        }

        protected override void OnShutdown()
        {
            if (myThread != null)
            {
                myThread.Abort ();
            }
        }
    }
}
