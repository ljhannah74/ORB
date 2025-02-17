using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.CompilerServices;
using ORB_DLL.Orb;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
	public partial class frm_Edit : Form
	{
		

		private System.Data.DataTable dt0;

		private F2_Resource_Lookup orb_obj;

		private Statutes_Lookup orbStats;

		private int i;

		private int c;

		private string dsn;

		private StringBuilder sb;

		private System.Data.DataTable dt;

		private OleDbDataAdapter da;

		private OleDbCommandBuilder cmdBuilder;

		private OleDbCommand cmd;

		private string Import_File;

		private string sheetNm1;

		private string sheetNm2;

		private string sheetNm3;

		private string sheetNm4;

		private string sheetNm5;

		private string sheetNm7;

		private string sheetNm8;




		public frm_Edit()
		{
			base.Load += new EventHandler(frm_Edit_Load);
			this.dt0 = new System.Data.DataTable();
			this.i = 0;
			this.c = 0;
			this.sb = new StringBuilder();
			this.dt = new System.Data.DataTable();
			this.da = new OleDbDataAdapter();
			this.cmdBuilder = new OleDbCommandBuilder();
			this.cmd = new OleDbCommand();
			this.Import_File = "T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\ORB_DATABASE.xls";
			this.sheetNm1 = "orb";
			this.sheetNm2 = "taxes";
			this.sheetNm3 = "state_counsels";
			this.sheetNm4 = "statutes";
			this.sheetNm5 = "other_logins";
			this.sheetNm7 = "misc";
			this.sheetNm8 = "customers";
			this.InitializeComponent();
		}

		private void Button_ExitApp_Click(object sender, EventArgs e)
		{
			this.Close();
			System.Windows.Forms.Application.OpenForms["Form1"].Close();
		}

		private void Button_EXITupdates_Click(object sender, EventArgs e)
		{
			Form1 thisForm = ((Form1)System.Windows.Forms.Application.OpenForms["Form1"]);
			thisForm.Panel2.Visible = false;
			thisForm.TabControl1.Visible = true;
			thisForm.SplitContainer1.Visible = true;
			thisForm.SplitContainer1.Panel1Collapsed = false;
			thisForm.SplitContainer1.Height = 363;
		}

		private void Button_NEW_Click(object sender, EventArgs e)
		{
			this.txtInput_NewTaxState.ResetText();
			this.txtInput_NewTaxCounty.ResetText();
			this.txtInput_TaxAuthType.ResetText();
			this.txtInput_TaxAuthName.ResetText();
			this.txtInput_TaxPayeeName.ResetText();
			this.txtInput_TaxPayeeStr1.ResetText();
			this.txtInput_LocalTaxURL.ResetText();
			this.txtInput_TaxPayeeStr2.ResetText();
			this.txtInput_TaxPayeeCity.ResetText();
			this.txtInput_TaxPayeeState.ResetText();
			this.txtInput_TaxPayeeZip.ResetText();
			this.txtInput_TaxPayeePhone.ResetText();
			this.txtInput_TaxPayeeFax.ResetText();
			this.txtInput_TaxOfficeHours.ResetText();
			this.txtInput_TaxCertFee.ResetText();
			this.txtInput_TaxDueDates.ResetText();
			this.txtInput_TaxComments.ResetText();
			this.chkbxTaxCertRequired.Checked = false;
		}

		private void Button_Reset_Click(object sender, EventArgs e)
		{
			this.cboxState_EditORB.ResetText();
			this.cboxCounty_EditORB.ResetText();
			this.cboxCounty_EditORB.Items.Clear();
			this.cboxCounty_EditORB.Text = "choose";
			this.cboxTaxAuth_EditORB.Items.Clear();
			this.cboxTaxAuth_EditORB.Text = "choose";
			this.cboxTaxAuthType_EditORB.Items.Clear();
			this.cboxTaxAuthType_EditORB.Text = "choose";
		}

		private void Button_SAVE_Click(object sender, EventArgs e)
		{
			int i;
			Microsoft.Office.Interop.Excel.Application applicationClass = new Microsoft.Office.Interop.Excel.ApplicationClass()
			{
				Visible = false
			};
			Workbook workbook = applicationClass.Workbooks.Open("T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\ORB_DATABASE.xls", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
			Worksheet worksheets = (Worksheet)workbook.Worksheets["orb"];
			Worksheet worksheet = (Worksheet)workbook.Worksheets["taxes"];
			Worksheet worksheets1 = (Worksheet)workbook.Worksheets["statutes"];
			Worksheet worksheet1 = (Worksheet)workbook.Worksheets["Letters"];
			Worksheet worksheets2 = (Worksheet)workbook.Worksheets["misc"];
			Worksheet worksheet2 = (Worksheet)workbook.Worksheets["customers"];
			long str = (long)0;
			long upper = (long)-1;
			long num = (long)0;
			long str1 = (long)0;
			long num1 = (long)0;
			long count = (long)2;
			string[,] strArrays = new string[8, 71];
			for (i = 1; i <= 70; i = checked(i + 1))
			{
				strArrays[0, i] = worksheet1.Range[string.Concat("A", Conversions.ToString(i)), Missing.Value].Value.ToString();
			}
			i = 1;
			if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.TabControl1.SelectedTab.Name.ToString(), "TabPage06", false) == 0)
			{
				strArrays[1, 0] = "orb";
				while (i <= 64)
				{
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(worksheets.Range[string.Concat(strArrays[0, i], Conversions.ToString(1)), Missing.Value].Value.ToString(), null, false) != 0)
					{
						strArrays[1, i] = worksheets.Range[string.Concat(strArrays[0, i], Conversions.ToString(1)), Missing.Value].Value.ToString();
					}
					i = checked(i + 1);
				}
				i = 1;
				while (count <= (long)worksheets.Rows.Count)
				{
					if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.cboxState_EditORB.SelectedItem, worksheets.Range[string.Concat("A", Conversions.ToString(count)), Missing.Value].Value, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.cboxCounty_EditORB.SelectedItem, worksheets.Range[string.Concat("B", Conversions.ToString(count)), Missing.Value].Value, false))))
					{
						str = count;
						count = checked(count + (long)worksheets.Rows.Count);
					}
					count = checked(count + (long)1);
				}
				count = (long)2;
				if (!this.ckbxSubscripNeeded.Checked)
				{
					worksheets.Range[string.Concat(this.ColHeads("sub_need", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "No";
				}
				else
				{
					worksheets.Range[string.Concat(this.ColHeads("sub_need", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "Yes";
				}
				if (!this.ckbxWeAreSubscribed.Checked)
				{
					worksheets.Range[string.Concat(this.ColHeads("we_subscribe", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "No";
				}
				else
				{
					worksheets.Range[string.Concat(this.ColHeads("we_subscribe", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "Yes";
				}
				worksheets.Range[string.Concat(this.ColHeads("sub_term", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_SubscripTerm.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("subFee", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_SubscripFeeAmt.Text.ToString();
				if (!this.ckbxUseDatatree.Checked)
				{
					worksheets.Range[string.Concat(this.ColHeads("dtree_desk", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "No";
				}
				else
				{
					worksheets.Range[string.Concat(this.ColHeads("dtree_desk", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "Yes";
				}
				if (!this.ckbxUseTapestry.Checked)
				{
					worksheets.Range[string.Concat(this.ColHeads("tap", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "No";
				}
				else
				{
					worksheets.Range[string.Concat(this.ColHeads("tap", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "Yes";
				}
				if (!this.ckbxUseRedVision.Checked)
				{
					worksheets.Range[string.Concat(this.ColHeads("rv", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "No";
				}
				else
				{
					worksheets.Range[string.Concat(this.ColHeads("rv", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "Yes";
				}
				string.Concat(this.ColHeads("comments", "orb", strArrays), Conversions.ToString(str));
				worksheets.Range[string.Concat(this.ColHeads("comments", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_Comments.Text.ToString();
				Marshal.FinalReleaseComObject(worksheets);
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.TabControl1.SelectedTab.Name.ToString(), "TabPage05", false) == 0)
			{
				strArrays[1, 0] = "orb";
				while (i <= 64)
				{
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(worksheets.Range[string.Concat(strArrays[0, i], Conversions.ToString(1)), Missing.Value].Value.ToString(), null, false) != 0)
					{
						strArrays[1, i] = worksheets.Range[string.Concat(strArrays[0, i], Conversions.ToString(1)), Missing.Value].Value.ToString();
					}
					i = checked(i + 1);
				}
				i = 1;
				while (count <= (long)worksheets.Rows.Count)
				{
					if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.cboxState_EditORB.SelectedItem, worksheets.Range[string.Concat("A", Conversions.ToString(count)), Missing.Value].Value, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.cboxCounty_EditORB.SelectedItem, worksheets.Range[string.Concat("B", Conversions.ToString(count)), Missing.Value].Value, false))))
					{
						str = count;
						count = checked(count + (long)worksheets.Rows.Count);
					}
					count = checked(count + (long)1);
				}
				count = (long)2;
				if (!this.ckbxProdIns.Checked)
				{
					worksheets.Range[string.Concat(this.ColHeads("ins", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "No";
				}
				else
				{
					worksheets.Range[string.Concat(this.ColHeads("ins", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "Yes";
				}
				if (!this.ckbxProdPropReports.Checked)
				{
					worksheets.Range[string.Concat(this.ColHeads("props", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "No";
				}
				else
				{
					worksheets.Range[string.Concat(this.ColHeads("props", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "Yes";
				}
				if (!this.ckbxProdDocRet.Checked)
				{
					worksheets.Range[string.Concat(this.ColHeads("copy", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "No";
				}
				else
				{
					worksheets.Range[string.Concat(this.ColHeads("copy", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "Yes";
				}
				Marshal.FinalReleaseComObject(worksheets);
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.TabControl1.SelectedTab.Name.ToString(), "TabPage01", false) == 0)
			{
				strArrays[1, 0] = "orb";
				while (i <= 64)
				{
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(worksheets.Range[string.Concat(strArrays[0, i], Conversions.ToString(1)), Missing.Value].Value.ToString(), null, false) != 0)
					{
						strArrays[1, i] = worksheets.Range[string.Concat(strArrays[0, i], Conversions.ToString(1)), Missing.Value].Value.ToString();
					}
					i = checked(i + 1);
				}
				i = 1;
				while (count <= (long)worksheets.Rows.Count)
				{
					if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.cboxState_EditORB.SelectedItem, worksheets.Range[string.Concat("A", Conversions.ToString(count)), Missing.Value].Value, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.cboxCounty_EditORB.SelectedItem, worksheets.Range[string.Concat("B", Conversions.ToString(count)), Missing.Value].Value, false))))
					{
						str = count;
						count = checked(count + (long)worksheets.Rows.Count);
					}
					count = checked(count + (long)1);
				}
				count = (long)2;
				if (!this.ckbxLoginRequired.Checked)
				{
					worksheets.Range[string.Concat(this.ColHeads("login_req", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "N";
				}
				else
				{
					worksheets.Range[string.Concat(this.ColHeads("login_req", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = "Y";
				}
				worksheets.Range[string.Concat(this.ColHeads("land_url", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_LandIndexURL.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("county_user", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_LandUsername.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("county_pwd", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_LandPwd.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("index_date", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_LandIndexDate.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("img_date", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_LandImageDate.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("copy_source", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_CopySource.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("copy_pmt_method", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_Copy_Pmt_Method.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("copyFeeAmt", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtCopyFeeAmount.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("index_pmt_method", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_Index_Pmt_Method.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("subscrFeeAmt", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_SubscripFeeAmt.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("subscr_term", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_SubscripTerm.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("assessor_url", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_AssessorURL.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("assessor_user", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_AssessorUsername.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("assessor_pwd", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_AssessorPwd.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("tax_url", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_TaxCountyURL.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("tax_user", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_TaxCountyUsername.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("tax_pwd", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_TaxCountyPwd.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("delinq_tax_url", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_DelinqTaxURL.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("tax2_url", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_Tax2URL.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("tax2_user", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_TaxLocalUsername.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("tax2_pwd", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_TaxLocalPwd.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("ucc_url", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_UCC_url.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("muniCourt_url", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_MuniCtURL.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("muni_user", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_MuniCtUsername.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("muni_pwd", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_MuniCtPwd.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("prothon_url", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_ProthonURL.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("pro_user", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_ProthonUsername.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("pro_pwd", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_ProthonPwd.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("sheriff_url", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_SheriffURL.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("court_url", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_CivCtIndexURL.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("court_user", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_CivCtUsername.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("court_pwd", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_CivCtPwd.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("foreclosure_url", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_ForeclosureURL.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("probate_url", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_ProbateURL.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("probate_user", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_ProbateUsername.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("probate_pwd", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_ProbatePwd.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("map_url", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_MapURL.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("plat_url", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_PlatsURL.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("county_homepage", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_CountyHomeURL.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("other_url", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_OtherURL.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("other_user", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_OtherURLUsername.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("other_pwd", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_OtherURLPwd.Text.ToString();
				worksheets.Range[string.Concat(this.ColHeads("index_source", "orb", strArrays), Conversions.ToString(str)), Missing.Value].Value = this.txtInput_LandIndexSource.Text.ToString();
				Marshal.FinalReleaseComObject(worksheets);
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.TabControl1.SelectedTab.Name.ToString(), "TabPage03", false) == 0)
			{
				strArrays[2, 0] = "taxes";
				while (i <= 21)
				{
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(worksheet.Range[string.Concat(strArrays[0, i], Conversions.ToString(1)), Missing.Value].Value.ToString(), "", false) != 0)
					{
						strArrays[2, i] = worksheet.Range[string.Concat(strArrays[0, i], Conversions.ToString(1)), Missing.Value].Value.ToString();
					}
					i = checked(i + 1);
				}
				i = 1;
				this.cboxState_EditORB.Text = this.txtInput_NewTaxState.Text.ToUpper();
				this.cboxCounty_EditORB.Text = this.txtInput_NewTaxCounty.Text.ToUpper();
				this.cboxTaxAuth_EditORB.Text = this.txtInput_TaxAuthName.Text.ToUpper();
				this.cboxTaxAuthType_EditORB.Text = this.txtInput_TaxAuthType.Text.ToUpper();
				while (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Convert.ToString(RuntimeHelpers.GetObjectValue(worksheet.Range[string.Concat("A", Conversions.ToString(count)), Missing.Value].Value)), "", false) != 0)
				{
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboxState_EditORB.Text, Convert.ToString(RuntimeHelpers.GetObjectValue(worksheet.Range[string.Concat("A", Conversions.ToString(count)), Missing.Value].Value)), false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboxCounty_EditORB.Text, Convert.ToString(RuntimeHelpers.GetObjectValue(worksheet.Range[string.Concat("B", Conversions.ToString(count)), Missing.Value].Value)), false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboxTaxAuth_EditORB.Text, Convert.ToString(RuntimeHelpers.GetObjectValue(worksheet.Range[string.Concat("C", Conversions.ToString(count)), Missing.Value].Value)), false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboxTaxAuthType_EditORB.Text, Convert.ToString(RuntimeHelpers.GetObjectValue(worksheet.Range[string.Concat("D", Conversions.ToString(count)), Missing.Value].Value)), false) == 0)
					{
						upper = count;
					}
					count = checked(count + (long)1);
				}
				if (upper == (long)-1)
				{
					upper = count;
				}
				count = (long)2;
				worksheet.Range[string.Concat(this.ColHeads("st", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_NewTaxState.Text.ToString().ToUpper();
				worksheet.Range[string.Concat(this.ColHeads("county", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_NewTaxCounty.Text.ToString().ToUpper();
				worksheet.Range[string.Concat(this.ColHeads("tax_auth", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_TaxAuthName.Text.ToString().ToUpper();
				worksheet.Range[string.Concat(this.ColHeads("tax_auth_type", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_TaxAuthType.Text.ToString().ToUpper();
				worksheet.Range[string.Concat(this.ColHeads("dt_verified", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txt_TaxDateVerified.Text.ToString();
				worksheet.Range[string.Concat(this.ColHeads("locTx_url", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_LocalTaxURL.Text.ToString();
				worksheet.Range[string.Concat(this.ColHeads("phone", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_TaxPayeePhone.Text.ToString();
				worksheet.Range[string.Concat(this.ColHeads("fax", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_TaxPayeeFax.Text.ToString();
				worksheet.Range[string.Concat(this.ColHeads("cert_req", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.chkbxTaxCertRequired.Text.ToString();
				worksheet.Range[string.Concat(this.ColHeads("cert_fee", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_TaxCertFee.Text.ToString();
				worksheet.Range[string.Concat(this.ColHeads("cycle", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.cboxInput_TaxBillingCycle.Text.ToString();
				worksheet.Range[string.Concat(this.ColHeads("due_dates", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_TaxDueDates.Text.ToString();
				worksheet.Range[string.Concat(this.ColHeads("hours", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_TaxOfficeHours.Text.ToString();
				worksheet.Range[string.Concat(this.ColHeads("notes", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_TaxComments.Text.ToString();
				worksheet.Range[string.Concat(this.ColHeads("tat", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_TaxCertTAT.Text.ToString();
				worksheet.Range[string.Concat(this.ColHeads("payee", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_TaxPayeeName.Text.ToString();
				worksheet.Range[string.Concat(this.ColHeads("street1", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_TaxPayeeStr1.Text.ToString();
				worksheet.Range[string.Concat(this.ColHeads("street2", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_TaxPayeeStr2.Text.ToString();
				worksheet.Range[string.Concat(this.ColHeads("city", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_TaxPayeeCity.Text.ToString();
				worksheet.Range[string.Concat(this.ColHeads("tx_st", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_TaxPayeeState.Text.ToString();
				worksheet.Range[string.Concat(this.ColHeads("zip", "taxes", strArrays), Conversions.ToString(upper)), Missing.Value].Value = this.txtInput_TaxPayeeZip.Text.ToString();
				Marshal.FinalReleaseComObject(worksheet);
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.TabControl1.SelectedTab.Name.ToString(), "TabPage07", false) == 0)
			{
				strArrays[4, 0] = "statutes";
				while (i <= 27)
				{
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(worksheets1.Range[string.Concat(strArrays[0, i], Conversions.ToString(1)), Missing.Value].Value.ToString(), "", false) != 0)
					{
						strArrays[4, i] = worksheets1.Range[string.Concat(strArrays[0, i], Conversions.ToString(1)), Missing.Value].Value.ToString();
					}
					i = checked(i + 1);
				}
				i = 1;
				while (count <= (long)worksheets1.Rows.Count)
				{
					if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.cboxState_EditORB.SelectedItem, worksheets1.Range[string.Concat("A", Conversions.ToString(count)), Missing.Value].Value, false))
					{
						num = count;
						count = checked(count + (long)worksheets1.Rows.Count);
					}
					count = checked(count + (long)1);
				}
				count = (long)2;
				worksheets1.Range[string.Concat(this.ColHeads("mtg1RD", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_MtgRD.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("mtg1AM", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_MtgAM.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("helAM", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_HelocAM.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("helRD", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_HelocRD.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("mech_lien", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_MechLiens.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("NOC", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_Notice.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("LP", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_LisPendens.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("HOA", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_HOALien.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("hosp_lien", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_HospLien.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("claim_of_lien", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_ClaimOfLien.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("jgmt", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_Jgmt.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("supt_obl", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_SupportObl.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("state_jgmt", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_StateJgmt.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("aft_acq_lien", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_AfterAcquired.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("TE_rule", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_TE_Rule.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("cred_claims", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_CreditorClaims.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("pers_tx_liens", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_PersonalTax.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("forecl_redem_per", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_ForeclosureRedem.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("tax_redem_per", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_TaxTakingRedem.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("vesting", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_Vesting.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("spousal", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtInput_SOL_SpousalState.Text.ToString();
				worksheets1.Range[string.Concat(this.ColHeads("notes", "statutes", strArrays), Conversions.ToString(num)), Missing.Value].Value = this.txtSOL_notes.Text.ToString();
				Marshal.FinalReleaseComObject(worksheets1);
			}
			else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.TabControl1.SelectedTab.Name.ToString(), "TabPage1", false) == 0)
			{
				strArrays[7, 0] = "misc";
				while (i <= 17)
				{
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(worksheets2.Range[string.Concat(strArrays[0, i], Conversions.ToString(1)), Missing.Value].Value.ToString(), "", false) != 0)
					{
						strArrays[7, i] = worksheets2.Range[string.Concat(strArrays[0, i], Conversions.ToString(1)), Missing.Value].Value.ToString();
					}
					i = checked(i + 1);
				}
				i = 1;
				while (count <= (long)worksheets2.Rows.Count)
				{
					if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.cboxState_EditORB.SelectedItem, worksheets2.Range[string.Concat("A", Conversions.ToString(count)), Missing.Value].Value, false))
					{
						str1 = count;
						count = checked(count + (long)worksheets2.Rows.Count);
					}
					count = checked(count + (long)1);
				}
				count = (long)2;
				worksheets2.Range[string.Concat(this.ColHeads("sec_state_url", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = this.txtInput_Sec_of_State_url.Text.ToString();
				worksheets2.Range[string.Concat(this.ColHeads("dept_ins_url", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = this.txtInput_DOIurl.Text.ToString();
				worksheets2.Range[string.Concat(this.ColHeads("atty_notes", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = this.txtInput_AttyNotes.Text.ToString();
				worksheets2.Range[string.Concat(this.ColHeads("homestead_notes", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = this.txtInput_HomesteadNotes.Text.ToString();
				worksheets2.Range[string.Concat(this.ColHeads("deed_notes", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = this.txtInput_DeedNotes.Text.ToString();
				worksheets2.Range[string.Concat(this.ColHeads("policy_notes", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = this.txtInput_PolicyNotes.Text.ToString();
				worksheets2.Range[string.Concat(this.ColHeads("foreclosure_notes", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = this.txtInput_ForeclosureNotes.Text.ToString();
				worksheets2.Range[string.Concat(this.ColHeads("probate_notes", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = this.txtInput_ProbateNotes.Text.ToString();
				worksheets2.Range[string.Concat(this.ColHeads("notary_url", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = this.txtInput_NotaryURL.Text.ToString();
				worksheets2.Range[string.Concat(this.ColHeads("deed_prep", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = this.cbox_DeedPrep.Text.ToString();
				if (!this.ckbx_Homestead.Checked)
				{
					worksheets2.Range[string.Concat(this.ColHeads("homestead", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = "No";
				}
				else
				{
					worksheets2.Range[string.Concat(this.ColHeads("homestead", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = "Yes";
				}
				if (!this.ckbx_AttyTitleSearch.Checked)
				{
					worksheets2.Range[string.Concat(this.ColHeads("atty_search", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = "No";
				}
				else
				{
					worksheets2.Range[string.Concat(this.ColHeads("atty_search", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = "Yes";
				}
				if (!this.ckbx_AttyCloser.Checked)
				{
					worksheets2.Range[string.Concat(this.ColHeads("atty_close", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = "No";
				}
				else
				{
					worksheets2.Range[string.Concat(this.ColHeads("atty_close", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = "Yes";
				}
				if (!this.ckbx_BeingClause.Checked)
				{
					worksheets2.Range[string.Concat(this.ColHeads("being_clause", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = "No";
				}
				else
				{
					worksheets2.Range[string.Concat(this.ColHeads("being_clause", "misc", strArrays), Conversions.ToString(str1)), Missing.Value].Value = "Yes";
				}
				Marshal.FinalReleaseComObject(worksheets);
			}
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
			GC.WaitForPendingFinalizers();
			Marshal.FinalReleaseComObject(worksheet1);
			workbook.Close(true, Missing.Value, Missing.Value);
			Marshal.FinalReleaseComObject(workbook);
			applicationClass.Quit();
			Marshal.FinalReleaseComObject(applicationClass);
		}

		private void Button_SEARCH_Click(object sender, EventArgs e)
		{
			string text = this.cboxState_EditORB.Text;
			string str = this.cboxCounty_EditORB.Text;
			string text1 = this.cboxTaxAuth_EditORB.Text;
			string str1 = this.cboxTaxAuthType_EditORB.Text;
			if (!(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(text, "", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(text1, "", false) == 0) & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "", false) != 0)
			{
				this.orb_obj = new F2_Resource_Lookup(text, str);
				this.cmd.CommandType = CommandType.TableDirect;
				this.dsn = string.Concat("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", this.Import_File, ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"");
				this.cmd.CommandText = string.Concat("Select * From [", this.sheetNm1, "$]");
				this.cmd.Connection = new OleDbConnection(this.dsn);
				this.da.SelectCommand = this.cmd;
				this.cmdBuilder.DataAdapter = this.da;
				this.da.Fill(this.dt);
				this.da.Dispose();
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboxState_EditORB.Text, "", false) != 0)
				{
					while (this.c <= checked(this.dt.Rows.Count - 1))
					{
						if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt.Rows[this.c]["st"].ToString(), this.cboxState_EditORB.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt.Rows[this.c]["county"].ToString(), this.cboxCounty_EditORB.Text, false) == 0)
						{
							this.txtInput_LandIndexURL.Text = this.orb_obj.F2land_url;
							this.txtInput_LandUsername.Text = this.orb_obj.F2county_user;
							this.txtInput_LandPwd.Text = this.orb_obj.F2county_pwd;
							if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2Login_Required, "Y", false) == 0)
							{
								this.ckbxLoginRequired.Checked = true;
							}
							else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2Login_Required, "N", false) == 0)
							{
								this.ckbxLoginRequired.Checked = false;
							}
							else if (null == this.orb_obj.F2Login_Required | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2Login_Required, "**", false) == 0)
							{
								this.ckbxLoginRequired.Checked = false;
							}
							this.txtInput_CivCtIndexURL.Text = this.orb_obj.F2court_url;
							this.txtInput_CivCtUsername.Text = this.orb_obj.F2court_user;
							this.txtInput_CivCtPwd.Text = this.orb_obj.F2court_pwd;
							this.txtInput_MuniCtURL.Text = this.orb_obj.F2muniCourt_url;
							this.txtInput_MuniCtUsername.Text = this.orb_obj.F2muniCourt_user;
							this.txtInput_MuniCtPwd.Text = this.orb_obj.F2muniCourt_pwd;
							this.txtInput_TaxCountyURL.Text = this.orb_obj.F2tax_url;
							this.txtInput_TaxCountyUsername.Text = this.orb_obj.F2tax_user;
							this.txtInput_TaxCountyPwd.Text = this.orb_obj.F2tax_pwd;
							this.txtInput_Tax2URL.Text = this.orb_obj.F2tax2_url;
							this.txtInput_TaxLocalUsername.Text = this.orb_obj.F2tax2_user;
							this.txtInput_TaxLocalPwd.Text = this.orb_obj.F2tax2_pwd;
							this.txtInput_PlatsURL.Text = this.orb_obj.F2plat_url;
							this.txtInput_MapURL.Text = this.orb_obj.F2map_url;
							this.txtInput_ProthonURL.Text = this.orb_obj.F2prothon_url;
							this.txtInput_ProthonUsername.Text = this.orb_obj.F2pro_user;
							this.txtInput_ProthonPwd.Text = this.orb_obj.F2pro_pwd;
							this.txtInput_AssessorURL.Text = this.orb_obj.F2assessor_url;
							this.txtInput_AssessorUsername.Text = this.orb_obj.F2assessor_user;
							this.txtInput_AssessorPwd.Text = this.orb_obj.F2assessor_pwd;
							this.txtInput_ProbateURL.Text = this.orb_obj.F2probate_url;
							this.txtInput_ProbateUsername.Text = this.orb_obj.F2pro_user;
							this.txtInput_ProbatePwd.Text = this.orb_obj.F2pro_pwd;
							this.txtInput_SheriffURL.Text = this.orb_obj.F2sheriff_url;
							this.txtInput_ForeclosureURL.Text = this.orb_obj.F2foreclosure_url;
							this.txtInput_CountyHomeURL.Text = this.orb_obj.F2county_homepage;
							this.txtInput_OtherURL.Text = this.orb_obj.F2other_url;
							this.txtInput_OtherURLUsername.Text = this.orb_obj.F2other_user;
							this.txtInput_OtherURLPwd.Text = this.orb_obj.F2other_pwd;
							this.txtInput_CopySource.Text = this.orb_obj.F2copy_source;
							this.txtInput_LandIndexSource.Text = this.orb_obj.F2index_source;
							this.txtCopyFeeAmount.Text = this.orb_obj.F2copyFeeAmt;
							this.txtInput_SubscripFeeAmt.Text = this.orb_obj.F2subFeeAmt;
							this.txtInput_SubscripTerm.Text = this.orb_obj.F2subTerm;
							this.txtInput_Index_Pmt_Method.Text = this.orb_obj.F2Index_pmt_method;
							this.txtInput_Copy_Pmt_Method.Text = this.orb_obj.F2Copy_pmt_method;
							this.txtInput_Comments.Text = this.orb_obj.F2comments;
							if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2sub_need, "Yes", false) != 0)
							{
								if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2sub_need, "yes", false) != 0)
								{
									if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2sub_need, "Y", false) == 0)
									{
										goto Label1;
									}
									if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2sub_need, "No", false) != 0)
									{
										if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2sub_need, "no", false) != 0)
										{
											if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2sub_need, "N", false) == 0)
											{
												goto Label2;
											}
											if (this.orb_obj.F2sub_need == null)
											{
												this.ckbxSubscripNeeded.Checked = false;
												goto Label0;
											}
											else
											{
												goto Label0;
											}
										}
									}
								Label2:
									this.ckbxSubscripNeeded.Checked = false;
									goto Label0;
								}
							}
						Label1:
							this.ckbxSubscripNeeded.Checked = true;
						Label0:
							if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2subscribed, "Yes", false) != 0)
							{
								if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2subscribed, "yes", false) != 0)
								{
									if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2subscribed, "Y", false) == 0)
									{
										goto Label4;
									}
									if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2subscribed, "No", false) != 0)
									{
										if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2subscribed, "no", false) != 0)
										{
											if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2subscribed, "N", false) == 0)
											{
												goto Label5;
											}
											if (this.orb_obj.F2subscribed == null)
											{
												this.ckbxWeAreSubscribed.Checked = false;
												goto Label3;
											}
											else
											{
												goto Label3;
											}
										}
									}
								Label5:
									this.ckbxWeAreSubscribed.Checked = false;
									goto Label3;
								}
							}
						Label4:
							this.ckbxWeAreSubscribed.Checked = true;
						Label3:
							if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2tap, "Yes", false) == 0)
							{
								this.ckbxUseTapestry.Checked = true;
							}
							else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2tap, "No", false) == 0)
							{
								this.ckbxUseTapestry.Checked = false;
							}
							else if (this.orb_obj.F2tap == null)
							{
								this.ckbxUseTapestry.Checked = false;
							}
							if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2rv, "Yes", false) == 0)
							{
								this.ckbxUseRedVision.Checked = true;
							}
							else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2rv, "No", false) == 0)
							{
								this.ckbxUseRedVision.Checked = false;
							}
							else if (this.orb_obj.F2rv != null)
							{
								this.ckbxUseRedVision.Checked = false;
							}
							if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2dtree_desk, "Yes", false) == 0)
							{
								this.ckbxUseDatatree.Checked = true;
							}
							else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2dtree_desk, "No", false) == 0)
							{
								this.ckbxUseDatatree.Checked = false;
							}
							else if (this.orb_obj.F2dtree_desk != null)
							{
								this.ckbxUseDatatree.Checked = false;
							}
							this.txtInput_LandImageDate.Text = this.orb_obj.F2img_date;
							this.txtInput_LandIndexDate.Text = this.orb_obj.F2index_date;
							this.txtInput_CivCourtImageDate.Text = this.orb_obj.F2courtImageDate;
							this.txtInput_CivCourtIndexDate.Text = this.orb_obj.F2courtIndexDate;
							if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2ins, "Yes", false) == 0)
							{
								this.ckbxProdIns.Checked = true;
							}
							else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2ins, "No", false) == 0)
							{
								this.ckbxProdIns.Checked = false;
							}
							else if (this.orb_obj.F2ins != null)
							{
								this.ckbxProdIns.Checked = false;
							}
							if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2props, "Yes", false) == 0)
							{
								this.ckbxProdPropReports.Checked = true;
							}
							else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2props, "No", false) == 0)
							{
								this.ckbxProdPropReports.Checked = false;
							}
							else if (this.orb_obj.F2props != null)
							{
								this.ckbxProdPropReports.Checked = false;
							}
							if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2doc_retrieval, "Yes", false) == 0)
							{
								this.ckbxProdDocRet.Checked = true;
							}
							else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.F2doc_retrieval, "No", false) == 0)
							{
								this.ckbxProdDocRet.Checked = false;
							}
							else if (this.orb_obj.F2doc_retrieval != null)
							{
								this.ckbxProdDocRet.Checked = false;
							}
							this.txtInput_Comments.Text = this.orb_obj.F2comments;
							this.c = checked(this.dt.Rows.Count + this.c);
						}
						this.c = checked(this.c + 1);
					}
				}
				OleDbCommand oleDbCommand = new OleDbCommand();
				System.Data.DataTable dataTable = new System.Data.DataTable();
				int num = 0;
				oleDbCommand.CommandType = CommandType.TableDirect;
				this.dsn = string.Concat("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", this.Import_File, ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"");
				oleDbCommand.CommandText = string.Concat("Select * From [", this.sheetNm2, "$]");
				oleDbCommand.Connection = new OleDbConnection(this.dsn);
				this.da.SelectCommand = oleDbCommand;
				this.cmdBuilder.DataAdapter = this.da;
				this.da.Fill(dataTable);
				this.da.Dispose();
				num = 0;
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboxTaxAuth_EditORB.Text, "", false) != 0)
				{
					while (num <= checked(dataTable.Rows.Count - 1))
					{
						if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["st"].ToString(), this.cboxState_EditORB.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["county"].ToString(), this.cboxCounty_EditORB.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["tax_auth"].ToString(), this.cboxTaxAuth_EditORB.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["tax_auth_type"].ToString(), this.cboxTaxAuthType_EditORB.Text, false) == 0)
						{
							this.txtInput_NewTaxState.Text = dataTable.Rows[num]["st"].ToString();
							this.txtInput_NewTaxCounty.Text = dataTable.Rows[num]["county"].ToString();
							this.txt_TaxDateVerified.Text = dataTable.Rows[num]["dt_verified"].ToString();
							this.lblTaxCounty.Text = string.Concat(this.lblTaxCounty.Text, dataTable.Rows[num]["county"].ToString());
							this.txtInput_TaxAuthType.Text = dataTable.Rows[num]["tax_auth_type"].ToString();
							this.txtInput_TaxAuthName.Text = dataTable.Rows[num]["tax_auth"].ToString();
							this.txtInput_TaxPayeeName.Text = dataTable.Rows[num]["payee"].ToString();
							this.txtInput_TaxPayeeStr1.Text = dataTable.Rows[num]["street1"].ToString();
							this.txtInput_LocalTaxURL.Text = dataTable.Rows[num]["locTx_url"].ToString();
							this.txtInput_TaxPayeeStr2.Text = dataTable.Rows[num]["street2"].ToString();
							this.txtInput_TaxPayeeCity.Text = dataTable.Rows[num]["city"].ToString();
							this.txtInput_TaxPayeeState.Text = dataTable.Rows[num]["tx_st"].ToString();
							this.txtInput_TaxPayeeZip.Text = dataTable.Rows[num]["zip"].ToString();
							this.txtInput_TaxPayeePhone.Text = dataTable.Rows[num]["phone"].ToString();
							this.txtInput_TaxPayeeFax.Text = dataTable.Rows[num]["fax"].ToString();
							this.txtInput_TaxOfficeHours.Text = dataTable.Rows[num]["hours"].ToString();
							this.txtInput_TaxCertFee.Text = dataTable.Rows[num]["cert_fee"].ToString();
							this.txtInput_TaxCertTAT.Text = dataTable.Rows[num]["tat"].ToString();
							this.txtInput_TaxDueDates.Text = dataTable.Rows[num]["due_dates"].ToString();
							this.txtInput_TaxComments.Text = dataTable.Rows[num]["notes"].ToString();
							this.txt_TaxDateVerified.Text = dataTable.Rows[num]["dt_verified"].ToString();
							this.cboxInput_TaxBillingCycle.Text = dataTable.Rows[num]["cycle"].ToString();
							if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["cert_req"].ToString(), "Y", false) == 0)
							{
								this.chkbxTaxCertRequired.Checked = true;
							}
							else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["cert_req"].ToString(), "N", false) == 0)
							{
								this.chkbxTaxCertRequired.Checked = false;
							}
							else if (dataTable.Rows[num]["cert_req"].ToString() != null)
							{
								this.chkbxTaxCertRequired.Checked = false;
							}
						}
						num = checked(num + 1);
					}
				}
				this.orbStats = new Statutes_Lookup(text);
				this.dt.Clear();
				this.cmd.CommandType = CommandType.TableDirect;
				this.dsn = string.Concat("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", this.Import_File, ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"");
				this.cmd.CommandText = string.Concat("Select * From [", this.sheetNm2, "$]");
				this.cmd.Connection = new OleDbConnection(this.dsn);
				this.da.SelectCommand = this.cmd;
				this.cmdBuilder.DataAdapter = this.da;
				this.da.Fill(this.dt);
				this.da.Dispose();
				this.c = 0;
				while (this.c <= checked(this.dt.Rows.Count - 1))
				{
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt.Rows[this.c]["st"].ToString(), text, false) == 0)
					{
						this.txtInput_SOL_MtgRD.Text = this.orbStats.SOL_MtgRD;
						this.txtInput_SOL_MtgAM.Text = this.orbStats.SOL_MtgAM;
						this.txtInput_SOL_HelocAM.Text = this.orbStats.SOL_HelocAM;
						this.txtInput_SOL_HelocRD.Text = this.orbStats.SOL_HelocRD;
						this.txtInput_SOL_MechLiens.Text = this.orbStats.SOL_Mech;
						this.txtInput_SOL_Notice.Text = this.orbStats.SOL_Notice;
						this.txtInput_SOL_LisPendens.Text = this.orbStats.SOL_lispen;
						this.txtInput_SOL_HOALien.Text = this.orbStats.SOL_HOA;
						this.txtInput_SOL_HospLien.Text = this.orbStats.SOL_Hosp;
						this.txtInput_SOL_ClaimOfLien.Text = this.orbStats.SOL_ClaimLien;
						this.txtInput_SOL_Jgmt.Text = this.orbStats.SOL_Jgmt;
						this.txtInput_SOL_SupportObl.Text = this.orbStats.SOL_Support;
						this.txtInput_SOL_StateJgmt.Text = this.orbStats.SOL_StateJgmt;
						this.txtInput_SOL_AfterAcquired.Text = this.orbStats.SOL_AftAcq;
						this.txtInput_SOL_TE_Rule.Text = this.orbStats.SOL_TERule;
						this.txtInput_SOL_CreditorClaims.Text = this.orbStats.SOL_Creditor_Claims;
						this.txtInput_SOL_PersonalTax.Text = this.orbStats.SOL_PersTax;
						this.txtInput_SOL_ForeclosureRedem.Text = this.orbStats.SOL_Foreclosure_RedemPer;
						this.txtInput_SOL_TaxTakingRedem.Text = this.orbStats.SOL_Tax_RedemPer;
						this.txtInput_SOL_SpousalState.Text = this.orbStats.SOL_Spousal;
						this.txtSOL_notes.Text = this.orbStats.SOL_notes;
						this.c = checked(this.dt.Rows.Count + this.c);
					}
					this.c = checked(this.c + 1);
				}
			}
			this.dt.Clear();
			this.cmd.CommandType = CommandType.TableDirect;
			this.dsn = string.Concat("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", this.Import_File, ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"");
			this.cmd.CommandText = string.Concat("Select * From [", this.sheetNm7, "$]");
			this.cmd.Connection = new OleDbConnection(this.dsn);
			this.da.SelectCommand = this.cmd;
			this.cmdBuilder.DataAdapter = this.da;
			this.da.Fill(this.dt);
			this.da.Dispose();
			this.c = 0;
			while (this.c <= checked(this.dt.Rows.Count - 1))
			{
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt.Rows[this.c]["st"].ToString(), text, false) == 0)
				{
					this.txtInput_Sec_of_State_url.Text = this.dt.Rows[this.c]["sec_state_url"].ToString();
					this.txtInput_DOIurl.Text = this.dt.Rows[this.c]["dept_ins_url"].ToString();
					this.txtInput_State_CodeURL.Text = this.dt.Rows[this.c]["state_code_url"].ToString();
					this.txtInput_AttyNotes.Text = this.dt.Rows[this.c]["atty_notes"].ToString();
					this.txtInput_HomesteadNotes.Text = this.dt.Rows[this.c]["homestead_notes"].ToString();
					this.txtInput_DeedNotes.Text = this.dt.Rows[this.c]["deed_notes"].ToString();
					this.txtInput_PolicyNotes.Text = this.dt.Rows[this.c]["policy_notes"].ToString();
					this.txtInput_ForeclosureNotes.Text = this.dt.Rows[this.c]["foreclosure_notes"].ToString();
					this.txtInput_ProbateNotes.Text = this.dt.Rows[this.c]["probate_notes"].ToString();
					this.txtInput_NotaryURL.Text = this.dt.Rows[this.c]["notary_url"].ToString();
					this.cbox_DeedPrep.Text = this.dt.Rows[this.c]["deed_prep"].ToString();
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt.Rows[this.c]["atty_search"].ToString(), "YES", false) == 0)
					{
						this.ckbx_AttyTitleSearch.Checked = true;
					}
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt.Rows[this.c]["atty_close"].ToString(), "YES", false) == 0)
					{
						this.ckbx_AttyCloser.Checked = true;
					}
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt.Rows[this.c]["being_clause"].ToString(), "YES", false) == 0)
					{
						this.ckbx_BeingClause.Checked = true;
					}
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt.Rows[this.c]["homestead"].ToString(), "YES", false) == 0)
					{
						this.ckbx_Homestead.Checked = true;
					}
					this.c = checked(this.dt.Rows.Count + this.c);
				}
				this.c = checked(this.c + 1);
			}
		}

		private void cboxCounty_EditORB_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.cmd.CommandType = CommandType.TableDirect;
			this.dsn = string.Concat("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", this.Import_File, ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"");
			this.cmd.CommandText = string.Concat("Select * From [", this.sheetNm2, "$]");
			this.cmd.Connection = new OleDbConnection(this.dsn);
			this.da.SelectCommand = this.cmd;
			this.cmdBuilder.DataAdapter = this.da;
			this.da.Fill(this.dt);
			this.da.Dispose();
			this.cboxTaxAuth_EditORB.Items.Clear();
			this.cboxTaxAuth_EditORB.ResetText();
			this.cboxTaxAuthType_EditORB.Items.Clear();
			this.cboxTaxAuthType_EditORB.ResetText();
			this.lblTaxCounty.ResetText();
			this.resetInputs();
			short num = 0;
			bool flag = false;
			while (this.i < this.dt.Rows.Count)
			{
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboxState_EditORB.Text.ToString(), this.dt.Rows[this.i]["st"].ToString(), false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboxCounty_EditORB.Text.ToString(), this.dt.Rows[this.i]["county"].ToString(), false) == 0)
				{
					this.cboxTaxAuth_EditORB.Items.Add("choose");
					num = 0;
					flag = false;
					while (num < this.cboxTaxAuth_EditORB.Items.Count)
					{
						if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboxTaxAuth_EditORB.Items[num].ToString(), this.dt.Rows[this.i]["tax_auth"].ToString(), false) == 0)
						{
							flag = true;
						}
						num = checked((short)(checked(num + 1)));
					}
					if (!flag)
					{
						this.cboxTaxAuth_EditORB.Items.Add(this.dt.Rows[this.i]["tax_auth"].ToString());
					}
				}
				this.i = checked(this.i + 1);
			}
			if (this.cboxTaxAuth_EditORB.Items.Contains(""))
			{
				this.cboxTaxAuth_EditORB.Items.Remove("");
			}
		}

		private void cboxState_EditORB_TextChanged(object sender, EventArgs e)
		{
			string text = this.cboxState_EditORB.Text;
			if (text.Length >= 2)
			{
				this.cboxCounty_EditORB.ResetText();
				this.cboxCounty_EditORB.Items.Clear();
				this.cboxTaxAuth_EditORB.ResetText();
				this.cboxTaxAuth_EditORB.Items.Clear();
				this.cboxTaxAuthType_EditORB.ResetText();
				this.cboxTaxAuthType_EditORB.Items.Clear();
				this.lblTaxCounty.ResetText();
				this.resetInputs();
				for (int i = 0; i < this.dt0.Rows.Count; i = checked(i + 1))
				{
					if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt0.Rows[i]["st"].ToString(), text, false) == 0)
					{
						this.cboxCounty_EditORB.Items.Add(this.dt0.Rows[i]["county"].ToString());
					}
				}
			}
		}

		private void cboxTaxAuth_EditORB_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.cmd.CommandType = CommandType.TableDirect;
			this.dsn = string.Concat("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", this.Import_File, ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"");
			this.cmd.CommandText = string.Concat("Select * From [", this.sheetNm2, "$]");
			this.cmd.Connection = new OleDbConnection(this.dsn);
			this.da.SelectCommand = this.cmd;
			this.cmdBuilder.DataAdapter = this.da;
			this.da.Fill(this.dt);
			this.da.Dispose();
			this.lblTaxCounty.ResetText();
			this.resetInputs();
			this.cboxTaxAuthType_EditORB.ResetText();
			this.cboxTaxAuthType_EditORB.Items.Clear();
			for (int i = 0; i < this.dt.Rows.Count; i = checked(i + 1))
			{
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt.Rows[i]["st"].ToString(), this.cboxState_EditORB.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt.Rows[i]["county"].ToString(), this.cboxCounty_EditORB.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt.Rows[i]["tax_auth"].ToString(), this.cboxTaxAuth_EditORB.Text, false) == 0)
				{
					if (!this.cboxTaxAuthType_EditORB.Items.Contains(this.dt.Rows[i]["tax_auth_type"].ToString()))
					{
						this.cboxTaxAuthType_EditORB.Items.Add(this.dt.Rows[i]["tax_auth_type"].ToString());
					}
				}
			}
		}

		private string ColHeads(string head, string shet, string[,] headers)
		{
			string str = "";
			short num = 1;
			long num1 = (long)1;
			while (num <= 7)
			{
				if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(headers[num, 0], shet, false) == 0)
				{
					while (num1 <= (long)70)
					{
						if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(headers[num, checked((int)num1)], head, false) == 0)
						{
							str = headers[0, checked((int)num1)];
							num1 = checked(num1 + (long)70);
							num = checked((short)(checked(num + 7)));
						}
						num1 = checked(num1 + (long)1);
					}
				}
				num = checked((short)(checked(num + 1)));
			}
			return str;
		}

		private void frm_Edit_Load(object sender, EventArgs e)
		{
			this.cmd.CommandType = CommandType.TableDirect;
			this.dsn = string.Concat("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", this.Import_File, ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"");
			this.cmd.CommandText = string.Concat("Select * From [", this.sheetNm1, "$]");
			this.cmd.Connection = new OleDbConnection(this.dsn);
			this.da.SelectCommand = this.cmd;
			this.cmdBuilder.DataAdapter = this.da;
			this.da.Fill(this.dt0);
			this.da.Dispose();
		}




		private void lblOpenORB_Click(object sender, EventArgs e)
		{
			Process.Start("T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\ORB_DATABASE.xls");
		}

		private void pboxOpenORB_Click(object sender, EventArgs e)
		{
			Process.Start("T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\ORB_DATABASE.xls");
		}

		private void pboxOpenORB_MouseHover(object sender, EventArgs e)
		{
			this.ToolTip1.SetToolTip(this.pboxOpenORB, "CLICK TO EDIT");
		}

		private void resetInputs()
		{
			this.txtInput_CopySource.ResetText();
			this.txtInput_LandIndexSource.ResetText();
			this.txtCopyFeeAmount.ResetText();
			this.txtInput_SubscripFeeAmt.ResetText();
			this.txtInput_SubscripTerm.ResetText();
			this.txtInput_Index_Pmt_Method.ResetText();
			this.txtInput_Comments.ResetText();
			this.ckbxSubscripNeeded.CheckState = CheckState.Unchecked;
			this.ckbxWeAreSubscribed.CheckState = CheckState.Unchecked;
			this.ckbxUseDatatree.CheckState = CheckState.Unchecked;
			this.ckbxUseRedVision.CheckState = CheckState.Unchecked;
			this.ckbxUseTapestry.CheckState = CheckState.Unchecked;
			this.ckbxProdDocRet.CheckState = CheckState.Unchecked;
			this.ckbxProdIns.CheckState = CheckState.Unchecked;
			this.ckbxProdPropReports.CheckState = CheckState.Unchecked;
			this.ckbxProdTaxReports.CheckState = CheckState.Unchecked;
			this.txtInput_CivCourtIndexDate.ResetText();
			this.txtInput_LandIndexDate.ResetText();
			this.txtInput_CivCourtImageDate.ResetText();
			this.txtInput_LandImageDate.ResetText();
			this.txtInput_MuniCourtImageDate.ResetText();
			this.txtInput_MuniCourtIndexDate.ResetText();
			this.txtInput_PlatImageDate.ResetText();
			this.txtInput_PlatIndexDate.ResetText();
			this.txtInput_LandIndexURL.ResetText();
			this.txtInput_CivCtIndexURL.ResetText();
			this.txtInput_TaxCountyURL.ResetText();
			this.txtInput_ProthonURL.ResetText();
			this.txtInput_AssessorURL.ResetText();
			this.txtInput_MapURL.ResetText();
			this.txtInput_ProbateURL.ResetText();
			this.txtInput_CountyHomeURL.ResetText();
			this.txtInput_ForeclosureURL.ResetText();
			this.txtInput_PlatsURL.ResetText();
			this.txtInput_MuniCtURL.ResetText();
			this.txtInput_Tax2URL.ResetText();
			this.txtInput_SheriffURL.ResetText();
			this.txtInput_LandUsername.ResetText();
			this.txtInput_LandPwd.ResetText();
			this.txtInput_CivCtUsername.ResetText();
			this.txtInput_CivCtPwd.ResetText();
			this.txtInput_TaxCountyUsername.ResetText();
			this.txtInput_TaxCountyPwd.ResetText();
			this.txtInput_ProthonUsername.ResetText();
			this.txtInput_ProthonPwd.ResetText();
			this.txtInput_LandImageDate.ResetText();
			this.txtInput_LandIndexDate.ResetText();
			this.ckbxUseRedVision.Checked = false;
			this.txtInput_NewTaxState.ResetText();
			this.txtInput_NewTaxCounty.ResetText();
			this.txt_TaxDateVerified.ResetText();
			this.txtInput_TaxAuthType.ResetText();
			this.txtInput_TaxAuthName.ResetText();
			this.txtInput_TaxPayeeName.ResetText();
			this.txtInput_TaxPayeeStr1.ResetText();
			this.txtInput_LocalTaxURL.ResetText();
			this.txtInput_TaxPayeeStr2.ResetText();
			this.txtInput_TaxPayeeCity.ResetText();
			this.txtInput_TaxPayeeState.ResetText();
			this.txtInput_TaxPayeeZip.ResetText();
			this.txtInput_TaxPayeePhone.ResetText();
			this.txtInput_TaxPayeeFax.ResetText();
			this.txtInput_TaxOfficeHours.ResetText();
			this.txtInput_TaxCertFee.ResetText();
			this.txtInput_TaxCertTAT.ResetText();
			this.txtInput_TaxDueDates.ResetText();
			this.txtInput_TaxComments.ResetText();
			this.chkbxTaxCertRequired.Checked = false;
			this.txtInput_SOL_MtgRD.ResetText();
			this.txtInput_SOL_MtgAM.ResetText();
			this.txtInput_SOL_HelocAM.ResetText();
			this.txtInput_SOL_HelocRD.ResetText();
			this.txtInput_SOL_MechLiens.ResetText();
			this.txtInput_SOL_Notice.ResetText();
			this.txtInput_SOL_LisPendens.ResetText();
			this.txtInput_SOL_HOALien.ResetText();
			this.txtInput_SOL_HospLien.ResetText();
			this.txtInput_SOL_ClaimOfLien.ResetText();
			this.txtInput_SOL_Jgmt.ResetText();
			this.txtInput_SOL_SupportObl.ResetText();
			this.txtInput_SOL_StateJgmt.ResetText();
			this.txtInput_SOL_AfterAcquired.ResetText();
			this.txtInput_SOL_TE_Rule.ResetText();
			this.txtInput_SOL_CreditorClaims.ResetText();
			this.txtInput_SOL_PersonalTax.ResetText();
			this.txtInput_SOL_ForeclosureRedem.ResetText();
			this.txtInput_SOL_SpousalState.ResetText();
			this.txtSOL_notes.ResetText();
		}

		private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
		{
			Graphics graphics = e.Graphics;
			TabPage item = TabControl1.TabPages[e.Index];
			StringFormat stringFormat = new StringFormat();
			float x = (float)e.Bounds.X;
			float y = (float)(checked(e.Bounds.Y + 2));
			float width = (float)e.Bounds.Width;
			System.Drawing.Rectangle bounds = e.Bounds;
			RectangleF rectangleF = new RectangleF(x, y, width, (float)(checked(bounds.Height - 2)));
			stringFormat.Alignment = StringAlignment.Center;
			string text = item.Text;
			Brush solidBrush = new SolidBrush(item.BackColor);
			graphics.FillRectangle(solidBrush, e.Bounds);
			solidBrush = new SolidBrush(item.ForeColor);
			graphics.DrawString(text, this.TabControl1.Font, solidBrush, rectangleF, stringFormat);
		}
	}
}