using TTB.LabelVerifier.Core.Models;

namespace TTB.LabelVerifier.Core.Comparison
{
    public interface IFieldComparer
    {
        ComparisonResult Compare(LabelFields extracted, LabelFields expected);
    }
}
