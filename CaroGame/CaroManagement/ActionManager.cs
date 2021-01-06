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
using System.Collections.Generic;
using System.Windows.Forms;

namespace CaroGame.CaroManagement
{
    public class ActionManager
    {
        private Stack<Button> undoBut;
        private Stack<Button> redoBut;
        private int maxUndo;

        public ActionManager()
        {
            undoBut = new Stack<Button>();
            redoBut = new Stack<Button>();
            maxUndo = 5;
        }

        public ActionManager(int maxUndo)
        {
            undoBut = new Stack<Button>();
            redoBut = new Stack<Button>();
            if (maxUndo <= 0) throw new Exception();
            this.maxUndo = maxUndo;
        }

        public void UndoGame()
        {
            
        }

        public void RedoGame()
        {

        }
    }
}
