using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using Decal.Adapter;

namespace PhatACUtil
{
    [FriendlyName("PhatACUtil")]
    public partial class PluginCore : PluginBase
    {
        static string log_path;
        static string model_path;

        internal static Decal.Adapter.Wrappers.PluginHost MyHost;

        internal static Dictionary<int, string> models;

        protected override void Startup()
        {
            log_path = Path.ToString() + "\\error.txt";
            MyHost = Host;

            // Init views etc
            try
            {
                // Load data

                models = LoadModels();

                // Set up views
                MainView.ViewInit();
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
            
        }

        protected override void Shutdown()
        {
            try
            {
                MainView.ViewDestroy();
                models = null;
            }
            catch (Exception ex)
            {
                LogError(ex);
            }

            MyHost = null;
        }

        public static void LogMessage(String msg)
        {
            try
            {
                StreamWriter sw = new StreamWriter(log_path, true);
                sw.WriteLine(msg);
                sw.Close();
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        public static void LogError(Exception ex) {
            try {
                StreamWriter sw = new StreamWriter(log_path, true);

                sw.WriteLine("============================================================================");
                sw.WriteLine(DateTime.Now.ToString());
                sw.WriteLine("Error: " + ex.Message);
                sw.WriteLine("Source: " + ex.Source);
                sw.WriteLine("Stack: " + ex.StackTrace);
                if (ex.InnerException != null)
                {
                    sw.WriteLine("Inner: " + ex.InnerException.Message);
                    sw.WriteLine("Inner Stack: " + ex.InnerException.StackTrace);
                }
                sw.WriteLine("============================================================================");
                sw.WriteLine("");
                sw.Close();
            }
            catch (Exception exc) {
            }
        }

        static void Chat(String msg)
        {
            try
            {
                MyHost.Actions.AddChatText(msg, 0, 1);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        static Dictionary<int, string> LoadModels()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Dictionary<int, string> models = new Dictionary<int, string>();
            StreamReader sr = new StreamReader(assembly.GetManifestResourceStream("PhatACUtil.Data.models.csv"));

            String[] tokens;
            string line;
            string name;

            try
            {
                while ((line = sr.ReadLine()) != null)
                {
                    tokens = line.Split(',');
                    name = tokens[1].Replace("\"", "");
                    models.Add(int.Parse(tokens[0], System.Globalization.NumberStyles.HexNumber),name );  
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
           
            return models;
        }
    }
}
