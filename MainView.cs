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

namespace PhatACAdmin
{
    internal static class MainView
    {
        #region Auto-generated view code
        static MyClasses.MetaViewWrappers.IView View;
        static MyClasses.MetaViewWrappers.IButton btnSpawn;
        static MyClasses.MetaViewWrappers.ITextBox txtInput;

        public static void ViewInit()
        {
            //Create view here
            View = MyClasses.MetaViewWrappers.ViewSystemSelector.CreateViewResource(PluginCore.MyHost, "PhatACAdmin.ViewXML.MainView.xml");

            txtInput = (MyClasses.MetaViewWrappers.ITextBox)View["txtInput"]; 
            btnSpawn = (MyClasses.MetaViewWrappers.IButton)View["btnSpawn"];

            btnSpawn.Hit += new EventHandler(btnSpawn_Hit);
        }

        public static void ViewDestroy()
        {
            btnSpawn.Hit -= new EventHandler(btnSpawn_Hit);

            btnSpawn = null;
            txtInput = null;

            View.Dispose();
        }
        #endregion Auto-generated view code

        static void btnSpawn_Hit(object sender, EventArgs e)
        {
            String msg = "/spawn " + txtInput.Text;
            PluginCore.MyHost.Actions.AddChatText(msg, 0, 1);
            PluginCore.MyHost.Actions.InvokeChatParser(msg);
        }
    }
}
