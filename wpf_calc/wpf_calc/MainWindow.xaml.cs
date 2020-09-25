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

namespace wpf_calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region members
        private string tmpN1 = string.Empty;
        private string tmpN2 = string.Empty;
        private double tmpSum = double.MinValue;
        private bool operationClicked = false;
        private bool sumClicked = false;
        private char operation = char.MinValue;


        #endregion
        public MainWindow()
        {
            InitializeComponent();
            n1.Click += Button_Clicked;
            n2.Click += Button_Clicked;
            n3.Click += Button_Clicked;
            n4.Click += Button_Clicked;
            n5.Click += Button_Clicked;
            n6.Click += Button_Clicked;
            n7.Click += Button_Clicked;
            n8.Click += Button_Clicked;
            n9.Click += Button_Clicked;
            n0.Click += Button_Clicked;

            add.Click += Button_Clicked;
            dec.Click += Button_Clicked;
            mul.Click += Button_Clicked;
            div.Click += Button_Clicked;
            sum.Click += Button_Clicked;
            clear.Click += Button_Clicked;

        }

        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            var buttonClicked = sender.ToString().Split(':')[1];

            

            string[] numbers = { " _1", " _2", " _3", " _4", " _5", " _6", " _7", " _8", " _9", " _0" };
            string[] operations = { " _+", " _-", " _*", " _/" };

            if (numbers.Contains(buttonClicked))
            {
                if(sumClicked)
                {
                    Ergebnis.Text = string.Empty;
                }
                if (!operationClicked)
                {
                    tmpN1 += buttonClicked[2];
                    Ergebnis.Text = tmpN1;
                }
                if (operationClicked)
                {
                    tmpN2 += buttonClicked[2];
                    Ergebnis.Text = tmpN2;
                }
            }
            if(operations.Contains(buttonClicked))
            {
                operationClicked = true;
                operation = buttonClicked[2];
            }
            if(buttonClicked.Equals(" _="))
            {
                tmpSum = DoTheMathThing(tmpN1, tmpN2, operation);
                Ergebnis.Text = tmpSum.ToString();
                tmpN1 = tmpSum.ToString();
                tmpN2 = string.Empty;
                sumClicked = true;
            }
            if(buttonClicked.Equals(" _C"))
            {
                Ergebnis.Text = string.Empty;
                tmpN1 = string.Empty;
                tmpN2 = string.Empty;
                tmpSum = double.MinValue;
                operationClicked = false;
                sumClicked = false;
                operation = char.MinValue;

            }
        }

        private double DoTheMathThing(string tmpN1, string tmpN2, char operation)
        {
            int n1 = 0;
            int n2 = 0;
            if (!string.IsNullOrEmpty(tmpN1)) n1 = Int32.Parse(tmpN1);
            if (!string.IsNullOrEmpty(tmpN2)) n2 = Int32.Parse(tmpN2);

            double sum = double.MinValue;
            switch (operation)
            {
                case '+':
                    sum = n1 + n2;
                    break;
                case '-':
                    sum = n1 - n2;
                    break;
                case '*':
                    sum = n1 * n2;
                    break;
                case '/':
                    sum = n1 / n2;
                    break;
                default:
                    sum = n1;
                    break;
            }
            return sum;
        }
    }
}
