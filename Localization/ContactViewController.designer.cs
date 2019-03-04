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

namespace Localization
{
    [Register ("ContactViewController")]
    partial class ContactViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField fullName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField mobile { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton save { get; set; }

        [Action ("Save:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Save (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (fullName != null) {
                fullName.Dispose ();
                fullName = null;
            }

            if (mobile != null) {
                mobile.Dispose ();
                mobile = null;
            }

            if (save != null) {
                save.Dispose ();
                save = null;
            }
        }
    }
}