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

namespace MyCalculator
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

        string newResultStr;
        bool isDecimal = false;
        bool isExponent = false;
        bool happeningOperation = false;
        string secondNuber = string.Empty;
        string baseNumber = string.Empty; // üssü veya kök alırken yazdığımız ilk sayıyı hatırlaması için

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {//sonuçtaki yazıyı al, yanına yeni sayı ekle
            if (calculatedResult.Content.ToString() == "0")
            {
                newResultStr = $"{(sender as Button).Content.ToString()}";
                calculatedResult.Content = $"{newResultStr}";
            }
            else
            {
                newResultStr = $"{calculatedResult.Content.ToString()}{(sender as Button).Content.ToString()}";
                calculatedResult.Content = newResultStr;
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            calculatedResult.Content = "0";
            isDecimal = false;
            isExponent = false;
            baseNumber = string.Empty;
        }

        private void decimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (isDecimal == false)
            {
                isDecimal = true;
                calculatedResult.Content = $"{calculatedResult.Content},";
            }
        }

        private void exponentButton_Click(object sender, RoutedEventArgs e)
        {//üssü alma işlemi
            isExponent = true;
            isDecimal = false;
            baseNumber = calculatedResult.Content.ToString();

        }

        private void operationButton_Click(object sender, RoutedEventArgs e)
        {
            /*calculatedResult.Content = $"{calculatedResult.Content} {(sender as Button).Content} {secondNumber}";
             if happeningOperation = true;
            calculatedResult.Content += secondNumber;
            
            switch((sender as Button).Content.ToString())
            {
                case "+": //toplama işlemi
                    if (happeningOperation = false)
                    {
                        calculatedResult.Content = $"{calculatedResult.Content} {(sender as Button).Content} {secondNumber}";
                    }
                    else
                    {
                        calculatedResult.Content += secondNumber;
                        calculatedResult.Content = $"{calculatedResult.Content} {(sender as Button).Content} {secondNumber}";
                    }
                    break;
            }*/


        }
    }
}
