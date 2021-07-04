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

namespace CaroGame.Entities
{
    public struct BoardPosition
    {
        public int Row
        {
            get; private set;
        }
        public int Column
        {
            get; private set;
        }

        public BoardPosition(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}
