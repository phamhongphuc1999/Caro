using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CaroGame.Presentation
{
    partial class BaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected virtual void InitializeComponent(string formTitle, Icon icon)
        {
            this.Text = formTitle;
            this.Icon = icon;
            this.components = new Container();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(600, 375);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Opacity = 1;
        }
    }
}