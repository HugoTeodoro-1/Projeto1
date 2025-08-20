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

namespace Projeto1
{
    public partial class frmLogin : Form
    {
        //INSTANCIANDO A STRING DE CONEXÃO
        Conexao con = new Conexao();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" && txtSenha.Text == "")
            {
                MessageBox.Show("Usuário e Senha invalídos");
            }
        
            try
            {
                string sql = "select * from tbLogin where usuario= @user and senha = @senha ";
                MySqlCommand cmd = new MySqlCommand(sql, con.ConnectarBD());
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = txtUsuario.Text;
                cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value= txtSenha.Text;
                MySqlDataReader dados;
                dados = cmd.ExecuteReader(); //Vai executar o 

                if (dados.HasRows)
                {
                    MessageBox.Show("Seja bem-vindo ao sistema"); //Vai aparecer uma mensagem falando "Seja bem vindo ao sistema"
                    frmMenu menu = new frmMenu();
                    this.Hide();
                    menu.Show();
                }
                else
                {
                    txtUsuario.Clear(); // esse comando vai limpar a txtUsuario
                    txtSenha.Clear(); // esse comando vai limpar a  txtSenha
                    txtUsuario.Focus(); // esse comando vai 
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message); //Vai aparecer uma mensagem de erro
            }
            finally
            {
                con.DesConnectarBD();
            }
        }
    }
}
