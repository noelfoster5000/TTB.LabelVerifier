namespace TTB.LabelVerifier.Core.Models
{
    public class ComparisonResult
    {
        public bool BrandMatches { get; set; }
        public bool ABVMatches { get; set; }
        public bool NetContentsMatch { get; set; }
        public bool ClassTypeMatches { get; set; }

        public string BrandMessage { get; set; } = string.Empty;
        public string ABVMessage { get; set; } = string.Empty;
        public string NetContentsMessage { get; set; } = string.Empty;
        public string ClassTypeMessage { get; set; } = string.Empty;

        public bool AllPassed =>
            BrandMatches &&
            ABVMatches &&
            NetContentsMatch &&
            ClassTypeMatches;
    }
}
