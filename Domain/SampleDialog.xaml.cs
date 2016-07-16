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

                var userCfg = new UserConfiguration();
                var key = new StringBuilder("#rtcsandbox#");
                key.Append(mysandboxName);
                var value = mysandboxPath;
                userCfg.AddUpdateAppSettings(key.ToString(), mysandboxPath);

                //System.Windows.Application.Current.Shutdown();
                //System.Windows.Forms.Application.Restart();
            }
        }
    }
}
