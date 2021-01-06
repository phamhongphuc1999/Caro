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

namespace CaroGame.Presentation
{
    public class CustomMenu : MenuStrip
    {
        protected ToolStripSeparator bottomQuickSeparator;
        protected ToolStripMenuItem mainItemTool, newGameItemTool, quickItemTool, settingItemTool, aboutItemTool;

        public CustomMenu() : base()
        {
            CreateMainMenu();
            Items.AddRange(new ToolStripItem[]
            {
                mainItemTool
            });
        }

        public event EventHandler NewGameItemClickEvent
        {
            add { newGameItemTool.Click += value; }
            remove { newGameItemTool.Click -= value; }
        }

        public event EventHandler QuickItemClickEvent
        {
            add { quickItemTool.Click += value; }
            remove { quickItemTool.Click -= value; }
        }

        public event EventHandler SettingItemClickEvent
        {
            add { settingItemTool.Click += value; }
            remove { settingItemTool.Click -= value; }
        }

        public event EventHandler AboutItemClickEvent
        {
            add { aboutItemTool.Click += value; }
            remove { aboutItemTool.Click -= value; }
        }

        private void CreateMainMenu()
        {
            settingItemTool = new ToolStripMenuItem()
            {
                Text = "Setting Game",
                ShortcutKeys = (Keys)Shortcut.CtrlShiftS
            };
            newGameItemTool = new ToolStripMenuItem()
            {
                Text = "New Game",
                ShortcutKeys = (Keys)Shortcut.CtrlN
            };
            quickItemTool = new ToolStripMenuItem()
            {
                Text = "Quick Game",
                ShortcutKeys = (Keys)Shortcut.CtrlQ
            };
            bottomQuickSeparator = new ToolStripSeparator();
            aboutItemTool = new ToolStripMenuItem()
            {
                Text = "About"
            };
            mainItemTool = new ToolStripMenuItem()
            {
                Text = "Menu"
            };
            mainItemTool.DropDownItems.AddRange(new ToolStripItem[]
            {
                newGameItemTool,
                settingItemTool,
                quickItemTool,
                bottomQuickSeparator,
                aboutItemTool
            });
        }
    }
}
