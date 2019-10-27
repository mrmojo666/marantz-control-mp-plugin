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
using MediaPortal.GUI.Library;
using MediaPortal.Dialogs;



namespace marantz_control_mp_plugin
{
    public partial class MarantzSettingsForm : Form
    {
        public MarantzConfig _config;

        public MarantzSettingsForm()
        {


            _config = new MarantzConfig();


            InitializeComponent();

            try
            {
               _config.ReadConfig();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error while reading configuration from MediaPortal.xml" + exp.ToString());
            }


            textAddress.Text = _config.Address;
            textPort.Text = _config.Port;
            textTelnelCommand.Text = _config.TelnetCommand;

        }

        

        
        
        

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _config.Address = textAddress.Text ;
            _config.Port = textPort.Text;
            _config.TelnetCommand = textTelnelCommand.Text;

            _config.WriteConfig();
            this.Close();
        }
    }

    
    
}
