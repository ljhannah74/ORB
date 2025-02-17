using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Text;

namespace ORB_DLL.Orb
{
	public class Tax_Lookup2
	{
		private string _TaxType_Collected;

		private string _TaxAuthName;

		private string _TaxLocalURL;

		private string _TaxPayeeName;

		private string _TaxPayee_Street1;

		private string _TaxPayee_Street2;

		private string _TaxPayee_City;

		private string _TaxPayee_State;

		private string _TaxPayee_Zip;

		private string _TaxPayee_Phone;

		private string _TaxPayee_Fax;

		private string _OtherTaxCollected;

		private string _TaxBillCycle;

		private string _TaxDueDates;

		private string _TaxOffcHours;

		private string _TaxCertRequired;

		private string _TaxCertFee;

		private string _TaxCertTAT;

		private string _Tax_Comments;

		public string OtherTaxCollected
		{
			get
			{
				return this._OtherTaxCollected;
			}
			set
			{
				this._OtherTaxCollected = value;
			}
		}

		public string Tax_Comments
		{
			get
			{
				return this._Tax_Comments;
			}
			set
			{
				this._Tax_Comments = value;
			}
		}

		public string TaxAuthName
		{
			get
			{
				return this._TaxAuthName;
			}
			set
			{
				this._TaxAuthName = value;
			}
		}

		public string TaxBillCycle
		{
			get
			{
				return this._TaxBillCycle;
			}
			set
			{
				this._TaxBillCycle = value;
			}
		}

		public string TaxCertFee
		{
			get
			{
				return this._TaxCertFee;
			}
			set
			{
				this._TaxCertFee = value;
			}
		}

		public string TaxCertRequired
		{
			get
			{
				return this._TaxCertRequired;
			}
			set
			{
				this._TaxCertRequired = value;
			}
		}

		public string TaxCertTAT
		{
			get
			{
				return this._TaxCertTAT;
			}
			set
			{
				this._TaxCertTAT = value;
			}
		}

		public string TaxDueDates
		{
			get
			{
				return this._TaxDueDates;
			}
			set
			{
				this._TaxDueDates = value;
			}
		}

		public string TaxLocalURL
		{
			get
			{
				return this._TaxLocalURL;
			}
			set
			{
				this._TaxLocalURL = value;
			}
		}

		public string TaxOffcHours
		{
			get
			{
				return this._TaxOffcHours;
			}
			set
			{
				this._TaxOffcHours = value;
			}
		}

		public string TaxPayee_City
		{
			get
			{
				return this._TaxPayee_City;
			}
			set
			{
				this._TaxPayee_City = value;
			}
		}

		public string TaxPayee_Fax
		{
			get
			{
				return this._TaxPayee_Fax;
			}
			set
			{
				this._TaxPayee_Fax = value;
			}
		}

		public string TaxPayee_Phone
		{
			get
			{
				return this._TaxPayee_Phone;
			}
			set
			{
				this._TaxPayee_Phone = value;
			}
		}

		public string TaxPayee_State
		{
			get
			{
				return this._TaxPayee_State;
			}
			set
			{
				this._TaxPayee_State = value;
			}
		}

		public string TaxPayee_Street1
		{
			get
			{
				return this._TaxPayee_Street1;
			}
			set
			{
				this._TaxPayee_Street1 = value;
			}
		}

		public string TaxPayee_Street2
		{
			get
			{
				return this._TaxPayee_Street2;
			}
			set
			{
				this._TaxPayee_Street2 = value;
			}
		}

		public string TaxPayee_Zip
		{
			get
			{
				return this._TaxPayee_Zip;
			}
			set
			{
				this._TaxPayee_Zip = value;
			}
		}

		public string TaxPayeeName
		{
			get
			{
				return this._TaxPayeeName;
			}
			set
			{
				this._TaxPayeeName = value;
			}
		}

		public string TaxType_Collected
		{
			get
			{
				return this._TaxType_Collected;
			}
			set
			{
				this._TaxType_Collected = value;
			}
		}

		public Tax_Lookup2(string state, string county, string tax_auth, string tax_auth_type)
		{
			string str = "taxes";
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			DataTable dataTable = new DataTable();
			OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
			OleDbCommandBuilder oleDbCommandBuilder = new OleDbCommandBuilder();
			OleDbCommand oleDbCommand = new OleDbCommand();
			string str1 = "T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\ORB_DATABASE.xls";
			oleDbCommand.CommandType = CommandType.TableDirect;
			string str2 = string.Concat("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", str1, ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"");
			string[] strArrays = new string[] { "Select * From [", str, "$] where st = '", state, "' and county = '", county, "' and tax_auth = '", tax_auth, "' and tax_auth_type = '", tax_auth_type, "'" };
			oleDbCommand.CommandText = string.Concat(strArrays);
			oleDbCommand.Connection = new OleDbConnection(str2);
			oleDbDataAdapter.SelectCommand = oleDbCommand;
			oleDbCommandBuilder.DataAdapter = oleDbDataAdapter;
			oleDbDataAdapter.Fill(dataTable);
			oleDbDataAdapter.Dispose();
			if (dataTable.Rows.Count > 0)
			{
				this.TaxAuthName = dataTable.Rows[num]["tax_auth"].ToString();
				this.TaxType_Collected = dataTable.Rows[num]["tax_auth_type"].ToString();
				this.TaxPayee_Phone = dataTable.Rows[num]["phone"].ToString();
				this.TaxPayee_Fax = dataTable.Rows[num]["fax"].ToString();
				this.TaxPayeeName = dataTable.Rows[num]["payee"].ToString();
				this.TaxPayee_Street1 = dataTable.Rows[num]["street1"].ToString();
				this.TaxPayee_Street2 = dataTable.Rows[num]["street2"].ToString();
				this.TaxPayee_City = dataTable.Rows[num]["city"].ToString();
				this.TaxPayee_State = dataTable.Rows[num]["tx_st"].ToString();
				this.TaxPayee_Zip = dataTable.Rows[num]["zip"].ToString();
				this.TaxOffcHours = dataTable.Rows[num]["hours"].ToString();
				this.TaxCertRequired = dataTable.Rows[num]["cert_req"].ToString();
				this.TaxCertFee = dataTable.Rows[num]["cert_fee"].ToString();
				this.TaxBillCycle = dataTable.Rows[num]["cycle"].ToString();
				this.TaxDueDates = dataTable.Rows[num]["due_dates"].ToString();
				this.Tax_Comments = dataTable.Rows[num]["notes"].ToString();
			}
		}
	}
}