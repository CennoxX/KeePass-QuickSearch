using KeePass.Plugins;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;

namespace QuickSearch.Properties
{
    internal sealed partial class Settings
    {
        private const string OptionsConfigRoot = "QuickSearchExt.";

        public void Save(IPluginHost host)
        {
            foreach (SettingsPropertyValue property in PropertyValues)
            {
                if (property.IsDirty)
                {
                    string val;
                    if (property.PropertyValue is Color)
                    {
                        Color color = (Color)property.PropertyValue;
                        val = string.Format("{0}, {1}, {2}", color.R, color.G, color.B);
                    }
                    else
                    {
                        val = property.SerializedValue as string;
                    }
                    if (val != null)
                    {
                        host.CustomConfig.SetString(OptionsConfigRoot + property.Name, val);
                    }
                    else
                    {
                        Debug.Fail("Non-string serialized settings property");
                    }
                }
            }
        }

        public void Load(IPluginHost host)
        {
            var _ = SearchInUserName; //Access any property just to make it load settings.

            foreach (SettingsPropertyValue property in PropertyValues)
            {
                var value = host.CustomConfig.GetString(OptionsConfigRoot + property.Name);
                if (value != null)
                {
                    property.SerializedValue = value;
                    property.Deserialized = false;
                    property.IsDirty = false;
                }
            }
        }

        public override void Save()
        {
            Debug.Fail("Use Save(IPluginHost) method instead, to persist to KeePass settings");
        }
    }
}