using System.Drawing;

namespace CaroGame.Presentation
{
    public partial class AboutForm : BaseForm
    {
        public AboutForm(string formText, Icon icon): base(formText, icon)
        {
            this.Size = new Size(400, 250);
            InitializeController();
        }
    }
}
