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
        private List<LengthEnglish> _units;

        public MainWindow()
        {
            InitializeComponent();

            LoadConversionUnits();

            //
            // populate the combo boxes with the units
            //
            initialUnits.ItemsSource = _units;
            convertedUnits.ItemsSource = _units;
        }

        /// <summary>
        /// calculate the conversion
        /// </summary>
        /// <param name="sender">Convert button</param>
        /// <param name="e"></param>
        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            double initialDimension = double.Parse(inputDimension.Text);

            double conversionFactorDenominator = double.Parse(convertedUnits.SelectedValue.ToString());
            double conversionFactorNumerator = double.Parse(initialUnits.SelectedValue.ToString());
            double conversionFactor = conversionFactorNumerator / conversionFactorDenominator;

            convertedDimension.Text = (conversionFactor * initialDimension).ToString();

        }

        /// <summary>
        /// load all of the unit info into a list
        /// </summary>
        private void LoadConversionUnits()
        {
            _units = new List<LengthEnglish>()
            {
              new LengthEnglish {UnitName="Inches", UnitConversionReference=true, UnitConversionFactor=1},
              new LengthEnglish {UnitName="Feet", UnitConversionReference=false, UnitConversionFactor=12},
              new LengthEnglish {UnitName="Yards", UnitConversionReference=false, UnitConversionFactor=36},
              new LengthEnglish {UnitName="Miles", UnitConversionReference=false, UnitConversionFactor=63360}
            };
        }
    }
}
