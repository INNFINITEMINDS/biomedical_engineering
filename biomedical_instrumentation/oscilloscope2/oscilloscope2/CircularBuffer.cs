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

namespace DataAcquisition
{
    /// <summary>
    /// Represents a circular buffer. Provides methods for handling data acquisition.
    /// </summary>
    public class CircularBuffer
    {
        /// <summary>
        /// Gets the data buffer size
        /// </summary>
        public int Size { get; private set; }
        /// <summary>
        /// Gets the number of samples available
        /// </summary>
        public int SamplesToRead { get; private set; }

        /// <summary>
        /// Data buffer
        /// </summary>
        private double[] buffer; 
        /// <summary>
        /// Points to the position where a new sample will be stored
        /// </summary>
        private int writerPointer;
        /// <summary>
        /// Points to the position where the sample will be read
        /// </summary>
        private int readerPointer;

        /// <summary>
        /// Creates a new instance of the <see cref="CircularBuffer"/> class with the specified
        /// capacity
        /// </summary>
        /// <param name="_capacity"></param>
        public CircularBuffer(int _capacity)
        {            
            this.buffer = new double[_capacity];
            this.Size = _capacity;
            this.SamplesToRead = 0;
        }

        /// <summary>
        /// Writes a new sample in the data buffer
        /// </summary>
        /// <param name="_sample"></param>
        public void Write(double _sample)
        {
            //Writes a new sample in the data buffer
            this.buffer[this.writerPointer] = _sample;
            //Increments the writerPointer
            this.writerPointer++;
            //Increments the number of available samples in the buffer
            this.SamplesToRead++;
            //Returns the writerPointer to zero if it exceeds the buffer size
            if (this.writerPointer >= this.Size)
                this.writerPointer = 0;
        }

        /// <summary>
        /// Reads one sample from the data buffer
        /// </summary>
        /// <returns></returns>
        public double Read()
        {
            //Retrieves the sample from the data buffer
            double sample = this.buffer[this.readerPointer];
            //Increments the readerPointer
            this.readerPointer++;
            //Decrements the number of avaliable samples
            this.SamplesToRead--;

            //Returns the readerPointer to zero if it exceeds the buffer size
            if (this.readerPointer >= this.Size)
                this.readerPointer = 0;

            //Returns the sample
            return sample;
        }
    }
}
