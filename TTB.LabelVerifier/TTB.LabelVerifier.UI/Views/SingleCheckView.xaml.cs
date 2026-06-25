using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TTB.LabelVerifier.UI.ViewModels;

namespace TTB.LabelVerifier.UI.Views
{
    /// <summary>
    /// Interaction logic for SingleCheckView.xaml
    /// </summary>
    public partial class SingleCheckView : UserControl
    {
        public SingleCheckView()
        {
            InitializeComponent();
            DataContext = new SingleCheckViewModel();
        }
    }
}
