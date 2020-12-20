using CaroGame.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation
{
    partial class BaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = null;

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
        /// Draw base form
        /// </summary>
        /// <param name="form">The specified form is drawed</param>
        /// <param name="formText">The specified form's name is named specified form</param>
        /// <param name="width">The specified form's width is assigned to specified form</param>
        /// <param name="height">The specified form's width is assigned to specified form</param>
        /// <param name="isClear">If true, all of controls in specified form is cleaned</param>
        protected void DrawCommonForm(ref Form form, string formText, int width = 600, int height = 375, bool isClear = true)
        {
            if (isClear) form.Controls.Clear();
            form.Text = formText;
            form.AutoScaleDimensions = new SizeF(9F, 20F);
            form.ClientSize = new Size(width, height);
            Config.caroFlow.Push(formText);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected virtual void InitializeComponent(string formTitle, Icon icon)
        {
            this.Text = formTitle;
            this.Icon = icon;
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Opacity = 1;
        }

        #endregion
    }
}