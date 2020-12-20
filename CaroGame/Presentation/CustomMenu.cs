using System.Windows.Forms;

namespace CaroGame.Presentation
{
    public class CustomMenu : MenuStrip
    {
        public ToolStripSeparator bottomQuickSeparator;
        public ToolStripMenuItem toolItemMain, toolItemNewGame, toolItemQuick, toolItemSetting, toolItemAbout;

        public CustomMenu() : base()
        {
            CreateMainMenu();
            Items.AddRange(new ToolStripItem[]
            {
                toolItemMain
            });
        }

        private void CreateMainMenu()
        {
            toolItemSetting = new ToolStripMenuItem()
            {
                Text = "Setting Game",
                ShortcutKeys = (Keys)Shortcut.CtrlShiftS
            };
            toolItemNewGame = new ToolStripMenuItem()
            {
                Text = "New Game",
                ShortcutKeys = (Keys)Shortcut.CtrlN
            };
            toolItemQuick = new ToolStripMenuItem()
            {
                Text = "Quick Game",
                ShortcutKeys = (Keys)Shortcut.CtrlQ
            };
            bottomQuickSeparator = new ToolStripSeparator();
            toolItemAbout = new ToolStripMenuItem()
            {
                Text = "About"
            };
            toolItemMain = new ToolStripMenuItem()
            {
                Text = "Menu"
            };
            toolItemMain.DropDownItems.AddRange(new ToolStripItem[]
            {
                toolItemNewGame,
                toolItemSetting,
                toolItemQuick,
                bottomQuickSeparator,
                toolItemAbout
            });
        }
    }
}
