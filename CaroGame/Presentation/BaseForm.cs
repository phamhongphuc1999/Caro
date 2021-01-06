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

        protected void SetCurrentPanel(Panel panel, string title)
        {
            SetCurrentPanel(panel);
            this.Text = title;
        }

        protected void AddFit(Panel panel)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Size = panel.Size;
            this.Controls.Add(panel);
        }
    }
}
