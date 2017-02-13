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

namespace ExamplePlugin
{
    internal static class MainView
    {
        #region Auto-generated view code
        static MyClasses.MetaViewWrappers.IView View;
        static MyClasses.MetaViewWrappers.IButton bTest;
        static MyClasses.MetaViewWrappers.ITextBox txtTest;
        static MyClasses.MetaViewWrappers.ISlider sldTest;

        public static void ViewInit()
        {
            //Create view here
            View = MyClasses.MetaViewWrappers.ViewSystemSelector.CreateViewResource(PluginCore.MyHost, "ExamplePlugin.ViewXML.testlayout.xml");
            bTest = (MyClasses.MetaViewWrappers.IButton)View["bTest"];
            txtTest = (MyClasses.MetaViewWrappers.ITextBox)View["txtTest"];
            sldTest = (MyClasses.MetaViewWrappers.ISlider)View["sldTest"];

            sldTest.Change += new EventHandler<MyClasses.MetaViewWrappers.MVIndexChangeEventArgs>(sldTest_Change);
            bTest.Hit += new EventHandler(bTest_Hit);
        }

        public static void ViewDestroy()
        {
            bTest = null;
            txtTest = null;
            sldTest = null;
            View.Dispose();
        }
        #endregion Auto-generated view code

        static void bTest_Hit(object sender, EventArgs e)
        {
            PluginCore.MyHost.Actions.AddChatText("Button hit!", 0, 1);
        }

        static void sldTest_Change(object sender, EventArgs e)
        {
            txtTest.Text = sldTest.Position.ToString();
        }
    }
}
