// --------------------CARO  GAME-----------------
//
//
// Copyright (c) Microsoft. All Rights Reserved.
// License under the Apache License, Version 2.0.
//
//
// Product by: Pham Hong Phuc
//
//
// ------------------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CaroPanel
{
    public class TwoTextPanel: Panel
    {
        protected TextBox txt1, txt2;
        protected Label lbl1, lbl2;
        protected RoutePanel routePnl;

        public TwoTextPanel() : base()
        {
            this.Size = new Size(600, 375);
            DrawBasePanel();
        }

        public bool CaroVisible
        {
            get { return lbl2.Visible; }
            set
            {
                lbl2.Visible = value;
                txt2.Visible = value;
            }
        }

        public string LabelText1
        {
            get { return lbl1.Text; }
            set { lbl1.Text = value; }
        }

        public string LabelText2
        {
            get { return lbl2.Text; }
            set { lbl2.Text = value; }
        }

        public string Text1
        {
            get { return txt1.Text; }
            set { txt1.Text = value; }
        }

        public string Text2
        {
            get { return txt2.Text; }
            set { txt2.Text = value; }
        }

        public string NextText
        {
            get
            {
                return routePnl.NextText;
            }
            set
            {
                routePnl.NextText = value;
            }
        }

        public string CancelText
        {
            get
            {
                return routePnl.CancelText;
            }
            set
            {
                routePnl.CancelText = value;
            }
        }

        public virtual (bool, string) IsValid()
        {
            if (this.CaroVisible)
            {
                if (txt1.Text == "" || txt2.Text == "") return (false, "Vui lòng nhập tên người chơi");
                if (txt1.Text == txt2.Text) return (false, "Tên không được trùng nhau, vui lòng chọn tên khác");
            }
            else if(txt1.Text == "") return (false, "Vui lòng nhập tên người chơi");
            return (true, "");
        }

        public event EventHandler NextActionClickEvent
        {
            add { routePnl.NextActionClickEvent += value; }
            remove { routePnl.NextActionClickEvent -= value; }
        }

        public event EventHandler CancelActionClickEvent
        {
            add { routePnl.CancelActionClickEvent += value; }
            remove { routePnl.CancelActionClickEvent -= value; }
        }

        private void DrawBasePanel()
        {
            lbl1 = new Label
            {
                Size = new Size(80, 45),
                Location = new Point(30, 85)
            };
            lbl2 = new Label()
            {
                Size = new Size(80, 45),
                Location = new Point(30, 170)
            };
            txt1 = new TextBox()
            {
                Width = 360,
                Location = new Point(120, 85)
            };
            txt2 = new TextBox()
            {
                Width = 360,
                Location = new Point(120, 170)
            };
            routePnl = new RoutePanel()
            {
                Location = new Point(0, 280)
            };
            this.Controls.Add(lbl1);
            this.Controls.Add(lbl2);
            this.Controls.Add(txt1);
            this.Controls.Add(txt2);
            this.Controls.Add(routePnl);
        }
    }
}
