using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
	public partial class frmEdit : Form
	{
		public frmEdit()
		{
			InitializeComponent();
		}

		public void SetStateCounty(string szState, string szCounty, string szTaxAuth, string szTaxAuthType)
		{
			this.cboxState_EditORB.Text = szState;
			this.cboxCounty_EditORB.Text = szCounty;
			this.cboxTaxAuth_EditORB.Text = szTaxAuth;
			this.cboxTaxAuthType_EditORB.Text = szTaxAuthType;
			this.Button_SEARCH.PerformClick();
		}
	}
}
