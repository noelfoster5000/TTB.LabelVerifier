using System.Windows.Controls;
using TTB.LabelVerifier.UI.ViewModels;

namespace TTB.LabelVerifier.UI.Views
{
    public partial class BatchCheckView : UserControl
    {
        public BatchCheckView()
        {
            InitializeComponent();
            DataContext = new BatchCheckViewModel();
        }
    }
}
