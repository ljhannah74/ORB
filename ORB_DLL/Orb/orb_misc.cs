using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace ORB_DLL.Orb
{
	public class orb_misc
	{
		private string _Foreclosure_Notes;

		private string _Probate_Notes;

		private string _Deed_Notes;

		private string _Deed_Prep;

		private string _Homestead_Notes;

		private string _Homestead;

		private string _Policy_Notes;

		private string _Attorney_Notes;

		private string _Attorney_Close;

		private string _Attorney_Search;

		private string _DOI_url;

		private string _SecretaryState_url;

		private string _State_Code_url;

		private string _Being_Clause;

		public string Attorney_Close
		{
			get
			{
				return this._Attorney_Close;
			}
			set
			{
				this._Attorney_Close = value;
			}
		}

		public string Attorney_Notes
		{
			get
			{
				return this._Attorney_Notes;
			}
			set
			{
				this._Attorney_Notes = value;
			}
		}

		public string Attorney_Search
		{
			get
			{
				return this._Attorney_Search;
			}
			set
			{
				this._Attorney_Search = value;
			}
		}

		public string Being_Clause
		{
			get
			{
				return this._Being_Clause;
			}
			set
			{
				this._Being_Clause = value;
			}
		}

		public string Deed_Notes
		{
			get
			{
				return this._Deed_Notes;
			}
			set
			{
				this._Deed_Notes = value;
			}
		}

		public string Deed_Prep
		{
			get
			{
				return this._Deed_Prep;
			}
			set
			{
				this._Deed_Prep = value;
			}
		}

		public string DOI_url
		{
			get
			{
				return this._DOI_url;
			}
			set
			{
				this._DOI_url = value;
			}
		}

		public string Foreclosure_Notes
		{
			get
			{
				return this._Foreclosure_Notes;
			}
			set
			{
				this._Foreclosure_Notes = value;
			}
		}

		public string Homestead
		{
			get
			{
				return this._Homestead;
			}
			set
			{
				this._Homestead = value;
			}
		}

		public string Homestead_Notes
		{
			get
			{
				return this._Homestead_Notes;
			}
			set
			{
				this._Homestead_Notes = value;
			}
		}

		public string Policy_Notes
		{
			get
			{
				return this._Policy_Notes;
			}
			set
			{
				this._Policy_Notes = value;
			}
		}

		public string Probate_Notes
		{
			get
			{
				return this._Probate_Notes;
			}
			set
			{
				this._Probate_Notes = value;
			}
		}

		public string SecretaryState_url
		{
			get
			{
				return this._SecretaryState_url;
			}
			set
			{
				this._SecretaryState_url = value;
			}
		}

		public string State_Code_url
		{
			get
			{
				return this._State_Code_url;
			}
			set
			{
				this._State_Code_url = value;
			}
		}

		public orb_misc(string state)
		{
			int num = 0;
			DataTable dataTable = new DataTable();
			OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
			OleDbCommandBuilder oleDbCommandBuilder = new OleDbCommandBuilder();
			OleDbCommand oleDbCommand = new OleDbCommand();
			string dataFileName = @"Data\ORB_DATABASE.xlsx";
			string dsn = string.Concat("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=", dataFileName, ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
			string str1 = "misc";
			oleDbCommand.CommandText = string.Concat("Select * From [", str1, "$] where st = '", state, "'");
			oleDbCommand.Connection = new OleDbConnection(dsn);
			oleDbDataAdapter.SelectCommand = oleDbCommand;
			oleDbCommandBuilder.DataAdapter = oleDbDataAdapter;
			oleDbDataAdapter.Fill(dataTable);
			oleDbDataAdapter.Dispose();
			num = 0;
			if (dataTable.Rows.Count > 0)
			{
				this.Deed_Notes = dataTable.Rows[num]["deed_notes"].ToString();
				this.Deed_Prep = dataTable.Rows[num]["deed_prep"].ToString();
				this.Policy_Notes = dataTable.Rows[num]["policy_notes"].ToString();
				this.Attorney_Notes = dataTable.Rows[num]["atty_notes"].ToString();
				this.Attorney_Close = dataTable.Rows[num]["atty_close"].ToString();
				this.Attorney_Search = dataTable.Rows[num]["atty_search"].ToString();
				this.DOI_url = dataTable.Rows[num]["dept_ins_url"].ToString();
				this.SecretaryState_url = dataTable.Rows[num]["sec_state_url"].ToString();
				this.State_Code_url = dataTable.Rows[num]["state_code_url"].ToString();
				this.Being_Clause = dataTable.Rows[num]["being_clause"].ToString();
			}
		}
	}
}