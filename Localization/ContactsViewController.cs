using Foundation;
using System;
using UIKit;

namespace Localization
{
    public partial class ContactsViewController : UITableViewController
    {
        private NSArray contacts;

        public ContactsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var data = NSUserDefaults.StandardUserDefaults.ValueForKey((NSString)"contacts");
            if (data != null)
            {
                contacts = (NSArray)data;
            }
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            if (contacts == null)
            {
                return 0;
            }

            return (nint)contacts.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = TableView.DequeueReusableCell("Cell", indexPath);

            var contact = contacts.GetItem<NSDictionary>((nuint)indexPath.Row);
            cell.TextLabel.Text = contact.ValueForKey((NSString)"fullName").ToString();
            return cell;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (sender != null)
            {
                NSDictionary contact = (NSDictionary)sender;
                ContactViewController contactViewController = (ContactViewController)segue.DestinationViewController;
                contactViewController.contact = contact;
            }
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            var contact = contacts.GetItem<NSDictionary>((nuint)indexPath.Row);
            this.PerformSegue("ContactSegue", contact);
        }

        partial void AddContact(UIBarButtonItem sender)
        {
            this.PerformSegue("ContactSegue", null);
        }
    }
}