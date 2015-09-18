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

namespace Projects.BasicConverter.Solution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            double initialDimension = double.Parse(inputDimension.Text);

            double conversionFactorDenominator = double.Parse(convertedUnits.SelectedValue.ToString());
            double conversionFactorNumerator = double.Parse(initialUnits.SelectedValue.ToString());
            double conversionFactor = conversionFactorNumerator / conversionFactorDenominator;

            convertedDimension.Text = (conversionFactor * initialDimension).ToString();

        }
    }
}
