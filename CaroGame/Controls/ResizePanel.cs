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

using System.Drawing;
using System.Windows.Forms;
using static CaroGame.Configuration.Constants;

namespace CaroGame.Controls
{
    public class ResizePanel : Panel
    {
        private bool mMouseDown = false;
        private bool mOutlineDrawn = false;
        private EdgeEnum mEdge = EdgeEnum.None;
        private int mWidth = 5;
        private bool top, right, bottom, left;

        public ResizePanel(bool top, bool right, bool bottom, bool left) : base()
        {
            this.top = top;
            this.right = right;
            this.bottom = bottom;
            this.left = left;
            this.MouseDown += ResizePanel_MouseDown;
            this.MouseUp += ResizePanel_MouseUp;
            this.MouseMove += ResizePanel_MouseMove;
            this.MouseLeave += ResizePanel_MouseLeave;
        }

        public ResizePanel(bool topLeft, bool bottomRight): base()
        {
            this.top = topLeft;
            this.right = bottomRight;
            this.bottom = bottomRight;
            this.left = topLeft;
            this.MouseDown += ResizePanel_MouseDown;
            this.MouseUp += ResizePanel_MouseUp;
            this.MouseMove += ResizePanel_MouseMove;
            this.MouseLeave += ResizePanel_MouseLeave;
        }

        private void ResizePanel_MouseLeave(object sender, System.EventArgs e)
        {
            Control c = (Control)sender;
            mEdge = EdgeEnum.None;
            c.Refresh();
        }

        private void ResizePanel_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            Graphics g = c.CreateGraphics();
            switch (mEdge)
            {
                case EdgeEnum.TopLeft:
                    g.FillRectangle(Brushes.Fuchsia, 0, 0, mWidth * 4, mWidth * 4);
                    mOutlineDrawn = true;
                    break;
                case EdgeEnum.Left:
                    g.FillRectangle(Brushes.Fuchsia, 0, 0, mWidth, c.Height);
                    mOutlineDrawn = true;
                    break;
                case EdgeEnum.Right:
                    g.FillRectangle(Brushes.Fuchsia, c.Width - mWidth, 0, c.Width, c.Height);
                    mOutlineDrawn = true;
                    break;
                case EdgeEnum.Top:
                    g.FillRectangle(Brushes.Fuchsia, 0, 0, c.Width, mWidth);
                    mOutlineDrawn = true;
                    break;
                case EdgeEnum.Bottom:
                    g.FillRectangle(Brushes.Fuchsia, 0, c.Height - mWidth, c.Width, mWidth);
                    mOutlineDrawn = true;
                    break;
                case EdgeEnum.None:
                    if (mOutlineDrawn)
                    {
                        c.Refresh();
                        mOutlineDrawn = false;
                    }
                    break;
            }
            if (mMouseDown & mEdge != EdgeEnum.None)
            {
                c.SuspendLayout();
                switch (mEdge)
                {
                    case EdgeEnum.TopLeft:
                        if (left && top) c.SetBounds(c.Left + e.X, c.Top + e.Y, c.Width, c.Height);
                        break;
                    case EdgeEnum.Left:
                        if (left) c.SetBounds(c.Left + e.X, c.Top, c.Width - e.X, c.Height);
                        break;
                    case EdgeEnum.Right:
                        if (right) c.SetBounds(c.Left, c.Top, c.Width - (c.Width - e.X), c.Height);
                        break;
                    case EdgeEnum.Top:
                        if (top) c.SetBounds(c.Left, c.Top + e.Y, c.Width, c.Height - e.Y);
                        break;
                    case EdgeEnum.Bottom:
                        if (bottom) c.SetBounds(c.Left, c.Top, c.Width, c.Height - (c.Height - e.Y));
                        break;
                }
                c.ResumeLayout();
            }
            else
            {
                if (e.X <= (mWidth * 4) & e.Y <= (mWidth * 4))
                {
                    c.Cursor = Cursors.SizeAll;
                    mEdge = EdgeEnum.TopLeft;
                }
                else if (e.X <= mWidth)
                {
                    c.Cursor = Cursors.VSplit;
                    mEdge = EdgeEnum.Left;
                }
                else if (e.X > c.Width - (mWidth + 1))
                {
                    c.Cursor = Cursors.VSplit;
                    mEdge = EdgeEnum.Right;
                }
                else if (e.Y <= mWidth)
                {
                    c.Cursor = Cursors.HSplit;
                    mEdge = EdgeEnum.Top;
                }
                else if (e.Y > c.Height - (mWidth + 1))
                {
                    c.Cursor = Cursors.HSplit;
                    mEdge = EdgeEnum.Bottom;
                }
                else
                {
                    c.Cursor = Cursors.Default;
                    mEdge = EdgeEnum.None;
                }
            }
        }

        private void ResizePanel_MouseUp(object sender, MouseEventArgs e)
        {
            mMouseDown = false;
        }

        private void ResizePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mMouseDown = true;
            }
        }
    }
}
