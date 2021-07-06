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
using static CaroGame.Program;

namespace CaroGame
{
    internal static class Utils
    {
        public static void ApplicationExit()
        {
            storageManager.SaveConfiguration();
            storageManager.SaveGameToFile();
            Application.Exit();
        }
    }
}
