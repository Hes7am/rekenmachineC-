using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace REKEN_Machine_2e_versie
{
    public partial class MainWindow : Window
    {
        double eerst;
        double tweede;
        char oper;
        bool hasOperator = false;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            TxtResult.Text += btn.Content.ToString();
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text = "";
            hasOperator = false;
        }

        private void verwijder_Click(object sender, RoutedEventArgs e)
        {
            if (TxtResult.Text.Length > 0)
            {
                TxtResult.Text = TxtResult.Text.Substring(0, TxtResult.Text.Length - 1);
            }
        }

        private void comma_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text += ".";
        }

        private void Links_Click(object sender, RoutedEventArgs e)
        {
            // Add a left parenthesis and reset the operator flag
            TxtResult.Text += "(";
            hasOperator = false;
        }

        private void Rechts_Click(object sender, RoutedEventArgs e)
        {
            // Add a right parenthesis and reset the operator flag
            TxtResult.Text += ")";
            hasOperator = false;
        }

        private void Delen_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text += " / ";
            hasOperator = true;
        }

        private void Vermenig_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text += " * ";
            hasOperator = true;
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            if (TxtResult.Text == "" || (hasOperator && TxtResult.Text.EndsWith(" ")))
            {
                TxtResult.Text += "-";
            }
            else
            {
                TxtResult.Text += " - ";
                hasOperator = true;
            }
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text += " + ";
            hasOperator = true;
        }

        private void Gelijk_aan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string expression = TxtResult.Text;
                DataTable table = new DataTable();
                double result = Convert.ToDouble(table.Compute(expression, String.Empty));


                if (expression.Contains("/ 0"))
                {
                    TxtResult.Text = "Cannot divide by zero.";
                    return;
                }
                if (result != 0)
                {
                    TxtResult.Text = result.ToString();
                }
                hasOperator = false; // Reset for next calculation
            }

            catch (Exception)
            {
                TxtResult.Text = "Please enter a valid equation.";
            }
        }
    }
}

