using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CustomPanel
{
    public class SettingPanel: Panel
    {
        public Button saveBut, cancelBut;

        public SettingPanel() : base()
        {
            this.Size = new Size(600, 95);
            DrawBasePanel();
        }

        private void DrawBasePanel()
        {
            saveBut = new Button()
            {
                Text = "Save",
                Size = new Size(90, 40),
                Location = new Point(490, 0)
            };
            cancelBut = new Button()
            {
                Text = "Back",
                Size = new Size(90, 40),
                Location = new Point(370, 0)
            };
            this.Controls.Add(saveBut);
            this.Controls.Add(cancelBut);
        }
    }
}
