using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadInSoutions
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            uxGrade.Enabled = false;
            uxMode.SelectedIndex = 0;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (uxMode.SelectedIndex == 0)
            {
                if (uxJson.Lines == null || uxAssnId.Text == String.Empty || uxStud.Text == String.Empty)
                {
                    MessageBox.Show("Fill out all boxes");
                }
                else
                {
                    int grade = -1;
                    functions f = new functions();
                    if (uxJson.Lines[0].Substring(1, 1) == "[" || uxJson.Lines[0].Substring(uxJson.Lines[0].Length - 1, 1) == "]")
                    {
                        grade = f.addSubmission(uxJson.Lines[0].Substring(1, uxJson.Lines[0].Length - 2), Convert.ToInt32(uxAssnId.Text), Convert.ToInt32(uxStud.Text));
                    }
                    else
                    {
                        grade = f.addSubmission(uxJson.Lines[0], Convert.ToInt32(uxAssnId.Text), Convert.ToInt32(uxStud.Text));
                    }
                    MessageBox.Show("Successfully graded. The grade recieved was " + grade);
                }
            }
            else if (uxMode.SelectedIndex == 1)
            {
                if (uxJson.Lines[0] == null || uxAssnId.Text == String.Empty || uxGrade.Text == String.Empty)
                {
                    MessageBox.Show("Fill out all boxes");
                }
                else
                {
                    functions f = new functions();
                    f.addSolutions(uxJson.Lines[0], Convert.ToInt32(uxAssnId.Text), Convert.ToInt32(uxGrade.Text));
                    MessageBox.Show("Successfully added solutions");
                }
            }

        }

        private void uxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uxMode.SelectedIndex == 0)
            {
                uxGrade.Enabled = false;
                uxStud.Enabled = true;
                uxGrade.Text = "";
            }
            else if (uxMode.SelectedIndex == 1)
            {
                uxGrade.Enabled = true;
                uxStud.Enabled = false;
            }

        }
    }
}
