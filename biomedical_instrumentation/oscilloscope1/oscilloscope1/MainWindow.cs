﻿/*
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

namespace oscilloscope1
{
    public partial class MainWindow : Form
    {
        private const int generatorSampFreq = 500; //Hz       
        private const int oscilloscopeSampFreq = 500; //Hz 
        private SignalGenerator signalGenerator;
        private Oscilloscope oscilloscope;
        private bool dataFlag;
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

            //Initializes the data acquisition flag
            dataFlag = false;
            //Initializes the dataSample variable
            dataSample = 0;

            //Updates the signal generator
            UpdateSignalGenerator();
            //Updates the oscilloscope
            UpdateOscilloscope();

            //Sets the timer interval for the signal generator
            timerSignalGenerator.Interval = Convert.ToInt32((1.0 / generatorSampFreq) * 1000);
            //Sets the timer interval for the oscilloscope
            timerOscilloscope.Interval = Convert.ToInt32((0.5 / generatorSampFreq) * 1000);
            //Starts the signal generator timer
            timerSignalGenerator.Start();
            //Starts the signal oscilloscope timer
            timerOscilloscope.Start();
        }       

        //The signalGenerator timer creates a new sample and sets the
        //data acquisition flag
        private void timerSignalGenerator_Tick(object sender, EventArgs e)
        {
            dataSample = signalGenerator.GetSample();
            dataFlag = true;            
        }

        //The oscilloscope timer checks the data acquisition flag
        //If a new sample have been created, then the new point is plotted
        //and the flag is set to false
        private void timerOscilloscope_Tick(object sender, EventArgs e)
        {
            if (dataFlag)
            {
                oscilloscope.Plot(dataSample);
                dataFlag = false;
            }            
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
