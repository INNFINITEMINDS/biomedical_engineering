using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using LabInstruments;
using DataAcquisition;

namespace intro_threads
{
    public partial class MainWindow : Form
    {
        private int x = 0; //counter
        private double amp = 1;
        private double freq = 1;
        private double sampfreq = 100;
        private const int bufferCapacity = 1000;
        private CircularBuffer circularBuffer; //Circular buffer
        private Queue<double> signalQueue; //Queue containing the generated signal
        private SignalGenerator signalGenerator; //Signal generator        
        private ThreadHandler threadAcq; //Acquisition thread
        private ThreadHandler threadProc; //Processing thread
        private Mutex syncMutex; //Mutex for synchronizing acess

        public MainWindow()
        {
            InitializeComponent();            
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.signalChart.Series[0].ChartType = SeriesChartType.FastLine;
            this.signalChart.Series[0].BorderWidth = 3;
            this.signalQueue = new Queue<double>();
            this.circularBuffer = new CircularBuffer(bufferCapacity);
            this.signalGenerator = new SignalGenerator(sampfreq, amp, freq, SignalGenerator.SignalType.Sine);
            this.threadAcq = new ThreadHandler(this.Counter);
            this.threadProc = new ThreadHandler(this.Display);
            this.syncMutex = new Mutex();
        }

        //Function of the acquisition thread
        public void Counter()
        {
            syncMutex.WaitOne();
            if(signalQueue.Count > 0)
                circularBuffer.Write(signalQueue.Dequeue());
            syncMutex.ReleaseMutex();
        }

        //Function of the processing thread
        public void Display()
        {
            syncMutex.WaitOne();
            int count = circularBuffer.SamplesToRead;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    double sample = circularBuffer.Read();
                    label1.Invoke(new Action(() => label1.Text = sample.ToString()));
                    signalChart.Invoke(new Action(() => signalChart.Series[0].Points.AddY(sample)));
                }
            }
            syncMutex.ReleaseMutex();
        }

        //Starts both threads
        private void btStart_Click(object sender, EventArgs e)
        {
            this.threadAcq.Start();
            this.threadProc.Start();
            this.timerGenerator.Start();
        }

        //Resumes the acquisition thread
        private void btnResume_Click(object sender, EventArgs e)
        {
            this.threadAcq.Resume();            
        }

        //Pauses the acquisition thread
        private void btPause_Click(object sender, EventArgs e)
        {
            this.threadAcq.Pause();
        }

        //Stops both threads
        private void btnStop_Click(object sender, EventArgs e)
        {
            this.threadAcq.Stop();
            this.threadProc.Stop();
        }

        private void timerGenerator_Tick(object sender, EventArgs e)
        {
            syncMutex.WaitOne();
            if (signalQueue.Count > 0)
                signalQueue.Dequeue();
            signalQueue.Enqueue(signalGenerator.GetSample());
            syncMutex.ReleaseMutex();
        }
    }
}
