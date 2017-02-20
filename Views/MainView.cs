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
using MyClasses.MetaViewWrappers;

namespace PhatACUtil
{
    internal static class MainView
    {
        #region Auto-generated view code
        static IView View;
        static ITextBox txtSpawnMonsterSearchText;
        static IList lstSpawnMonsterSearchList;

        public static void ViewInit()
        {
            //Create view here
            View = ViewSystemSelector.CreateViewResource(PluginCore.MyHost, "PhatACUtil.Views.MainView.xml");

            txtSpawnMonsterSearchText = (ITextBox)View["txtSpawnMonsterSearchText"]; 
            lstSpawnMonsterSearchList = (IList)View["lstSpawnMonsterSearchList"];

            txtSpawnMonsterSearchText.Change += new EventHandler<MVTextBoxChangeEventArgs>(txtSpawnMonsterSearchText_Change);
            lstSpawnMonsterSearchList.Selected += new EventHandler<MVListSelectEventArgs>(lstSpawnMonsterSearchList_Selected);

            addAll();
        }


        public static void ViewDestroy()
        {
            txtSpawnMonsterSearchText.Change -= new EventHandler<MVTextBoxChangeEventArgs>(txtSpawnMonsterSearchText_Change);
            lstSpawnMonsterSearchList.Selected -= new EventHandler<MVListSelectEventArgs>(lstSpawnMonsterSearchList_Selected);

            txtSpawnMonsterSearchText = null;
            lstSpawnMonsterSearchList = null;

            View.Dispose();
        }
        #endregion Auto-generated view code

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
                PluginCore.MyHost.Actions.AddChatText(sb.ToString(), 0, 1);
                PluginCore.MyHost.Actions.InvokeChatParser(sb.ToString());

            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        static void lstSpawnMonsterSearchList_Selected(object sender, MVListSelectEventArgs e)
        {
            try
            {
                String val = (String)lstSpawnMonsterSearchList[e.Row][0][0];
                String id = (String)lstSpawnMonsterSearchList[e.Row][1][0];

                ChatCommand("spawnmonster", id);
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
            
        }

        static void txtSpawnMonsterSearchText_Change(object sender, MVTextBoxChangeEventArgs e)
        {
            var searchText = txtSpawnMonsterSearchText.Text;

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
                    row[1][0] = monster.Value.ToString();
                }
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
