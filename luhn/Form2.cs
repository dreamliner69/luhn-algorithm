using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luhn
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            int xSum = 0, ySum = 0;
            string code = maskedTextBox1.Text;

            for (int i = 0; i < code.Length; i += 2)
            {
                if (Int16.Parse(code[i].ToString()) * 2 > 9)
                {
                    xSum += (Int16.Parse(code[i].ToString()) * 2) % 10 + (Int16.Parse(code[i].ToString()) * 2) / 10;
                }
                else
                {
                    xSum += Int16.Parse(code[i].ToString()) * 2;
                }
            }

            for (int i = 1; i < code.Length - 1; i += 2)
            {
                ySum += Int16.Parse(code[i].ToString());
            }
            int controlDigit;

            if ((xSum + ySum) % 10 == 0)
            {
                controlDigit = 0;
            }
            else
            {
                controlDigit = (((xSum + ySum) / 10 + 1) * 10) - (xSum + ySum);
            }

            label1.Text = Int16.Parse(code[15].ToString()) == controlDigit ? "Kart Geçerli" : "Kart Geçersiz";

            
        }

        
    }
}
