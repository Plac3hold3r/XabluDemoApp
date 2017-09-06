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

namespace XabluAppTest.iOS.Views
{
    [Register ("HomeViewController")]
    partial class HomeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton testButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView testCollectionView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel testLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (testButton != null) {
                testButton.Dispose ();
                testButton = null;
            }

            if (testCollectionView != null) {
                testCollectionView.Dispose ();
                testCollectionView = null;
            }

            if (testLabel != null) {
                testLabel.Dispose ();
                testLabel = null;
            }
        }
    }
}