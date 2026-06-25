using TTB.LabelVerifier.Core.Models;

namespace TTB.LabelVerifier.Core.Extraction
{
    public interface IFieldExtractor
    {
        LabelFields Extract(string inputText);
    }
}
