using System.Linq;
using System.Text.RegularExpressions;
using TTB.LabelVerifier.Core.Models;

namespace TTB.LabelVerifier.Core.Extraction
{
    public class FieldExtractor : IFieldExtractor
    {
        public LabelFields Extract(string inputText)
        {
            return new LabelFields
            {
                BrandName = ExtractBrand(inputText),
                ABV = ExtractABV(inputText),
                NetContents = ExtractNetContents(inputText),
                ClassType = ExtractClassType(inputText)
            };
        }

        private string? ExtractBrand(string text)
        {
            var firstLine = text.Split('\n').FirstOrDefault()?.Trim();
            return string.IsNullOrWhiteSpace(firstLine) ? null : firstLine;
        }

        private string? ExtractABV(string text)
        {
            var match = Regex.Match(text, @"(\d{1,2}\.\d{1,2}%\s*ABV|\d{1,2}%\s*ABV)", RegexOptions.IgnoreCase);
            return match.Success ? match.Value : null;
        }

        private string? ExtractNetContents(string text)
        {
            var match = Regex.Match(text, @"\b(\d+(\.\d+)?\s*(ml|mL|L|oz|OZ))\b");
            return match.Success ? match.Value : null;
        }

        private string? ExtractClassType(string text)
        {
            string[] types = { "vodka", "whiskey", "rum", "gin", "tequila", "bourbon", "wine", "brandy" };

            foreach (var type in types)
            {
                if (text.Contains(type, System.StringComparison.OrdinalIgnoreCase))
                    return type;
            }

            return null;
        }
    }
}
