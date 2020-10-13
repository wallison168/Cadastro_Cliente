using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;


namespace Cadastro_Cliente
{
    /// <summary>
    /// Lógica interna para Cadastro.xaml
    /// </summary>
    public partial class Cadastro : Window
    {
        public Cadastro()
        {
            InitializeComponent();
        }


        MySqlConnection connection;
        MySqlCommand comando;

        string sql;

        public void Insert()
        {
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=cadastro_cliente;Uid=root;Pwd=kekinho13;");

                sql = "insert into cliente (nome, cpf, cnpj, telefone, logradouro, numero, cidade, estado, bairro, cep, complemento) values (@nome, @cpf, @cnpj, @telefone, @logradouro, @numero, @cidade, @estado, @bairro, @cep, @complemento)";

                comando = new MySqlCommand(sql, connection);
                comando.Parameters.AddWithValue("@nome", tb_nome.Text);
                comando.Parameters.AddWithValue("@cpf", tb_cpf.Text);
                comando.Parameters.AddWithValue("@cnpj", tb_cnpj.Text);
                comando.Parameters.AddWithValue("@telefone", tb_telefone.Text);
                comando.Parameters.AddWithValue("@logradouro", tb_logradouro.Text);
                comando.Parameters.AddWithValue("@numero", tb_numero_cas.Text);
                comando.Parameters.AddWithValue("@cidade", tb_cidade.Text);
                comando.Parameters.AddWithValue("@estado", tb_estado_uf.Text);
                comando.Parameters.AddWithValue("@bairro", tb_bairro.Text);
                comando.Parameters.AddWithValue("@cep", tb_cep.Text);
                comando.Parameters.AddWithValue("@complemento", tb_complemento.Text);

                connection.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                connection = null;
                comando = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Insert();

            tb_bairro.Clear();
            tb_cep.Clear();
            tb_cidade.Clear();
            tb_cnpj.Clear();
            tb_complemento.Clear();
            tb_cpf.Clear();
            tb_estado_uf.Clear();
            tb_logradouro.Clear();
            tb_nome.Clear();
            tb_numero_cas.Clear();
            tb_telefone.Clear();

            tb_nome.Focus();
        }
    }
}
