/*
-----------------------------------------------------------
    FEDERAL UNIVERSITY OF UBERLÂNDIA
    Faculty of Electrical Engineering
    Biomedical Engineering Lab
-----------------------------------------------------------
    Author: Andrei Nakagawa, MSc
    email: andrei.ufu@gmail.com
-----------------------------------------------------------

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
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using LabInstruments;
using DataAcquisition;

namespace oscilloscope2
{
    public partial class MainWindow : Form
    {
        private const int generatorSampFreq = 100; //Hz       
        private const int oscilloscopeSampFreq = 500; //Hz 
        private const int generatorInterval = 10; //ms
        private const int oscilloscopeInterval = 100; //ms
        private const int bufferSize = 1000;

        private SignalGenerator signalGenerator;
        private Oscilloscope oscilloscope;
        private CircularBuffer buffer;
        
        private double dataSample;
        private int pastXfactor;
        private int pastYfactor;

        public MainWindow()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Updates the <see cref="SignalGenerator"/> instance with the GUI parameters
        /// </summary>
        private void UpdateSignalGenerator()
        {            
            //Sets the sampling frequency
            signalGenerator.SamplingFrequency = generatorSampFreq;
            //Sets the amplitude
            signalGenerator.Amplitude = Convert.ToDouble(nuAmplitude.Value);
            //Sets the signal frequency
            signalGenerator.Frequency = Convert.ToDouble(nuFrequency.Value);

            //Determines which signal needs to be generated
            if (rbSine.Checked)
                signalGenerator.Type = SignalGenerator.SignalType.Sine;
            else if(rbSquare.Checked)
                signalGenerator.Type = SignalGenerator.SignalType.Square;
            else if(rbTriangular.Checked)
                signalGenerator.Type = SignalGenerator.SignalType.Triangle;
        }

        /// <summary>
        /// Updates the <see cref="Oscilloscope"/> instance with the GUI parameters
        /// </summary>
        private void UpdateOscilloscope()
        {
            //Checks if the scale should increase or decrease
            //When increasing
            if (tbXAxis.Value > pastXfactor)
            {
                for (int i = 0; i < (tbXAxis.Value - pastXfactor); i++)
                {
                    if (oscilloscope.IncreaseXScale())
                        continue;                    
                }
                pastXfactor = tbXAxis.Value;
            }
            else //When decreasing
            {
                for (int i = 0; i < (pastXfactor - tbXAxis.Value); i++)
                {
                    if (oscilloscope.DecreaseXScale())
                        continue;
                }
                pastXfactor = tbXAxis.Value;
            }

            //Checks if the scale should increase or decrease
            //When increasing
            if (tbYAxis.Value > pastYfactor)
            {
                for (int i = 0; i < (tbYAxis.Value - pastYfactor); i++)
                {
                    if (oscilloscope.IncreaseYScale())
                        continue;
                }
                pastYfactor = tbYAxis.Value;
            }
            else //when decreasing
            {
                for (int i = 0; i < (pastYfactor - tbYAxis.Value); i++)
                {
                    if (oscilloscope.DecreaseYScale())
                        continue;
                }
                pastYfactor = tbYAxis.Value;
            }

            //Changes the time scale label
            lbXScale.Text = "T/div : " + oscilloscope.XScaleFactor.ToString();
            //Changes the voltage scale label
            lbYScale.Text = "V/div : " + oscilloscope.YScaleFactor.ToString();
        }

        //The Load event is used to initialize the application
        private void MainWindow_Load(object sender, EventArgs e)
        {
            //Creating a new instance for the oscilloscope
            oscilloscope = new Oscilloscope(ref oscChart, oscilloscopeSampFreq);
            //Creating a new instance of the signal generator
            signalGenerator = new SignalGenerator();
            //Creating a new instance of the circular buffer
            buffer = new CircularBuffer(bufferSize);

            //Sets the minimum and maximum values for the trackbar controlling
            //the time scale
            tbXAxis.Minimum = 0;
            tbXAxis.Maximum = Oscilloscope.scaleLevels - 1;            
            pastXfactor = tbXAxis.Value;

            //Sets the minimum and maximum values for the trackbar controlling
            //the voltage scale
            tbYAxis.Minimum = 0;
            tbYAxis.Maximum = Oscilloscope.scaleLevels - 1;            
            pastYfactor = tbXAxis.Value;

            //Initializes the dataSample variable
            dataSample = 0;

            //Updates the signal generator
            UpdateSignalGenerator();
            //Updates the oscilloscope
            UpdateOscilloscope();

            //Sets the timer interval for the signal generator
            timerSignalGenerator.Interval = generatorInterval;
            //Sets the timer interval for the oscilloscope
            timerOscilloscope.Interval = oscilloscopeInterval;
            //Starts the signal generator timer
            timerSignalGenerator.Start();
            //Starts the signal oscilloscope timer
            timerOscilloscope.Start();
        }

        //The signalGenerator timer creates a new sample and sets the
        //data acquisition flag
        private void timerSignalGenerator_Tick(object sender, EventArgs e)
        {
            //Gets a new sample from the Signal Generator
            dataSample = signalGenerator.GetSample();
            //Writes the new sample in the circular buffer
            buffer.Write(dataSample);
        }

        //The oscilloscope timer checks the data acquisition flag
        //If a new sample have been created, then the new point is plotted
        //and the flag is set to false
        private void timerOscilloscope_Tick(object sender, EventArgs e)
        {
            //Checks the number of samples available
            int numbSamples = buffer.SamplesToRead;
            //Writes the number of samples in the console
            Console.WriteLine(numbSamples.ToString());
            //Reads all the available data in the buffer and plot them in the chart
            for (int i = 0; i < numbSamples; i++)
                oscilloscope.Plot(buffer.Read());
        }

        //GUI Events
        //Changes the time scale of the oscilloscope
        private void tbXAxis_Scroll(object sender, EventArgs e)
        {            
            UpdateOscilloscope();
        }

        //Changes the voltage scale of the oscilloscope
        private void tbYAxis_Scroll(object sender, EventArgs e)
        {            
            UpdateOscilloscope();
        }

        //Creates a sine wave
        private void rbSine_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSignalGenerator();
        }

        //Creates a square wave
        private void rbSquare_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSignalGenerator();
        }

        //Creates a triangle wave
        private void rbTriangular_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSignalGenerator();
        }

        //Sets the amplitude of the signal
        private void nuAmplitude_ValueChanged(object sender, EventArgs e)
        {
            UpdateSignalGenerator();
        }

        //Sets the frequency of the signal
        private void nuFrequency_ValueChanged(object sender, EventArgs e)
        {
            UpdateSignalGenerator();
        }
    }
}
