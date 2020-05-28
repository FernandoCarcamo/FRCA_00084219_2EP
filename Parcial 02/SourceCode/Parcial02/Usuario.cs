using System;
using System.Windows.Forms;

namespace Parcial02
{
    public partial class Usuario : UserControl
    {
        private string idusuario, pss;
        public Usuario()
        {
            InitializeComponent();
        }
        public Usuario(string id, string contra)
        {
            idusuario = id;
            pss = contra;
            InitializeComponent();
        }
        
        private void Usuario_Load(object sender, EventArgs e)
        {
            tabPage1.Controls.Add(new Orders(idusuario,pss));
            tabPage2.Controls.Add(new Address(idusuario));
        }
    }
}