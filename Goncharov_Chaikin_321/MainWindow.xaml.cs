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

namespace Goncharov_Chaikin_321
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            double x;
            double b; if (shRadioButton.IsChecked == true || x2RadioButton.IsChecked == true || exRadioButton.IsChecked == true)
            {
                if (Double.TryParse(xTextBox.Text, out x) && Double.TryParse(xTextBox2.Text, out b))
                {
                    double result = 0;
                    if (shRadioButton.IsChecked == true)
                    {
                        double fx = Math.Sinh(x); result = Calculate(x, b, fx);
                    }
                    else if (x2RadioButton.IsChecked == true)
                    {
                        double fx = Math.Pow(x, 2);
                        result = Calculate(x, b, fx);
                    }
                    else if (exRadioButton.IsChecked == true)
                    {
                        double fx = Math.Exp(x); result = Calculate(x, b, fx);
                    }
                    resultTextBox.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Please enter a valid number for x or b.");
                }
            }
            else
            {
                MessageBox.Show("Please enter an argument.");
            }
        }
        private double Calculate(double x, double b, double fx)
        {
            double result;
            if (x * b > 0.5 && x * b < 10)
            {
                result = Math.Exp(fx - Math.Abs(b));
            }
            else if (x * b > 0.1 && x * b < 0.5)
            {
                result = Math.Sqrt(Math.Abs(fx + b));
            }
            else
            {
                result = 2 * Math.Pow(fx, 2);
            }
            return result;
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            xTextBox.Text = "";
            xTextBox2.Text = ""; resultTextBox.Text = "";
            shRadioButton.IsChecked = false; x2RadioButton.IsChecked = false;
            exRadioButton.IsChecked = false;
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo); if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}

