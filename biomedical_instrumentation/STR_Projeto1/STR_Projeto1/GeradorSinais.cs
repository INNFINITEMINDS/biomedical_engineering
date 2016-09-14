using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STR_Projeto1
{
    public class GeradorSinais
    {
        //Declaração de vetor
        //Este vetor armazena o sinal gerado
        public double[] sinal;
        //Este vetor armazena o tempo
        public double[] tempo;
        //Taxa de Amostragem
        public double taxaAmostragem;
        //Frequência
        public double frequencia;

        //Construtor
        public GeradorSinais()
        {
            taxaAmostragem = 0;
            frequencia = 0;
        }

        /// <summary>
        /// Esta função gera uma senóide de acordo com os parâmetros configurados
        /// </summary>
        /// <param name="_tempoMaximo"></param>
        public void Senoide(double _tempoMaximo)
        {   
            //Descobrindo a quantidade de amostras
            int numeroAmostras = Convert.ToInt32(Math.Round(_tempoMaximo * taxaAmostragem));
            sinal = new double[numeroAmostras]; //Inicialização do vetor
            tempo = new double[numeroAmostras];
            double dt = 1.0 / taxaAmostragem;
            for(int i=1; i<numeroAmostras-1; i++)
            {
                //Armazeno a nova amostra da senóide no vetor sinal
                sinal[i-1] = Math.Sin(2 * Math.PI * tempo[i-1] * frequencia);
                tempo[i] = tempo[i-1] + dt; //Incremento o tempo por dt
            }
        }
    }
}
