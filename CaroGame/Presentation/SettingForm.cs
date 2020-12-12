﻿// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.
//  Owner: Pham Hong Phuc

namespace CaroGame.Presentation
{
    public partial class SettingForm : BaseForm
    {
        public SettingForm()
        {
            InitializeComponent();
            InitializeController();
            DrawSettingForm(this);
        }
    }
}
