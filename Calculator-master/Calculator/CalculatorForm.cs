using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        Calculator calc;
        public CalculatorForm()
        {
            InitializeComponent();
            calc = new Calculator();
            calc.didUpdateValue += CalculatorDidUpdateValue;
            calc.InputError += CalculatorError;
            calc.ComputationError += CalculatorError;
            calc.Clear();
        }

        private void CalculatorError(Calculator sender, string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CalculatorDidUpdateValue(Calculator sender, double value, int precision)
        {
            lb_Digit.Text = (value / Math.Pow(value, precision)).ToString();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int digit = -1;

            if (int.TryParse(button.Text, out digit))
            {
                calc.AddDigit(digit);
            }
            else
            {    
                switch (button.Tag)
                {
                    case "Add":
                        calc.ProcessBinOp(CalculatorOperations.Add);
                        break;
                    case "Sub":
                        calc.ProcessBinOp(CalculatorOperations.Sub);
                        break;
                    case "Mul":
                        calc.ProcessBinOp(CalculatorOperations.Mul);
                        break;
                    case "Div":
                        calc.ProcessBinOp(CalculatorOperations.Div);
                        break;
                    case "Eq":
                        calc.ProcessBinOp(CalculatorOperations.Eq);
                        break;
                    case "Invert":
                        calc.ProcessUnOp(CalculatorUnOperations.Invert);
                        break;
                    case "Point":
                        calc.AddPoint();
                        break;
                    case "Reciprocal":
                        calc.ProcessUnOp(CalculatorUnOperations.Reciprocal);
                        break;
                    case "CE":
                        calc.Clear();
                        break;
                    case "C":
                        calc.ClearAll();
                        break;
                    case "Percent":
                        calc.ProcessBinOp(CalculatorOperations.Percent);
                        break;
                    case "Sqr":
                        calc.ProcessUnOp(CalculatorUnOperations.Sqr);
                        break;
                    case "Sqrt":
                        calc.ProcessUnOp(CalculatorUnOperations.Sqrt);
                        break;
                    case "Backspace":
                        calc.ProcessUnOp(CalculatorUnOperations.Backspace);
                        break;
                }
            }

        }
    }
}
