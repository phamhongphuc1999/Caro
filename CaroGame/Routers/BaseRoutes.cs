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

namespace CaroGame.Routers
{
    public class EventArgsRoute : EventArgs
    {
        public string title
        {
            get; private set;
        }

        public EventArgsRoute(string router) : base()
        {
            this.title = router;
        }
    }

    public class BaseRoutes
    {
        protected Control currentControl;

        public BaseRoutes()
        {
            currentControl = new Control();
        }

        protected void SetCurrentControl(Control control)
        {
            if (currentControl != null) currentControl.Visible = false;
            currentControl = control;
            currentControl.Visible = true;
        }
    }
}
