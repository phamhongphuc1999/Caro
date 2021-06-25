using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Views
{
    public partial class BaseForm : Form
    {
        public BaseForm(string title, Icon icon)
        {
            InitializeComponent(title, icon);
        }
    }
}
