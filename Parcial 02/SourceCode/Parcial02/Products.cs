using System;
using System.Windows.Forms;

namespace Parcial02
{
    public partial class Products : UserControl
    {
        private string idLogin4;
        public Products()
        {
            InitializeComponent();
        }
        public Products(string id)
        {
            idLogin4 = id; 
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    string p = textBox1.Text, neg = textBox2.Text;
                    DBconnection.realizarAccion($"INSERT into PRODUCT(Name, idBusiness) VALUES('{p}', '{neg}')");
                    MessageBox.Show("Se ha ingresado un producto");
                    
                }else MessageBox.Show("Debe rellenar los campos primero");}
            
            catch (Exception ex){MessageBox.Show(ex.Message);}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != "")
                {
                    string p = textBox3.Text;
                    DBconnection.realizarAccion($"DELETE FROM public.PRODUCT WHERE name = '{p}'; ");
                    MessageBox.Show("Se ha eliminado el producto");
                    
                }else MessageBox.Show("Debe llenar el campo primero");}
            
            catch (Exception ex){MessageBox.Show(ex.Message);}
        }
        private void Products_Load(object sender, EventArgs e)
        {
            var dt = DBconnection.realizarConsulta($"SELECT * FROM PRODUCT"); 
            dataGridView1.DataSource = dt;
            
            var dt1 = DBconnection.realizarConsulta($"SELECT * FROM BUSINESS"); 
            dataGridView2.DataSource = dt1;
        }
    }
}