using System;
using TTB.LabelVerifier.Core.Models;

namespace TTB.LabelVerifier.Core.Comparison
{
    public class FieldComparer : IFieldComparer
    {
        public ComparisonResult Compare(LabelFields extracted, LabelFields expected)
        {
            var result = new ComparisonResult();

            // BRAND
            result.BrandMatches = string.Equals(
                extracted.BrandName?.Trim(),
                expected.BrandName?.Trim(),
                StringComparison.OrdinalIgnoreCase
            );
            result.BrandMessage = result.BrandMatches
                ? "Brand ✔ Match"
                : $"Brand ❌ Mismatch (Expected: {expected.BrandName}, Found: {extracted.BrandName})";

            // ABV
            result.ABVMatches = string.Equals(
                extracted.ABV?.Trim(),
                expected.ABV?.Trim(),
                StringComparison.OrdinalIgnoreCase
            );
            result.ABVMessage = result.ABVMatches
                ? "ABV ✔ Match"
                : $"ABV ❌ Mismatch (Expected: {expected.ABV}, Found: {extracted.ABV})";

            // NET CONTENTS
            result.NetContentsMatch = string.Equals(
                extracted.NetContents?.Trim(),
                expected.NetContents?.Trim(),
                StringComparison.OrdinalIgnoreCase
            );
            result.NetContentsMessage = result.NetContentsMatch
                ? "Net Contents ✔ Match"
                : $"Net Contents ❌ Mismatch (Expected: {expected.NetContents}, Found: {extracted.NetContents})";

            // CLASS TYPE
            result.ClassTypeMatches = string.Equals(
                extracted.ClassType?.Trim(),
                expected.ClassType?.Trim(),
                StringComparison.OrdinalIgnoreCase
            );
            result.ClassTypeMessage = result.ClassTypeMatches
                ? "Class/Type ✔ Match"
                : $"Class/Type ❌ Mismatch (Expected: {expected.ClassType}, Found: {extracted.ClassType})";

            return result;
        }
    }
}
