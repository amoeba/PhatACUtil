///////////////////////////////////////////////////////////////////////////////
//File: PluginCore.cs
//
//Description: An example plugin using the VVS MetaViewWrappers. When VVS is
//  enabled, the plugin's view appears under the VVS bar. Otherwise, it appears
//  in the regular Decal bar.
//
//This file is Copyright (c) 2009 VirindiPlugins
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
///////////////////////////////////////////////////////////////////////////////

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
                System.IO.StreamWriter sw = new System.IO.StreamWriter(LogPath, true);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        public static void LogError(Exception ex) {
            try {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(LogPath, true);

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
