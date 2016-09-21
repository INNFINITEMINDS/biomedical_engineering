/*
-----------------------------------------------------------
    FEDERAL UNIVERSITY OF UBERLÂNDIA
    Faculty of Electrical Engineering
    Biomedical Engineering Lab
-----------------------------------------------------------
    Author: Andrei Nakagawa, MSc
    email: andrei.ufu@gmail.com
-----------------------------------------------------------
    File: Oscilloscope.cs
    Description: Class that simulates an one-channel
        digital oscilloscope
-----------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LabInstruments
{
    public class Oscilloscope
    {
        /// <summary>
        /// Defines the number of possible scale factors
        /// </summary>
        public const int scaleLevels = 6;
        /// <summary>
        /// Defines the index of the default X and Y scale intervals
        /// </summary>
        private const int startScale = 0;
        /// <summary>
        /// Defines the factor for multiplying the interval and estimate
        /// the minimum and maximum values of the axis
        /// </summary>
        private const int numbDiv = 5;
        /// <summary>
        /// Defines the sampling rate of the Oscilloscope
        /// </summary>
        public int SamplingFrequency { get; private set; }
        /// <summary>
        /// Returns the current time scale
        /// </summary>
        public double XScaleFactor { get; private set; }
        /// <summary>
        /// Returns the current voltage scale
        /// </summary>
        public double YScaleFactor { get; private set; }

        private Chart plotChart;
        private ChartArea plotArea;
        private Series plotSeries;

        private double[] xScale = { 0.05, 0.1, 0.25, 0.5, 1, 2 };
        private double[] yScale = { 0.1, 0.25, 0.5, 1, 2, 5 };
        private int xpointer;
        private int ypointer;
        private double timeSample;

        /// <summary>
        /// Initializes a new instance of the <see cref="Oscilloscope"/>  class
        /// </summary>
        /// <param name="_oscilloscopeChart"></param>
        /// <param name="_samprate"></param>
        public Oscilloscope(ref Chart _oscilloscopeChart, int _samprate)
        {            
            this.plotChart = _oscilloscopeChart;                        
            this.plotArea = new ChartArea();
            this.plotSeries = new Series("Signal");

            this.SamplingFrequency = _samprate;

            this.timeSample = 0;
            this.xpointer = startScale;
            this.ypointer = startScale;
            
            this.plotSeries.IsVisibleInLegend = false;
            this.plotSeries.ChartType = SeriesChartType.FastLine;
            this.plotSeries.BorderWidth = 4;

            this.plotArea.AxisX.RoundAxisValues();
            this.plotArea.AxisX.Minimum = 0;
            this.setXAxis();

            this.setYAxis();

            this.plotChart.ChartAreas.Clear();
            this.plotChart.Series.Clear();
            this.plotChart.ChartAreas.Add(plotArea);
            this.plotChart.Series.Add(plotSeries);
        }

        /// <summary>
        /// Changes the time scale
        /// </summary>
        private void setXAxis()
        {
            this.XScaleFactor = this.xScale[xpointer];
            this.plotArea.AxisX.Interval = XScaleFactor;            
            this.plotArea.AxisX.Maximum = XScaleFactor * numbDiv;
        }

        /// <summary>
        /// Changes the voltage scale
        /// </summary>
        private void setYAxis()
        {
            this.YScaleFactor = this.yScale[ypointer];
            this.plotArea.AxisY.Interval = YScaleFactor;
            this.plotArea.AxisY.Minimum = (-YScaleFactor) * numbDiv;
            this.plotArea.AxisY.Maximum = (YScaleFactor) * numbDiv;
        }

        /// <summary>
        /// Increases the time scale
        /// </summary>
        /// <returns></returns>
        public bool IncreaseXScale()
        {
            if (xpointer == xScale.Length - 1)
                return false;
            this.xpointer++;            
            this.setXAxis();
            return true;
        }

        /// <summary>
        /// Decreases the time scale
        /// </summary>
        /// <returns></returns>
        public bool DecreaseXScale()
        {
            if (xpointer == 0)
                return false;
            this.xpointer--;
            this.setXAxis();
            return true;
        }

        /// <summary>
        /// Increases the voltage scale
        /// </summary>
        /// <returns></returns>
        public bool IncreaseYScale()
        {
            if (ypointer == yScale.Length - 1)
                return false;
            this.ypointer++;
            this.setYAxis();
            return true;
        }

        /// <summary>
        /// Decreases the voltage scale
        /// </summary>
        /// <returns></returns>
        public bool DecreaseYScale()
        {
            if (ypointer == 0)
                return false;
            this.ypointer--;
            this.setYAxis();
            return true;
        }

        /// <summary>
        /// Plots a new point in the oscilloscope
        /// </summary>        
        /// <param name="signalSample"></param>
        public void Plot(double signalSample)
        {            
            plotSeries.Points.AddXY(timeSample, signalSample);
            timeSample += (1.0 / this.SamplingFrequency);
            if (timeSample >= this.plotArea.AxisX.Maximum)
            {
                timeSample = 0;
                plotSeries.Points.Clear();
            }
        }
    }
}
