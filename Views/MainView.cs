using System;
using System.Collections.Generic;
using System.Text;
using MyClasses.MetaViewWrappers;

namespace PhatACUtil
{
    internal static class MainView
    {
        static IView View;

        // Object
        static ITextBox txtObjectIDName;
        static ITextBox txtObjectScale;
        static IButton btnObjectSpawn;
        static IButton btnObjectSolidTrue;
        static IButton btnObjectSolidFalse;
        static IButton btnObjectEditableEnabled;
        static IButton btnObjectEditableDisabled;
        static ITextBox txtObjectNudgeAmount;
        static IButton btnObjectNudgeXMinus;
        static IButton btnObjectNudgeXPlus;
        static IButton btnObjectNudgeYMinus;
        static IButton btnObjectNudgeYPlus;
        static IButton btnObjectNudgeZPlus;
        static IButton btnObjectNudgeZMinus;
        static ITextBox txtObjectSpinAmount;
        static IButton btnObjectSpin;
        static IButton btnObjectSpinWMinus;
        static IButton btnObjectSpinWPlus;
        static IButton btnObjectSpinWXMinus;
        static IButton btnObjectSpinWXPlus;
        static IButton btnObjectSpinWYMinus;
        static IButton btnObjectSpinWYPlus;
        static IButton btnObjectSpinWZMinus;
        static IButton btnObjectSpinWZPlus;

        // Spawn

        // Spawn:Model
        static ITextBox txtSpawnModelSearchText;
        static IList lstSpawnModelSearchList;
        static IButton btnSpawnModelClearSpawns;
        static IButton btnSpawnModelClearLastAssessed;

        // Spawn Tool
        static ITextBox txtSpawnToolCommand;
        static ITextBox txtSpawnToolValue;
        static IButton btnSpawnToolSpawn;
        static IButton btnSpawnToolSpawnTenX;
        static IButton btnSpawnToolSpawnMinus;
        static IButton btnSpawnToolSpawnPlus;
        static IButton btnSpawnToolClearSpawns;
        static IButton btnSpawnToolClearLastAssessed;

        // Tele town
        static ITextBox txtTeleTownSearchText;
        static IList lstTeleTownSearchList;

