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
using Action = MediaPortal.GUI.Library.Action;



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

            comboBoxAction.Items.Add("");
            foreach (string actiontype in Enum.GetNames(typeof(Action.ActionType)))
            {
                comboBoxAction.Items.Add(actiontype);
            }
          
                
            comboBoxAction.SelectedItem = (string)Enum.GetName(typeof(Action.ActionType), _config.Action);

            

        }

        

        
        
        

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            _config.Address = textAddress.Text ;
            _config.Port = textPort.Text;
            _config.TelnetCommand = textTelnelCommand.Text;
            _config.Action = (int)Enum.Parse(typeof(Action.ActionType), comboBoxAction.SelectedItem.ToString());

            _config.WriteConfig();
            this.Close();
        }

        private void ComboBoxAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }

    
    
}
