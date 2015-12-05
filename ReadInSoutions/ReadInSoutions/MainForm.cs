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
        }

        private void button1_Click(object sender, EventArgs e)
        {    
            functions f = new functions();
            int grade = f.addSubmission(uxJson.Lines[0].Substring(1, uxJson.Lines[0].Length - 2));
            MessageBox.Show("Successfully graded. The grade recieved was " + grade);
        }
    }
}
