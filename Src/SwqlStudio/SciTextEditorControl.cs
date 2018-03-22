using System;
using System.Drawing;
using System.Windows.Forms;
using ScintillaNET;
using System.Linq;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    internal class SciTextEditorControl : Scintilla, ILexerDataSource
    {
        private ContextMenuStrip editorContextMenu;

        public SciTextEditorControl()
        {
            Lexer = Lexer.Sql;
            LexerService = new LexerService(this);

            StyleResetDefault();
            Styles[Style.Default].Font = "Consolas";
            Styles[Style.Default].Size = 10;
            
            StyleClearAll(); // Propagates the settings from Style.Default to all language-specific lexer styles

            // TODO: wait for newest nuget package, it will ocntains this method!!!
            //this.AutoCSetFillUps(" {}[]().,:;+-*/%&|^!~=<>?@#'\"\\");
            foreach (var words in LexerService.LexerKeywords)
                SetKeywords(words.Item1, string.Join(" ", words.Item2));

            //// Default (whitespace) style index.
            //Styles[Style.Sql.Default].ForeColor = Color.Black;

            //// Comment style index.
            //Styles[Style.Sql.Comment].ForeColor = Color.Green;

            // Line comment style index.
            Styles[Style.Sql.CommentLine].ForeColor = Color.Green;

            //// Documentation comment style index.
            //Styles[Style.Sql.CommentDoc].ForeColor = Color.DarkOliveGreen;

            //// Number style index.
            //Styles[Style.Sql.Number].ForeColor = Color.Blue;

            // Keyword list 1 style index.
            Styles[Style.Sql.Word].ForeColor = Color.Blue;

            //// Double-quoted string style index.
            //Styles[Style.Sql.String].ForeColor = Color.Red;

            // Single-quoted string style index.
            Styles[Style.Sql.Character].ForeColor = Color.Red;

            //// Keyword from the SQL*Plus list style index.
            //Styles[Style.Sql.SqlPlus].ForeColor = Color.HotPink;

            //// SQL*Plus prompt style index.
            //Styles[Style.Sql.SqlPlusPrompt].ForeColor = Color.DodgerBlue;

            // Operator style index.
            Styles[Style.Sql.Operator].ForeColor = Color.DarkGray;

            // Identifier style index.
            Styles[Style.Sql.Identifier].ForeColor = Color.Black;

            //// SQL*Plus comment style index.
            //Styles[Style.Sql.SqlPlusComment].ForeColor = Color.LightSeaGreen;

            //// Documentation line comment style index.
            //Styles[Style.Sql.CommentLineDoc].ForeColor = Color.RoyalBlue;

            //// Keyword list 2 style index.
            //Styles[Style.Sql.Word2].ForeColor = Color.ForestGreen;

            //// Documentation (Doxygen) keyword style index.
            //Styles[Style.Sql.CommentDocKeyword].ForeColor = Color.Black;

            //// Documentation (Doxygen) keyword error style index.
            //Styles[Style.Sql.CommentDocKeywordError].ForeColor = Color.Fuchsia;

            // Keyword user-list 1 style index. (scalar functions)
            Styles[Style.Sql.User1].ForeColor = Color.Fuchsia;
            
            // Keyword user-list 2 style index. (aggregate functions)
            Styles[Style.Sql.User2].ForeColor = Color.Salmon;

            //// Keyword user-list 3 style index.
            //Styles[Style.Sql.User3].ForeColor = Color.Salmon;

            //// Keyword user-list 4 style index.
            //Styles[Style.Sql.User4].ForeColor = Color.Peru;

            //// Quoted identifier style index.
            //Styles[Style.Sql.QuotedIdentifier].ForeColor = Color.Brown;

            //// Q operator style index.
            //Styles[Style.Sql.QOperator].ForeColor = Color.DarkGray;

            InitializeCustomContextMenu();
        }

        private void InitializeCustomContextMenu()
        {
            this.editorContextMenu = new ContextMenuStrip();
            this.editorContextMenu.SuspendLayout();
            
            ToolStripMenuItem undoMenuItem = new ToolStripMenuItem();
            undoMenuItem.Text = "Undo";
            undoMenuItem.Image = Resources.Undo_16x;
            undoMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoMenuItem.Click += new EventHandler(this.UndoMenuClick);
            
            ToolStripMenuItem redoMenuItem = new ToolStripMenuItem();
            redoMenuItem.Text = "Redo";
            redoMenuItem.Image = Resources.Redo_16x;
            redoMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoMenuItem.Click += new EventHandler(this.RedodoMenuClick);
            
            ToolStripMenuItem cutMenuItem = new ToolStripMenuItem();
            cutMenuItem.Text = "Cut";
            cutMenuItem.Image = Resources.Cut_16x;
            cutMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutMenuItem.Click += new EventHandler(this.CutMenuClick);
            
            ToolStripMenuItem copyMenuItem = new ToolStripMenuItem();
            copyMenuItem.Text = "Copy";
            copyMenuItem.Image = Resources.ASX_Copy_blue_16x;
            copyMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyMenuItem.Click += new EventHandler(this.CopyMenuClick);
            
            ToolStripMenuItem pasteMenuItem = new ToolStripMenuItem();
            pasteMenuItem.Text = "Paste";
            pasteMenuItem.Image = Resources.ASX_Paste_blue_16x;
            pasteMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteMenuItem.Click += new EventHandler(this.PasteMenuClick);

            this.editorContextMenu.Items.AddRange(new ToolStripItem[]
            {
                undoMenuItem,
                redoMenuItem,
                cutMenuItem,
                copyMenuItem,
                pasteMenuItem
            });
            this.ContextMenuStrip = this.editorContextMenu;
            this.editorContextMenu.ResumeLayout(false);
        }

        private void PasteMenuClick(object sender, EventArgs e)
        {
            this.Paste();
        }

        private void CopyMenuClick(object sender, EventArgs e)
        {
            this.Copy();
        }

        private void CutMenuClick(object sender, EventArgs e)
        {
            this.Cut();
        }

        private void RedodoMenuClick(object sender, EventArgs e)
        {
            this.Redo();
        }

        private void UndoMenuClick(object sender, EventArgs e)
        {
            this.Undo();
        }

        public void SetMetadata(IMetadataProvider provider)
        {
            if (provider != null)
                LexerService.SetMetadata(provider);
        }

        public string GetSelectedOrAllText()
        {
            var text = SelectedText;
            if (string.IsNullOrEmpty(text))
                text = Text;
            return text;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == 5)
            {
                e.Handled = true;
                if (Execute != null)
                    Execute();
            }
            else
                base.OnKeyPress(e);
        }

        public string FileName { get; set; }

        public LexerService LexerService { get; }

        public event Action Execute;

        protected override void OnCharAdded(CharAddedEventArgs e)
        {
            base.OnCharAdded(e);

            if (!Settings.Default.AutocompleteEnabled)
                return;

            // Find the word start
            var currentPos = this.CurrentPosition;
            var wordStartPos = this.WordStartPosition(currentPos, true);

            var lenEntered = currentPos - wordStartPos;
            if (lenEntered <= 0 && e.Char != '.')
                return;

            var currentWord = this.GetWordFromPosition(wordStartPos) ?? "";
            

            // Display the autocompletion list
            var keywords = string.Join(" ", LexerService.GetAutoCompletionKeywords(currentPos).
                Where(x => x.StartsWith(currentWord, StringComparison.OrdinalIgnoreCase)).OrderBy(x => x));
            this.AutoCShow(lenEntered, keywords);
        }

        string ILexerDataSource.Text => this.Text;

        protected override void Dispose(bool disposing)
        {
            LexerService.Dispose();
            base.Dispose(disposing);
        }
    }
}
