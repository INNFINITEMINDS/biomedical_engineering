/*
-----------------------------------------------------------
    FEDERAL UNIVERSITY OF UBERLÂNDIA
    Faculty of Electrical Engineering
    Biomedical Engineering Lab
-----------------------------------------------------------
    Author: Andrei Nakagawa, MSc
    email: andrei.ufu@gmail.com
-----------------------------------------------------------
*/

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
using SignalProcessing;

namespace intro_threads
{
    public partial class MainWindow : Form
    {
        //Signal generator parameters                
        private double amp = 1; //Amplitude
        private double freq = 2; //Frequency
        private const double sampfreq = 100; //Sampling Frequency
        private const double dt = 1.0 / sampfreq;
        private const int bufferCapacity = 1000; //Circular buffer size
        private double time = 0; //Time counter
        private CircularBuffer circularBuffer; //Circular buffer
        private Queue<double> signalQueue; //Queue containing the generated signal
        private SignalGenerator signalGenerator; //Signal generator        
        private ThreadHandler threadAcq; //Acquisition thread
        private ThreadHandler threadProc; //Processing thread
        private Mutex acqMutex; //Mutex for synchronizing acess
        private Mutex procMutex; //Mutex for synchronizing acess

        //Signal 
        private const string signalSeriesName = "signalSeries"; //Name of the signal's series
        private const string signalAreaName = "signalArea"; //Name of the signal's series
        private Series signalSeries; //Series for plotting the signal
        private ChartArea signalArea; //Area for plotting the signal

        //FFT
        private const string fftSeriesName = "fftSeries"; //Name of the signal's series
        private const string fftAreaName = "fftArea"; //Name of the signal's series
        private ChartArea fftArea;
        private Series fftSeries; //Series for plotting the fft

        //Signal handler
        private double[] signalBuffer;
        private double[] timeBuffer;

        //FFT parameters
        FFT2 fftHandler;
        private double[] realFFT;
        private double[] imFFT;
        private double[] freqs;
        private double[] pow;        
        private const int fftN = 6;
        private int fftWindow = (int)Math.Pow(2, fftN);        
        
        public MainWindow()
        {
            InitializeComponent();            
        }

        //Method that initializes the chart
        private void setMainChart()
        {
            //Clear the existing areas
            this.mainChart.ChartAreas.Clear();
            //Clear the existing Series
            this.mainChart.Series.Clear(); 

            //Creating the area
            this.signalArea = new ChartArea(signalAreaName);
            this.signalArea.AxisX.Minimum = 0;
            this.signalArea.AxisX.Maximum = fftWindow / sampfreq;
            this.signalArea.AxisX.RoundAxisValues();
            this.signalArea.AxisY.RoundAxisValues();

            //Creating the series            
            this.signalSeries = new Series(signalSeriesName); //Creates a new Series
            this.signalSeries.ChartArea = this.signalArea.Name;
            this.signalSeries.ChartType = SeriesChartType.FastLine;
            this.signalSeries.BorderWidth = 4;

            //FFT - Area
            this.fftArea = new ChartArea(fftAreaName);
            this.fftArea.AxisX.Minimum = 0;
            this.fftArea.AxisY.Maximum = sampfreq / 2;
            //FFT - Series            
            this.fftSeries = new Series(fftSeriesName);
            this.fftSeries.ChartArea = this.fftArea.Name;
            this.fftSeries.ChartType = SeriesChartType.FastLine;
            this.fftSeries.Color = Color.Black;          
            this.fftSeries.BorderWidth = 4;

            this.mainChart.ChartAreas.Add(this.signalArea);
            this.mainChart.Series.Add(this.signalSeries);

            this.mainChart.ChartAreas.Add(this.fftArea);
            this.mainChart.Series.Add(this.fftSeries);
        }

        //Initializing method
        private void MainWindow_Load(object sender, EventArgs e)
        {            
            this.signalQueue = new Queue<double>();
            this.circularBuffer = new CircularBuffer(bufferCapacity);
            this.signalGenerator = new SignalGenerator(sampfreq, amp, freq, SignalGenerator.SignalType.Sine);
            this.threadAcq = new ThreadHandler(this.Acquisition);
            this.threadProc = new ThreadHandler(this.Processing);
            this.acqMutex = new Mutex();
            this.procMutex = new Mutex();

            this.signalBuffer = new double[fftWindow];
            this.timeBuffer = new double[fftWindow];
            this.realFFT = new double[fftWindow];
            this.imFFT = new double[fftWindow];
            this.freqs = new double[fftWindow / 2];
            this.pow = new double[fftWindow / 2];
            this.fftHandler = new FFT2();

            //Initializes the chart
            this.setMainChart();
        }

