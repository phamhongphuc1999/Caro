using System.Drawing;

namespace CaroGame.Views
{
    public partial class AboutForm : BaseForm
    {
        public AboutForm(string title, Icon icon): base(title, icon)
        {
            InitializeComponent(title, icon);
        }
    }
}
