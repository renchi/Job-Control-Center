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
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Diagnostics;
using System.Configuration;
using JobControlCenter.Domain;


namespace JobControlCenter
{
    /// <summary>
    /// Interaction logic for RTCSandboxOperations.xaml
    /// </summary>
    public partial class RTCSandboxOperations : UserControl
    {
        private UserConfiguration userCfg;
        public RTCSandboxOperations()
        {
            InitializeComponent();
            updateCombo();
            foreach (SettingsProperty currentProperty in Properties.SWList.Default.Properties)
            {
                var key = currentProperty.Name;
                var name = Properties.SWList.Default[key];

                SWListCombo.Items.Add(key);
            }
            SWListCombo.SelectedIndex = 0;
        }

        private void updateCombo()
        {
            streamNameCombo.Items.Clear();
            userCfg = new UserConfiguration();
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        if (key.Contains("#rtcsandbox#"))
                        {
                            var sandboxName = key.Replace("#rtcsandbox#", "");
                            streamNameCombo.Items.Add(sandboxName);
                        }
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
            streamNameCombo.SelectedIndex = 0;
        }

        private void UpdateSandboxList(object sender, RoutedEventArgs e)
        {
            updateCombo();
        }

        private void LaunchVS_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedStream = streamNameCombo.SelectedItem.ToString();
            var key = new StringBuilder("#rtcsandbox#");
            key.Append(selectedStream);
            var pathName = userCfg.ReadSetting(key.ToString());

            
        }
       
        private void PopupBox_OnOpened(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Just making sure the popup has opened.");
        }

        private void PopupBox_OnClosed(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Just making sure the popup has closed.");
        }

        private void GitHubButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/ButchersBoy/MaterialDesignInXamlToolkit");
        }

        private void TwitterButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("https://twitter.com/James_Willock");
        }

        private void ChatButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("https://gitter.im/ButchersBoy/MaterialDesignInXamlToolkit");
        }

        private void EmailButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("mailto://james@dragablz.net");
        }

        private void DonateButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("https://pledgie.com/campaigns/31029");
        }

    }
}
