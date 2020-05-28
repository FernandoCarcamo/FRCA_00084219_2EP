using System;
using System.Windows.Forms;

namespace Parcial02
{
    public partial class Administrador : UserControl
    {
        string idUser, contra, type;
        public Administrador()
        {
            InitializeComponent();
        }
        public Administrador(string id,string pass, string t)
        {
            idUser = id;
            contra = pass;
            type = t;
            InitializeComponent();
        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            tabPage1.Controls.Add(new Users(idUser));
            tabPage2.Controls.Add(new Negocios(idUser));
            tabPage3.Controls.Add(new Products(idUser));
            tabPage4.Controls.Add(new Orders(idUser,type));
        }
    }
}