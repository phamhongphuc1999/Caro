﻿// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.
//  Owner: Pham Hong Phuc

using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation
{
    public partial class BaseForm : Form
    {
        public BaseForm(string formText, Icon icon)
        {
            InitializeComponent(formText, icon);
        }
    }
}