        public static void ViewInit()
        {
            //Create view here
            View = ViewSystemSelector.CreateViewResource(PluginCore.MyHost, "PhatACUtil.Views.MainView.xml");

            // Object
            txtObjectIDName = (ITextBox)View["txtObjectIDName"];
            txtObjectScale = (ITextBox)View["txtObjectScale"];
            btnObjectSpawn = (IButton)View["btnObjectSpawn"];
            btnObjectSpawn.Hit += btnObjectSpawn_Hit;
            btnObjectSolidTrue = (IButton)View["btnObjectSolidTrue"];
            btnObjectSolidTrue.Hit += btnObjectSolidTrue_Hit;
            btnObjectSolidFalse = (IButton)View["btnObjectSolidFalse"];
            btnObjectSolidFalse.Hit += btnObjectSolidFalse_Hit;
            btnObjectEditableEnabled = (IButton)View["btnObjectEditableEnabled"];
            btnObjectEditableEnabled.Hit += btnObjectEditableEnabled_Hit;
            btnObjectEditableDisabled = (IButton)View["btnObjectEditableDisabled"];
            btnObjectEditableDisabled.Hit += btnObjectEditableDisabled_Hit;
            txtObjectNudgeAmount = (ITextBox)View["txtObjectNudgeAmount"];
            btnObjectNudgeXMinus = (IButton)View["btnObjectNudgeXMinus"];
            btnObjectNudgeXMinus.Hit += btnObjectNudgeXMinus_Hit;
            btnObjectNudgeXPlus = (IButton)View["btnObjectNudgeXPlus"];
            btnObjectNudgeXPlus.Hit += btnObjectNudgeXPlus_Hit;
            btnObjectNudgeYMinus = (IButton)View["btnObjectNudgeYMinus"];
            btnObjectNudgeYMinus.Hit += btnObjectNudgeYMinus_Hit;
            btnObjectNudgeYPlus = (IButton)View["btnObjectNudgeYPlus"];
            btnObjectNudgeYPlus.Hit += btnObjectNudgeYPlus_Hit;
            btnObjectNudgeZMinus = (IButton)View["btnObjectNudgeZMinus"];
            btnObjectNudgeZMinus.Hit += btnObjectNudgeZMinus_Hit;
            btnObjectNudgeZPlus = (IButton)View["btnObjectNudgeZPlus"];
            btnObjectNudgeZPlus.Hit += btnObjectNudgeZPlus_Hit;

            txtObjectSpinAmount = (ITextBox)View["txtObjectSpinAmount"];

            btnObjectSpin = (IButton)View["btnObjectSpin"];
            btnObjectSpin.Hit += btnObjectSpin_Hit;

            btnObjectSpinWMinus = (IButton)View["btnObjectSpinWMinus"];
            btnObjectSpinWMinus.Hit += btnObjectSpinWMinus_Hit;
            btnObjectSpinWPlus = (IButton)View["btnObjectSpinWPlus"];
            btnObjectSpinWPlus.Hit += btnObjectSpinWPlus_Hit;

            btnObjectSpinWXMinus = (IButton)View["btnObjectSpinWXMinus"];
            btnObjectSpinWXMinus.Hit += btnObjectSpinWXMinus_Hit;

            btnObjectSpinWXPlus = (IButton)View["btnObjectSpinWXPlus"];
            btnObjectSpinWXPlus.Hit += btnObjectSpinWXPlus_Hit;

            btnObjectSpinWYMinus = (IButton)View["btnObjectSpinWYMinus"];
            btnObjectSpinWYMinus.Hit += btnObjectSpinWYMinus_Hit;

            btnObjectSpinWYPlus = (IButton)View["btnObjectSpinWYPlus"];
            btnObjectSpinWYPlus.Hit += btnObjectSpinWYPlus_Hit;

            btnObjectSpinWZMinus = (IButton)View["btnObjectSpinWZMinus"];
            btnObjectSpinWZMinus.Hit += btnObjectSpinWZMinus_Hit;

            btnObjectSpinWZPlus = (IButton)View["btnObjectSpinWZPlus"];
            btnObjectSpinWZPlus.Hit += btnObjectSpinWZPlus_Hit;

            // Spawn
            // Spawn Model
            txtSpawnModelSearchText = (ITextBox)View["txtSpawnModelSearchText"]; 
            lstSpawnModelSearchList = (IList)View["lstSpawnModelSearchList"];
            txtSpawnModelSearchText.Change += txtSpawnModelSearchText_Change;
            lstSpawnModelSearchList.Selected += lstSpawnModelSearchList_Selected;
            btnSpawnModelClearSpawns = (IButton)View["btnSpawnModelClearSpawns"];
            btnSpawnModelClearSpawns.Hit += btnSpawnModelClearSpawns_Hit;
            btnSpawnModelClearLastAssessed = (IButton)View["btnSpawnModelClearLastAssessed"];
            btnSpawnModelClearLastAssessed.Hit += btnSpawnModelClearLastAssessed_Hit;

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
            btnSpawnToolClearLastAssessed = (IButton)View["btnSpawnToolClearLastAssessed"];
            btnSpawnToolClearLastAssessed.Hit += btnSpawnToolClearLastAssessed_Hit;

            // Tele town
            txtTeleTownSearchText = (ITextBox)View["txtTeleTownSearchText"];
            lstTeleTownSearchList = (IList)View["lstTeleTownSearchList"];
            txtTeleTownSearchText.Change += txtTeleTownSearchText_Change;
            lstTeleTownSearchList.Selected += lstTeleTownSearchList_Selected;

            addAll();
        }

