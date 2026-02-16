using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loja
{
    public partial class Form4 : Form
    {
        private MySqlConnection conexao;
        private string data_source = "datasource = localhost; username=root; Convert Zero Datetime=True; password=; database=bdlojata";

        Form form3;
        public Form4(Form form)
        {
            InitializeComponent();
            form3 = form;

            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Add("codigocli", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("nomecli", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("sexocli", 60, HorizontalAlignment.Left);

            listView1.Columns.Add("CPFcli", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("dataNascimentocli", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("enderecoTipocli", 120, HorizontalAlignment.Left);

            listView1.Columns.Add("logradourocli", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("enderecoNumerocli", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("bairrocli", 60, HorizontalAlignment.Left);

            listView1.Columns.Add("cepcli", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("cidadecli", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("UFcli", 60, HorizontalAlignment.Left);

            listView1.Columns.Add("celularcli", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("emailcli", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("instagramcli", 60, HorizontalAlignment.Left);

            listar();
        }

       private void listar(string sql = "SELECT * " + "FROM clientes ")
        {
            try
            {
                string q = "'%" + txBusca.Text + "%'";

                //criar conexão com MySQL
                conexao = new MySqlConnection(data_source);

                //listar registros
                conexao.Open();

                MySqlCommand comando = new MySqlCommand(sql, conexao);
                MySqlDataReader reader = comando.ExecuteReader();

                listView1.Items.Clear();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetValue(0).ToString(),
                        reader.GetValue(1).ToString(),
                        reader.GetValue(2).ToString(),
                        reader.GetValue(3).ToString(),
                        reader.GetValue(4).ToString(),
                        reader.GetValue(5).ToString(),
                        reader.GetValue(6).ToString(),
                        reader.GetValue(7).ToString(),
                        reader.GetValue(8).ToString(),
                        reader.GetValue(9).ToString(),
                        reader.GetValue(10).ToString(),
                        reader.GetValue(11).ToString(),
                        reader.GetValue(12).ToString(),
                        reader.GetValue(13).ToString(),
                        reader.GetValue(14).ToString()
                    };
                    var linha_listview = new ListViewItem(row);
                    listView1.Items.Add(linha_listview);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            form3.Enabled = true;
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            txCodigo.Focus();
        }

        private void limpar()
        {
            new Form4(form3).Show();
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
             try
            {
                //criar conexão com MySQL
                conexao = new MySqlConnection(data_source);

                //inserir registros
                string sql = $"INSERT INTO clientes(nomecli, sexocli, dataNascimentocli, CPFcli, enderecoTipocli, logradourocli, enderecoNumerocli, bairrocli, cepcli, cidadecli, UFcli, celularcli, emailcli, instagramcli) VALUES ('{txNome.Text}', '{txSexo.Text}', '{txDataNascimento.Text}', '{txCPF.Text}', '{txTipoEndereco.Text}', '{txLogradouro.Text}', '{txNumero.Text}', '{txBairro.Text}', '{txCEP.Text}', '{txCidade.Text}', '{txUF.Text}', '{txCelular.Text}', '{txEmail.Text}', '{txInstagram.Text}')";

                MySqlCommand comando = new MySqlCommand(sql, conexao);

                conexao.Open();
                comando.ExecuteReader();

                MessageBox.Show("Campos inseridos!");
                listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
            limpar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //criar conexão com MySQL
                conexao = new MySqlConnection(data_source);

                //inserir registros
                string sql = $"DELETE FROM clientes WHERE `clientes`.`codigocli` = {txCodigo.Text}";

                MySqlCommand comando = new MySqlCommand(sql, conexao);

                conexao.Open();
                comando.ExecuteReader();

                MessageBox.Show("Campos apagados!");
                listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
            limpar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //criar conexão com MySQL
                conexao = new MySqlConnection(data_source);

                //inserir registros
                string sql = $"UPDATE `clientes` SET `nomecli`= '{txNome.Text}',`sexocli`= '{txSexo.Text}',`CPFcli`= '{txCPF.Text}',`dataNascimentocli`= '{txDataNascimento.Text}',`enderecoTipocli`= '{txTipoEndereco.Text}',`logradourocli`= '{txLogradouro.Text}',`enderecoNumerocli`= '{txNumero.Text}',`bairrocli`= '{txBairro.Text}',`cepcli`= '{txCEP.Text}',`cidadecli`= '{txCidade.Text}',`UFcli`= '{txUF.Text}',`celularcli`= '{txCelular.Text}',`emailcli`= '{txEmail.Text}',`instagramcli`= '{txInstagram.Text}' WHERE `clientes`.`codigocli` = {txCodigo.Text}";

                MySqlCommand comando = new MySqlCommand(sql, conexao);

                conexao.Open();
                comando.ExecuteReader();

                MessageBox.Show("Campos atualizados!");
                listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
            limpar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listar($"SELECT * FROM clientes WHERE nomecli like '%{txBusca.Text}%';");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txCodigo.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txNome.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txSexo.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txCPF.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txDataNascimento.Text = listView1.SelectedItems[0].SubItems[4].Text;
                txTipoEndereco.Text = listView1.SelectedItems[0].SubItems[5].Text;
                txLogradouro.Text = listView1.SelectedItems[0].SubItems[6].Text;
                txNumero.Text = listView1.SelectedItems[0].SubItems[7].Text;
                txBairro.Text = listView1.SelectedItems[0].SubItems[8].Text;
                txCEP.Text = listView1.SelectedItems[0].SubItems[9].Text;
                txCidade.Text = listView1.SelectedItems[0].SubItems[10].Text;
                txUF.Text = listView1.SelectedItems[0].SubItems[11].Text;
                txCelular.Text = listView1.SelectedItems[0].SubItems[12].Text;
                txEmail.Text = listView1.SelectedItems[0].SubItems[13].Text;
                txInstagram.Text = listView1.SelectedItems[0].SubItems[13].Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txUF_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
