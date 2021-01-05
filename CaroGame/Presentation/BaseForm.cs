using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation
{
    public partial class BaseForm : Form
    {
        public BaseForm(string formText, Icon icon)
        {
            InitializeComponent(formText, icon);
        }
    }
}
