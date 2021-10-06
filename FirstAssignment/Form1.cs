using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstAssignment
{
    public partial class Form1 : Form
    {
        //the logic should be done in the more simple way, but it already took me a while 
        //to debug and make it work. I included a scenario where we would have multiple characters that 
        //would show same number of times. The only thing left to do is to make sure that
        //solution would check for lowercase characters only. 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<Result> result = new List<Result>(); 
            string sentence = textBox1.Text;
            sentence = string.Join("", sentence.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
            int max = 1;
            char c = ' ';
            for (int i = 0; i < sentence.Length; i++)
            {
                int count = 1;
                for (int j = 0; j < sentence.Length; j++)
                {
                    if (sentence[i] == sentence[j] && i != j)
                    {
                        count++;
                    }
                }
                if (count >= max) 
                {
                    if (result.Count != 0)
                    {
                        if (count > max)
                        {
                            result = new List<Result>();
                            max = count;
                            c = sentence[i];
                            result.Add(new Result(c, max));
                        }
                        else if (count == max)
                        {
                            max = count;
                            c = sentence[i];
                            result.Add(new Result(c, max));
                        }
                    }
                    else
                    {
                        result = new List<Result>();
                        max = count;
                        c = sentence[i];
                        result.Add(new Result(c, max));
                    }
                }
            }

            //this should be done differently, with already having the list with unique values in the first place,
            //but I already spent a lot of time on this assignment that I just did this as a quick fix

            var uniqueList = result.GroupBy(x => x.Character).Select(y => y.First());

            foreach (var res in uniqueList)
            {
                resultLabel.Text += res.Character + ": " + res.Count.ToString() + Environment.NewLine;
            }
        }
    }
}