        //Function of the acquisition thread
        //The acquisition thread gets a new sample from the data queue and writes it to the circular buffer
        public void Acquisition()
        {
            double sample = 0;
            bool flag = false;
            //Blocks the mutex between the timer generator and the acquisition thread
            acqMutex.WaitOne();
            //Checks if there is a new sample in the data queue
            if (signalQueue.Count > 0)
            {
                flag = true; //Indicates that there is a new sample to be saved in the circular buffer
                sample = signalQueue.Dequeue(); //Gets the new sample
            }
            //Releases the acquisition thread mutex
            acqMutex.ReleaseMutex();

            //Blocks the mutex between the acquisition thread and the processing thread
            procMutex.WaitOne();
            //If there is a new sample, write it to the circular buffer
            if(flag)
                circularBuffer.Write(sample);
            
            //Releases the processing thread mutex
            procMutex.ReleaseMutex();
        }

        //Function of the processing thread
        //The processing thread reads an amount of samples from the buffer necessary for calculating the FFT
        //Plots the signal and the result of the FFT
        public void Processing()
        {
            //Blocks the mutex
            //Released when all the operations related to the circular buffer are finished
            //This might occur in two cases:
            //a) After all the samples have been read from the buffer
            //b) After checking that the buffer does not have the necessary number of samples to be read
            procMutex.WaitOne();
            //Gets the number of samples to be read
            int count = circularBuffer.SamplesToRead;
            //If there are enough samples for the FFT, proceed
            if (count >= fftWindow)
            {
                //Reads all samples from the circular buffer
                for (int i = 0; i < fftWindow; i++)
                {
                    //Reading from buffer
                    double sample = circularBuffer.Read();
                    //Saving in the signal buffer
                    signalBuffer[i] = sample;
                    //Updating the time buffer
                    timeBuffer[i] = time;
                    //Updating the FFT vectors
                    realFFT[i] = sample;
                    imFFT[i] = 0;
                    //Updating the time variable
                    time += dt;
                }

                //Releases the mutex
                procMutex.ReleaseMutex();

                //Calculating the FFT                
                fftHandler.init(fftN);
                fftHandler.run(realFFT, imFFT);

                //Retrieving the power and frequencies from FFT
                for (int k = 0; k < fftWindow / 2; k++)
                {
                    //Frequency
                    freqs[k] = k * ((sampfreq / 2) / (fftWindow / 2));
                    //Power
                    pow[k] = Math.Sqrt(Math.Pow(realFFT[k], 2) + Math.Pow(imFFT[k], 2));                    
                }

                //Plotting
                //Signal
                mainChart.Invoke(new Action(() => mainChart.Series[signalSeriesName].Points.DataBindXY(timeBuffer, signalBuffer)));
                //FFT
                mainChart.Invoke(new Action(() => mainChart.Series[fftSeriesName].Points.DataBindXY(freqs, pow)));
                //Adjusting the maximum of the FFT area -> Y-axis
                mainChart.Invoke(new Action(() => mainChart.ChartAreas[fftAreaName].AxisY.Maximum = pow.Max() + 5));
                //Restarts the time counter
                time = 0;
            }         
            else                
                procMutex.ReleaseMutex(); //Releases the mutex                
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

        //Timer for generating new samples
        private void timerGenerator_Tick(object sender, EventArgs e)
        {
            //Blocks the mutex
            acqMutex.WaitOne();
            //The queue only stores one sample
            //If it is filled, then the past sample is discarded
            if (signalQueue.Count > 0)
                signalQueue.Dequeue();
            //Enqueues the new sample
            signalQueue.Enqueue(signalGenerator.GetSample()); 
            //Releases the mutex
            acqMutex.ReleaseMutex();
        }

        //Method for updating the signal generator parameters
        private void UpdateGUI()
        {
            //Gets the new amplitude
            if(nuAmplitude.Value > 0)            
                this.amp = Convert.ToDouble(nuAmplitude.Value);

            //Gets the new frequency
            if (nuFrequency.Value > 0)
                this.freq = Convert.ToDouble(nuFrequency.Value);

            //Updates the amplitude of the signal generator
            this.signalGenerator.Amplitude = this.amp;
            //Updates the frequency of the signal generator
            this.signalGenerator.Frequency = this.freq;
        }

        //Whenever the amplitude is changed, the updated method is called
        private void nuAmplitude_ValueChanged(object sender, EventArgs e)
        {
            UpdateGUI();
        }

        //Whenever the frequency is changed, the updated method is called
        private void nuFrequency_ValueChanged(object sender, EventArgs e)
        {
            UpdateGUI();
        }
    }
}
