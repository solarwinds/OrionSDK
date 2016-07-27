using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwqlStudio
{
    public class LexerService
    {
        private static LexerService instance;

        protected List<string> BasicAutoCompletionKeywords { get; private set; }
        protected List<string> CustomAutoCompletionKeywords { get; private set; }
        public List<string> AutoCompletionKeywords { get; private set; }

        private LexerService()
        {
            BasicAutoCompletionKeywords = new List<string>();
            CustomAutoCompletionKeywords = new List<string>();

            foreach (var words in this.LexerKeywords)
                BasicAutoCompletionKeywords.AddRange(words.Item2.Select(w => w.ToUpper()));
            BasicAutoCompletionKeywords.Sort();

            ProcessACKeywords();
        }

        public static LexerService Instance
        {
            get
            {
                if (instance == null)
                    instance = new LexerService();
                return instance;
            }
        }

        public IEnumerable<Tuple<int, IEnumerable<string>>> LexerKeywords
        {
            get
            {
                yield return new Tuple<int, IEnumerable<string>>(0,
                    @"all any and as asc between class desc distinct exists false full group having in inner into is isa from join left like not null or outer right select set some true union where end when then else case on top return xml raw auto with limitation rows to order by desc totalrows noplancache queryplan querystats"
                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries));
                // User Keywords 1 - scalar functions
                yield return new Tuple<int, IEnumerable<string>>(4,
                    @"toutc tolocal getdate getutcdate datetime isnull tostring escapeswisurivalue splitstringtoarray floor round ceiling yeardiff monthdiff weekdiff daydiff hourdiff minutediff seconddiff milliseconddiff year quarterofyear dayofyear month week day hour minute second millisecond uriequals arraycontains datetrunc changetimezone toupper tolower concat substring adddate addyear addmonth addweek addday addhour addminute addsecond addmillisecond arraylength arrayvalueat"
                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries));
                // User Keywords 2 - aggregate functions
                yield return new Tuple<int, IEnumerable<string>>(5,
                    @"min max avg count sum"
                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries));
            }
        }

        public void AddCustomACKeywords(IEnumerable<string> keywords)
        {
            this.CustomAutoCompletionKeywords.AddRange(keywords);
            ProcessACKeywords();
        }

        public void ClearCustomACKeywords()
        {
            this.CustomAutoCompletionKeywords.Clear();
            ProcessACKeywords();
        }

        public void ProcessACKeywords()
        {
            this.AutoCompletionKeywords = BasicAutoCompletionKeywords
                .Concat(CustomAutoCompletionKeywords)
                .Distinct(StringComparer.CurrentCultureIgnoreCase)
                .OrderBy(w => w)
                .ToList();
        }
    }
}
