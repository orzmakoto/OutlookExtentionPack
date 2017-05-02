using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

using Outlook = Microsoft.Office.Interop.Outlook;
using OutlookExtentionPack.SubWindow.MailComposeAddin;
using Microsoft.Office.Interop.Outlook;

namespace OutlookExtentionPack
{
    public partial class MailReadAddin
    {
        Outlook.MailItem mailItem = null;

        private void MailReadAddin_Load(object sender, RibbonUIEventArgs e)
        {
            if (mailItem == null)
            {
                var inspector = base.Context as Microsoft.Office.Interop.Outlook.Inspector;
                mailItem = inspector.CurrentItem as Outlook.MailItem;
            }
        }

        private void btn_SaveAttFileForTemp_Click(object sender, RibbonControlEventArgs e)
        {
            var result = FileManager.CreateTempDirectory(mailItem.Subject);
            foreach (var item in mailItem.Attachments.Cast<Attachment>())
            {
                item.SaveAsFile(System.IO.Path.Combine(result.Path, item.FileName));
            }
            System.Diagnostics.Process.Start(result.Path);

        }
    }
}
