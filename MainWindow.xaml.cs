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

namespace WPF_DZ1
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

        private void Button_Encrypt_Click(object sender, RoutedEventArgs e)
        {
            string originalText = tbOrig.Text;
            string key = "Key";
            string encryptedText = VigenereCipherEncrypt(originalText, key);
            tbCrypt.Text = encryptedText;
        }
        private string VigenereCipherEncrypt(string text, string key)
        {
            string result = "";
            int keyIndex = 0;
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char keyChar = key[keyIndex % key.Length];
                    int shift = char.IsUpper(keyChar) ? char.ToUpper(c) - 'A' : char.ToLower(c) - 'a';
                    char encryptedChar = (char)(shift + keyChar);
                    result += encryptedChar;
                    keyIndex++;
                }
                else
                    result += c;
            }
            return result;
        }

        private void Button_Calc_Click(object sender, RoutedEventArgs e)
        {

            double x;
            double precision;

            if (Double.TryParse(tbX.Text, out x) &&
                Double.TryParse(tbPrecision.Text, out precision))
                MessageBox.Show(CalculateSeries(x, precision)); 
            else
                MessageBox.Show("Некорректные данные");
        }
        private string CalculateSeries(double x, double precision)
        {
            double sum = x;
            double term = x;
            int n = 1;

            while (true)
            {
                double nextTerm = x / (n + 1);
                if (Math.Abs(nextTerm - term) < precision)
                {
                    break;
                }
                sum += nextTerm;
                term = nextTerm;
                n++;

            }

            return $"sum = {sum}, num of steps = {n}";
        }

        private void Button_Count_Click(object sender, RoutedEventArgs e)
        {
            int countA = tbText.Text.Count(c => c == 'а');
            MessageBox.Show( $"Букв а в строке {countA}");
        }
    }
}