using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsApplication1
{
	[DesignerGenerated]
	public class Form4_pw : Form
	{
		private IContainer components;

		[AccessedThroughProperty("WebBrowser1")]
		private WebBrowser _WebBrowser1;

		internal virtual WebBrowser WebBrowser1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._WebBrowser1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._WebBrowser1 = value;
			}
		}

		[DebuggerNonUserCode]
		public Form4_pw()
		{
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && this.components != null)
				{
					this.components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.WebBrowser1 = new WebBrowser();
			this.SuspendLayout();
			this.WebBrowser1.Dock = DockStyle.Fill;
			this.WebBrowser1.Location = new Point(0, 0);
			this.WebBrowser1.Size = new System.Drawing.Size(20, 20);
			this.WebBrowser1.Name = "WebBrowser1";
			this.WebBrowser1.Size = new System.Drawing.Size(536, 370);
			this.WebBrowser1.TabIndex = 0;
			this.WebBrowser1.Url = new Uri("T:\\Title Insurance Policy Forms\\2006 Policy Templates\\policy warehouse\\pol-warehouse-frames.htm", UriKind.Absolute);
			this.AutoScaleDimensions = new SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(536, 370);
			this.ClientSize = this.Size;
			this.Controls.Add(this.WebBrowser1);
			this.Name = "Form4_pw";
			this.Text = "iMS Policy Warehouse";
			this.ResumeLayout(false);
		}
	}
}