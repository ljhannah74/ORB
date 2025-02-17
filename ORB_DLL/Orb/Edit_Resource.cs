using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace ORB_DLL.Orb
{
	public class Edit_Resource
	{
		private string _e_img_date;

		private string _e_pmt_type;

		private string _e_pmt_method;

		private string _e_sub_need;

		private string _e_subscribed;

		private string _e_subTerm;

		private string _e_subFee;

		private string _e_tap;

		private string _e_rv;

		private string _e_dtree_desk;

		private string _e_ins;

		private string _e_props;

		private string _e_doc_retrieval;

		private string _e_land_url;

		private string _e_county_user;

		private string _e_county_pwd;

		private string _e_copy_source;

		private string _e_copyFeeAmt;

		private string _e_index_date;

		private string _e_index_source;

		private string _e_court_url;

		private string _e_court_user;

		private string _e_court_pwd;

		private string _e_courtIndexDate;

		private string _e_courtImageDate;

		private string _e_muniCourt_url;

		private string _e_MuniCtUsername;

		private string _e_MuniCtPwd;

		private string _e_tax_url;

		private string _e_tax_user;

		private string _e_tax_pwd;

		private string _e_tax2_url;

		private string _e_tax2_user;

		private string _e_tax2_pwd;

		private string _e_delinqTax_url;

		private string _e_assessor_url;

		private string _e_assessor_user;

		private string _e_assessor_pwd;

		private string _e_prothon_url;

		private string _e_pro_user;

		private string _e_pro_pwd;

		private string _e_plat_url;

		private string _e_map_url;

		private string _e_probate_url;

		private string _e_foreclosure_url;

		private string _e_county_homepage;

		private string _e_sheriff_url;

		private string _e_other_url;

		private string _e_other_user;

		private string _e_other_pwd;

		private string _e_comments;

		private string[] _e_URLS;

		private string[,] _e_Tax_Offices;

		private long _Row;

		public string e_assessor_pwd
		{
			get
			{
				return this._e_assessor_pwd;
			}
			set
			{
				this._e_assessor_pwd = value;
			}
		}

		public string e_assessor_url
		{
			get
			{
				return this._e_assessor_url;
			}
			set
			{
				this._e_assessor_url = value;
			}
		}

		public string e_assessor_user
		{
			get
			{
				return this._e_assessor_user;
			}
			set
			{
				this._e_assessor_user = value;
			}
		}

		public string e_comments
		{
			get
			{
				return this._e_comments;
			}
			set
			{
				this._e_comments = value;
			}
		}

		public string e_copy_source
		{
			get
			{
				return this._e_copy_source;
			}
			set
			{
				this._e_copy_source = value;
			}
		}

		public string e_copyFeeAmt
		{
			get
			{
				return this._e_copyFeeAmt;
			}
			set
			{
				this._e_copyFeeAmt = value;
			}
		}

		public string e_county_homepage
		{
			get
			{
				return this._e_county_homepage;
			}
			set
			{
				this._e_county_homepage = value;
			}
		}

		public string e_county_pwd
		{
			get
			{
				return this._e_county_pwd;
			}
			set
			{
				this._e_county_pwd = value;
			}
		}

		public string e_county_user
		{
			get
			{
				return this._e_county_user;
			}
			set
			{
				this._e_county_user = value;
			}
		}

		public string e_court_pwd
		{
			get
			{
				return this._e_court_pwd;
			}
			set
			{
				this._e_court_pwd = value;
			}
		}

		public string e_court_url
		{
			get
			{
				return this._e_court_url;
			}
			set
			{
				this._e_court_url = value;
			}
		}

		public string e_court_user
		{
			get
			{
				return this._e_court_user;
			}
			set
			{
				this._e_court_user = value;
			}
		}

		public string e_courtImageDate
		{
			get
			{
				return this._e_courtImageDate;
			}
			set
			{
				this._e_courtImageDate = value;
			}
		}

		public string e_courtIndexDate
		{
			get
			{
				return this._e_courtIndexDate;
			}
			set
			{
				this._e_courtIndexDate = value;
			}
		}

		public string e_delinqTax_url
		{
			get
			{
				return this._e_delinqTax_url;
			}
			set
			{
				this._e_delinqTax_url = value;
			}
		}

		public string e_doc_retrieval
		{
			get
			{
				return this._e_doc_retrieval;
			}
			set
			{
				this._e_doc_retrieval = value;
			}
		}

		public string e_dtree_desk
		{
			get
			{
				return this._e_dtree_desk;
			}
			set
			{
				this._e_dtree_desk = value;
			}
		}

		public string e_foreclosure_url
		{
			get
			{
				return this._e_foreclosure_url;
			}
			set
			{
				this._e_foreclosure_url = value;
			}
		}

		public string e_img_date
		{
			get
			{
				return this._e_img_date;
			}
			set
			{
				this._e_img_date = value;
			}
		}

		public string e_index_date
		{
			get
			{
				return this._e_index_date;
			}
			set
			{
				this._e_index_date = value;
			}
		}

		public string e_index_source
		{
			get
			{
				return this._e_index_source;
			}
			set
			{
				this._e_index_source = value;
			}
		}

		public string e_ins
		{
			get
			{
				return this._e_ins;
			}
			set
			{
				this._e_ins = value;
			}
		}

		public string e_land_url
		{
			get
			{
				return this._e_land_url;
			}
			set
			{
				this._e_land_url = value;
			}
		}

		public string e_map_url
		{
			get
			{
				return this._e_map_url;
			}
			set
			{
				this._e_map_url = value;
			}
		}

		public string e_muniCourt_url
		{
			get
			{
				return this._e_muniCourt_url;
			}
			set
			{
				this._e_muniCourt_url = value;
			}
		}

		public string e_MuniCtPwd
		{
			get
			{
				return this._e_MuniCtPwd;
			}
			set
			{
				this._e_MuniCtPwd = value;
			}
		}

		public string e_MuniCtUsername
		{
			get
			{
				return this._e_MuniCtUsername;
			}
			set
			{
				this._e_MuniCtUsername = value;
			}
		}

		public string e_other_pwd
		{
			get
			{
				return this._e_other_pwd;
			}
			set
			{
				this._e_other_pwd = value;
			}
		}

		public string e_other_url
		{
			get
			{
				return this._e_other_url;
			}
			set
			{
				this._e_other_url = value;
			}
		}

		public string e_other_user
		{
			get
			{
				return this._e_other_user;
			}
			set
			{
				this._e_other_user = value;
			}
		}

		public string e_plat_url
		{
			get
			{
				return this._e_plat_url;
			}
			set
			{
				this._e_plat_url = value;
			}
		}

		public string e_pmt_method
		{
			get
			{
				return this._e_pmt_method;
			}
			set
			{
				this._e_pmt_method = value;
			}
		}

		public string e_pmt_type
		{
			get
			{
				return this._e_pmt_type;
			}
			set
			{
				this._e_pmt_type = value;
			}
		}

		public string e_pro_pwd
		{
			get
			{
				return this._e_pro_pwd;
			}
			set
			{
				this._e_pro_pwd = value;
			}
		}

		public string e_pro_user
		{
			get
			{
				return this._e_pro_user;
			}
			set
			{
				this._e_pro_user = value;
			}
		}

		public string e_probate_url
		{
			get
			{
				return this._e_probate_url;
			}
			set
			{
				this._e_probate_url = value;
			}
		}

		public string e_props
		{
			get
			{
				return this._e_props;
			}
			set
			{
				this._e_props = value;
			}
		}

		public string e_prothon_url
		{
			get
			{
				return this._e_prothon_url;
			}
			set
			{
				this._e_prothon_url = value;
			}
		}

		public string e_rv
		{
			get
			{
				return this._e_rv;
			}
			set
			{
				this._e_rv = value;
			}
		}

		public string e_sheriff_url
		{
			get
			{
				return this._e_sheriff_url;
			}
			set
			{
				this._e_sheriff_url = value;
			}
		}

		public string e_sub_need
		{
			get
			{
				return this._e_sub_need;
			}
			set
			{
				this._e_sub_need = value;
			}
		}

		public string e_subFee
		{
			get
			{
				return this._e_subFee;
			}
			set
			{
				this._e_subFee = value;
			}
		}

		public string e_subscribed
		{
			get
			{
				return this._e_subscribed;
			}
			set
			{
				this._e_subscribed = value;
			}
		}

		public string e_subTerm
		{
			get
			{
				return this._e_subTerm;
			}
			set
			{
				this._e_subTerm = value;
			}
		}

		public string e_tap
		{
			get
			{
				return this._e_tap;
			}
			set
			{
				this._e_tap = value;
			}
		}

		public string[,] e_Tax_Offices
		{
			get
			{
				return this._e_Tax_Offices;
			}
			set
			{
				this._e_Tax_Offices = value;
			}
		}

		public string e_tax_pwd
		{
			get
			{
				return this._e_tax_pwd;
			}
			set
			{
				this._e_tax_pwd = value;
			}
		}

		public string e_tax_url
		{
			get
			{
				return this._e_tax_url;
			}
			set
			{
				this._e_tax_url = value;
			}
		}

		public string e_tax_user
		{
			get
			{
				return this._e_tax_user;
			}
			set
			{
				this._e_tax_user = value;
			}
		}

		public string e_tax2_pwd
		{
			get
			{
				return this._e_tax2_pwd;
			}
			set
			{
				this._e_tax2_pwd = value;
			}
		}

		public string e_tax2_url
		{
			get
			{
				return this._e_tax2_url;
			}
			set
			{
				this._e_tax2_url = value;
			}
		}

		public string e_tax2_user
		{
			get
			{
				return this._e_tax2_user;
			}
			set
			{
				this._e_tax2_user = value;
			}
		}

		public string[] e_URLS
		{
			get
			{
				return this._e_URLS;
			}
			set
			{
				this._e_URLS = value;
			}
		}

		public long Row
		{
			get
			{
				return this._Row;
			}
			set
			{
			}
		}

		public Edit_Resource(string state, string county, string tax_auth)
		{
			this._e_Tax_Offices = new string[11, 5];
			int num = 0;
			DataTable dataTable = new DataTable();
			OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
			OleDbCommandBuilder oleDbCommandBuilder = new OleDbCommandBuilder();
			OleDbCommand oleDbCommand = new OleDbCommand();
			string str = "T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\ORB_DATABASE.xls";
			string str1 = "orb";
			oleDbCommand.CommandType = CommandType.TableDirect;
			string str2 = string.Concat("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", str, ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"");
			string[] strArrays = new string[] { "Select * From [", str1, "$] where st = '", state, "' and county = '", county, "'" };
			oleDbCommand.CommandText = string.Concat(strArrays);
			oleDbCommand.Connection = new OleDbConnection(str2);
			oleDbDataAdapter.SelectCommand = oleDbCommand;
			oleDbCommandBuilder.DataAdapter = oleDbDataAdapter;
			oleDbDataAdapter.Fill(dataTable);
			oleDbDataAdapter.Dispose();
			num = 0;
			if (dataTable.Rows.Count > 0)
			{
				this.e_pmt_type = dataTable.Rows[num]["pmt_type"].ToString();
				this.e_pmt_method = dataTable.Rows[num]["pmt_method"].ToString();
				this.e_sub_need = dataTable.Rows[num]["sub_need"].ToString();
				this.e_subscribed = dataTable.Rows[num]["we_subscribe"].ToString();
				this.e_subFee = dataTable.Rows[num]["we_subFee"].ToString();
				this.e_subTerm = dataTable.Rows[num]["subTerm"].ToString();
				this.e_tap = dataTable.Rows[num]["tap"].ToString();
				this.e_rv = dataTable.Rows[num]["rv"].ToString();
				this.e_dtree_desk = dataTable.Rows[num]["dtree_desk"].ToString();
				this.e_ins = dataTable.Rows[num]["ins"].ToString();
				this.e_props = dataTable.Rows[num]["props"].ToString();
				this.e_doc_retrieval = dataTable.Rows[num]["copy"].ToString();
				this.e_land_url = dataTable.Rows[num]["land_url"].ToString();
				this.e_county_user = dataTable.Rows[num]["county_user"].ToString();
				this.e_county_pwd = dataTable.Rows[num]["county_pwd"].ToString();
				this.e_copy_source = dataTable.Rows[num]["copy_source"].ToString();
				this.e_copyFeeAmt = dataTable.Rows[num]["copyFeeAmt"].ToString();
				this.e_img_date = dataTable.Rows[num]["img_date"].ToString();
				this.e_index_date = dataTable.Rows[num]["index_date"].ToString();
				this.e_index_source = dataTable.Rows[num]["index_source"].ToString();
				this.e_tax_url = dataTable.Rows[num]["tax_url"].ToString();
				this.e_tax_user = dataTable.Rows[num]["tax_user"].ToString();
				this.e_tax_pwd = dataTable.Rows[num]["tax_pwd"].ToString();
				this.e_tax2_url = dataTable.Rows[num]["tax2_url"].ToString();
				this.e_tax2_user = dataTable.Rows[num]["tax2_user"].ToString();
				this.e_tax2_pwd = dataTable.Rows[num]["tax2_pwd"].ToString();
				this.e_delinqTax_url = dataTable.Rows[num]["delinq_tax_url"].ToString();
				this.e_assessor_url = dataTable.Rows[num]["assessor_url"].ToString();
				this.e_assessor_user = dataTable.Rows[num]["assessor_user"].ToString();
				this.e_assessor_pwd = dataTable.Rows[num]["assessor_pwd"].ToString();
				this.e_court_url = dataTable.Rows[num]["court_url"].ToString();
				this.e_court_user = dataTable.Rows[num]["court_user"].ToString();
				this.e_court_pwd = dataTable.Rows[num]["court_pwd"].ToString();
				this.e_muniCourt_url = dataTable.Rows[num]["muniCourt_url"].ToString();
				this.e_MuniCtUsername = dataTable.Rows[num]["muni_user"].ToString();
				this.e_MuniCtPwd = dataTable.Rows[num]["muni_pwd"].ToString();
				this.e_prothon_url = dataTable.Rows[num]["prothon_url"].ToString();
				this.e_pro_user = dataTable.Rows[num]["pro_user"].ToString();
				this.e_pro_pwd = dataTable.Rows[num]["pro_pwd"].ToString();
				this.e_plat_url = dataTable.Rows[num]["plat_url"].ToString();
				this.e_map_url = dataTable.Rows[num]["map_url"].ToString();
				this.e_sheriff_url = dataTable.Rows[num]["sheriff_url"].ToString();
				this.e_probate_url = dataTable.Rows[num]["probate_url"].ToString();
				this.e_foreclosure_url = dataTable.Rows[num]["foreclosure_url"].ToString();
				this.e_county_homepage = dataTable.Rows[num]["county_homepage"].ToString();
				this.e_other_url = dataTable.Rows[num]["other_url"].ToString();
				this.e_other_user = dataTable.Rows[num]["other_user"].ToString();
				this.e_other_pwd = dataTable.Rows[num]["other_pwd"].ToString();
				this.e_comments = dataTable.Rows[num]["comments"].ToString();
			}
		}
	}
}