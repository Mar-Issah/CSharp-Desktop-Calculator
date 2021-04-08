using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        Double value = 0;
        string operation = "";
        bool operationPressed = false;  //Did you pressed any arithmetic operators; you want to be able to reset the numbers as you press an operators

       
        public CalculatorForm()
        {
            InitializeComponent();              //call the method in form1.designer class which  will initialize all the widgets
        }

        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtDisplay.Text);
        }

        private void ButtonNum_Click(object btn, EventArgs e)
        {
            if (txtDisplay.Text == "0" || operationPressed) //if its display zero or if and operator is pressed clear and display the number
            {
                txtDisplay.Clear();
            }
            operationPressed = false;   //switch to false here
            txtDisplay.Text += (btn as Button).Text;
            
            //txtDisplay = txtDisplay + (btn as Button).Text       it will the first num and wait to receive another input          
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {    
                txtDisplay.Text = "0";         
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            if(txtDisplay.Text.Length > 0)
            {

               if (! double.TryParse(txtDisplay.Text[txtDisplay.Text.Length - 1].ToString(), out double result))
                    //basically trying to see if it can be backspaced, if it returns a false, then operation = ""
                    //out double result, A return value indicates whether the conversion succeeded or failed.
               {
                    operation = "";
               }

               txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
        }

        private void ButtonOp_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            value = double.Parse(txtDisplay.Text);
            operationPressed = true;
            equation.Text += value + " " + operation;       
        }
  
        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            equation.Text = "";
            switch (operation)
            {
                case "+":
                    txtDisplay.Text = (value + double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (value - double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (value * double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    try
                    {
                        txtDisplay.Text = (value / double.Parse(txtDisplay.Text)).ToString();
                    }
                    catch (DivideByZeroException)
                    {

                        txtDisplay.Text = "You cannot divide by Zero";
                    }                 
                    break;
                default:
                    break;
            }
        }


        private void ButtonDot_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += (sender as Button).Text;
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}