using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ScintillaNET;
using System.Collections.Generic;
using System.Linq;

namespace SwqlStudio
{
    internal class SciTextEditorControl : Scintilla, ILexerDataSource
    {
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

        public void SaveFile(string path)
        {
            File.WriteAllText(path, Text);
        }

        public event Action Execute;

        

        protected override void OnCharAdded(CharAddedEventArgs e)
        {
            base.OnCharAdded(e);

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
    }
}
