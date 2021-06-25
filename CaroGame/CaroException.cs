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
