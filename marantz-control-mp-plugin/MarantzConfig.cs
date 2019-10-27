using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaPortal.Configuration;
using MediaPortal.GUI.Library;
using MediaPortal.Dialogs;

namespace marantz_control_mp_plugin
{
    public class MarantzConfig
    {

        public string Address;
        public string Port;
        public string TelnetCommand;

        public void SetDefault()
        {
            Address = "0.0.0.0";
            Port = "23";
            TelnetCommand = "";

        }
        public void ReadConfig()
        {
            try
            {
                using (MediaPortal.Profile.Settings reader = new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, "MediaPortal.xml")))
                {
                    Address = reader.GetValueAsString("MarantzControl", "Address", "0.0.0.0");
                    Port = reader.GetValueAsString("MarantzControl", "Port", "23");
                    TelnetCommand = reader.GetValueAsString("MarantzControl", "TelnetCommand", "");

                }
            }
            catch (Exception ex)
            {
                Log.Error("MarantzControl: Configuration read failed, using defaults! {0}", ex.ToString());
                SetDefault();
            }
        }

        public void WriteConfig()
        {
            try
            {
                using (MediaPortal.Profile.Settings writer = new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, "MediaPortal.xml")))
                {
                    writer.SetValue("MarantzControl", "Address", Address);
                    writer.SetValue("MarantzControl", "Port", Port);
                    writer.SetValue("MarantzControl", "TelnetCommand", TelnetCommand);

                }
            }
            catch (Exception ex)
            {
                Log.Error("MarantzControl: Configuration read failed, using defaults! {0}", ex.ToString());
                throw;
            }
        }
    }
}
