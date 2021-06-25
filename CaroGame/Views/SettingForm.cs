using System.Drawing;

namespace CaroGame.Views
{
    public partial class SettingForm : BaseForm
    {
        public SettingForm(string title, Icon icon) : base(title, icon)
        {
            InitializeComponent(title, icon);
        }
    }
}
