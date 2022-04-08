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

namespace LOGIN
{
    public partial class Form1 : Form
    {
        private Form1()
        {
            InitializeComponent();
        }
        public static Form1 patronSingleton = new Form1();
        SqlConnection conexion = new SqlConnection("server= DESKTOP-3GF3IGG; database=usuarios; INTEGRATED SECURITY=true");
        private void btnAcceder_Click(object sender, EventArgs e)
        {

        }

       

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtuser.Text))
            {
                MessageBox.Show("Debe llenar el campo de usuario");
            }
            else if (string.IsNullOrEmpty(txtpass.Text))
            {
                MessageBox.Show("Debe llenar el campo de contraseña");
            }
            else
            {
                login();
            }
        }

        private void linkcuenta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void login()
        {

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("select nombre_usuario, contrasena from usuarios where usuario = @Usuario and contraseña = @Contraseña", conexion);
                comando.Parameters.AddWithValue("@Usuario", txtuser.Text);
                comando.Parameters.AddWithValue("@Contraseña", txtpass.Text);

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read())
                {
                    conexion.Close();
                    MessageBox.Show("inicio de sesion con exito", "EnHoraBuena");
                    Form3 form3 = new Form3();
                    form3.Show();
                }
                else
                {
                    MessageBox.Show("Su nombre de usuario o contraseña no son correctos, sino tiene cuenta debe Registrarse", "Advertencia");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Su nombre de usuario o contraseña no son correctos, sino tiene cuenta debe Registrarse", "Advertencia");

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}