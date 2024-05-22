using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScientificCalculator
{
    public partial class Form1 : Form
    {
        private Button[] buttonNumeric = new Button[10];
        private Button[] buttonOperator = new Button[6];
        private Button[] buttonOperator2 = new Button[3];
        private Button[] buttonOperator3 = new Button[3];
        private Button[] buttonOperator4 = new Button[7];
        private Button[] buttonOperator5 = new Button[5];
        private Button buttonBackspace;
        private Button ButtonC;
        private Button ButtonSign;
        private Button ButtonDecimal;
        private Button ButtonZero;
        private Button buttonE;
        private Button buttonPi;

        public Form1()
        {
            InitializeOperatorButtons();
            InitializeComponent();
            InitializeNumericButtons();
            InitializeBackspaceButton();
            InitializeButtonC();
            InitializeButtonSign();
            InitializeButtonDecimal();
            InitializeButtonZero();
            InitializeEButton();
            InitializePiButton();
        }

        private void InitializeNumericButtons()
        {
            int index = 0;
            for (int i = 1; i < buttonNumeric.Length; i++)
            {
                this.buttonNumeric[i] = new Button();
                this.buttonNumeric[i].Location = new Point(70 + ((i - 1) % 3) * 50, 337 - ((i - 1) / 3) * 50);
                if (index == 0)
                {
                    index += 2;
                }
                index++;
                this.buttonNumeric[i].Name = "button" + (i + 1);
                this.buttonNumeric[i].Size = new Size(35, 35);
                this.buttonNumeric[i].TabIndex = i + 1;
                this.buttonNumeric[i].Text = "" + (i);
                this.buttonNumeric[i].UseVisualStyleBackColor = true;
                this.buttonNumeric[i].Click += new EventHandler(this.buttonDigit_Click);
                this.Controls.Add(this.buttonNumeric[i]);
            }
        }
        private void InitializeEButton()
        {
            buttonE = new Button();
            buttonE.Location = new Point(120, 92);
            buttonE.Name = "buttonE";
            buttonE.Size = new Size(35, 35);
            buttonE.TabIndex = 18;
            buttonE.Text = "e";
            buttonE.UseVisualStyleBackColor = true;
            buttonE.Click += new EventHandler(this.buttonE_Click);
            this.Controls.Add(buttonE);
        }

        private void InitializePiButton()
        {
            buttonPi = new Button();
            buttonPi.Location = new Point(70, 92);
            buttonPi.Name = "buttonPi";
            buttonPi.Size = new Size(35, 35);
            buttonPi.TabIndex = 19;
            buttonPi.Text = "π";
            buttonPi.UseVisualStyleBackColor = true;
            buttonPi.Click += new EventHandler(this.buttonPi_Click);
            this.Controls.Add(buttonPi);
        }

        private void InitializeOperatorButtons()
        {
            string[] operatorSymbols = { "mod", "/", "*", "-", "+", "=" };
            for (int i = 0; i < buttonOperator.Length; i++)
            {
                this.buttonOperator[i] = new Button();
                this.buttonOperator[i].Location = new Point(330, 216 + i * 76);
                this.buttonOperator[i].Name = "button" + (i + 11);
                this.buttonOperator[i].Size = new Size(54, 54);
                this.buttonOperator[i].TabIndex = i + 11;
                this.buttonOperator[i].Text = operatorSymbols[i];
                this.buttonOperator[i].UseVisualStyleBackColor = true;
                this.buttonOperator[i].Click += new EventHandler(this.buttonOperator_Click);
                this.Controls.Add(this.buttonOperator[i]);
            }

            string[] operatorSymbols2 = { "1/x", "|x|", "exp" };
            for (int i = 0; i < operatorSymbols2.Length; i++)
            {
                this.buttonOperator2[i] = new Button();
                this.buttonOperator2[i].Location = new Point(105 + i * 75, 215);
                this.buttonOperator2[i].Name = "button" + (i + 11 + operatorSymbols.Length);
                this.buttonOperator2[i].Size = new Size(53, 53);
                this.buttonOperator2[i].TabIndex = i + 11;
                this.buttonOperator2[i].Text = operatorSymbols2[i];
                this.buttonOperator2[i].UseVisualStyleBackColor = true;
                this.buttonOperator2[i].Click += new EventHandler(this.buttonOperator_Click);
                this.Controls.Add(this.buttonOperator2[i]);
            }

            string[] operatorSymbols3 = { "log", "ln", "n!" };
            for (int i = 0; i < operatorSymbols3.Length; i++)
            {
                this.buttonOperator3[i] = new Button();
                this.buttonOperator3[i].Location = new Point(105 + i * 75, 290);
                this.buttonOperator3[i].Name = "button" + (i + 11 + operatorSymbols.Length);
                this.buttonOperator3[i].Size = new Size(53, 53);
                this.buttonOperator3[i].TabIndex = i + 11;
                this.buttonOperator3[i].Text = operatorSymbols3[i];
                this.buttonOperator3[i].UseVisualStyleBackColor = true;
                this.buttonOperator3[i].Click += new EventHandler(this.buttonOperator_Click);
                this.Controls.Add(this.buttonOperator3[i]);
            }

            string[] operatorSymbols4 = { "x^3", "x^2", "sqrt", "cbrt", "10^x", "2^x", "e^x" };
            for (int i = 0; i < operatorSymbols4.Length; i++)
            {
                this.buttonOperator4[i] = new Button();
                this.buttonOperator4[i].Location = new Point(23, 141 + i * 75);
                this.buttonOperator4[i].Name = "button" + (i + 11 + operatorSymbols.Length);
                this.buttonOperator4[i].Size = new Size(57, 57);
                this.buttonOperator4[i].TabIndex = i + 11;
                this.buttonOperator4[i].Text = operatorSymbols4[i];
                this.buttonOperator4[i].UseVisualStyleBackColor = true;
                this.buttonOperator4[i].Click += new EventHandler(this.buttonOperator_Click);
                this.Controls.Add(this.buttonOperator4[i]);
            }

            string[] operatorSymbols5 = { "floor", "sin", "cos", "tan", "cot" };
            for (int i = 0; i < operatorSymbols5.Length; i++)
            {
                this.buttonOperator5[i] = new Button();
                this.buttonOperator5[i].Location = new Point(23 + i * 76, 70);
                this.buttonOperator5[i].Name = "button" + (i + 11 + operatorSymbols.Length);
                this.buttonOperator5[i].Size = new Size(57, 57);
                this.buttonOperator5[i].TabIndex = i + 11;
                this.buttonOperator5[i].Text = operatorSymbols5[i];
                this.buttonOperator5[i].UseVisualStyleBackColor = true;
                this.buttonOperator5[i].Click += new EventHandler(this.buttonOperator_Click);
                this.Controls.Add(this.buttonOperator5[i]);
            }
        }

        private void InitializeBackspaceButton()
        {
            buttonBackspace = new Button();
            buttonBackspace.Location = new Point(220, 92);
            buttonBackspace.Name = "buttonBackspace";
            buttonBackspace.Size = new Size(35, 35);
            buttonBackspace.Text = "<-";
            buttonBackspace.UseVisualStyleBackColor = true;
            buttonBackspace.Click += new EventHandler(this.buttonBackspace_Click);
            this.Controls.Add(buttonBackspace);
        }

        private void InitializeButtonC()
        {
            ButtonC = new Button();
            ButtonC.Location = new Point(170, 92);
            ButtonC.Name = "ButtonC";
            ButtonC.Size = new Size(35, 35);
            ButtonC.Text = "C";
            ButtonC.UseVisualStyleBackColor = true;
            ButtonC.Click += new EventHandler(this.button15_Click);
            this.Controls.Add(ButtonC);
        }

        private void InitializeButtonSign()
        {
            ButtonSign = new Button();
            ButtonSign.Location = new Point(70, 387);
            ButtonSign.Name = "ButtonSign";
            ButtonSign.Size = new Size(35, 35);
            ButtonSign.Text = "+/-";
            ButtonSign.UseVisualStyleBackColor = true;
            ButtonSign.Click += new EventHandler(this.buttonSign_Click);
            this.Controls.Add(ButtonSign);
        }

        private void InitializeButtonDecimal()
        {
            ButtonDecimal = new Button();
            ButtonDecimal.Location = new Point(170, 387);
            ButtonDecimal.Name = "ButtonDecimal";
            ButtonDecimal.Size = new Size(35, 35);
            ButtonDecimal.Text = ".";
            ButtonDecimal.UseVisualStyleBackColor = true;
            ButtonDecimal.Click += new EventHandler(this.buttonDigit_Click);
            this.Controls.Add(ButtonDecimal);
        }

        private void InitializeButtonZero()
        {
            ButtonZero = new Button();
            ButtonZero.Location = new Point(120, 387);
            ButtonZero.Name = "ButtonZero";
            ButtonZero.Size = new Size(35, 35);
            ButtonZero.Text = "0";
            ButtonZero.UseVisualStyleBackColor = true;
            ButtonZero.Click += new EventHandler(this.buttonDigit_Click);
            this.Controls.Add(ButtonZero);
        }

        private void buttonDigit_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text == "0" || isOperator)
            {
                textBoxNumber.Text = "";
                isOperator = false;
            }

            if ((sender as Button).Text == ".")
            {
                if (!textBoxNumber.Text.Contains("."))
                {
                    textBoxNumber.Text += ".";
                }
            }
            else
            {
                textBoxNumber.Text += (sender as Button).Text;
            }
        }

        double result = 0;
        bool isOperator = false;
        string prevOperator = "+";
        private double Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }  

            double result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        private void buttonOperator_Click(object sender, EventArgs e)
        {
            switch (prevOperator)
            {
                case "+":
                    result += double.Parse(textBoxNumber.Text);
                    break;
                case "-":
                    result -= double.Parse(textBoxNumber.Text);
                    break;
                case "*":
                    result *= double.Parse(textBoxNumber.Text);
                    break;
                case "/":
                    result /= double.Parse(textBoxNumber.Text);
                    break;
                case "%":
                    double currentValue = double.Parse(textBoxNumber.Text);
                    result = currentValue * 0.01;
                    break;
                case "1/x":
                    result = 1 / double.Parse(textBoxNumber.Text);
                    break;
                case "x^2":
                    result = Math.Pow(double.Parse(textBoxNumber.Text), 2);
                    break;
                case "sqrt":
                    result = Math.Sqrt(double.Parse(textBoxNumber.Text));
                    break;
                case "mod":
                    result %= double.Parse(textBoxNumber.Text);
                    break;
                case "exp":
                    result = Math.Exp(double.Parse(textBoxNumber.Text));
                    break;
                case "|x|":
                    result = Math.Abs(double.Parse(textBoxNumber.Text));
                    break;
                case "n!":
                    int factorialValue = int.Parse(textBoxNumber.Text);
                    result = Factorial(factorialValue);
                    break;
                case "log":
                    result = Math.Log10(double.Parse(textBoxNumber.Text));
                    break;
                case "ln":
                    result = Math.Log(double.Parse(textBoxNumber.Text));
                    break;
                case "cbrt":
                    result = Math.Pow(double.Parse(textBoxNumber.Text), 1.0 / 3.0);
                    break;
                case "10^x":
                    result = Math.Pow(10, double.Parse(textBoxNumber.Text));
                    break;
                case "2^x":
                    result = Math.Pow(2, double.Parse(textBoxNumber.Text));
                    break;
                case "e^x":
                    result = Math.Exp(double.Parse(textBoxNumber.Text));
                    break;
                case "x^3":
                    result = Math.Pow(double.Parse(textBoxNumber.Text), 3);
                    break;
                case "sin":
                    result = Math.Sin(double.Parse(textBoxNumber.Text));
                    break;
                case "cos":
                    result = Math.Cos(double.Parse(textBoxNumber.Text));
                    break;
                case "tan":
                    result = Math.Tan(double.Parse(textBoxNumber.Text));
                    break;
                case "cot":
                    result = 1 / Math.Tan(double.Parse(textBoxNumber.Text));
                    break;
                case "floor":
                    result = Math.Floor(double.Parse(textBoxNumber.Text));
                    break;
                default:
                    break;
            }

            textBoxNumber.Text = result.ToString();
            isOperator = true;
            prevOperator = (sender as Button).Text;
        }

        private void button15_Click(object sender, EventArgs e) //C
        {
            textBoxNumber.Text = "0";
            result = 0;
            isOperator = false;
            prevOperator = "+";
        }

        private void buttonSign_Click(object sender, EventArgs e) //+/-
        {
            if (textBoxNumber.Text != "")
            {
                if (isOperator)
                {
                    result = -result;
                    textBoxNumber.Text = result.ToString();
                }
                else
                {
                    double currentValue = double.Parse(textBoxNumber.Text);
                    textBoxNumber.Text = (-currentValue).ToString();
                }
            }
        }

        private void buttonBackspace_Click(object sender, EventArgs e) //<-
        {
            int index = textBoxNumber.Text.Length;
            index--;
            textBoxNumber.Text = textBoxNumber.Text.Remove(index);
            if (textBoxNumber.Text == "")
            {
                textBoxNumber.Text = "0";
            }
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            textBoxNumber.Text = Math.E.ToString();
        }

        private void buttonPi_Click(object sender, EventArgs e)
        {
            textBoxNumber.Text = Math.PI.ToString();
        }
    }
}
