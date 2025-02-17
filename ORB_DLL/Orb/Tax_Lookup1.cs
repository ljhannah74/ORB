using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Text;

namespace ORB_DLL.Orb
{
	public class Tax_Lookup1
	{
		private string[] _URLS;

		private string[,] _Tax_Offices;

		private string[] _Verified_On_Date;

		private string[] _Taxes_Verified;

		private string[] _LocalTaxLink;

		private string[] _TaxAuthority;

		private string _DateVerified;

		public string DateVerified
		{
			get
			{
				return this._DateVerified;
			}
			set
			{
				this._DateVerified = value;
			}
		}

		public string[] LocalTaxLink
		{
			get
			{
				return this._LocalTaxLink;
			}
			set
			{
				this._LocalTaxLink = value;
			}
		}

		public string[,] Tax_Offices
		{
			get
			{
				return this._Tax_Offices;
			}
			set
			{
				this._Tax_Offices = value;
			}
		}

		public string[] TaxAuthority
		{
			get
			{
				return this._TaxAuthority;
			}
			set
			{
				this._TaxAuthority = value;
			}
		}

		public string[] Taxes_Verified
		{
			get
			{
				return this._Taxes_Verified;
			}
			set
			{
				this._Taxes_Verified = value;
			}
		}

		public string[] URLS
		{
			get
			{
				return this._URLS;
			}
			set
			{
				this._URLS = value;
			}
		}

		public string[] Verified_On_Date
		{
			get
			{
				return this._Verified_On_Date;
			}
			set
			{
				this._Verified_On_Date = value;
			}
		}

		public Tax_Lookup1(string state, string county, string tax_auth)
		{
			this._Tax_Offices = new string[11, 5];
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
			string[] strArrays = new string[] { "Select * From [", str, "$] where st = '", state, "' and county = '", county, "' and tax_auth = '", tax_auth, "'" };
			oleDbCommand.CommandText = string.Concat(strArrays);
			oleDbCommand.Connection = new OleDbConnection(str2);
			oleDbDataAdapter.SelectCommand = oleDbCommand;
			oleDbCommandBuilder.DataAdapter = oleDbDataAdapter;
			oleDbDataAdapter.Fill(dataTable);
			oleDbDataAdapter.Dispose();
			int num1 = 0;
			num = 0;
			this.Tax_Offices = new string[6, 5];
			strArrays = new string[6];
			this.URLS = strArrays;
			while (!(num > checked(dataTable.Rows.Count - 1) | num > 4))
			{
				this.DateVerified = dataTable.Rows[num]["dt_verified"].ToString();
				this.URLS.SetValue(dataTable.Rows[num]["locTx_url"].ToString(), num);
				this.Tax_Offices.SetValue(string.Concat("TaxType: ", dataTable.Rows[num]["tax_auth_type"].ToString(), " TaxingAuth: ", dataTable.Rows[num]["tax_auth"].ToString()), num, 1);
				string[,] taxOffices = this.Tax_Offices;
				strArrays = new string[] { "Phone: ", dataTable.Rows[num]["phone"].ToString(), "  Fax: ", dataTable.Rows[num]["fax"].ToString(), "\r\nPayee: ", dataTable.Rows[num]["payee"].ToString(), "\r\n", dataTable.Rows[num]["street1"].ToString(), ", ", dataTable.Rows[num]["street2"].ToString(), "\r\n", dataTable.Rows[num]["city"].ToString(), ", ", dataTable.Rows[num]["tx_st"].ToString(), "  ", dataTable.Rows[num]["zip"].ToString(), "\r\nHours: ", dataTable.Rows[num]["hours"].ToString(), "\r\nCert Needed? ", dataTable.Rows[num]["cert_req"].ToString(), "    Fee: ", dataTable.Rows[num]["cert_fee"].ToString(), "\r\nBill Cycle: ", dataTable.Rows[num]["cycle"].ToString(), "   DueDates: ", dataTable.Rows[num]["due_dates"].ToString(), "\r\nNOTES: ", dataTable.Rows[num]["notes"].ToString() };
				((Array)taxOffices).SetValue(string.Concat(strArrays), num, 2);
				if (!(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["street1"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["locTx_url"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["street2"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["city"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["tx_st"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["zip"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["phone"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["fax"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["hours"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["cert_req"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["cert_fee"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["cycle"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["due_dates"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[num]["notes"].ToString(), "", false) == 0))
				{
					this.Tax_Offices.SetValue("True", num, 3);
				}
				else
				{
					this.Tax_Offices.SetValue("False", num, 3);
				}
				if (num1 != 5)
				{
					num1 = checked(num1 + 1);
				}
				num = checked(num + 1);
			}
		}
	}
}