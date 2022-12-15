using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResMart
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }
        int startingValue = 15;
        private void timer1_Tick(object sender, EventArgs e)
        {
            NewMethod();
            startingValue += 1;
            loadingBar.Value = startingValue;
            if (loadingBar.Value == 100)
            {
                timer1.Stop();
                loadingBar.Value = 0;
                Login log = new Login();
                log.Show();
                this.Hide();
            }
        }

        private void NewMethod()
        {
            Trace.WriteLine(startingValue);
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            Trace.WriteLine($"Loading Screen: {loadingBar.Value}");
            timer1.Start();
            

        }
    }
}
