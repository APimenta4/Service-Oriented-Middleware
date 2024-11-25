using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lighting {
    public partial class LightingForm : Form {

        public LightingForm() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            state.Text = "OFF";
        }
    }
}