        public static void ViewDestroy()
        {
            // Controls
            txtObjectIDName = null;
            txtObjectScale = null;
            btnObjectSpawn = null;
            btnObjectSolidTrue = null;
            btnObjectSolidFalse = null;
            btnObjectEditableEnabled = null;
            btnObjectEditableDisabled = null;
            txtObjectNudgeAmount = null;
            btnObjectNudgeXMinus = null;
            btnObjectNudgeXPlus = null;
            btnObjectNudgeYMinus = null;
            btnObjectNudgeYPlus = null;
            btnObjectNudgeZMinus = null;
            btnObjectNudgeZPlus = null;
            btnObjectSpinWXMinus = null;
            btnObjectSpin = null;
            btnObjectSpinWMinus = null;
            btnObjectSpinWPlus = null;
            btnObjectSpinWXMinus = null;
            btnObjectSpinWXPlus = null;
            btnObjectSpinWYMinus = null;
            btnObjectSpinWYPlus = null;
            btnObjectSpinWZMinus = null;
            btnObjectSpinWZPlus = null;

            txtSpawnModelSearchText = null;
            lstSpawnModelSearchList = null;
            btnSpawnModelClearSpawns = null;
            btnSpawnModelClearLastAssessed = null;

            btnSpawnToolClearSpawns = null;
            btnSpawnToolSpawn = null;
            btnSpawnToolSpawnTenX = null;
            btnSpawnToolSpawnMinus = null;
            btnSpawnToolSpawnPlus = null;
            btnSpawnToolClearSpawns = null;
            btnSpawnToolClearLastAssessed = null;

            View.Dispose();
        }

