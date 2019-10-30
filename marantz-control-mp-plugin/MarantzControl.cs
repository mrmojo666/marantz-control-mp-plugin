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
using MediaPortal.Configuration;
using Action = MediaPortal.GUI.Library.Action;



namespace marantz_control_mp_plugin
{
    public class MarantzControl : GUIWindow, ISetupForm 
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
            settings.Show();

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
            return 1696;
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
        public override int GetID
        {
            get
            {
                return 1696;
            }

            set
            {
            }
        }

        #endregion

        private MarantzConfig _config;
        public int result = 0;



        public override bool Init()
        
        {
            Log.Info("Marantzconfig.init(): called");            
            Log.Info("MarantzControl: Version 0.0.1");

            _config = new MarantzConfig();
            

            _config.ReadConfig();
            
            GUIWindowManager.OnNewAction += OnNewAction;

            


            
            return true;





        }

       

        public void  OnNewAction(Action action)
        {
            // Remote Key to open Menu
            if ((action.wID == Action.ActionType.ACTION_HOME) || (action.wID == Action.ActionType.ACTION_SWITCH_HOME))
            {
               
                FireTelnetCommand(_config);
                DialogNotifyTelnet(result);
            }
        }




        private async void FireTelnetCommand(MarantzConfig _config)
        {
            Log.Info("MarantzControl: preparing to send telnet command");

           
            try
            {
                using (Client client = new Client(_config.Address, Int32.Parse(_config.Port), new System.Threading.CancellationToken()))
                {
                    if (client.IsConnected)
                    {

                        await client.WriteLine(_config.TelnetCommand);
                        Log.Info("MarantzControl: Sent Telnet command {0}:{1} {2}", _config.Address, _config.Port, _config.TelnetCommand);
                        result = 0;
                    }
                    else
                    {
                        Log.Error("MarantzControl: Cant't Connect to {0}:{1}", _config.Address, _config.Port);
                        result = 1;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("MarantzControl: Cant't Connect to {0}:{1}", _config.Address, _config.Port);
                Log.Error(ex.Message);
                result = 1;

            }


            
        }


        public void DialogNotifyTelnet(int _result)
        {
            switch (_result)
            { 
                case 0 :
                try
                {

                    var dialogNotify = (GUIDialogNotify)GUIWindowManager.GetWindow((int)Window.WINDOW_DIALOG_NOTIFY);
                    //dialogNotify.Reset();
                    dialogNotify.SetHeading("Telnet Command to Marantz");
                    dialogNotify.SetText("Sent Tenet Command");
                    dialogNotify.DoModal(GUIWindowManager.ActiveWindow);

                    }
                catch (Exception ex)
                {
                    Log.Error("MarantzControl: Error occured during DialogNotifyTelnet()");
                    Log.Error(ex.Message);
                }
                    break;
            
       case 1:
            
                try
                {

                    var dialogNotify = (GUIDialogNotify)GUIWindowManager.GetWindow((int)Window.WINDOW_DIALOG_NOTIFY);
                    //dialogNotify.Reset();
                    dialogNotify.SetHeading("Telnet Command to Marantz");
                    dialogNotify.SetText("error sending telnet command");
                    dialogNotify.DoModal(GUIWindowManager.ActiveWindow);
                   
                       

                }
                catch (Exception ex)
                {
                    Log.Error("MarantzControl: Error occured during DialogNotifyTelnet()");
                    Log.Error(ex.Message);
                }

                    break;



            }

        }


        




    }


}