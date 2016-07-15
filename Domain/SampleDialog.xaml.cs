using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace JobControlCenter.Domain
{
    /// <summary>
    /// Interaction logic for SampleDialog.xaml
    /// </summary>
    public partial class SampleDialog : UserControl
    {
        public SampleDialog()
        {
            InitializeComponent();
        }
        public void AddSandbox()
        {
            if (!string.IsNullOrWhiteSpace(txtSandboxName.Text) &&
               !string.IsNullOrWhiteSpace(txtSandboxPath.Text))
            {
                var builder = new StringBuilder(txtSandboxName.Text);
                if (chkExportControl.IsChecked == true)
                {
                    builder.Append("_EC");
                }
                var mysandboxName = builder.ToString();
                var mysandboxPath = txtSandboxPath.Text;

                //SettingsProperty newProperty = new SettingsProperty(mysandboxName);
                //newProperty.Name = mysandboxName;
                //newProperty.PropertyType = string;
                //newProperty.DefaultValue = mysandboxPath;
                //// newProperty.Name = mysandboxName;
                //Properties.RtcSandboxOperations.Default.Properties.Add(newProperty);
                //Properties.RtcSandboxOperations.Default.Save();


                System.Configuration.SettingsProperty property = new SettingsProperty(mysandboxName);
                property.DefaultValue = mysandboxPath;
                property.IsReadOnly = false;
                property.PropertyType = typeof(string);
                property.Provider = Properties.Settings.Default.Providers["LocalFileSettingsProvider"];
                property.Attributes.Add(typeof(System.Configuration.UserScopedSettingAttribute), new System.Configuration.UserScopedSettingAttribute());
                Properties.RtcSandboxOperations.Default.Properties.Add(property);
                Properties.RtcSandboxOperations.Default.Save();
                Properties.RtcSandboxOperations.Default.Reload();
                Properties.RtcSandboxOperations.Default.Upgrade();

                foreach (SettingsProperty currentProperty in Properties.RtcSandboxOperations.Default.Properties)
                {
                    var key = currentProperty.Name;
                    var name = currentProperty.DefaultValue;
                }
                //System.Windows.Application.Current.Shutdown();
                //System.Windows.Forms.Application.Restart();

            }
        }
    }
}
