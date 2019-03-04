using Foundation;
using System;
using UIKit;

namespace Localization
{
    public partial class ContactViewController : UIViewController
    {
        public NSDictionary contact;

        public ContactViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (contact != null)
            {
                fullName.Text = contact.ValueForKey((NSString)"fullName").ToString();
                mobile.Text = contact.ValueForKey((NSString)"mobile").ToString();
                save.Hidden = true;
                this.Title = fullName.Text;
            }
            else
            {
                this.Title = "New Contact";
            }
        }

        partial void Save(UIButton sender)
        {
            NSMutableArray contacts;

            var userDefaults = NSUserDefaults.StandardUserDefaults;
            var data = userDefaults.ValueForKey((NSString)"contacts");
            if (data != null)
            {
                contacts = (NSMutableArray)data;
            }
            else
            {
                contacts = new NSMutableArray();
            }

            contacts.Add(new NSDictionary(
                (NSString)"fullName", fullName.Text,
                (NSString)"mobile", mobile.Text,
                (NSString)"createdOn", NSDate.FromTimeIntervalSince1970(0)
            ));

            userDefaults.SetValueForKey(contacts, (NSString)"contacts");
            userDefaults.Synchronize();

            this.DismissViewController(true, null);
        }
    }
}