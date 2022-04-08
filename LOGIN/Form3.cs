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
    public partial class Form3 : Form
    {
        public Form3()

        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("server=DESKTOP-3GF3IGG ;database=usuarios; INTEGRATED SECURITY=true");
        private void Form3_Load(object sender, EventArgs e)
        {
            dgvusuarios.DataSource = Consulta();
        }


        private void btncerrarsesion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cierre de sesion exitoso", "Felicidades");
            Form1.patronSingleton.Show();
            this.Close();
        }

        #region eventos
        private void btnagregar_Click(object sender, EventArgs e)
        {
         
            if (string.IsNullOrEmpty(TxtNombre.Text))
            {
                MessageBox.Show("Debe llenar el campo de nombre");
            }
            else if (string.IsNullOrEmpty(TxtApellido.Text))
            {
                MessageBox.Show("Debe llenar el campo de apellido");
            }
            else if (string.IsNullOrEmpty(TxtTelefono.Text))
            {
                MessageBox.Show("Debe llenar el campo de telefono");
            }
            else if (string.IsNullOrEmpty(TxtCorreo.Text))
            {
                MessageBox.Show("Debe llenar el campo de correo electronico");
            }
            else if (string.IsNullOrEmpty(TxtUsuario.Text))
            {
                MessageBox.Show("Debe llenar el campo de nombre de usuario");
            }
            else if (string.IsNullOrEmpty(TxtContraseña.Text))
            {
                MessageBox.Show("Debe llenar el campo de contraseña");
            }
            else if (string.IsNullOrEmpty(TxtConfContra.Text))
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }
            else
            {
                Agregar_Usuario();
            }

        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            Actualizar_Usuarios(Convert.ToInt32(dgvusuarios.Rows[0].Cells[0].Value));
            dgvusuarios.DataSource = Consulta();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar_Usuarios(Convert.ToInt32(dgvusuarios.Rows[0].Cells[0].Value));
        }
        private void dgvusuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            TxtNombre.Text = dgvusuarios.CurrentRow.Cells[1].Value.ToString();
            TxtApellido.Text = dgvusuarios.CurrentRow.Cells[2].Value.ToString();
            TxtTelefono.Text = dgvusuarios.CurrentRow.Cells[3].Value.ToString();
            TxtCorreo.Text = dgvusuarios.CurrentRow.Cells[4].Value.ToString();
            TxtUsuario.Text = dgvusuarios.CurrentRow.Cells[5].Value.ToString();
            TxtContraseña.Text = dgvusuarios.CurrentRow.Cells[6].Value.ToString();
        }

        
        public void Actualizar_Usuarios(int ID)
        {
                conexion.Open();
                SqlCommand comando = new SqlCommand("update usuario set nombre=@Nombre, apellido=@Apellido, telefono=@Telefono," +
                    " correo_electronico=@Correo, nombre_usuario=@Usuario, contrasena=@Contraseña where ID=@ID", conexion);
            comando.Parameters.AddWithValue("@ID", ID);
            comando.Parameters.AddWithValue("@Nombre", TxtNombre.Text);
                comando.Parameters.AddWithValue("@Apellido", TxtApellido.Text);
                comando.Parameters.AddWithValue("@Telefono", TxtTelefono.Text);
                comando.Parameters.AddWithValue("@Correo", TxtCorreo.Text);
                comando.Parameters.AddWithValue("@Usuario", TxtUsuario.Text);
                comando.Parameters.AddWithValue("@Contraseña", TxtContraseña.Text);

                comando.ExecuteNonQuery();

                conexion.Close();
                MessageBox.Show("Se ha actualizado exitosamente", "Notificacion");
        }
        public void Agregar_Usuario()
        {
            if (TxtContraseña.Text == TxtConfContra.Text)
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("insert into usuario (nombre, apellido, telefono, correo_electronico, nombre_usuario, contrasena) values(@Nombre, @Apellido, @Telefono, @CorreoElec, @Usuario, @Contraseña)", conexion);
                
                comando.Parameters.AddWithValue("@Nombre", TxtNombre.Text);
                comando.Parameters.AddWithValue("@Apellido", TxtApellido.Text);
                comando.Parameters.AddWithValue("@Telefono", TxtTelefono.Text);
                comando.Parameters.AddWithValue("@CorreoElec", TxtCorreo.Text);
                comando.Parameters.AddWithValue("@Usuario", TxtUsuario.Text);
                comando.Parameters.AddWithValue("@Contraseña", TxtContraseña.Text);

                comando.ExecuteNonQuery();

                conexion.Close();
                MessageBox.Show("Se Agrego exitosamente", "EnHoraBuena");
                dgvusuarios.DataSource = Consulta();
            }

            else
            {
                MessageBox.Show(" Las contraseñas no coinciden ", "Advertencia ");
            }

        }

        public void Eliminar_Usuarios(int ID)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("delete from usuario where ID = @ID", conexion);
            comando.Parameters.AddWithValue("@ID", ID);


            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Se ha borrado el usuario registrado", "Notificacion");
            dgvusuarios.DataSource = Consulta();
        }
        public void Limpiar()
        {
           
            TxtNombre.Clear();
            TxtApellido.Clear();
            TxtTelefono.Clear();
            TxtCorreo.Clear();
            TxtUsuario.Clear();
            TxtContraseña.Clear();
            TxtConfContra.Clear();
        }
        public DataTable Consulta()
        {
            string query = ("select *from usuario");
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            return tabla;
        }

        #endregion




    }
}
