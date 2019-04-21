// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Sudoku.iOS
{
    [Register ("SettingsController")]
    partial class SettingsController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch Music { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView Settings { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Music != null) {
                Music.Dispose ();
                Music = null;
            }

            if (Settings != null) {
                Settings.Dispose ();
                Settings = null;
            }
        }
    }
}