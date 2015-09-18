using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
        /// load all of the unit info from a text file into a list
        /// </summary>
        private void LoadConversionUnits()
        {
            //
            // set a constant equal to the name of the text file with the unit info
            //
            const string textfile = "english_units.txt";

            string line;
            string[] unitInfoFromFile;
            
            //
            // instantiate a new list of units
            //
            _units = new List<LengthEnglish>();

            //
            // use a stream reader object to access the text file
            //
            using (StreamReader sr = new StreamReader(textfile))
            {
                //
                // read one full line
                //
                while ((line = sr.ReadLine()) != null)
                {
                    //
                    // split the line into an array of strings
                    //
                    unitInfoFromFile = line.Split(',');

                    //
                    // instantiate a new unitInfo objec
                    //
                    LengthEnglish unitInfo = new LengthEnglish();

                    //
                    // populate the unitInfo properties with the array elements
                    // parsing the appropriate properties
                    //
                    unitInfo.UnitName = unitInfoFromFile[0];
                    unitInfo.UnitConversionReference = bool.Parse(unitInfoFromFile[1]);
                    unitInfo.UnitConversionFactor = double.Parse(unitInfoFromFile[2]);

                    //
                    // add the new unitInfo objext to the list
                    //
                    _units.Add(unitInfo);
                }
            }

        }
    }
}