        static void lstSpawnModelSearchList_Selected(object sender, MVListSelectEventArgs e)
        {
            try
            {
                String id = (String)lstSpawnModelSearchList[e.Row][0][0];
                String val = (String)lstSpawnModelSearchList[e.Row][1][0];

                PluginCore.ChatCommand("spawnmodel", id);
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
                lstSpawnModelSearchList.Clear();

                foreach (KeyValuePair<int, string> model in PluginCore.models)
                {
                    if (!(model.Value.ToLowerInvariant().Contains(searchText.ToLowerInvariant())))
                    {
                        continue;
                    }
                    
                    IListRow row = lstSpawnModelSearchList.Add();

                    row[0][0] = model.Key.ToString("X4");
                    row[1][0] = model.Value.ToString();
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
                PluginCore.ChatCommand("clearspawns");
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        private static void btnSpawnModelClearLastAssessed_Hit(object sender, EventArgs e)
        {
            PluginCore.ChatCommand("removethis");
        }

        private static void btnSpawnToolSpawn_Hit(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            try
            {

                if (txtSpawnToolCommand.Text.ToString().Length == 0)
                {
                    PluginCore.MyHost.Actions.AddChatText("You must enter a command.", 1);
                    return;
                }

                if (txtSpawnToolValue.Text.ToString().Length == 0)
                {
                    PluginCore.MyHost.Actions.AddChatText("You must enter a value.", 1);
                    return;
                }

                PluginCore.ChatCommand(txtSpawnToolCommand.Text, txtSpawnToolValue.Text);
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
                if (txtSpawnToolCommand.Text.ToString().Length == 0)
                {
                    PluginCore.MyHost.Actions.AddChatText("You must enter a command.", 1);
                    return;
                }

                if (txtSpawnToolValue.Text.ToString().Length == 0)
                {
                    PluginCore.MyHost.Actions.AddChatText("You must enter a value.", 1);
                    return;
                }

                PluginCore.ChatCommand(txtSpawnToolCommand.Text, txtSpawnToolValue.Text, "10");
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
                int value = int.Parse(txtSpawnToolValue.Text, System.Globalization.NumberStyles.HexNumber);
 
                value += 1;
                txtSpawnToolValue.Text = value.ToString("X4");
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
                int value = int.Parse(txtSpawnToolValue.Text, System.Globalization.NumberStyles.HexNumber);
                value -= 1;
                txtSpawnToolValue.Text = value.ToString("X4");
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
                PluginCore.ChatCommand("clearspawns");
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        private static void btnSpawnToolClearLastAssessed_Hit(object sender, EventArgs e)
        {
            PluginCore.ChatCommand("removethis");
        }

        static void addAll()
        {
            try
            {
                // Models
                lstSpawnModelSearchList.Clear();

                foreach (KeyValuePair<int, string> model in PluginCore.models)
                {
                    IListRow row = lstSpawnModelSearchList.Add();

                    row[0][0] = model.Key.ToString("X4");
                    row[1][0] = model.Value.ToString();
                }

                // Towns
                lstTeleTownSearchList.Clear();

                foreach (string town in PluginCore.towns)
                {
                    IListRow row = lstTeleTownSearchList.Add();

                    row[0][0] = town;
                }
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        static void lstTeleTownSearchList_Selected(object sender, MVListSelectEventArgs e)
        {
            try
            {
                String name = (String)lstTeleTownSearchList[e.Row][0][0];

                PluginCore.ChatCommand("teletown", name);
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

        }

        static void txtTeleTownSearchText_Change(object sender, MVTextBoxChangeEventArgs e)
        {
            var searchText = txtTeleTownSearchText.Text;

            if (searchText.Length == 0)
            {
                addAll();
                return;
            }

            try
            {
                lstTeleTownSearchList.Clear();

                foreach (string name in PluginCore.towns)
                {
                    if (!(name.ToLowerInvariant().Contains(searchText.ToLowerInvariant())))
                    {
                        continue;
                    }

                    IListRow row = lstTeleTownSearchList.Add();

                    row[0][0] = name;
                }
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

        }

        // Syntax: @b_spawnobj 0xID or Name, Scale - Spawns an object for building things!-->
        private static void btnObjectSpawn_Hit(object sender, EventArgs e)
        {
            string id = "";
            int scale = 1;

            try
            {
                id = txtObjectIDName.Text.ToString();
                scale = int.Parse(txtObjectScale.Text.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

            PluginCore.ChatCommand("b_spawnobj", id, scale.ToString());
        }

        // Syntax: @b_setsolid 1 for true, 0 for false - Set this object as solid
        private static void btnObjectSolidTrue_Hit(object sender, EventArgs e)
        {
            PluginCore.ChatCommand("b_setsolid", "1");
        }

        private static void btnObjectSolidFalse_Hit(object sender, EventArgs e)
        {
            PluginCore.ChatCommand("b_setsolid", "0");
        }

        // Syntax: @b_enableEditing 1 for true, 0 for false - Enables editing your objects in a landblock!
        private static void btnObjectEditableEnabled_Hit(object sender, EventArgs e)
        {
            PluginCore.ChatCommand("b_enableEditing", "1");
        }

        private static void btnObjectEditableDisabled_Hit(object sender, EventArgs e)
        {
            PluginCore.ChatCommand("b_enableEditing", "0");
        }

        // Syntax: @b_nudgeX u units to nudge - Nudges selected object in X direction by U units
        private static void btnObjectNudgeXMinus_Hit(object sender, EventArgs e)
        {
            int amount = 1;

            try
            {
                amount = int.Parse(txtObjectNudgeAmount.Text.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

            // Override the user input if it's nonsense
            if (amount < 0)
            {
                PluginCore.MyHost.Actions.AddChatText("Overriding user input of " + amount + " and using a value of 1 instead.", 1);
                amount = 1;
            }

            PluginCore.ChatCommand("b_nudgeX", "-" + amount.ToString());
        }

        private static void btnObjectNudgeXPlus_Hit(object sender, EventArgs e)
        {
            int amount = 1;

            try
            {
                amount = int.Parse(txtObjectNudgeAmount.Text.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

            // Override the user input if it's nonsense
            if (amount < 0)
            {
                PluginCore.MyHost.Actions.AddChatText("Overriding user input of " + amount + " and using a value of 1 instead.", 1);
                amount = 1;
            }

            PluginCore.ChatCommand("b_nudgeX", amount.ToString());
        }

        // Syntax: @b_nudgeY u units to nudge - Nudges selected object in Y direction by U units
        private static void btnObjectNudgeYMinus_Hit(object sender, EventArgs e)
        {
            int amount = 1;

            try
            {
                amount = int.Parse(txtObjectNudgeAmount.Text.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

            // Override the user input if it's nonsense
            if (amount < 0)
            {
                PluginCore.MyHost.Actions.AddChatText("Overriding user input of " + amount + " and using a value of 1 instead.", 1);
                amount = 1;
            }

            PluginCore.ChatCommand("b_nudgeY", "-" + amount.ToString());
        }

        private static void btnObjectNudgeYPlus_Hit(object sender, EventArgs e)
        {
            int amount = 1;

            try
            {
                amount = int.Parse(txtObjectNudgeAmount.Text.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

            // Override the user input if it's nonsense
            if (amount < 0)
            {
                PluginCore.MyHost.Actions.AddChatText("Overriding user input of " + amount + " and using a value of 1 instead.", 1);
                amount = 1;
            }

            PluginCore.ChatCommand("b_nudgeY", amount.ToString());
        }

        // Syntax: @b_nudgeZ u units to nudge - Nudges selected object in Z direction by U units
        private static void btnObjectNudgeZMinus_Hit(object sender, EventArgs e)
        {
            double amount = 1;

            try
            {
                amount = double.Parse(txtObjectNudgeAmount.Text.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

            // Override the user input if it's nonsense
            if (amount < 0)
            {
                PluginCore.MyHost.Actions.AddChatText("Overriding user input of " + amount + " and using a value of 1 instead.", 1);
                amount = 1;
            }

            PluginCore.ChatCommand("b_nudgeZ", "-" + Math.Round((amount / 10), 2).ToString());
        }


        private static void btnObjectNudgeZPlus_Hit(object sender, EventArgs e)
        {
            double amount = 1;

            try
            {
                amount = double.Parse(txtObjectNudgeAmount.Text.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

            // Override the user input if it's nonsense
            if (amount < 0)
            {
                PluginCore.MyHost.Actions.AddChatText("Overriding user input of " + amount + " and using a value of 1 instead.", 1);
                amount = 1;
            }

            PluginCore.ChatCommand("b_nudgeZ", Math.Round((amount/10), 2).ToString());
        }

        private static void btnObjectSpin_Hit(object sender, EventArgs e)
        {
            PluginCore.ChatCommand("b_spin");
        }

        private static void btnObjectSpinWMinus_Hit(object sender, EventArgs e)
        {
            double amount = 0.1;

            try
            {
                amount = double.Parse(txtObjectSpinAmount.Text.ToString());
            } 
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

            try
            {
                PluginCore.ChatCommand("b_spinW", (-1 * amount).ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        private static void btnObjectSpinWPlus_Hit(object sender, EventArgs e)
        {
            double amount = 0.1;

            try
            {
                amount = double.Parse(txtObjectSpinAmount.Text.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

            try
            {
                PluginCore.ChatCommand("b_spinW", amount.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        private static void btnObjectSpinWXMinus_Hit(object sender, EventArgs e)
        {
            double amount = 0.1;

            try
            {
                amount = double.Parse(txtObjectSpinAmount.Text.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

            try
            {
                PluginCore.ChatCommand("b_spinWX", (-1 * amount).ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        private static void btnObjectSpinWXPlus_Hit(object sender, EventArgs e)
        {
            double amount = 0.1;

            try
            {
                amount = double.Parse(txtObjectSpinAmount.Text.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

            try
            {
                PluginCore.ChatCommand("b_spinWX", amount.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        private static void btnObjectSpinWYMinus_Hit(object sender, EventArgs e)
        {
            double amount = 0.1;

            try
            {
                amount = double.Parse(txtObjectSpinAmount.Text.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

            try
            {
                PluginCore.ChatCommand("b_spinWY", (-1 * amount).ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        private static void btnObjectSpinWYPlus_Hit(object sender, EventArgs e)
        {
            double amount = 0.1;

            try
            {
                amount = double.Parse(txtObjectSpinAmount.Text.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

            try
            {
                PluginCore.ChatCommand("b_spinWY", amount.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        private static void btnObjectSpinWZMinus_Hit(object sender, EventArgs e)
        {
            double amount = 0.1;

            try
            {
                amount = double.Parse(txtObjectSpinAmount.Text.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

            try
            {
                PluginCore.ChatCommand("b_spinWZ", (-1 * amount).ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }

        private static void btnObjectSpinWZPlus_Hit(object sender, EventArgs e)
        {
            double amount = 0.1;

            try
            {
                amount = double.Parse(txtObjectSpinAmount.Text.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }

            try
            {
                PluginCore.ChatCommand("b_spinWZ", amount.ToString());
            }
            catch (Exception ex)
            {
                PluginCore.LogError(ex);
            }
        }
    }
}
