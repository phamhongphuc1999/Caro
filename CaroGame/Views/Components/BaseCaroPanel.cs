using System.Windows.Forms;

namespace CaroGame.Views.Components
{
    public class BaseCaroPanel: Panel
    {
        public BaseCaroPanel(bool isAutoSize = false): base()
        {
            if (isAutoSize)
            {
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            DrawBasePanel();
        }

        protected virtual void DrawBasePanel() { }
    }
}
