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
        static ITextBox txtSearchText;
        static IList lstSearchList;

        public static void ViewInit()
        {
            //Create view here
            View = ViewSystemSelector.CreateViewResource(PluginCore.MyHost, "PhatACUtil.Views.MainView.xml");

            txtSearchText = (ITextBox)View["txtSearchText"]; 
            lstSearchList = (IList)View["txtSearchList"];

            txtSearchText.Change += new EventHandler<MVTextBoxChangeEventArgs>(txtSearchText_Change);
            lstSearchList.Selected += new EventHandler<MVListSelectEventArgs>(lstSearchList_Selected);

            addAll();
        }


        public static void ViewDestroy()
        {
            txtSearchText.Change -= new EventHandler<MVTextBoxChangeEventArgs>(txtSearchText_Change);
            lstSearchList.Selected -= new EventHandler<MVListSelectEventArgs>(lstSearchList_Selected);

            txtSearchText = null;
            lstSearchList = null;

            View.Dispose();
        }
        #endregion Auto-generated view code

        static void Spawn(String id)
        {
            String msg = "/spawn " + id.ToString();

            try
            {
                PluginCore.MyHost.Actions.AddChatText(msg, 0, 1);
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        static void lstSearchList_Selected(object sender, MVListSelectEventArgs e)
        {
            try
            {
                String val = (String)lstSearchList[e.Row][1][0];
                Spawn("0x" + Convert.ToInt32(val).ToString("X"));
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
            
        }

        static void txtSearchText_Change(object sender, MVTextBoxChangeEventArgs e)
        {
            var searchText = txtSearchText.Text;

            if (searchText.Length == 0)
            {
                addAll();
                return;
            }

            try
            {
                lstSearchList.Clear();

                foreach (KeyValuePair<String, Int32> entry in PluginCore.lookup)
                {
                    if (!(entry.Key.ToLowerInvariant().Contains(searchText.ToLowerInvariant())))
                    {
                        continue;
                    }

                    IListRow row = lstSearchList.Add();

                    row[0][0] = entry.Key;
                    row[1][0] = entry.Value.ToString();
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
                lstSearchList.Clear();

                foreach (KeyValuePair<String, Int32> entry in PluginCore.lookup)
                {

                    IListRow row = lstSearchList.Add();

                    row[0][0] = entry.Key;
                    row[1][0] = entry.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        static void Chat(String msg)
        {
            try
            {
                PluginCore.MyHost.Actions.AddChatText(msg, 0, 1);
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }
    }
}
