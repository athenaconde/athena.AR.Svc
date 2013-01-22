using System;
using System.ServiceProcess;
using System.Threading;
namespace athena.AR.SVC
{
    public partial class athenaService : ServiceBase
    {
        private string _runtime;
        private int daysToDue = athena.AR.SVC.Properties.Settings.Default.DaysToDue;
        private Timer _timer;
        private static Object _syncObject = new object();
        public athenaService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _runtime = athena.AR.SVC.Properties.Settings.Default.RunTime;
            SetTimer();
        }

        protected override void OnContinue()
        {
           //continue any process
            SetTimer();
        }
        protected override void OnStop()
        {
            //stop service
            _timer.Dispose();
        }

        private void SetTimer()
        {
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(new TimerCallback(TimerCallback), autoResetEvent, 0, 1000);
            autoResetEvent.WaitOne(1000, false);
           

        }

        private void TimerCallback(object resetEvent)
        {
            AutoResetEvent _autoreset = (AutoResetEvent)resetEvent;
            var currTime = DateTime.Now.ToShortTimeString();
            lock (_syncObject)
            {
               
                if (currTime == _runtime)
                {
                  try{
                     //Post Receivables
                      athena.AR.SVC.Library.Common.PostAR();

                    //Update Receivables
                      athena.AR.SVC.Library.Common.UpdateAR(daysToDue);   
                       
                    }
                    //Log any errors
                    catch(Exception ex)
                        {   athena.AR.SVC.ExceptionManager.LoggerAsync(ex);   }
                   
                }
            }
            _autoreset.Reset();
        }
    }
}
