///////////////////////////////////////////////////////////////////////////////
//File: MainView.cs
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
using System.Collections.Generic;
using System.Text;
using Decal.Adapter;
using Decal.Adapter.Wrappers;
using MyClasses.MetaViewWrappers;

namespace PhatACUtil
{
    internal static class MainView
    {
        static IView View;

        // Spawn

        // Spawn:Model
        static ITextBox txtSpawnModelSearchText;
        static IList lstSpawnModelSearchList;
        static IButton btnSpawnModelClearSpawns;

        // Spawn Tool
        static ITextBox txtSpawnToolCommand;
        static ITextBox txtSpawnToolValue;
        static IButton btnSpawnToolSpawn;
        static IButton btnSpawnToolSpawnTenX;
        static IButton btnSpawnToolSpawnMinus;
        static IButton btnSpawnToolSpawnPlus;
        static IButton btnSpawnToolClearSpawns;




        public static void ViewInit()
        {
            //Create view here
            View = ViewSystemSelector.CreateViewResource(PluginCore.MyHost, "PhatACUtil.Views.MainView.xml");

            // Spawn
            // Spawn:model
            txtSpawnModelSearchText = (ITextBox)View["txtSpawnModelSearchText"]; 
            lstSpawnModelSearchList = (IList)View["lstSpawnModelSearchList"];
            btnSpawnModelClearSpawns = (IButton)View["btnSpawnModelClearSpawns"];
            txtSpawnModelSearchText.Change += txtSpawnModelSearchText_Change;
            lstSpawnModelSearchList.Selected += lstSpawnModelSearchList_Selected;
            btnSpawnModelClearSpawns.Hit += btnSpawnModelClearSpawns_Hit;
            
            // Spawn Tool
            txtSpawnToolCommand = (ITextBox)View["txtSpawnToolCommand"];
            txtSpawnToolValue = (ITextBox)View["txtSpawnToolValue"];
            btnSpawnToolSpawn = (IButton)View["btnSpawnToolSpawn"];

            btnSpawnToolSpawn.Hit += btnSpawnToolSpawn_Hit;
            btnSpawnToolSpawnTenX = (IButton)View["btnSpawnToolSpawnTenX"];
            btnSpawnToolSpawnTenX.Hit += btnSpawnToolSpawnTenX_Hit;
            btnSpawnToolSpawnMinus = (IButton)View["btnSpawnToolSpawnMinus"];
            btnSpawnToolSpawnMinus.Hit += btnSpawnToolSpawnMinus_Hit;
            btnSpawnToolSpawnPlus = (IButton)View["btnSpawnToolSpawnPlus"];
            btnSpawnToolSpawnPlus.Hit += btnSpawnToolSpawnPlus_Hit;
            btnSpawnToolClearSpawns = (IButton)View["btnSpawnToolClearSpawns"];
            btnSpawnToolClearSpawns.Hit += btnSpawnToolClearSpawns_Hit;

            addAll();
        }

        public static void ViewDestroy()
        {
            txtSpawnModelSearchText.Change -= txtSpawnModelSearchText_Change;
            lstSpawnModelSearchList.Selected -= lstSpawnModelSearchList_Selected;
            btnSpawnModelClearSpawns.Hit -= btnSpawnModelClearSpawns_Hit;
            btnSpawnToolSpawn.Hit -= btnSpawnToolSpawn_Hit;
            btnSpawnToolSpawnTenX.Hit -= btnSpawnToolSpawnTenX_Hit;
            btnSpawnToolSpawnMinus.Hit -= btnSpawnToolSpawnMinus_Hit;
            btnSpawnToolSpawnPlus.Hit -= btnSpawnToolSpawnPlus_Hit;
            btnSpawnToolClearSpawns.Hit -= btnSpawnToolClearSpawns_Hit;

            txtSpawnModelSearchText = null;
            lstSpawnModelSearchList = null;
            btnSpawnModelClearSpawns = null;
            btnSpawnToolSpawn = null;
            btnSpawnToolSpawnTenX = null;
            btnSpawnToolSpawnMinus = null;
            btnSpawnToolSpawnPlus = null;
            btnSpawnToolClearSpawns = null;

            View.Dispose();
        }

        static void ChatCommand(string command, params string[] tokens)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("@");
            sb.Append(command);
            sb.Append(" ");
            
            foreach (string token in tokens)
            {
                sb.Append(token.Trim());
                sb.Append(' ');
            }

            try
            {
                PluginCore.MyHost.Actions.InvokeChatParser(sb.ToString());

            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        static void lstSpawnModelSearchList_Selected(object sender, MVListSelectEventArgs e)
        {
            try
            {
                String id = (String)lstSpawnModelSearchList[e.Row][0][0];
                String val = (String)lstSpawnModelSearchList[e.Row][1][0];

                ChatCommand("spawnmodel", id);
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
            
        }

        static void txtSpawnModelSearchText_Change(object sender, MVTextBoxChangeEventArgs e)
        {
            var searchText = txtSpawnModelSearchText.Text;

            if (searchText.Length == 0)
            {
                addAll();
                return;
            }

            try
            {
                lstSpawnMonsterSearchList.Clear();

                foreach (KeyValuePair<string, Int32> monster in PluginCore.monsters)
                {
                    if (!(monster.Key.ToLowerInvariant().Contains(searchText.ToLowerInvariant())))
                    {
                        continue;
                    }
                    
                    IListRow row = lstSpawnMonsterSearchList.Add();

                    row[0][0] = monster.Key;
                    row[1][0] = monster.Value.ToString("X");
                }
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

        }

        private static void btnSpawnModelClearSpawns_Hit(object sender, EventArgs e)
        {
            try
            {
                ChatCommand("clearspawns");
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        private static void btnSpawnToolSpawn_Hit(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                ChatCommand(txtSpawnToolCommand.Text, txtSpawnToolValue.Text);
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        private static void btnSpawnToolSpawnTenX_Hit(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                ChatCommand(txtSpawnToolCommand.Text, txtSpawnToolValue.Text, "10");
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        private static void btnSpawnToolSpawnPlus_Hit(object sender, EventArgs e)
        {
            try
            {
                Int32 value = Int32.Parse(txtSpawnToolValue.Text);
                value += 1;
                txtSpawnToolValue.Text = value.ToString();
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        private static void btnSpawnToolSpawnMinus_Hit(object sender, EventArgs e)
        {
            try
            {
                Int32 value = Int32.Parse(txtSpawnToolValue.Text);
                value -= 1;
                txtSpawnToolValue.Text = value.ToString();
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        private static void btnSpawnToolClearSpawns_Hit(object sender, EventArgs e)
        {
            try
            {
                ChatCommand("clearspawns");
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        static void addAll()
        {
            try
            {
                lstSpawnMonsterSearchList.Clear();

                foreach (KeyValuePair<string, Int32> monster in PluginCore.monsters)
                {
                    IListRow row = lstSpawnMonsterSearchList.Add();

                    row[0][0] = monster.Key;
                    row[1][0] = monster.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }
    }
}
