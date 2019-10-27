using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaPortal.GUI.Library;
using MediaPortal.Dialogs;

namespace marantz_control_mp_plugin
{
    public class MarantzControl : GUIWindow, ISetupForm
    {
        
    #region ISetupForm Members

    // Returns the name of the plugin which is shown in the plugin menu
    public string PluginName()
    {
        return "MyFirstPlugin";
    }

    // Returns the description of the plugin is shown in the plugin menu
    public string Description()
    {
        return "My First Plugin";
    }

    // Returns the author of the plugin which is shown in the plugin menu
    public string Author()
    {
        return "YourNameHere";
    }

    // show the setup dialog
    public void ShowPlugin()
    {
            MarantzSettings settings = new MarantzSettings();
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
        return 9999;
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

        // With GetID it will be an window-plugin / otherwise a process-plugin
        // Enter the id number here again
        //public override int GetID
        //{
        //    get
        //    {
        //        return 9991;
        //    }

        //    set
        //    {
        //    }
        //}

        #endregion

        
    }
}
