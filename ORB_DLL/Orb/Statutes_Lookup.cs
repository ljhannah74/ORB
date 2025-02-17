using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace ORB_DLL.Orb
{
	public class Statutes_Lookup
	{
		private string _SOL_MtgAM;

		private string _SOL_MtgRD;

		private string _SOL_HelocAM;

		private string _SOL_HelocRD;

		private string _SOL_Mech;

		private string _SOL_Notice;

		private string _SOL_lispen;

		private string _SOL_HOA;

		private string _SOL_Hosp;

		private string _SOL_ClaimLien;

		private string _SOL_Jgmt;

		private string _SOL_Support;

		private string _SOL_StateJgmt;

		private string _SOL_AftAcq;

		private string _SOL_TERule;

		private string _SOL_Creditor_Claims;

		private string _SOL_PersTax;

		private string _SOL_Tax_RedemPer;

		private string _SOL_Foreclosure_RedemPer;

		private string _SOL_Spousal;

		private string _SOL_notes;

		public string SOL_AftAcq
		{
			get
			{
				return this._SOL_AftAcq;
			}
			set
			{
				this._SOL_AftAcq = value;
			}
		}

		public string SOL_ClaimLien
		{
			get
			{
				return this._SOL_ClaimLien;
			}
			set
			{
				this._SOL_ClaimLien = value;
			}
		}

		public string SOL_Creditor_Claims
		{
			get
			{
				return this._SOL_Creditor_Claims;
			}
			set
			{
				this._SOL_Creditor_Claims = value;
			}
		}

		public string SOL_Foreclosure_RedemPer
		{
			get
			{
				return this._SOL_Foreclosure_RedemPer;
			}
			set
			{
				this._SOL_Foreclosure_RedemPer = value;
			}
		}

		public string SOL_HelocAM
		{
			get
			{
				return this._SOL_HelocAM;
			}
			set
			{
				this._SOL_HelocAM = value;
			}
		}

		public string SOL_HelocRD
		{
			get
			{
				return this._SOL_HelocRD;
			}
			set
			{
				this._SOL_HelocRD = value;
			}
		}

		public string SOL_HOA
		{
			get
			{
				return this._SOL_HOA;
			}
			set
			{
				this._SOL_HOA = value;
			}
		}

		public string SOL_Hosp
		{
			get
			{
				return this._SOL_Hosp;
			}
			set
			{
				this._SOL_Hosp = value;
			}
		}

		public string SOL_Jgmt
		{
			get
			{
				return this._SOL_Jgmt;
			}
			set
			{
				this._SOL_Jgmt = value;
			}
		}

		public string SOL_lispen
		{
			get
			{
				return this._SOL_lispen;
			}
			set
			{
				this._SOL_lispen = value;
			}
		}

		public string SOL_Mech
		{
			get
			{
				return this._SOL_Mech;
			}
			set
			{
				this._SOL_Mech = value;
			}
		}

		public string SOL_MtgAM
		{
			get
			{
				return this._SOL_MtgAM;
			}
			set
			{
				this._SOL_MtgAM = value;
			}
		}

		public string SOL_MtgRD
		{
			get
			{
				return this._SOL_MtgRD;
			}
			set
			{
				this._SOL_MtgRD = value;
			}
		}

		public string SOL_notes
		{
			get
			{
				return this._SOL_notes;
			}
			set
			{
				this._SOL_notes = value;
			}
		}

		public string SOL_Notice
		{
			get
			{
				return this._SOL_Notice;
			}
			set
			{
				this._SOL_Notice = value;
			}
		}

		public string SOL_PersTax
		{
			get
			{
				return this._SOL_PersTax;
			}
			set
			{
				this._SOL_PersTax = value;
			}
		}

		public string SOL_Spousal
		{
			get
			{
				return this._SOL_Spousal;
			}
			set
			{
				this._SOL_Spousal = value;
			}
		}

		public string SOL_StateJgmt
		{
			get
			{
				return this._SOL_StateJgmt;
			}
			set
			{
				this._SOL_StateJgmt = value;
			}
		}

		public string SOL_Support
		{
			get
			{
				return this._SOL_Support;
			}
			set
			{
				this._SOL_Support = value;
			}
		}

		public string SOL_Tax_RedemPer
		{
			get
			{
				return this._SOL_Tax_RedemPer;
			}
			set
			{
				this._SOL_Tax_RedemPer = value;
			}
		}

		public string SOL_TERule
		{
			get
			{
				return this._SOL_TERule;
			}
			set
			{
				this._SOL_TERule = value;
			}
		}

		public Statutes_Lookup(string state)
		{
			int num = 0;
			DataTable dataTable = new DataTable();
			OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
			string str = "statutes";
			OleDbCommandBuilder oleDbCommandBuilder = new OleDbCommandBuilder();
			OleDbCommand oleDbCommand = new OleDbCommand();
			string dataFileName = @"Data\ORB_DATABASE.xlsx";
			string dsn = string.Concat("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=", dataFileName, ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
			oleDbCommand.CommandText = string.Concat("Select * From [", str, "$] where st = '", state, "'");
			oleDbCommand.Connection = new OleDbConnection(dsn);
			oleDbDataAdapter.SelectCommand = oleDbCommand;
			oleDbCommandBuilder.DataAdapter = oleDbDataAdapter;
			oleDbDataAdapter.Fill(dataTable);
			oleDbDataAdapter.Dispose();
			num = 0;
			if (dataTable.Rows.Count > 0)
			{
				this.SOL_MtgRD = dataTable.Rows[num]["mtg1RD"].ToString();
				this.SOL_MtgAM = dataTable.Rows[num]["mtg1AM"].ToString();
				this.SOL_HelocAM = dataTable.Rows[num]["helAM"].ToString();
				this.SOL_HelocRD = dataTable.Rows[num]["helRD"].ToString();
				this.SOL_Mech = dataTable.Rows[num]["mech_lien"].ToString();
				this.SOL_Notice = dataTable.Rows[num]["NOC"].ToString();
				this.SOL_lispen = dataTable.Rows[num]["LP"].ToString();
				this.SOL_HOA = dataTable.Rows[num]["HOA"].ToString();
				this.SOL_Hosp = dataTable.Rows[num]["hosp_lien"].ToString();
				this.SOL_ClaimLien = dataTable.Rows[num]["claim_of_lien"].ToString();
				this.SOL_Jgmt = dataTable.Rows[num]["jgmt"].ToString();
				this.SOL_Support = dataTable.Rows[num]["supt_obl"].ToString();
				this.SOL_StateJgmt = dataTable.Rows[num]["state_jgmt"].ToString();
				this.SOL_AftAcq = dataTable.Rows[num]["aft_acq_lien"].ToString();
				this.SOL_TERule = dataTable.Rows[num]["TE_rule"].ToString();
				this.SOL_Creditor_Claims = dataTable.Rows[num]["cred_claims"].ToString();
				this.SOL_PersTax = dataTable.Rows[num]["pers_tx_liens"].ToString();
				this.SOL_Foreclosure_RedemPer = dataTable.Rows[num]["forecl_redem_per"].ToString();
				this.SOL_Tax_RedemPer = dataTable.Rows[num]["tax_redem_per"].ToString();
				this.SOL_Spousal = dataTable.Rows[num]["spousal"].ToString();
				this.SOL_notes = dataTable.Rows[num]["notes"].ToString();
			}
		}
	}
}