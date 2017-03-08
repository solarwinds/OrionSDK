namespace SwqlStudio.Autocomplete
{
    // what do we detect user is/can be typing?
    internal struct ExpectedCaretPosition
    {
        public ExpectedCaretPosition(ExpectedCaretPositionType type, string proposedEntity)
        {
            Type = type;
            ProposedEntity = proposedEntity;
        }

        // what do we detect user is/can be typing?
        public ExpectedCaretPositionType Type { get; }
        // what entity columns to display? canonical name
        public string ProposedEntity { get; }
    }
}