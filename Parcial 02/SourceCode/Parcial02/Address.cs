using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial02
{
    public partial class Address : UserControl
    {
        private int idAddress;
        private string idLogin1;
        public Address()
        {
            InitializeComponent();
        }
        public Address(string id)
        {
            idLogin1 = id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    string add = textBox1.Text;
                    DBconnection.realizarAccion(
                        $"INSERT into ADDRESS(address, iduser) VALUES('{add}', {idLogin1})");
                    MessageBox.Show("Se ha ingresado la direccion");
                    
                } else MessageBox.Show("Debe rellenar el campos primero"); }
            
            catch (Exception ex){MessageBox.Show(ex.Message);}
        }

        private void Address_Load(object sender, EventArgs e)
        {
            var dt = DBconnection.realizarConsulta($"SELECT * FROM ADDRESS"); 
            dataGridView1.DataSource = dt;
            
            var address = DBconnection.realizarConsulta("SELECT address FROM ADDRESS ");
            var addressCombo = new List<String>();

            foreach (DataRow dr in address.Rows)
            {
                addressCombo.Add(dr[0].ToString());
            }
            comboBox2.DataSource = addressCombo;
            
            
            var addressE = DBconnection.realizarConsulta("SELECT address FROM ADDRESS ");
            var addressECombo = new List<String>();

            foreach (DataRow dr in addressE.Rows)
            {
                addressECombo.Add(dr[0].ToString());
            }
            comboBox3.DataSource = addressECombo;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string add = comboBox2.Text;
                DBconnection.realizarAccion(
                    $"UPDATE public.address SET address = '{textBox2.Text}' WHERE address = '{add}'");
                MessageBox.Show("Se ha actualizado la direccion");
            }
            catch (Exception ex) {MessageBox.Show(ex.Message);}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox3.Text != "")
                {
                    string user = comboBox3.Text;
                    DBconnection.realizarAccion(
                        $"DELETE FROM public.ADDRESS WHERE address = '{comboBox3.Text}'");
                    MessageBox.Show("Se ha eliminado la direccion");
                    
                }else MessageBox.Show("Debe seleccionar una direccion primero");
            }
            
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
    }
