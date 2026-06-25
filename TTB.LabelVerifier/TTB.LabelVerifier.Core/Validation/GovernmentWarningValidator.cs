namespace TTB.LabelVerifier.Core.Validation
{
    public static class GovernmentWarningValidator
    {
        private const string OfficialText =
            "GOVERNMENT WARNING: (1) According to the Surgeon General, women should not drink " +
            "alcoholic beverages during pregnancy because of the risk of birth defects. " +
            "(2) Consumption of alcoholic beverages impairs your ability to drive a car or " +
            "operate machinery, and may cause health problems.";

        public static bool IsExactMatch(string input, out string diff)
        {
            if (string.Equals(input?.Trim(), OfficialText.Trim(), System.StringComparison.Ordinal))
            {
                diff = string.Empty;
                return true;
            }

            diff = "Text does not exactly match the official government warning.";
            return false;
        }
    }
}
