using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginCsharpSqlServer
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-CCH60LK6;Initial Catalog=teste;Integrated Security=True");

        public Login()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();    
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            con.Open(); 
            String query = "SELECT * FROM Usuario  WHERE login = '" + txtLogin.Text + "' AND senha = '" + txtSenha.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                Form2 form2 = new Form2();
                this.Hide();
                form2.Show();
                con.Close();
            }
            else
            {
                MessageBox.Show("Login ou senha, incorretos! Verifique suas informações e tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Text = "";
                txtSenha.Text = "";
                txtLogin.Select();
            }
        }
    }
}
