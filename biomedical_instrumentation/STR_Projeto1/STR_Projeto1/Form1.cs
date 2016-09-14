//Declaração de bibliotecas
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

namespace STR_Projeto1
{
    public partial class Form1 : Form
    {
        //ESPAÇO PARA VARIÁVEIS GLOBAIS
        //Tipos de acesso: private, public
        //Variáveis constantes
        private const double tempoMaximo = 1; //segundos
        //Taxa de amostragem
        private const double taxaAmostragem = 1000; //Hz
        //Variável para frequência da senóide
        private int frequencia = 0;
        //Chart Area do gráfico
        //Declaração de um objeto
        private ChartArea areaGrafico;
        //Série para o gráfico
        private Series serieGrafico;
        //Declaração do objeto da classe GeradorSinais
        GeradorSinais geradorSenoide;

        //Função de inicialização
        //Construtor
        public Form1()
        {
            //Desenhar a interface
            InitializeComponent();            
        }

        //Inicialização do programa
        private void Form1_Load(object sender, EventArgs e)
        {
            //Inicializar o objeto da área do gráfico
            areaGrafico = new ChartArea();            
            //Inicializar o objeto da série do gráfico
            serieGrafico = new Series("Sinal");
            //Tipo de gráfico -> Fast Line é melhor para tempo real
            serieGrafico.ChartType = SeriesChartType.FastLine;
            //Adicionar a área ao gráfico
            chGrafico.ChartAreas.Add(areaGrafico);            
            //Adicionar a série ao gráfico
            chGrafico.Series.Add(serieGrafico);
            //Inicializar o objeto da classe GeradorSinais
            geradorSenoide = new GeradorSinais();
            geradorSenoide.taxaAmostragem = taxaAmostragem;
        }

        //Evento de clique no botão
        private void btnConfirmarFreq_Click(object sender, EventArgs e)
        {
            //Toda vez que o botão for pressionado
            //vamos limpar o gráfico, gerar uma nova senóide
            //e plotar na tela
            
            //Limpar o gráfico
            serieGrafico.Points.Clear();

            //Recuperar o valor da frequencia
            frequencia = Convert.ToInt32(nuFrequencia.Value);

            //Gerar a senóide
            geradorSenoide.frequencia = frequencia;
            geradorSenoide.Senoide(tempoMaximo);

            //Plotar a senóide
            //Laço que percorre todo o vetor sinal
            for(int i=0; i<geradorSenoide.sinal.Length; i++)
            {
                serieGrafico.Points.AddXY(geradorSenoide.tempo[i], geradorSenoide.sinal[i]);
            }            
        }

        //Botão que escolhe a cor do gráfico
        private void btnCor_Click(object sender, EventArgs e)
        {
            //Abre a caixa de diálogo para seleção de cor
            //Se o botão "OK" for pressionado, então
            //uma cor foi selecionada
            if(cdCorGrafico.ShowDialog() == DialogResult.OK)
            {
                //A cor da série vai ser a cor escolhida
                //na caixa de diálogo
                serieGrafico.Color = cdCorGrafico.Color;                 
            }
        }
    }
}
