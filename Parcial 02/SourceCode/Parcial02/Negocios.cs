using System;
using System.Windows.Forms;

namespace Parcial02
{
    public partial class Negocios : UserControl
    {
        private string idlogin5;
        public Negocios()
        {
            InitializeComponent();
        }
        public Negocios(string id)
        {
            idlogin5 = id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && richTextBox1.Text != "")
                {
                    string neg = textBox1.Text, des = richTextBox1.Text;
                    DBconnection.realizarAccion( $"INSERT into BUSINESS(Name, description) VALUES('{neg}', '{des}')");
                    MessageBox.Show("Se ha ingresado el negocio");
                    
                }else MessageBox.Show("Debe rellenar los campos primero");}
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    string neg = textBox2.Text;
                    DBconnection.realizarAccion($"DELETE FROM public.BUSINESS WHERE name = '{neg}'; ");
                    MessageBox.Show("Se ha eliminado el negocio");
                    
                } else MessageBox.Show("Debe llenar el campo primero");}
            
            catch (Exception ex){MessageBox.Show(ex.Message);}
        }

        private void Negocios_Load(object sender, EventArgs e)
        {
            var dt = DBconnection.realizarConsulta($"SELECT * FROM BUSINESS"); 
            dataGridView2.DataSource = dt;
        }
    }
}