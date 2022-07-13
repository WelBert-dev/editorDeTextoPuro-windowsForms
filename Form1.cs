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

namespace wfEditorTextoPuro
{
    public partial class Form1 : Form
    {
        StreamReader leitura = null;
        public Form1()
        {
            InitializeComponent();

        }
        private void NovoArq() // principal
        {
            try
            {
                
                rtb_principal.Clear();
                rtb_principal.Focus();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: "+ ex.Message);
                return;
            }
        }
        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NovoArq();
        }
        private void btn_novo_Click(object sender, EventArgs e)
        {
            NovoArq();
        }
        //
        private void AbrirArq() // principal
        {
            this.openFileDialog1.Title = "Abrir Arquivo";
            openFileDialog1.InitialDirectory = @"C:\Users\welli\OneDrive\Área de Trabalho\IFSP\IFSP21-informatica-3Semestre-2022\Linguagem e Tecnica de Programacao II (LG2 T3)";
            openFileDialog1.Filter = "(*.WEC)|*.WEC";
            openFileDialog1.Multiselect = false;

            DialogResult dr = this.openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader wec_StreamReader = new StreamReader(arquivo);
                    wec_StreamReader.BaseStream.Seek(0, SeekOrigin.Begin); // começa a ler apartir do inicio "0" e vai até o fim "Begin"
                    this.rtb_principal.Clear();
                    string linha = wec_StreamReader.ReadLine();
                    while (linha != null)
                    {
                        rtb_principal.Text += linha + "\n";
                        linha = wec_StreamReader.ReadLine();
                    }
                    wec_StreamReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de leitura: " + ex.Message, "Erro ao ler: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirArq();
        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            AbrirArq();
        }
        //
        private void SalvarArq() // principal
        {
            this.saveFileDialog1.Title = "Salvar arquivo";
            this.saveFileDialog1.InitialDirectory = @"C:\Users\welli\OneDrive\Área de Trabalho\IFSP\IFSP21-informatica-3Semestre-2022\Linguagem e Tecnica de Programacao II (LG2 T3)";
            this.saveFileDialog1.Filter = "(*.WEC)|*.WEC";

            try
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter wec_StreamWriter = new StreamWriter(arquivo);
                    wec_StreamWriter.Flush();
                    wec_StreamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    wec_StreamWriter.Write(this.rtb_principal.Text);
                    wec_StreamWriter.Flush();
                    wec_StreamWriter.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na gravação: "+ ex.Message,"Erro ao gravar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalvarArq();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            SalvarArq();
        }
        private void Copiar() // principal
        {
            if (rtb_principal.SelectionLength > 0)
            {
                rtb_principal.Copy();
            }
        }
        private void btn_copiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }
        private void Colar() // principal
        {
            rtb_principal.Paste();
        }

        private void btn_colar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }
        private void Negrito() // principal
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool n, i, s = false; // aonde n é negrito, i italic e s Underline


            nome_da_fonte = rtb_principal.Font.Name;
            tamanho_da_fonte = rtb_principal.Font.Size;
            n = rtb_principal.SelectionFont.Bold;
            i = rtb_principal.SelectionFont.Italic;
            s = rtb_principal.SelectionFont.Underline;
            

            if (n == false)
            {
                if (i == true && s == true)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (i == false && s == true)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (i == true && s == false)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
                }
                
            }
            else
            {
                if (i == true && s == true)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (i == false && s == true)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
                }
                else if (i == true && s == false)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
                }
                else
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);
                }
            }

        }
        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negrito();
        }
        private void btn_negrito_Click(object sender, EventArgs e)
        {
            Negrito();
        }
        private void Italico() // principal
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool n, i, s = false; // aonde n é negrito, i italic e s Underline

            nome_da_fonte = rtb_principal.Font.Name;
            tamanho_da_fonte = rtb_principal.Font.Size;
            n = rtb_principal.SelectionFont.Bold;
            i = rtb_principal.SelectionFont.Italic;
            s = rtb_principal.SelectionFont.Underline;


            if (i == false)
            {
                if (n == true && s == true)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Bold | FontStyle.Underline);
                }
                else if (n == false && s == true)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (n == true && s == false)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Bold);
                }
                else
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
                }
            }
            else
            {
                if (n == true && s == true)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (n == false && s == true)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
                }
                else if (n == true && s == false)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
                }
                else
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);
                }
            }
        }

        private void btn_italico_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void italicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italico();
        }
        private void Sublinhado() // principal
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool n, i, s = false; // aonde n é negrito, i italic e s Underline

            nome_da_fonte = rtb_principal.Font.Name;
            tamanho_da_fonte = rtb_principal.Font.Size;
            n = rtb_principal.SelectionFont.Bold;
            i = rtb_principal.SelectionFont.Italic;
            s = rtb_principal.SelectionFont.Underline;


            if (s == false)
            {
                if (i == true && n == true)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline | FontStyle.Italic | FontStyle.Bold);
                }
                else if (i == false && n == true)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline | FontStyle.Bold);
                }
                else if (i == true && n == false)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline | FontStyle.Italic);
                }
                else
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
                }
            }
            else
            {
                if (i == true & n == true)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Bold);
                }
                else if (i == false & n == true)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
                }
                else if (i == true && n == false)
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
                }
                else
                {
                    rtb_principal.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);
                }
            }
        }

        private void btn_sublinhado_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }
        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }
        private void Centralizar() // principal
        {
            rtb_principal.SelectionAlignment = HorizontalAlignment.Center;
        }
        private void btn_centralizar_Click(object sender, EventArgs e)
        {

        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
