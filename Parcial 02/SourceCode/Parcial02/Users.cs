using System;
using System.Windows.Forms;

namespace Parcial02
{
    public partial class Users : UserControl
    {
        private int idUsuario;
        private string idLogin;
        public Users()
        {
            InitializeComponent();
        }
        public Users(string id)
        {
            idLogin = id;
            InitializeComponent();
        }

        private void tabPage1_KeyUp(object sender, KeyEventArgs e)
        {
            textBox3.Text = textBox4.Text;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            var usuario = DBconnection.realizarConsulta($"SELECT * FROM APPUSER where userName = '{textBox2.Text}'");
            idUsuario = Convert.ToInt32(usuario.Rows[0][0].ToString());
            textBox7.Text = usuario.Rows[0][1].ToString();
            textBox5.Text = usuario.Rows[0][2].ToString();
            textBox6.Text = usuario.Rows[0][4].ToString();
            comboBox2.Text = usuario.Rows[0][3].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreCompleto = textBox7.Text, nombreUsuario = textBox5.Text, pswd1 = textBox6.Text;
                string tipo = comboBox2.Text;
                
                DBconnection.realizarAccion(
                    $"UPDATE APPUSER SET fullName = '{nombreCompleto}', userName = '{nombreUsuario}', pswd = '{pswd1}', " +
                    $"type = '{tipo}' WHERE iduser = {idUsuario}");
                MessageBox.Show("Se ha actualizado el usuario");
            }
            
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreCompleto = textBox1.Text,
                    nombreUsuario = textBox4.Text,
                    tipo = comboBox1.Text,
                    pswd1 = textBox3.Text;
                    

                DBconnection.realizarAccion(
                    $"INSERT into APPUSER(fullName, userName, type, pswd) VALUES('{nombreCompleto}', '{nombreUsuario}', " +
                    $"'{tipo}', '{pswd1}')");
                MessageBox.Show("Se ha ingresado un usuario");
            }
            
            catch (Exception ex) {MessageBox.Show(ex.Message);}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox8.Text != "")
                {
                    string user = textBox8.Text;
                    DBconnection.realizarAccion(
                        $"DELETE FROM public.appuser WHERE userName = '{user}'; ");
                    MessageBox.Show("Se ha eliminado el usuario");
                }
                
                else MessageBox.Show("Debe llenar el campo primero");
            }
            catch (Exception ex){MessageBox.Show(ex.Message);}
        }


        private void Users_Load(object sender, EventArgs e)
        {
            var dt = DBconnection.realizarConsulta($"SELECT * FROM APPUSER");
            dataGridView1.DataSource = dt;
            var dt1 = DBconnection.realizarConsulta($"SELECT * FROM APPUSER");
            dataGridView2.DataSource = dt1;
        }
    }
}