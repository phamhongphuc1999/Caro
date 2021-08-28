using static CaroGame.Program;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Views
{
    partial class AboutForm
    {
        private RichTextBox rtbAbout;
        private LinkLabel gitLlbl;

        public void InitializeController()
        {
            rtbAbout = new RichTextBox()
            {
                Text = string.Format("\n          {0}: Phạm Hồng Phúc\n          {1}: Việt Nam\n          Game: Caro\n          {2}: v3.0",
                CaroService.Language.GetString("developer"), CaroService.Language.GetString("country"), CaroService.Language.GetString("version")),
                Size = new Size(400, 150),
                Location = new Point(0, 0),
                Enabled = false
            };
            gitLlbl = new LinkLabel
            {
                BackColor = Color.Red,
                ForeColor = Color.Green,
                Text = "github",
                Size = new Size(400, 50),
                Location = new Point(0, 150)
            };
            gitLlbl.Click += GitLlbl_Click;
            this.Controls.Add(rtbAbout);
            this.Controls.Add(gitLlbl);
        }
    }
}