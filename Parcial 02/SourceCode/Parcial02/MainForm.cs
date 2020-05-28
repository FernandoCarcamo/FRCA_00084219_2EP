using System.Windows.Forms;

namespace Parcial02
{
    public partial class MainForm : Form
    {
       
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(Administrador userControl)
        {
            InitializeComponent();
            this.Controls.Add(userControl);
        }
        public MainForm(Usuario userControl)
        {
            InitializeComponent();
            this.Controls.Add(userControl);
        }
    }
    
}
