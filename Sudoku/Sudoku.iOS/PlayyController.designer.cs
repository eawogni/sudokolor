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
    [Register ("PlayyController")]
    partial class PlayyController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton bt1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton bt2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton bt3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton bt4 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton bt5 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton bt6 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton bt7 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton bt8 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton bt9 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btSauver { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btValider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btVoid { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView grille { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView Playy { get; set; }

        [Action ("Bt1_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Bt1_TouchUpInside (UIKit.UIButton sender);

        [Action ("Bt2_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Bt2_TouchUpInside (UIKit.UIButton sender);

        [Action ("Bt3_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Bt3_TouchUpInside (UIKit.UIButton sender);

        [Action ("Bt4_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Bt4_TouchUpInside (UIKit.UIButton sender);

        [Action ("Bt5_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Bt5_TouchUpInside (UIKit.UIButton sender);

        [Action ("Bt6_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Bt6_TouchUpInside (UIKit.UIButton sender);

        [Action ("Bt7_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Bt7_TouchUpInside (UIKit.UIButton sender);

        [Action ("Bt8_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Bt8_TouchUpInside (UIKit.UIButton sender);

        [Action ("Bt9_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Bt9_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtSauver_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtSauver_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtValider_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtValider_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtVoid_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtVoid_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (bt1 != null) {
                bt1.Dispose ();
                bt1 = null;
            }

            if (bt2 != null) {
                bt2.Dispose ();
                bt2 = null;
            }

            if (bt3 != null) {
                bt3.Dispose ();
                bt3 = null;
            }

            if (bt4 != null) {
                bt4.Dispose ();
                bt4 = null;
            }

            if (bt5 != null) {
                bt5.Dispose ();
                bt5 = null;
            }

            if (bt6 != null) {
                bt6.Dispose ();
                bt6 = null;
            }

            if (bt7 != null) {
                bt7.Dispose ();
                bt7 = null;
            }

            if (bt8 != null) {
                bt8.Dispose ();
                bt8 = null;
            }

            if (bt9 != null) {
                bt9.Dispose ();
                bt9 = null;
            }

            if (btSauver != null) {
                btSauver.Dispose ();
                btSauver = null;
            }

            if (btValider != null) {
                btValider.Dispose ();
                btValider = null;
            }

            if (btVoid != null) {
                btVoid.Dispose ();
                btVoid = null;
            }

            if (grille != null) {
                grille.Dispose ();
                grille = null;
            }

            if (Playy != null) {
                Playy.Dispose ();
                Playy = null;
            }
        }
    }
}