using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaPortal.GUI.Library;
using MediaPortal.Dialogs;
using MediaPortal.InputDevices;
using PrimS.Telnet;
using Action = MediaPortal.GUI.Library.Action;


namespace marantz_control_mp_plugin
{
    public class MarantzControl : IPlugin , ISetupForm 
    {

        #region ISetupForm Members

        // Returns the name of the plugin which is shown in the plugin menu
        public string PluginName()
        {
            return "MarantzControl";
        }

        // Returns the description of the plugin is shown in the plugin menu
        public string Description()
        {
            return "MarantzControl";
        }

        // Returns the author of the plugin which is shown in the plugin menu
        public string Author()
        {
            return "mrmojo666";
        }

        // show the setup dialog
        public void ShowPlugin()
        {
            MarantzSettingsForm settings = new MarantzSettingsForm();
            settings.ShowDialog();

        }

        // Indicates whether plugin can be enabled/disabled
        public bool CanEnable()
        {
            return true;
        }

        // Get Windows-ID
        public int GetWindowId()
        {
            // WindowID of windowplugin belonging to this setup
            // enter your own unique code
            return 0;
        }

        // Indicates if plugin is enabled by default;
        public bool DefaultEnabled()
        {
            return true;
        }

        // indicates if a plugin has it's own setup screen
        public bool HasSetup()
        {
            return true;
        }

        /// <summary>
        /// If the plugin should have it's own button on the main menu of MediaPortal then it
        /// should return true to this method, otherwise if it should not be on home
        /// it should return false
        /// </summary>
        /// <param name="strButtonText">text the button should have</param>
        /// <param name="strButtonImage">image for the button, or empty for default</param>
        /// <param name="strButtonImageFocus">image for the button, or empty for default</param>
        /// <param name="strPictureImage">subpicture for the button or empty for none</param>
        /// <returns>true : plugin needs it's own button on home
        /// false : plugin does not need it's own button on home</returns>

        public bool GetHome(out string strButtonText, out string strButtonImage,
          out string strButtonImageFocus, out string strPictureImage)
        {
            strButtonText = String.Empty;
            strButtonImage = String.Empty;
            strButtonImageFocus = String.Empty;
            strPictureImage = String.Empty;
            return false;
        }

        //With GetID it will be an window-plugin / otherwise a process-plugin
        //Enter the id number here again
        //public override int GetID
        //{
        //    get
        //    {
        //        return -1;
        //    }

        //    set
        //    {
        //    }
        //}

        #endregion

        public MarantzConfig _config;
        

        public void Start()
        {
            Log.Info("Marantzconfig.start(): called");            
            Log.Info("MarantzControl: Version 0.0.1");

            _config = new MarantzConfig();
            _config.ReadConfig();

            






        }

        public void Stop()
        { }







        //public override void OnAction(MediaPortal.GUI.Library.Action action)
        //{



        //    if (action.wID == MediaPortal.GUI.Library.Action.ActionType.ACTION_HOME)
        //    {
        //        using (Client client = new Client(_config.Address, Int32.Parse(_config.Port), new System.Threading.CancellationToken()))
        //        {
        //            if (client.IsConnected)
        //            {

        //                client.WriteLine(_config.TelnetCommand);

        //            }
        //        }

        //        base.OnAction(action);
        //    }
        //}
    }


}