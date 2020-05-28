using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial02
{
    public partial class Orders : UserControl
    {
        private string idLogin2, type;
        public Orders()
        {
            InitializeComponent();
        }
        public Orders(string id, string t)
        {
            idLogin2 = id;
            type = t;
            InitializeComponent();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            var dt = DBconnection.realizarConsulta(
                $"SELECT product.name as \"product_name\", business.name as \"business_name\", " +
                $"apporder.createdate, address.address, apporder.idorder from apporder " +
                $"inner join product on apporder.idproduct = product.idproduct inner join business on " +
                $"product.idbusiness = business.idbusiness " +
                $"inner join address on apporder.idaddress = address.idaddress where address.iduser = {idLogin2}");
            dataGridView3.DataSource = dt;

            var dt2 = DBconnection.realizarConsulta(
                $"SELECT product.name as \"product_name\", business.name as \"business_name\", " +
                $"apporder.createdate, address.address, apporder.idorder from apporder " +
                $"inner join product on apporder.idproduct = product.idproduct inner join business on " +
                $"product.idbusiness = business.idbusiness " +
                $"inner join address on apporder.idaddress = address.idaddress");
            dataGridView3.DataSource = dt2;
            
            
            var dt1 = DBconnection.realizarConsulta($"SELECT * FROM PRODUCT"); 
            dataGridView2.DataSource = dt1;
            
            
            var orders = DBconnection.realizarConsulta($"SELECT idorder FROM APPORDER");
            var ordersCombo = new List<String>();

            foreach (DataRow dr in orders.Rows)
            {
                ordersCombo.Add(dr[0].ToString());
            }
            comboBox3.DataSource = ordersCombo;
            
            var dt4 = DBconnection.realizarConsulta($"SELECT * FROM APPORDER");
            dataGridView1.DataSource = dt4;

            if (type == "Admin")
            {
                tabPage1.Enabled = false;
                tabPage2.Enabled = false;
                tabPage3.Enabled = true;
            }
            else
            {
                tabPage1.Enabled = true;
                tabPage2.Enabled = true;
                tabPage3.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    string idP = textBox1.Text, add = textBox2.Text;
                    DBconnection.realizarAccion(  $"INSERT into APPORDER(createdate, idproduct, idaddress)" +
                                                  $" VALUES('{DateTime.Now}', {idP}, " + $" {add})");
                    MessageBox.Show("Pedido registrado con exito");
                    
                } else MessageBox.Show("Debe llevar los campos"); }
            
            catch (Exception ex) {MessageBox.Show(ex.Message);}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox3.Text != "")
                {
                    string user = comboBox3.Text;
                    DBconnection.realizarAccion(  $"DELETE FROM public.apporder WHERE idorder = '{comboBox3.Text}'");
                    MessageBox.Show("Se ha eliminado el pedido");
                    
                } else MessageBox.Show("Debe seleccionar un ID");}
            
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }
    }
}