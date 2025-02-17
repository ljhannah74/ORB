namespace WindowsApplication1
{	partial class SplashScreen1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			//
			// MainLayoutPanel
			//
			this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.MainLayoutPanel.BackgroundImage = WindowsApplication1.Resources.ims_ORB_logo;
			this.MainLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.MainLayoutPanel.ColumnCount = 2;
			this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 243f));
			this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100f));
			this.MainLayoutPanel.Controls.Add(this.DetailsLayoutPanel, 1, 1);
			this.MainLayoutPanel.Controls.Add(this.ApplicationTitle, 0, 1);
			this.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.MainLayoutPanel.Name = "MainLayoutPanel";
			this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 198f));
			this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58f));
			this.MainLayoutPanel.Size = new System.Drawing.Size(463, 303);
			this.MainLayoutPanel.TabIndex = 0;
			//
			// DetailsLayoutPanel
			//
			this.DetailsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.DetailsLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.DetailsLayoutPanel.BackColor = System.Drawing.Color.Transparent;
			this.DetailsLayoutPanel.ColumnCount = 1;
			this.DetailsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247f));
			this.DetailsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142f));
			this.DetailsLayoutPanel.Controls.Add(this.Copyright, 0, 1);
			this.DetailsLayoutPanel.Controls.Add(this.Version, 0, 0);
			this.DetailsLayoutPanel.Location = new System.Drawing.Point(246, 237);
			this.DetailsLayoutPanel.Name = "DetailsLayoutPanel";
			this.DetailsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33f));
			this.DetailsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33f));
			this.DetailsLayoutPanel.Size = new System.Drawing.Size(214, 63);
			this.DetailsLayoutPanel.TabIndex = 1;
			//
			// Version
			//
			this.Version = new System.Windows.Forms.Label();
			this.Version.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.Version.BackColor = System.Drawing.Color.Transparent;
			this.Version.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Version.Location = new System.Drawing.Point(41, 3);
			this.Version.Name = "Version";
			this.Version.Size = new System.Drawing.Size(164, 24);
			this.Version.TabIndex = 1;
			this.Version.Text = "Version {0}.{1:00}";
			this.Version.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// Copyright
			//
			this.Copyright = new System.Windows.Forms.Label();
			this.Copyright.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.Copyright.BackColor = System.Drawing.Color.Transparent;
			this.Copyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Copyright.Location = new System.Drawing.Point(3, 38);
			this.Copyright.Name = "Copyright";
			this.Copyright.Size = new System.Drawing.Size(202, 25);
			this.Copyright.TabIndex = 2;
			this.Copyright.Text = "Copyright";
			this.Copyright.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ApplicationTitle
			//
			this.ApplicationTitle = new System.Windows.Forms.Label();
			this.ApplicationTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.ApplicationTitle.BackColor = System.Drawing.Color.Transparent;
			this.ApplicationTitle.Font = new System.Drawing.Font("Leelawadee", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.ApplicationTitle.Location = new System.Drawing.Point(3, 204);
			this.ApplicationTitle.Name = "ApplicationTitle";
			this.ApplicationTitle.Size = new System.Drawing.Size(237, 93);
			this.ApplicationTitle.TabIndex = 0;
			this.ApplicationTitle.Text = "Application Title";
			this.ApplicationTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// SplashScreen1
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(463, 303);
			this.ControlBox = false;
			this.Controls.Add(this.MainLayoutPanel);
			this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SplashScreen1";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(SplashScreen1_Load);
		}

		#endregion

		private System.Windows.Forms.Label ApplicationTitle;
		private System.Windows.Forms.Label Version;
		private System.Windows.Forms.Label Copyright;
		private System.Windows.Forms.TableLayoutPanel MainLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel DetailsLayoutPanel;
	}
}