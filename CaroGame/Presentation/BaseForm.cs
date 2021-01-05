using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation
{
    public partial class BaseForm : Form
    {
        protected Panel currentPnl;

        public BaseForm(string formText, Icon icon)
        {
            InitializeComponent(formText, icon);
        }

        protected void SetCurrentPanel(Panel panel)
        {
            currentPnl.Visible = false;
            currentPnl = panel;
            currentPnl.Visible = true;
        }
    }
}
