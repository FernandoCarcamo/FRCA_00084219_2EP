using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            var users = DBconnection.realizarConsulta("SELECT userName FROM APPUSER ");
            var usersCombo = new List<String>();

            foreach (DataRow dr in users.Rows)
            {
                usersCombo.Add(dr[0].ToString());
            }
            comboBox1.DataSource = usersCombo;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var usuario = DBconnection.realizarConsulta($"SELECT * FROM appuser " +
                                                        $"where userName = '{comboBox1.Text}' and pswd = '{textBox2.Text}'");
            
            if (usuario.Rows.Count == 0) MessageBox.Show("Usuario o contraseña invalidos");
            
            else
            {
                if (usuario.Rows[0]["type"].ToString() == "Admin")
                {
                    MessageBox.Show("Usuario admin");
                    string a = usuario.Rows[0]["iduser"].ToString();
                    string b = usuario.Rows[0]["pswd"].ToString();
                    string c = usuario.Rows[0]["type"].ToString();
                        
                    var AF = new MainForm(new Administrador(a, b, c));
                    AF.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario normal");
                    var AF = new MainForm(new Usuario(usuario.Rows[0]["iduser"].ToString(), usuario.Rows[0]["pswd"].ToString()));
                    AF.Show();
                    this.Hide();
                }
            }        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var AF = new PswdChange();
                AF.Show();
                this.Hide();
            }
            catch (Exception ex){MessageBox.Show(ex.Message);}
        }
    }
}