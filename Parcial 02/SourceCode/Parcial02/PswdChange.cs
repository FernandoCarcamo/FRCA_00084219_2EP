using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial02
{
    public partial class PswdChange : Form
    {
        private string contrasena;
        public PswdChange()
        {
            InitializeComponent();
        }
        public PswdChange(string pass)
        {
            contrasena = pass;
            InitializeComponent();
        }

        private void btnCambiarContra_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = DBconnection.realizarConsulta($"SELECT * FROM appuser " +
                                                            $"where userName = '{cmbUsuario.Text}'");
            
                if (usuario.Rows.Count == 0) MessageBox.Show("Usuario o contraseña invalidos");
                

                contrasena = usuario.Rows[0]["pswd"].ToString();
                MessageBox.Show(contrasena);
                if ((txtActual.Text == contrasena) && (txtActual.Text != txtNueva.Text) && (txtNueva.Text == txtRepetir.Text))
                {
                    DBconnection.realizarAccion($"UPDATE APPUSER SET pswd = '{txtNueva.Text}' WHERE userName = '{cmbUsuario.Text}'");
                    MessageBox.Show("Se ha cambiado su contraseña exitosamente!");
                }
                else MessageBox.Show("Usuario o contraseña invalidos");
                

            }
            catch(Exception ex){MessageBox.Show(ex.Message);}   
        }

        private void PswdChange_Load(object sender, EventArgs e)
        {
            var users = DBconnection.realizarConsulta("SELECT userName FROM APPUSER ");
            var usersCombo = new List<String>();

            foreach (DataRow dr in users.Rows)
            {
                usersCombo.Add(dr[0].ToString());
            }
            cmbUsuario.DataSource = usersCombo;
        }
    }
}