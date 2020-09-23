namespace SwqlStudio
{
    internal class Documentation
    {
        public string ItemType { get; set; }
        public string Documents { get; set; }

        public static readonly Documentation Empty = new Documentation(string.Empty, string.Empty);

        public Documentation(string itemType, string documents)
        {
            ItemType = itemType;
            Documents = documents;
        }
    }
}
