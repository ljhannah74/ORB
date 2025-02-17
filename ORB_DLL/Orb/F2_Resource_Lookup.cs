using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace ORB_DLL.Orb
{
	public class F2_Resource_Lookup
	{
		private string _F2land_url;

		private string _F2county_user;

		private string _F2county_pwd;

		private string _F2Login_Required;

		private string _F2court_url;

		private string _F2court_user;

		private string _F2court_pwd;

		private string _F2tax_url;

		private string _F2tax_user;

		private string _F2tax_pwd;

		private string _F2tax2_url;

		private string _F2tax2_user;

		private string _F2tax2_pwd;

		private string _F2assessor_url;

		private string _F2assessor_user;

		private string _F2assessor_pwd;

		private string _F2UCC_url;

		private string _F2muniCourt_url;

		private string _F2muniCourt_user;

		private string _F2muniCourt_pwd;

		private string _F2prothon_url;

		private string _F2pro_user;

		private string _F2pro_pwd;

		private string _F2map_url;

		private string _F2probate_url;

		private string _F2probate_user;

		private string _F2probate_pwd;

		private string _F2county_homepage;

		private string _F2foreclosure_url;

		private string _F2plat_url;

		private string _F2sheriff_url;

		private string _F2other_url;

		private string _F2other_user;

		private string _F2other_pwd;

		private string _F2copy_source;

		private string _F2img_date;

		private string _F2index_date;

		private string _F2index_source;

		private string _F2Copy_pmt_method;

		private string _F2Index_pmt_method;

		private string _F2sub_need;

		private string _F2tap;

		private string _F2rv;

		private string _F2dtree_desk;

		private string _F2ins;

		private string _F2props;

		private string _F2doc_retrieval;

		private string _F2comments;

		private string _F2copyFeeAmt;

		private string _F2subTerm;

		private string _F2subFeeAmt;

		private string _F2subscribed;

		private string _F2courtIndexDate;

		private string _F2courtImageDate;

		public string F2assessor_pwd
		{
			get
			{
				return this._F2assessor_pwd;
			}
			set
			{
				this._F2assessor_pwd = value;
			}
		}

		public string F2assessor_url
		{
			get
			{
				return this._F2assessor_url;
			}
			set
			{
				this._F2assessor_url = value;
			}
		}

		public string F2assessor_user
		{
			get
			{
				return this._F2assessor_user;
			}
			set
			{
				this._F2assessor_user = value;
			}
		}

		public string F2comments
		{
			get
			{
				return this._F2comments;
			}
			set
			{
				this._F2comments = value;
			}
		}

		public string F2Copy_pmt_method
		{
			get
			{
				return this._F2Copy_pmt_method;
			}
			set
			{
				this._F2Copy_pmt_method = value;
			}
		}

		public string F2copy_source
		{
			get
			{
				return this._F2copy_source;
			}
			set
			{
				this._F2copy_source = value;
			}
		}

		public string F2copyFeeAmt
		{
			get
			{
				return this._F2copyFeeAmt;
			}
			set
			{
				this._F2copyFeeAmt = value;
			}
		}

		public string F2county_homepage
		{
			get
			{
				return this._F2county_homepage;
			}
			set
			{
				this._F2county_homepage = value;
			}
		}

		public string F2county_pwd
		{
			get
			{
				return this._F2county_pwd;
			}
			set
			{
				this._F2county_pwd = value;
			}
		}

		public string F2county_user
		{
			get
			{
				return this._F2county_user;
			}
			set
			{
				this._F2county_user = value;
			}
		}

		public string F2court_pwd
		{
			get
			{
				return this._F2court_pwd;
			}
			set
			{
				this._F2court_pwd = value;
			}
		}

		public string F2court_url
		{
			get
			{
				return this._F2court_url;
			}
			set
			{
				this._F2court_url = value;
			}
		}

		public string F2court_user
		{
			get
			{
				return this._F2court_user;
			}
			set
			{
				this._F2court_user = value;
			}
		}

		public string F2courtImageDate
		{
			get
			{
				return this._F2courtImageDate;
			}
			set
			{
				this._F2courtImageDate = value;
			}
		}

		public string F2courtIndexDate
		{
			get
			{
				return this._F2courtIndexDate;
			}
			set
			{
				this._F2courtIndexDate = value;
			}
		}

		public string F2doc_retrieval
		{
			get
			{
				return this._F2doc_retrieval;
			}
			set
			{
				this._F2doc_retrieval = value;
			}
		}

		public string F2dtree_desk
		{
			get
			{
				return this._F2dtree_desk;
			}
			set
			{
				this._F2dtree_desk = value;
			}
		}

		public string F2foreclosure_url
		{
			get
			{
				return this._F2foreclosure_url;
			}
			set
			{
				this._F2foreclosure_url = value;
			}
		}

		public string F2img_date
		{
			get
			{
				return this._F2img_date;
			}
			set
			{
				this._F2img_date = value;
			}
		}

		public string F2index_date
		{
			get
			{
				return this._F2index_date;
			}
			set
			{
				this._F2index_date = value;
			}
		}

		public string F2Index_pmt_method
		{
			get
			{
				return this._F2Index_pmt_method;
			}
			set
			{
				this._F2Index_pmt_method = value;
			}
		}

		public string F2index_source
		{
			get
			{
				return this._F2index_source;
			}
			set
			{
				this._F2index_source = value;
			}
		}

		public string F2ins
		{
			get
			{
				return this._F2ins;
			}
			set
			{
				this._F2ins = value;
			}
		}

		public string F2land_url
		{
			get
			{
				return this._F2land_url;
			}
			set
			{
				this._F2land_url = value;
			}
		}

		public string F2Login_Required
		{
			get
			{
				return this._F2Login_Required;
			}
			set
			{
				this._F2Login_Required = value;
			}
		}

		public string F2map_url
		{
			get
			{
				return this._F2map_url;
			}
			set
			{
				this._F2map_url = value;
			}
		}

		public string F2muniCourt_pwd
		{
			get
			{
				return this._F2muniCourt_pwd;
			}
			set
			{
				this._F2muniCourt_pwd = value;
			}
		}

		public string F2muniCourt_url
		{
			get
			{
				return this._F2muniCourt_url;
			}
			set
			{
				this._F2muniCourt_url = value;
			}
		}

		public string F2muniCourt_user
		{
			get
			{
				return this._F2muniCourt_user;
			}
			set
			{
				this._F2muniCourt_user = value;
			}
		}

		public string F2other_pwd
		{
			get
			{
				return this._F2other_pwd;
			}
			set
			{
				this._F2other_pwd = value;
			}
		}

		public string F2other_url
		{
			get
			{
				return this._F2other_url;
			}
			set
			{
				this._F2other_url = value;
			}
		}

		public string F2other_user
		{
			get
			{
				return this._F2other_user;
			}
			set
			{
				this._F2other_user = value;
			}
		}

		public string F2plat_url
		{
			get
			{
				return this._F2plat_url;
			}
			set
			{
				this._F2plat_url = value;
			}
		}

		public string F2pro_pwd
		{
			get
			{
				return this._F2pro_pwd;
			}
			set
			{
				this._F2pro_pwd = value;
			}
		}

		public string F2pro_user
		{
			get
			{
				return this._F2pro_user;
			}
			set
			{
				this._F2pro_user = value;
			}
		}

		public string F2probate_pwd
		{
			get
			{
				return this._F2probate_pwd;
			}
			set
			{
				this._F2probate_pwd = value;
			}
		}

		public string F2probate_url
		{
			get
			{
				return this._F2probate_url;
			}
			set
			{
				this._F2probate_url = value;
			}
		}

		public string F2probate_user
		{
			get
			{
				return this._F2probate_user;
			}
			set
			{
				this._F2probate_user = value;
			}
		}

		public string F2props
		{
			get
			{
				return this._F2props;
			}
			set
			{
				this._F2props = value;
			}
		}

		public string F2prothon_url
		{
			get
			{
				return this._F2prothon_url;
			}
			set
			{
				this._F2prothon_url = value;
			}
		}

		public string F2rv
		{
			get
			{
				return this._F2rv;
			}
			set
			{
				this._F2rv = value;
			}
		}

		public string F2sheriff_url
		{
			get
			{
				return this._F2sheriff_url;
			}
			set
			{
				this._F2sheriff_url = value;
			}
		}

		public string F2sub_need
		{
			get
			{
				return this._F2sub_need;
			}
			set
			{
				this._F2sub_need = value;
			}
		}

		public string F2subFeeAmt
		{
			get
			{
				return this._F2subFeeAmt;
			}
			set
			{
				this._F2subFeeAmt = value;
			}
		}

		public string F2subscribed
		{
			get
			{
				return this._F2subscribed;
			}
			set
			{
				this._F2subscribed = value;
			}
		}

		public string F2subTerm
		{
			get
			{
				return this._F2subTerm;
			}
			set
			{
				this._F2subTerm = value;
			}
		}

		public string F2tap
		{
			get
			{
				return this._F2tap;
			}
			set
			{
				this._F2tap = value;
			}
		}

		public string F2tax_pwd
		{
			get
			{
				return this._F2tax_pwd;
			}
			set
			{
				this._F2tax_pwd = value;
			}
		}

		public string F2tax_url
		{
			get
			{
				return this._F2tax_url;
			}
			set
			{
				this._F2tax_url = value;
			}
		}

		public string F2tax_user
		{
			get
			{
				return this._F2tax_user;
			}
			set
			{
				this._F2tax_user = value;
			}
		}

		public string F2tax2_pwd
		{
			get
			{
				return this._F2tax2_pwd;
			}
			set
			{
				this._F2tax2_pwd = value;
			}
		}

		public string F2tax2_url
		{
			get
			{
				return this._F2tax2_url;
			}
			set
			{
				this._F2tax2_url = value;
			}
		}

		public string F2tax2_user
		{
			get
			{
				return this._F2tax2_user;
			}
			set
			{
				this._F2tax2_user = value;
			}
		}

		public string F2UCC_url
		{
			get
			{
				return this._F2UCC_url;
			}
			set
			{
				this._F2UCC_url = value;
			}
		}

		public F2_Resource_Lookup(string state, string county)
		{
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
				this.F2land_url = dataTable.Rows[num]["land_url"].ToString();
				this.F2county_user = dataTable.Rows[num]["county_user"].ToString();
				this.F2county_pwd = dataTable.Rows[num]["county_pwd"].ToString();
				this.F2Login_Required = dataTable.Rows[num]["login_req"].ToString();
				this.F2court_url = dataTable.Rows[num]["court_url"].ToString();
				this.F2court_user = dataTable.Rows[num]["court_user"].ToString();
				this.F2court_pwd = dataTable.Rows[num]["court_pwd"].ToString();
				this.F2muniCourt_url = dataTable.Rows[num]["muniCourt_url"].ToString();
				this.F2muniCourt_user = dataTable.Rows[num]["muni_user"].ToString();
				this.F2muniCourt_pwd = dataTable.Rows[num]["muni_pwd"].ToString();
				this.F2tax_url = dataTable.Rows[num]["tax_url"].ToString();
				this.F2tax_user = dataTable.Rows[num]["tax_user"].ToString();
				this.F2tax_pwd = dataTable.Rows[num]["tax_pwd"].ToString();
				this.F2tax2_url = dataTable.Rows[num]["tax2_url"].ToString();
				this.F2tax2_user = dataTable.Rows[num]["tax2_user"].ToString();
				this.F2tax2_pwd = dataTable.Rows[num]["tax2_pwd"].ToString();
				this.F2prothon_url = dataTable.Rows[num]["prothon_url"].ToString();
				this.F2pro_user = dataTable.Rows[num]["pro_user"].ToString();
				this.F2pro_pwd = dataTable.Rows[num]["pro_pwd"].ToString();
				this.F2assessor_url = dataTable.Rows[num]["assessor_url"].ToString();
				this.F2assessor_user = dataTable.Rows[num]["assessor_user"].ToString();
				this.F2assessor_pwd = dataTable.Rows[num]["assessor_pwd"].ToString();
				this.F2probate_url = dataTable.Rows[num]["probate_url"].ToString();
				this.F2probate_user = dataTable.Rows[num]["probate_user"].ToString();
				this.F2probate_pwd = dataTable.Rows[num]["probate_pwd"].ToString();
				this.F2other_url = dataTable.Rows[num]["other_url"].ToString();
				this.F2other_user = dataTable.Rows[num]["other_user"].ToString();
				this.F2other_pwd = dataTable.Rows[num]["other_pwd"].ToString();
				this.F2UCC_url = dataTable.Rows[num]["ucc_url"].ToString();
				this.F2map_url = dataTable.Rows[num]["map_url"].ToString();
				this.F2plat_url = dataTable.Rows[num]["plat_url"].ToString();
				this.F2foreclosure_url = dataTable.Rows[num]["foreclosure_url"].ToString();
				this.F2sheriff_url = dataTable.Rows[num]["sheriff_url"].ToString();
				this.F2county_homepage = dataTable.Rows[num]["county_homepage"].ToString();
				this.F2comments = dataTable.Rows[num]["comments"].ToString();
				this.F2sub_need = dataTable.Rows[num]["sub_need"].ToString();
				this.F2subFeeAmt = dataTable.Rows[num]["subFee"].ToString();
				this.F2subTerm = dataTable.Rows[num]["sub_term"].ToString();
				this.F2subscribed = dataTable.Rows[num]["we_subscribe"].ToString();
				this.F2copyFeeAmt = dataTable.Rows[num]["copyFeeAmt"].ToString();
				this.F2copy_source = dataTable.Rows[num]["copy_source"].ToString();
				this.F2Copy_pmt_method = dataTable.Rows[num]["copy_pmt_method"].ToString();
				this.F2Index_pmt_method = dataTable.Rows[num]["index_pmt_method"].ToString();
				this.F2img_date = dataTable.Rows[num]["img_date"].ToString();
				this.F2index_date = dataTable.Rows[num]["index_date"].ToString();
				this.F2index_source = dataTable.Rows[num]["index_source"].ToString();
				this.F2courtImageDate = dataTable.Rows[num]["courtImgDt"].ToString();
				this.F2courtImageDate = dataTable.Rows[num]["courtIndexDt"].ToString();
				this.F2tap = dataTable.Rows[num]["tap"].ToString();
				this.F2rv = dataTable.Rows[num]["rv"].ToString();
				this.F2dtree_desk = dataTable.Rows[num]["dtree_desk"].ToString();
				this.F2ins = dataTable.Rows[num]["ins"].ToString();
				this.F2props = dataTable.Rows[num]["props"].ToString();
				this.F2doc_retrieval = dataTable.Rows[num]["copy"].ToString();
			}
		}
	}
}