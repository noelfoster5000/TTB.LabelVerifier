using System.ComponentModel;
using System.Runtime.CompilerServices;
using TTB.LabelVerifier.Core.Comparison;
using TTB.LabelVerifier.Core.Extraction;
using TTB.LabelVerifier.Core.Models;
using TTB.LabelVerifier.Core.Validation;
using TTB.LabelVerifier.UI.Commands;

namespace TTB.LabelVerifier.UI.ViewModels
{
    public class SingleCheckViewModel : INotifyPropertyChanged
    {
        private readonly FieldExtractor _extractor = new();
        private readonly FieldComparer _comparer = new();

        // Expected fields
        private string _expectedBrand = string.Empty;
        private string _expectedABV = string.Empty;
        private string _expectedNetContents = string.Empty;
        private string _expectedClassType = string.Empty;

        // Extracted fields
        private string _fullLabelText = string.Empty;
        private string _extractedBrand = string.Empty;
        private string _extractedABV = string.Empty;
        private string _extractedNetContents = string.Empty;
        private string _extractedClassType = string.Empty;

        // Comparison result
        private string _comparisonResultText = string.Empty;

        // Government warning
        private string _governmentWarningInput = string.Empty;
        private string _governmentWarningResult = string.Empty;

        public RelayCommand ExtractFieldsCommand { get; }
        public RelayCommand ValidateWarningCommand { get; }
        public RelayCommand CompareFieldsCommand { get; }

        public SingleCheckViewModel()
        {
            ExtractFieldsCommand = new RelayCommand(_ => ExtractFields());
            ValidateWarningCommand = new RelayCommand(_ => ValidateWarning());
            CompareFieldsCommand = new RelayCommand(_ => CompareFields());
        }

        private void ExtractFields()
        {
            var fields = _extractor.Extract(FullLabelText);

            ExtractedBrand = $"Brand: {fields.BrandName ?? "Not found"}";
            ExtractedABV = $"ABV: {fields.ABV ?? "Not found"}";
            ExtractedNetContents = $"Net Contents: {fields.NetContents ?? "Not found"}";
            ExtractedClassType = $"Class/Type: {fields.ClassType ?? "Not found"}";
        }

        private void CompareFields()
        {
            var extracted = new LabelFields
            {
                BrandName = ExtractedBrand.Replace("Brand: ", ""),
                ABV = ExtractedABV.Replace("ABV: ", ""),
                NetContents = ExtractedNetContents.Replace("Net Contents: ", ""),
                ClassType = ExtractedClassType.Replace("Class/Type: ", "")
            };

            var expected = new LabelFields
            {
                BrandName = ExpectedBrand,
                ABV = ExpectedABV,
                NetContents = ExpectedNetContents,
                ClassType = ExpectedClassType
            };

            var result = _comparer.Compare(extracted, expected);

            ComparisonResultText =
                $"{result.BrandMessage}\n" +
                $"{result.ABVMessage}\n" +
                $"{result.NetContentsMessage}\n" +
                $"{result.ClassTypeMessage}\n\n" +
                (result.AllPassed ? "✔ All Fields Match" : "❌ One or More Fields Do Not Match");
        }

        private void ValidateWarning()
        {
            bool match = GovernmentWarningValidator.IsExactMatch(
                GovernmentWarningInput,
                out string diff
            );

            GovernmentWarningResult = match
                ? "Government Warning: ✔ Exact Match"
                : $"Government Warning: ❌ Mismatch\n\n{diff}";
        }

        // Properties

        public string FullLabelText
        {
            get => _fullLabelText;
            set { _fullLabelText = value; OnPropertyChanged(); }
        }

        public string ExtractedBrand
        {
            get => _extractedBrand;
            set { _extractedBrand = value; OnPropertyChanged(); }
        }

        public string ExtractedABV
        {
            get => _extractedABV;
            set { _extractedABV = value; OnPropertyChanged(); }
        }

        public string ExtractedNetContents
        {
            get => _extractedNetContents;
            set { _extractedNetContents = value; OnPropertyChanged(); }
        }

        public string ExtractedClassType
        {
            get => _extractedClassType;
            set { _extractedClassType = value; OnPropertyChanged(); }
        }

        public string ExpectedBrand
        {
            get => _expectedBrand;
            set { _expectedBrand = value; OnPropertyChanged(); }
        }

        public string ExpectedABV
        {
            get => _expectedABV;
            set { _expectedABV = value; OnPropertyChanged(); }
        }

        public string ExpectedNetContents
        {
            get => _expectedNetContents;
            set { _expectedNetContents = value; OnPropertyChanged(); }
        }

        public string ExpectedClassType
        {
            get => _expectedClassType;
            set { _expectedClassType = value; OnPropertyChanged(); }
        }

        public string ComparisonResultText
        {
            get => _comparisonResultText;
            set { _comparisonResultText = value; OnPropertyChanged(); }
        }

        public string GovernmentWarningInput
        {
            get => _governmentWarningInput;
            set { _governmentWarningInput = value; OnPropertyChanged(); }
        }

        public string GovernmentWarningResult
        {
            get => _governmentWarningResult;
            set { _governmentWarningResult = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
