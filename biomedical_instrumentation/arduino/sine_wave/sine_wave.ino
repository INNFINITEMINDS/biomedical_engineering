/*
 * -----------------------------------------------
 * Federal University of Uberlandia
 * Faculty of Electrical Engineering
 * Biomedical Engineering Lab
 * Author: Andrei Nakagawa, MSc
 * contact: nakagawa.andrei@gmail.com
 * * -----------------------------------------------
 */
 
//Libraries
#include <TimerOne.h>
#include <math.h>
//Parameters
//Sampling frequency
double sampfreq = 1000; //Hz
//Sampling period (in us)
double sampPeriod = 1000; //us 1000 us = 1 ms
//Resolution of the A/D converter
int bitsAD = 8;
//Frequency of the sine wave
int freq = 1;
//Amplitude of the sine wave
int amp = 1;
//Counter for the total number of samples generated
int cont = 0;
//LED
int ledPin = 13;

//Method that emulates an analog to digital conversion
int convAD(double xval, double xmin, double xmax)
{
  double adVal = 0;
  double ymin = 0;
  double ymax = pow(2,bitsAD)-1;
  adVal = ((xval-xmin)*(ymax-ymin) / (xmax-xmin)) + ymin;
  int iadVal = adVal;    
  return iadVal;
}

//Inicializar a serial
void setup() {
  //Inicaliza a porta serial
  Serial.begin(9600);  
  //Define o tipo do pino
  //Pino de saída digital  
  pinMode(ledPin,OUTPUT);

  //Timer period in us
  Timer1.initialize(sampPeriod);
  Timer1.attachInterrupt(timerTick);  
}

void timerTick()
{
  Timer1.stop();
    int sample = convAD(sin(2*PI*freq*cont*(1.0/sampfreq)),-amp,amp);
  cont++;
  if(cont >= sampfreq)
    cont = 0;  
  Serial.write(sample);    
  Timer1.initialize(sampPeriod);
}

void loop() {
}
