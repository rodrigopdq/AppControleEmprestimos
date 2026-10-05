using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppControleEmprestimos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                EmprestimoDB db = new EmprestimoDB();
                dataGridView1.DataSource = db.getEmprestimos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItem.Text) || string.IsNullOrWhiteSpace(txtAmigo.Text))
            {
                MessageBox.Show("Por favor, preencha o nome do item e do amigo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string item = txtItem.Text.Trim();
                string amigo = txtAmigo.Text.Trim();
                string contato = txtContato.Text.Trim();
                DateTime dataEmp = dtpEmprestimo.Value;
                DateTime dataComb = dtpDevolucaoCombinada.Value;

                Emprestimo novoEmp = new Emprestimo(item, amigo, contato, dataEmp, dataComb);

                EmprestimoDB db = new EmprestimoDB();
                db.IncluirEmprestimo(novoEmp);

                MessageBox.Show("Empréstimo cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtItem.Clear();
            txtAmigo.Clear();
            txtContato.Clear();
            dtpEmprestimo.Value = DateTime.Now;
            dtpDevolucaoCombinada.Value = DateTime.Now;
            txtItem.Focus();
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    }
}