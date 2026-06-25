using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TTB.LabelVerifier.Core.Comparison;
using TTB.LabelVerifier.Core.Extraction;
using TTB.LabelVerifier.Core.Models;
using TTB.LabelVerifier.Core.Validation;
using TTB.LabelVerifier.UI.Commands;

public class BatchCheckViewModel : INotifyPropertyChanged
{
    private readonly FieldExtractor _extractor = new();
    private readonly FieldComparer _comparer = new();

    private string _batchInput = string.Empty;
    public string BatchInput
    {
        get => _batchInput;
        set { _batchInput = value; OnPropertyChanged(); }
    }

    public ObservableCollection<BatchResult> BatchResults { get; } = new();

    public RelayCommand ProcessBatchCommand { get; }

    public BatchCheckViewModel()
    {
        ProcessBatchCommand = new RelayCommand(_ => ProcessBatch());
    }

    private void ProcessBatch()
    {
        BatchResults.Clear();

        var labels = BatchInput.Split("---", StringSplitOptions.RemoveEmptyEntries);

        int index = 1;

        foreach (var rawLabel in labels)
        {
            string label = rawLabel.Trim();

            var fields = _extractor.Extract(label);

            // Government warning validation
            bool warningMatch = GovernmentWarningValidator.IsExactMatch(label, out string diff);

            var result = new BatchResult
            {
                LabelName = fields.BrandName ?? $"Label {index}",
                ResultText =
                    $"Brand: {fields.BrandName ?? "Not found"}\n" +
                    $"ABV: {fields.ABV ?? "Not found"}\n" +
                    $"Net Contents: {fields.NetContents ?? "Not found"}\n" +
                    $"Class/Type: {fields.ClassType ?? "Not found"}\n\n" +
                    (warningMatch
                        ? "Warning: ✔ Exact Match"
                        : $"Warning: ❌ Mismatch\n{diff}")
            };

            BatchResults.Add(result);
            index++;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

public class BatchResult
{
    public string LabelName { get; set; }
    public string ResultText { get; set; }
}
