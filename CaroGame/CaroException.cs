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

namespace CaroGame
{
    public class MaxUndoException : Exception
    {
        public MaxUndoException() : base("Invalid MaxUndo") { }
    }

    public class RedoException : Exception
    {
        public RedoException() : base("Redo Exception") { }
    }

    public class UndoException : Exception
    {
        public UndoException() : base("Undo Exception") { }
    }

    public class StayOldGameException : Exception
    {
        public StayOldGameException() : base() { }
    }
}
