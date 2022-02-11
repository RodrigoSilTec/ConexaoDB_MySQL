using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoModulo8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = ConexaoBD.getInstancia().getConexao();

            try
            {
                connection.Open();
                MessageBox.Show("Conexão criada com sucesso!");
            }
            catch (MySqlException msqle)
            {
                MessageBox.Show("Erro de acesso ao MySQL: " + msqle.Message, "Erro");
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = ConexaoBD.getInstancia().getConexao();

            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select nome from usuarios";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nome"] != null)
                    {
                        MessageBox.Show(reader["nome"].ToString());
                    }
                }
            }
            catch (MySqlException msqle)
            {
                MessageBox.Show("Erro de acesso ao MySQL: " + msqle.Message, "Erro");
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim().Equals(String.Empty)) { return; }

            MySqlConnection connection = ConexaoBD.getInstancia().getConexao();

            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "insert into usuarios(nome) values(@varNome);";
                cmd.Parameters.AddWithValue("varNome", txtNome.Text.Trim());
                int valorRetorno = cmd.ExecuteNonQuery();
                if (valorRetorno < 1)
                {
                    MessageBox.Show("Erro! Nenhuma alteração.");
                }
                else
                {
                    MessageBox.Show("Sucesso! Colunas afetadas: " + valorRetorno.ToString());
                }
            }
            catch (MySqlException msqle)
            {
                MessageBox.Show("Erro de acesso ao MySQL: " + msqle.Message, "Erro");
            }
            finally
            {
                connection.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNome2.Text.Trim().Equals(String.Empty) || txtId.Text.Trim().Equals(String.Empty)) { return; }

            MySqlConnection connection = ConexaoBD.getInstancia().getConexao();

            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "update usuarios set nome = @varNome where id = @varId;";

                cmd.Parameters.AddWithValue("varNome", txtNome2.Text.Trim());
                cmd.Parameters.AddWithValue("varId", Convert.ToInt32(txtId.Text.Trim()));

                int valorRetorno = cmd.ExecuteNonQuery();
                if (valorRetorno < 1)
                {
                    MessageBox.Show("Erro! Nenhuma alteração.");
                }
                else
                {
                    MessageBox.Show("Sucesso! Colunas afetadas: " + valorRetorno.ToString());
                }
            }
            catch (MySqlException msqle)
            {
                MessageBox.Show("Erro de acesso ao MySQL: " + msqle.Message, "Erro");
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = ConexaoBD.getInstancia().getConexao();

            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "delete from usuarios where id = @varId;";

                cmd.Parameters.AddWithValue("varId", Convert.ToInt32(txtIdDel.Text.Trim()));

                int valorRetorno = cmd.ExecuteNonQuery();
                if (valorRetorno < 1)
                {
                    MessageBox.Show("Erro! Nenhuma alteração.");
                }
                else
                {
                    MessageBox.Show("Sucesso! Colunas afetadas: " + valorRetorno.ToString());
                }
            }
            catch (MySqlException msqle)
            {
                MessageBox.Show("Erro de acesso ao MySQL: " + msqle.Message, "Erro");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
