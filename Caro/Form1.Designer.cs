using System.Windows.Forms;
using System.Drawing;

namespace Caro
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Button butMode, butModeLan;

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

        #region Windows Form Designer generated code
        
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Name = "Form1";
            this.Text = "Game Mode";
            this.ResumeLayout(false);

            butMode = new Button()
            {
                Name = "butMode",
                Text = "One Computer",
                Size = new Size(70, 50),
                Location = new Point(0, 0)
            };

            butModeLan = new Button()
            {
                Name = "butModeLan",
                Text = "LAN Mode",
                Size = new Size(70, 50),
                Location = new Point(100, 100)
            };
        }

        #endregion
    }
}

