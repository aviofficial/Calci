using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Calculator.Win
{
    public partial class Help : Form
    {
        private TextBox txtBoxMain;
        String _helpFile = "Calculator.Win.HelpForm.txt";
        public Help()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Help_Load);
        }

        public void Help_Load(object sender, EventArgs e) {
            
            //text Box Main
            this.txtBoxMain = new TextBox();
            this.txtBoxMain.Dock = DockStyle.Fill;
            this.txtBoxMain.Multiline = true;
            this.txtBoxMain.ReadOnly = true;
            this.txtBoxMain.TabStop = false;
            this.txtBoxMain.ScrollBars = ScrollBars.Vertical;
            this.txtBoxMain.Font = new Font("Arial", 12);
            //text loading

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(_helpFile))
            using (StreamReader reader = new StreamReader(stream))
            { 
                this.txtBoxMain.Text=reader.ReadToEnd();
            }
            //Help Form
            this.ClientSize = new Size(700, 700);
            this.Controls.Add(this.txtBoxMain);
            this.Location = new Point(10,10);
            this.ResumeLayout();
        }
    }
}
