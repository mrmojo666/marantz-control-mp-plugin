using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaPortal.Configuration;


namespace marantz_control_mp_plugin
{
    public partial class MarantzSettingsForm : Form
    {
        public MarantzSettingsForm _config;

        public MarantzSettingsForm()
        {
            //_config = new MarantzSettingsForm();

            


            InitializeComponent();

            try
            {
                ReadConfig();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error while reading configuration from MediaPortal.xml" + exp.ToString());
            }

        }

        private void SetDefault()
        {
            textAddress.Text = "0.0.0.0";
            textPort.Text = "23";
            textTelnelCommand.Text = "";

        }
        private void ReadConfig()
        {
            try
            {
                using (MediaPortal.Profile.Settings reader = new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, "MediaPortal.xml")))
                {
                    textAddress.Text = reader.GetValueAsString("MarantzControl", "Address", "0.0.0.0");
                    textPort.Text = reader.GetValueAsString("MarantzControl", "Port", "23");
                    textTelnelCommand.Text = reader.GetValueAsString("MarantzControl", "TelnetCommand", "");

                }
            }
            catch (Exception ex)
            {
                //Log.Error("CecRemote: Configuration read failed, using defaults! {0}", ex.ToString());
                SetDefault();
            }
        }
        private void WriteConfig()
        {
            try
            {
                using (MediaPortal.Profile.Settings writer = new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, "MediaPortal.xml")))
                {
                    writer.SetValue("MarantzControl", "Address",textAddress.Text);
                    writer.SetValue("MarantzControl", "Port", textPort.Text);
                    writer.SetValue("MarantzControl", "TelnetCommand", textTelnelCommand.Text);

                }
            }
            catch (Exception ex)
            {
                //Log.Error("CecRemote: Configuration read failed, using defaults! {0}", ex.ToString());
                throw;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            WriteConfig();
            this.Close();
        }
    }

    
    
}
