using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace intro_serial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btAbrir_Click(object sender, EventArgs e)
        {            
            //Definir a porta COM de acordo com o item selecionado na comboBox
            serialPort1.PortName = cbPortasCOM.Items[cbPortasCOM.SelectedIndex].ToString();
            //Tentar abrir a conexão
            serialPort1.Open();
            //Se a conexão for bem sucedida
            if(serialPort1.IsOpen)
            {
                //Mostra uma mensagem de OK
                MessageBox.Show("Conexão OK!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Caso contrário
            else
            {
                MessageBox.Show("Conexão Falhou!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            //Verifica se a porta COM está aberta
            //Caso esteja, fechar a porta
            if(serialPort1.IsOpen)
            {
                //Fecha a porta
                serialPort1.Close();
                //Verifica se realmente conseguiu fechar a porta
                if (serialPort1.IsOpen)
                {
                    MessageBox.Show("Erro ao fechar a porta!");
                }
                else
                    MessageBox.Show("Porta fechada!");
            }
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            //Recuperar o texto da textbox
            string textoEnviar = tbTextoEnviar.Text;
            //Uso o método que envia uma string e salta
            //uma linha
            serialPort1.WriteLine(textoEnviar);
        }

        private void btReceber_Click(object sender, EventArgs e)
        {
            //Se tiver algum dado disponível para leitura
            //Ler os dados
            if (serialPort1.BytesToRead > 0)
            {
                //Ler uma linha inteira de dados enviada pelo Arduino
                string textoRecebido = serialPort1.ReadLine();
                //Mostrar na textbox o que foi recebido
                tbReceber.Text = textoRecebido;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            //Receber todas as portas COM disponíveis no PC
            //A resposta é armazenada num vetor de strings
            string[] nomesPortas = System.IO.Ports.SerialPort.GetPortNames();

            //De acordo com o vetor de strings contendo os nomes das Portas COM
            //vou adicioná-las na comboBox
            //Laço que vai de zero até o tamanho do vetor
            for (int i = 0; i < nomesPortas.Length; i++)
                cbPortasCOM.Items.Add(nomesPortas[i]); //Adiciona os elementos na cb
        }

        private void btRecebeByte_Click(object sender, EventArgs e)
        {
            //Se tiver algum dado disponível para leitura
            //Ler os dados
            if (serialPort1.BytesToRead > 0)
            {
                //Ler um byte
                string byteLido = serialPort1.ReadByte().ToString();
                //Escreve o byte lido na textbox
                tbReceber.Text = byteLido;
            }
        }
    }
}
