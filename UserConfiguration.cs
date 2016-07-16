using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using System.Collections.Specialized; // NameValueConnlection


namespace JobControlCenter
{
    public class UserConfiguration
    {
        enum SettingsKind
        {
            eRtcSandboxOperation
        };

        public UserConfiguration()
        {
            //ReadAllSettingsByKind(SettingsKind.eRtcSandboxOperation);
            //ReadAllSettings();
            //ReadSetting("Setting1");
            //ReadSetting("NotValid");
            //AddUpdateAppSettings("NewSetting", "May 7, 2014");
            //AddUpdateAppSettings("Setting1", "May 8, 2014");
            //ReadAllSettings();

            //string command = ReadSetting("NotepaddCmd");
        }

        private void ReadAllSettingsByKind(SettingsKind kind)
        {
            try
            {
                if (kind == SettingsKind.eRtcSandboxOperation)
                {
                    foreach (SettingsProperty currentProperty in Properties.RtcSandboxOperations.Default.Properties)
                    {
                        var key = currentProperty.Name;
                        var name = Properties.RtcSandboxOperations.Default[key];
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        private void ReadAllSettings()
        {
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
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        public string ReadSetting(string key)
        {
            string result = "";
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? "Not Found";
                Console.WriteLine(result);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
            return result;
        }

        public void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        static void ExecuteCommand(string command)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            var process = Process.Start(processInfo);

            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("output>>" + e.Data);
            process.BeginOutputReadLine();

            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("error>>" + e.Data);
            process.BeginErrorReadLine();

            process.WaitForExit();

            Console.WriteLine("ExitCode: {0}", process.ExitCode);
            process.Close();
        }

        //private void ExecuteCommand(string command)
        //{
        //    int exitCode;
        //    ProcessStartInfo processInfo;
        //    Process process;

        //    processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
        //    processInfo.CreateNoWindow = true;
        //    processInfo.UseShellExecute = false;
        //    // *** Redirect the output ***
        //    processInfo.RedirectStandardError = true;
        //    processInfo.RedirectStandardOutput = true;

        //    process = Process.Start(processInfo);
        //    process.WaitForExit();

        //    // *** Read the streams ***
        //    // Warning: This approach can lead to deadlocks, see Edit #2
        //    string output = process.StandardOutput.ReadToEnd();
        //    string error = process.StandardError.ReadToEnd();

        //    exitCode = process.ExitCode;

        //    Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
        //    Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
        //    Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
        //    process.Close();
        //}


    }
}