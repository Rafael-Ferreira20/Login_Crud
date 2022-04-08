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
    public partial class Form2 : Form
    {
        public Form2()

        {
            InitializeComponent();
        }
       
        SqlConnection conexion = new SqlConnection("server=DESKTOP-3GF3IGG ;database=usuarios; INTEGRATED SECURITY=true");
        public void Agregar_Usuario()
        {
            
                

                if (txtcontraseña.Text == txtconfirmarcontra.Text)
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("insert into usuario (nombre, apellido, telefono, correo_electronico, nombre_usuario, contrasena) values(@Nombre, @Apellido, @Telefono, @CorreoElec, @Usuario, @Contraseña)", conexion);
                    comando.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    comando.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                    comando.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    comando.Parameters.AddWithValue("@CorreoElec", txtcontraseña.Text);
                    comando.Parameters.AddWithValue("@Usuario", txtnewusuario.Text);
                    comando.Parameters.AddWithValue("@Contraseña", txtcontraseña.Text);

                    comando.ExecuteNonQuery();

                    conexion.Close();
                    MessageBox.Show("Registro guardado exitosamente", "EnHoraBuena");
                    Form3 form3 = new Form3();

                    form3.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show(" Las contraseñas no coinciden ", "Advertencia ");
                }

           


        } 

        private void btnregistro_Click(object sender, EventArgs e)
        {
            
            if (txtNombre.Text=="")
            {
                MessageBox.Show("Debe llenar el campo de nombre");
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe llenar el campo de apellido");
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("Debe llenar el campo de telefono");
            }
            else if (string.IsNullOrEmpty(txtcorreo.Text))
            {
                MessageBox.Show("Debe llenar el campo de correo electronico");
            }
            else if (string.IsNullOrEmpty(txtnewusuario.Text))
            {
                MessageBox.Show("Debe llenar el campo del nombre de usuario");
            }
            else if (string.IsNullOrEmpty(txtcontraseña.Text))
            {
                MessageBox.Show("Debe llenar el campo de contraseña");
            }
            else if (string.IsNullOrEmpty(txtconfirmarcontra.Text))
            {
                MessageBox.Show("Debe verificar su contraseña");
            }
            else
            {
                Agregar_Usuario();
            }
        }

        
    }


    
}
