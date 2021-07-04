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

using System.Windows.Forms;

namespace CaroGame.Controls
{
    public class BoardButton : Button
    {
        public int Rows
        {
            get; set;
        }
        public int Columns
        {
            get; set;
        }
        public BoardButton() : base() { }
    }
}
