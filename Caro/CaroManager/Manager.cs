using Caro.Setting;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Caro.CaroManager
{
    class Manager
    {
        private Form1 mainForm;
        private Panel pnlCaroBoard;
        private static CONST caroConst;
        private Dictionary<KeyValuePair<int, int>, Button> caroBoard;

        public Manager(Form1 mainForm, Panel pnlCaroBoard, CONST caroConst)
        {
            this.mainForm = mainForm;
            this.pnlCaroBoard = pnlCaroBoard;
            Manager.caroConst = caroConst;

            caroBoard = new Dictionary<KeyValuePair<int, int>, Button>();
        }

        public void DrawCaroBoard(int numberOfRow, int numberOfColumn)
        {
            pnlCaroBoard.Controls.Clear();
            for(int i = 0; i < numberOfRow; i++)
            {
                for(int j = 0; j < numberOfColumn; j++)
                {
                    Button but = new Button()
                    {
                        Size = new Size(CONST.WIDTH, CONST.HEIGHT),
                        Location = new Point(CONST.WIDTH * j, CONST.HEIGHT * i)
                    };
                    but.Click += But_Click;
                    caroBoard.Add(new KeyValuePair<int, int>(CONST.WIDTH * j, CONST.HEIGHT * i), but);
                    pnlCaroBoard.Controls.Add(but);
                }
            }
        }

        #region Event handle
        private void But_Click(object sender, System.EventArgs e)
        {
        }
        #endregion
    }
}
