using System.Windows;
using TTB.LabelVerifier.UI.ViewModels;

namespace TTB.LabelVerifier
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
