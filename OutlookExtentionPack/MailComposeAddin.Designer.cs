
namespace OutlookExtentionPack
{
	partial class MailComposeAddin : Microsoft.Office.Tools.Ribbon.RibbonBase
	{
		/// <summary>
		/// デザイナー変数が必要です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public MailComposeAddin()
			: base(Globals.Factory.GetRibbonFactory())
		{
			InitializeComponent();
		}

		/// <summary> 
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region コンポーネント デザイナーで生成されたコード

		/// <summary>
		/// デザイナーのサポートに必要なメソッドです。
		/// このメソッドの内容をコード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.splitButton1 = this.Factory.CreateRibbonSplitButton();
            this.bt_Clip2Attached2 = this.Factory.CreateRibbonButton();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.bt_Clip2CompressAttached = this.Factory.CreateRibbonSplitButton();
            this.bt_Clip2CompressAttached2 = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.bt_Attached2Compress = this.Factory.CreateRibbonSplitButton();
            this.bt_Attached2CompressSetting = this.Factory.CreateRibbonButton();
            this.bt_NewPassMail = this.Factory.CreateRibbonButton();
            this.tab2 = this.Factory.CreateRibbonTab();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.splitButton2 = this.Factory.CreateRibbonSplitButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.splitButton3 = this.Factory.CreateRibbonSplitButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group3.SuspendLayout();
            this.tab2.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Label = "添付ツール";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.splitButton1);
            this.group1.Items.Add(this.separator2);
            this.group1.Items.Add(this.bt_Clip2CompressAttached);
            this.group1.Label = "クリップボード";
            this.group1.Name = "group1";
            // 
            // splitButton1
            // 
            this.splitButton1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.splitButton1.Image = global::OutlookExtentionPack.Properties.Resources.addAttached;
            this.splitButton1.Items.Add(this.bt_Clip2Attached2);
            this.splitButton1.Label = "追加    ";
            this.splitButton1.Name = "splitButton1";
            this.splitButton1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Clip2Attached_Click);
            // 
            // bt_Clip2Attached2
            // 
            this.bt_Clip2Attached2.Image = global::OutlookExtentionPack.Properties.Resources.Plus;
            this.bt_Clip2Attached2.Label = "名前を付けて追加";
            this.bt_Clip2Attached2.Name = "bt_Clip2Attached2";
            this.bt_Clip2Attached2.ShowImage = true;
            this.bt_Clip2Attached2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bt_Clip2Attached2_Click);
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // bt_Clip2CompressAttached
            // 
            this.bt_Clip2CompressAttached.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.bt_Clip2CompressAttached.Image = global::OutlookExtentionPack.Properties.Resources.addAttachedCompress;
            this.bt_Clip2CompressAttached.Items.Add(this.bt_Clip2CompressAttached2);
            this.bt_Clip2CompressAttached.Label = "圧縮して追加";
            this.bt_Clip2CompressAttached.Name = "bt_Clip2CompressAttached";
            this.bt_Clip2CompressAttached.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bt_Clip2CompressAttached_Click);
            // 
            // bt_Clip2CompressAttached2
            // 
            this.bt_Clip2CompressAttached2.Image = global::OutlookExtentionPack.Properties.Resources.Plus;
            this.bt_Clip2CompressAttached2.Label = "名前を付けて追加";
            this.bt_Clip2CompressAttached2.Name = "bt_Clip2CompressAttached2";
            this.bt_Clip2CompressAttached2.ShowImage = true;
            this.bt_Clip2CompressAttached2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bt_Clip2CompressAttached2_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.bt_Attached2Compress);
            this.group3.Items.Add(this.bt_NewPassMail);
            this.group3.Label = "圧縮";
            this.group3.Name = "group3";
            // 
            // bt_Attached2Compress
            // 
            this.bt_Attached2Compress.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.bt_Attached2Compress.Enabled = false;
            this.bt_Attached2Compress.Image = global::OutlookExtentionPack.Properties.Resources.AttachedToCompress;
            this.bt_Attached2Compress.Items.Add(this.bt_Attached2CompressSetting);
            this.bt_Attached2Compress.Label = "添付を圧縮";
            this.bt_Attached2Compress.Name = "bt_Attached2Compress";
            this.bt_Attached2Compress.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bt_Attached2Compress_Click);
            // 
            // bt_Attached2CompressSetting
            // 
            this.bt_Attached2CompressSetting.Image = global::OutlookExtentionPack.Properties.Resources.PanelSettings;
            this.bt_Attached2CompressSetting.Label = "詳細設定";
            this.bt_Attached2CompressSetting.Name = "bt_Attached2CompressSetting";
            this.bt_Attached2CompressSetting.ShowImage = true;
            this.bt_Attached2CompressSetting.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bt_Attached2CompressSetting_Click);
            // 
            // bt_NewPassMail
            // 
            this.bt_NewPassMail.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.bt_NewPassMail.Enabled = false;
            this.bt_NewPassMail.Image = global::OutlookExtentionPack.Properties.Resources.addAttachedName;
            this.bt_NewPassMail.Label = "パスワードメール作成";
            this.bt_NewPassMail.Name = "bt_NewPassMail";
            this.bt_NewPassMail.ShowImage = true;
            this.bt_NewPassMail.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bt_NewPassMail_Click);
            // 
            // tab2
            // 
            this.tab2.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab2.ControlId.OfficeId = "TabNewMailMessage";
            this.tab2.Groups.Add(this.group2);
            this.tab2.Label = "TabNewMailMessage";
            this.tab2.Name = "tab2";
            // 
            // group2
            // 
            this.group2.Items.Add(this.splitButton2);
            this.group2.Label = "添付";
            this.group2.Name = "group2";
            this.group2.Position = this.Factory.RibbonPosition.AfterOfficeId("GroupClipboard");
            // 
            // splitButton2
            // 
            this.splitButton2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.splitButton2.Image = global::OutlookExtentionPack.Properties.Resources.addAttached;
            this.splitButton2.Items.Add(this.button1);
            this.splitButton2.Label = "追加    ";
            this.splitButton2.Name = "splitButton2";
            this.splitButton2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Clip2Attached_Click);
            // 
            // button1
            // 
            this.button1.Image = global::OutlookExtentionPack.Properties.Resources.Plus;
            this.button1.Label = "名前を付けて追加";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bt_Clip2Attached2_Click);
            // 
            // splitButton3
            // 
            this.splitButton3.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.splitButton3.Label = "splitButton2";
            this.splitButton3.Name = "splitButton3";
            // 
            // MailComposeAddin
            // 
            this.Name = "MailComposeAddin";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose";
            this.Tabs.Add(this.tab2);
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.NewMailAttachedTool_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
		internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
		internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitButton1;
		internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton bt_Clip2CompressAttached;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton bt_Clip2Attached2;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton bt_Clip2CompressAttached2;
		internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
		internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
		internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton bt_Attached2Compress;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton bt_Attached2CompressSetting;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton bt_NewPassMail;
        private Microsoft.Office.Tools.Ribbon.RibbonTab tab2;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitButton3;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitButton2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
    }

    partial class ThisRibbonCollection
	{
		internal MailComposeAddin Ribbon2
		{
			get { return this.GetRibbon<MailComposeAddin>(); }
		}
	}
}
