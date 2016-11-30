using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DataAcquisition
{
    public class ThreadHandler
    {
        //The background thread
        private Thread backgroundWorker;
        //Flag that indicates if the thread should be running
        private bool flagRun;
        //Flag that indicates if the thread should be paused
        private bool flagPause;
        //The method to be called by the thread
        private Action threadFunc;        
        
        //Default constructor
        //Needs to receive the function to be called by the thread
        public ThreadHandler(Action _threadFunc)
        {
            this.threadFunc = _threadFunc;
            this.backgroundWorker = new Thread(this.Run);
            this.backgroundWorker.Priority = ThreadPriority.Normal;
        }

        //Sets the priority of the threads
        public void SetPriority(ThreadPriority _priority)
        {
            this.backgroundWorker.Priority = _priority;
        }

        //Starts the thread
        public void Start()
        {
            this.flagRun = true;
            this.backgroundWorker.Start();         
        }

        //Stops the thead
        public void Stop()
        {
            this.flagPause = true;
            this.flagRun = false;
        }

        //Resumes the thread
        public void Resume()
        {
            this.flagPause = false;
        }
        
        //Pauses the thread
        public void Pause()
        {
            this.flagPause = true;
        }        

        //The method passed to the ThreadHandler will be called inside the Run method
        //This method has two flags to control its execution
        private void Run()
        {
            while (flagRun)
            {
                while(!flagPause)
                    this.threadFunc();
            }
        }
    }
}
