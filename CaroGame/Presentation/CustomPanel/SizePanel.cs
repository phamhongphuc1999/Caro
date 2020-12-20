using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CustomPanel
{
    public class SizePanel: Panel
    {
        public TextBox txtRow, txtColumn;
        public Label lblRow, lblColumn;

        public SizePanel() : base()
        {
            this.Size = new Size(600, 280);
            DrawBasePanel();
        }

        private void DrawBasePanel()
        {
            lblRow = new Label
            {
                Text = "Player1",
                Size = new Size(80, 45),
                Location = new Point(30, 85)
            };
            lblColumn = new Label()
            {
                Text = "Player2",
                Size = new Size(80, 45),
                Location = new Point(30, 170)
            };
            txtRow = new TextBox()
            {
                Width = 360,
                Location = new Point(120, 85)
            };
            txtColumn = new TextBox()
            {
                Width = 360,
                Location = new Point(120, 170)
            };
            this.Controls.Add(lblRow);
            this.Controls.Add(lblColumn);
            this.Controls.Add(txtRow);
            this.Controls.Add(txtColumn);
        }
    }
}
