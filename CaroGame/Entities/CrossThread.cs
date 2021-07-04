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
using System.Windows.Forms;

namespace CaroGame.Entities
{
    public static class CrossThread
    {
        public static void PerformSafely(this Control target, Action action)
        {
            if (target.InvokeRequired) target.Invoke(action);
            else action();
        }

        public static void PerformSafely<T1>(this Control target, Action<T1> action, T1 parameter)
        {
            if (target.InvokeRequired) target.Invoke(action, parameter);
            else action(parameter);
        }

        public static void PerformSafely<T1, T2>(this Control target, Action<T1, T2> action, T1 p1, T2 p2)
        {
            if (target.InvokeRequired) target.Invoke(action, p1, p2);
            else action(p1, p2);
        }
    }
}
