using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartGreenhouse {
    public partial class Settings : Form {

        private Greenhouse greenhouseWindow;
        public Settings(Greenhouse greenhouseWindow) {
            InitializeComponent();
            this.greenhouseWindow = greenhouseWindow;
            numericLightsThreshold.Value = greenhouseWindow.LightsThreshold;
            numericTemperatureThreshold.Value = greenhouseWindow.TemperatureThreshold;
            numericWateringThreshold.Value = greenhouseWindow.HumidityThreshold;
        }
        private void numericWateringThreshold_ValueChanged(object sender, EventArgs e) {
            greenhouseWindow.HumidityThreshold = (int)numericWateringThreshold.Value;
            greenhouseWindow.reloadHumidityPicture();
        }
        private void numericTemperatureThreshold_ValueChanged(object sender, EventArgs e) {
            greenhouseWindow.TemperatureThreshold = (int)numericTemperatureThreshold.Value;
            greenhouseWindow.reloadTemperaturePicture();
        }
        private void numericLightsThreshold_ValueChanged(object sender, EventArgs e) {
            greenhouseWindow.LightsThreshold = (int)numericLightsThreshold.Value;
            greenhouseWindow.reloadLightPicture();
        }

    }
}
