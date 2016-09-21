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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabInstruments
{
    public class SignalGenerator
    {
        public double Amplitude { get; set; }
        public double Frequency { get; set; }
        public double SamplingFrequency { get; set; }
        public SignalType Type { get; set; }

        public enum SignalType { Sine = 1, Square, Triangle };

        public int tipoSinal;

        private double time;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalGenerator"/> class
        /// </summary>
        public SignalGenerator()
        {
            this.SamplingFrequency = 1000;
            this.Amplitude = 1;
            this.Frequency = 1;
            this.time = 0;            
            this.Type = SignalType.Sine;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalGenerator"/> class
        /// with the specified parameters
        /// </summary>
        public SignalGenerator(double _sampfreq, double _amp, double _freq, SignalType _type)
        {
            this.SamplingFrequency = _sampfreq;
            this.Amplitude = _amp;
            this.Frequency = _freq;
            this.time = 0;            
            this.Type = _type;
        }

        /// <summary>
        /// Generates a new sample of the chosen signal with the configured parameters
        /// </summary>
        /// <returns></returns>
        public double GetSample()
        {
            double sample = 0;
            switch (Type)
            {
                case SignalType.Sine:
                    sample = this.Amplitude * Math.Sin(2 * Math.PI * Frequency * time);
                    break;
                case SignalType.Square:
                    for (int i = 1; i < 19; i+=2)
                    {
                        sample += (1.0 / i) * Math.Sin(2 * Math.PI * i * Frequency * time);
                    }
                    sample *= ((Amplitude * 4.0) / Math.PI);
                    //sample = this.Amplitude * Math.Sin(2 * Math.PI * Frequency * time);
                    //if (sample > 0)
                    //    sample = this.Amplitude;
                    //else
                    //    sample = 0;
                    break;
                case SignalType.Triangle:
                    for (int i = 0; i < 10; i ++)
                    {
                        sample += Math.Pow(-1, i) * ((Math.Sin(2 * Math.PI * ((2 * i) + 1) * Frequency * time)) / (Math.Pow((2 * i) + 1, 2)));
                    }
                    sample *= (Amplitude*8.0) / (Math.Pow(Math.PI, 2));
                    break;
            }
            double dt = (1.0 / this.SamplingFrequency);
            time += dt;
            if (time >= 1)
                time = 0;
            return sample;
        }
    }
}
