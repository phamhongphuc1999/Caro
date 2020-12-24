using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation
{
    partial class AboutForm
    {
        private RichTextBox rtbAbout;

        public void InitializeController()
        {
            rtbAbout = new RichTextBox()
            {
                Name = "rtbAbout",
                Text = "\n\n" +
                "          Devepoler: Phạm Hồng Phúc\n" +
                "          Country: Việt Nam\n" +
                "          Game: Caro Game\n" +
                "          Version: v1",
                Size = new Size(400, 250),
                Location = new Point(0, 0),
                Enabled = false
            };
            this.Controls.Add(rtbAbout);
        }
    }
}