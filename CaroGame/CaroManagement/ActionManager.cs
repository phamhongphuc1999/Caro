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

using CaroGame.CaroException;
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
        private int count;

        public ActionManager()
        {
            undoBut = new Stack<Button>();
            redoBut = new Stack<Button>();
            maxUndo = 5;
            count = 0;
        }

        public ActionManager(int maxUndo)
        {
            undoBut = new Stack<Button>();
            redoBut = new Stack<Button>();
            if (maxUndo <= 0) throw new Exception();
            this.maxUndo = maxUndo;
            count = 0;
        }

        public void ResetAction()
        {
            undoBut.Clear();
            redoBut.Clear();
        }

        public Button AddUndo()
        {
            if (count == maxUndo) throw new UndoException();
            Button but = redoBut.Pop();
            undoBut.Push(but);
            count++;
            return but;
        }

        public Button AddRedo()
        {
            if (undoBut.Count == 0) throw new RedoException();
            Button but = undoBut.Pop();
            redoBut.Push(but);
            if (count > 0) count--;
            return but;
        }

        public void UpdateTurn(Button but)
        {
            redoBut.Push(but);
        }
    }
}
