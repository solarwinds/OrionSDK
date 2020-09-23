namespace SwqlStudio
{
    public class QueryVariable
    {
        public QueryVariable()
        {
        }

        public QueryVariable(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}
