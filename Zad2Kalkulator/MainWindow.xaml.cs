using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zad2Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double currValue = 0;
        private double prevValue = 0;
        private string currOperation = "";
        private bool isNewOperation = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumericButton_Click(object sender, RoutedEventArgs e)
        {
            if (isNewOperation)
            {
                Display.Text = "";
                isNewOperation = false;
            }

            var button = sender as Button;
            Display.Text += button.Content.ToString();
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Display.Text.Contains("."))
            {
                Display.Text += ",";
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            currOperation = button.Content.ToString();
            prevValue = double.Parse(Display.Text);
            PreviousOperation.Text = $"{prevValue} {currOperation}";
            isNewOperation = true;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            currValue = double.Parse(Display.Text);
            double result = 0;

            switch (currOperation)
            {
                case "+":
                    result = prevValue + currValue;
                    break;
                case "-":
                    result = prevValue - currValue;
                    break;
                case "*":
                    result = prevValue * currValue;
                    break;
                case "/":
                    result = prevValue / currValue;
                    break;
                case "^":
                    result = Math.Pow(prevValue, currValue);
                    break;
                case "%":
                    result = prevValue % currValue;
                    break;
            }

            Display.Text = result.ToString();
            PreviousOperation.Text = $"{prevValue} {currOperation} {currValue} = {result}";
            isNewOperation = true;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            PreviousOperation.Text = "";
            currValue = 0;
            prevValue = 0;
            currOperation = "";
            isNewOperation = true;
        }

        private void UnaryOperationButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            double value = double.Parse(Display.Text);
            double result = 0;

            switch (button.Content.ToString())
            {
                case "√":
                    result = Math.Sqrt(value);
                    break;
                case "1/x":
                    result = 1 / value;
                    break;
                case "!":
                    result = Factorial((int)value);
                    break;
                case "log":
                    result = Math.Log10(value);
                    break;
                case "ln":
                    result = Math.Log(value);
                    break;
                case "⌊x⌋":
                    result = Math.Floor(value);
                    break;
                case "⌈x⌉":
                    result = Math.Ceiling(value);
                    break;
            }

            Display.Text = result.ToString();
            PreviousOperation.Text = $"{button.Content}({value}) = {result}";
            isNewOperation = true;
        }

        private double Factorial(int n)
        {
            if (n < 0) return double.NaN;
            if (n == 0) return 1;
            double result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
