using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CalculatorRatedPowerAvailable
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
            this.Load += SplashForm_Load;
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            progressBar1.MarqueeAnimationSpeed = 1;
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 4000000;
            progressBar1.Step = 1;
            for (int i = 0; i < 4000000; i++)
            {
                progressBar1.PerformStep();
            }
        }
    }
}
