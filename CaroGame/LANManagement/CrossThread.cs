// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.
//  Owner: Pham Hong Phuc

using System;
using System.Windows.Forms;

namespace CaroGame.LANManagement
{
    public static class CrossThread
    {
        /// <summary>
        /// Perform safety
        /// </summary>
        /// <param name="target">The control is used mutiple thread</param>
        /// <param name="action">The specified action used the control</param>
        public static void PerformSafely(this Control target, Action action)
        {
            if (target.InvokeRequired) target.Invoke(action);
            else action();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="target"></param>
        /// <param name="action"></param>
        /// <param name="parameter"></param>
        public static void PerformSafely<T1>(this Control target, Action<T1> action, T1 parameter)
        {
            if (target.InvokeRequired) target.Invoke(action, parameter);
            else action(parameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="target"></param>
        /// <param name="action"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public static void PerformSafely<T1, T2>(this Control target, Action<T1, T2> action, T1 p1, T2 p2)
        {
            if (target.InvokeRequired) target.Invoke(action, p1, p2);
            else action(p1, p2);
        }
    }
}
