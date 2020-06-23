﻿using System;
using UnityEngine;
using KSPe.UI;

namespace TweakScale.GUI
{
    internal class SanityCheckAlertBox : CommonBox
    { 
        private static readonly string MSG = @"TweakScale found {0} parts that failed sanity checks! See KSP.log for details.

Parts that fails sanity check had TweakScale support withdrawn. This was necessary to prevent them to crash the game. At the present, there's no way to scale them without nasty consequences - but they can be used normally.

TweakScale is working to support these parts.";

        internal static void show(int sanity_failures)
        {
            GameObject go = new GameObject("TweakScale.WarningBox");
            TimedMessageBox dlg = go.AddComponent<TimedMessageBox>();

            GUIStyle win = createWinStyle(Color.yellow);
            GUIStyle text = createTextStyle();

            if (ModuleManagerListener.shouldShowWarnings)
                dlg.Show(
                    "TweakScale Warning", 
                    String.Format(MSG, sanity_failures),
                    30, 1, -1,
                    win, text
                );
            Log.force("\"TweakScale Warning\" about sanity checks was {0}", ModuleManagerListener.shouldShowWarnings ? "omitted" : "displayed");
        }
    }
}