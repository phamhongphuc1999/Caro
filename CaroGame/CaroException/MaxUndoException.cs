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

namespace CaroGame.CaroException
{
    public class MaxUndoException: Exception
    {
        public MaxUndoException(): base("Invalid MaxUndo") { }
    }
}
