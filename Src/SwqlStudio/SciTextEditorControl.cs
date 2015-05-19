using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ScintillaNET;

namespace SwqlStudio
{
    class SciTextEditorControl : Scintilla
    {
        public SciTextEditorControl()
        {
            Lexer = Lexer.Sql;

            StyleResetDefault();
            Styles[Style.Default].Font = "Consolas";
            Styles[Style.Default].Size = 10;
            
            StyleClearAll(); // Propagates the settings from Style.Default to all language-specific lexer styles

            SetKeywords(0, @"all any and as asc between class desc distinct exists false full group
        having in inner into is isa from join left like not null or outer right
        select set some true union where end when then else case on top return xml
        raw auto with limitation rows to order by desc totalrows noplancache queryplan");

            SetKeywords(4, @"toutc tolocal getdate getutcdate datetime isnull tostring escapeswisurivalue splitstringtoarray floor round ceiling yeardiff monthdiff weekdiff daydiff hourdiff minutediff seconddiff milliseconddiff year quarterofyear dayofyear month week day hour minute second millisecond uriequals arraycontains datetrunc changetimezone toupper tolower concat substring adddate addyear addmonth addweek addday addhour addminute addsecond addmillisecond arraylength arrayvalueat"); // User Keywords 1 - scalar functions

            SetKeywords(5, @"min max avg count sum"); // User Keywords 2 - aggregate functions

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

        public string GetSelectedOrAllText()
        {
            return Selections.IsEmpty ? Text : Selections[0].ToString();
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

        public void SaveFile(string path)
        {
            File.WriteAllText(path, Text);
        }

        public event Action Execute;
    }
}
