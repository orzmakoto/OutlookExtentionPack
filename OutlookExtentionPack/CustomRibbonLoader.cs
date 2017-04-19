using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Office = Microsoft.Office.Core;

namespace OutlookExtentionPack
{
	[ComVisible(true)]
	public class CustomRibbonLoader : Microsoft.Office.Core.IRibbonExtensibility
	{
		public CustomRibbonLoader()
		{
			Console.WriteLine("CustomRibbonLoader");
		}
		private Office.IRibbonUI ribbon;

		#region IRibbonExtensibility メンバー

		public void Ribbon_Load(Office.IRibbonUI ribbonUI)
		{
			this.ribbon = ribbonUI;
		}

		public string GetCustomUI(string RibbonID)
		{
			if (RibbonID == "Microsoft.Outlook.Mail.Compose")
			{
				return GetResourceText("OutlookExtentionPack.MailComposeAddin.xml");
			}
			return "";
		}

		private DateTime ttt;


		public void RibbonTest(Office.IRibbonControl control, bool pressed)
		{
			Test.Value1 = pressed;
			ttt = DateTime.Now;
			Console.WriteLine(control.Id);

			this.ribbon.InvalidateControl("CheckBox_AddSelfToCC");

			{
				Microsoft.Office.Interop.Outlook.Application application = Globals.ThisAddIn.Application;
				if (Test.Value1 == true)
				{
					application.ItemSend += OnItemSend;
				}
				else
				{
					application.ItemSend -= OnItemSend;
				}
			}
		}

		private void OnItemSend(object sendItem, ref bool cancel)
		{
			if (sendItem is Microsoft.Office.Interop.Outlook.MailItem && Test.Value1 == true)
			{
				var mailItem = sendItem as Microsoft.Office.Interop.Outlook.MailItem;
			}
		}

		public bool GetPressed(Office.IRibbonControl control)
		{
			return Test.Value1;
		}

		#endregion

		#region ヘルパー

		private static string GetResourceText(string resourceName)
		{
			Assembly asm = Assembly.GetExecutingAssembly();
			string[] resourceNames = asm.GetManifestResourceNames();
			for (int i = 0; i < resourceNames.Length; ++i)
			{
				if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
				{
					using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
					{
						if (resourceReader != null)
						{
							return resourceReader.ReadToEnd();
						}
					}
				}
			}
			return null;
		}
		#endregion
	}
}
