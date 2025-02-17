using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace ORB_DLL.Orb
{
	public class Resource_Lookup
	{
		string dataFileName;
		string dsn;

		public Resource_Lookup()
		{
			dataFileName = @"Data\ORB_DATABASE.xlsx";
			dsn = string.Concat("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=", dataFileName, ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");
		}

		public DataTable GetCountiesByState(string state)
		{
			DataTable dtReturn = new DataTable();
			OleDbCommand cmdGetCountiesByState = new OleDbCommand();
			cmdGetCountiesByState.Connection = new OleDbConnection(dsn);
			cmdGetCountiesByState.CommandText = string.Concat("Select state, county From [orb$] WHERE [state]='", state, "'");

			OleDbDataAdapter datGetCountiesByState = new OleDbDataAdapter();
			datGetCountiesByState.SelectCommand = cmdGetCountiesByState;
            datGetCountiesByState.Fill(dtReturn);
			datGetCountiesByState.Dispose();

			return dtReturn;
		}

		public string GetOnlineResources(string state)
		{
			DataTable dataTable = new DataTable();
			string cmdText = string.Concat("Select * From [orb$] Where state = '", state, "'");
			OleDbConnection dsn = new OleDbConnection(this.dsn);
			OleDbDataAdapter datGetOnlineResources = new OleDbDataAdapter(cmdText, dsn);
			datGetOnlineResources.Fill(dataTable);
			datGetOnlineResources.Dispose();

			string returnValue = "";

			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				if(dataTable.Rows[i]["props"].ToString() == "Yes")
				{
					returnValue = string.Concat(returnValue, dataTable.Rows[i]["state"].ToString(), " - ", dataTable.Rows[i]["county"].ToString(), "\r\n");
				}
			}

			return returnValue;
		}

		public Online_Resource GetResources(string state, string county, string tax_auth)
		{
			Online_Resource orReturn;
		
			DataTable getResource = new DataTable();
			OleDbDataAdapter dapResource = new OleDbDataAdapter();
			OleDbCommandBuilder oleDbCommandBuilder = new OleDbCommandBuilder();
			OleDbCommand cmdGetResource = new OleDbCommand();
			cmdGetResource.CommandText = string.Concat("Select * From [orb$] where state = '", state, "' and county = '", county, "'");
			cmdGetResource.Connection = new OleDbConnection(dsn);
			dapResource.SelectCommand = cmdGetResource;
			oleDbCommandBuilder.DataAdapter = dapResource;
			dapResource.Fill(getResource);
			
			if (getResource.Rows.Count > 0)
			{
				orReturn = new Online_Resource();
				orReturn.sub_need = getResource.Rows[0]["sub_need"].ToString();
				orReturn.subscribed = getResource.Rows[0]["we_subscribe"].ToString();
				orReturn.subscr_term = getResource.Rows[0]["sub_term"].ToString();
				orReturn.subscrFeeAmt = getResource.Rows[0]["subFee"].ToString();
				orReturn.tap = getResource.Rows[0]["tap"].ToString();
				orReturn.rv = getResource.Rows[0]["rv"].ToString();
				orReturn.dtree_desk = getResource.Rows[0]["dtree_desk"].ToString();
				orReturn.ins = getResource.Rows[0]["ins"].ToString();
				orReturn.props = getResource.Rows[0]["props"].ToString();
				orReturn.doc_retrieval = getResource.Rows[0]["copy"].ToString();
				orReturn.copy_pmt_method = getResource.Rows[0]["copy_pmt_method"].ToString();
				orReturn.copyFeeAmt = getResource.Rows[0]["copyFeeAmt"].ToString();
				orReturn.copy_source = getResource.Rows[0]["copy_source"].ToString();
				orReturn.img_date = getResource.Rows[0]["img_date"].ToString();
				orReturn.index_date = getResource.Rows[0]["index_date"].ToString();
				orReturn.index_source = getResource.Rows[0]["index_source"].ToString();
				orReturn.index_pmt_method = getResource.Rows[0]["index_pmt_method"].ToString();
				orReturn.land_url = getResource.Rows[0]["land_url"].ToString();
				orReturn.county_user = getResource.Rows[0]["county_user"].ToString();
				orReturn.county_pwd = getResource.Rows[0]["county_pwd"].ToString();
				orReturn.login_required = getResource.Rows[0]["login_req"].ToString();
				orReturn.court_url = getResource.Rows[0]["court_url"].ToString();
				orReturn.court_user = getResource.Rows[0]["court_user"].ToString();
				orReturn.court_pwd = getResource.Rows[0]["court_pwd"].ToString();
				orReturn.courtImageDate = getResource.Rows[0]["courtImgDt"].ToString();
				orReturn.courtIndexDate = getResource.Rows[0]["courtIndexDt"].ToString();
				orReturn.muniCourt_url = getResource.Rows[0]["muniCourt_url"].ToString();
				orReturn.muniCourt_user = getResource.Rows[0]["muni_user"].ToString();
				orReturn.muniCourt_pwd = getResource.Rows[0]["muni_pwd"].ToString();
				orReturn.tax_url = getResource.Rows[0]["tax_url"].ToString();
				orReturn.tax_user = getResource.Rows[0]["tax_user"].ToString();
				orReturn.tax_pwd = getResource.Rows[0]["tax_pwd"].ToString();
				orReturn.tax2_url = getResource.Rows[0]["tax2_url"].ToString();
				orReturn.tax2_user = getResource.Rows[0]["tax2_user"].ToString();
				orReturn.tax2_pwd = getResource.Rows[0]["tax2_pwd"].ToString();
				orReturn.prothon_url = getResource.Rows[0]["prothon_url"].ToString();
				orReturn.pro_user = getResource.Rows[0]["pro_user"].ToString();
				orReturn.pro_pwd = getResource.Rows[0]["pro_pwd"].ToString();
				orReturn.assessor_url = getResource.Rows[0]["assessor_url"].ToString();
				orReturn.assessor_user = getResource.Rows[0]["assessor_user"].ToString();
				orReturn.assessor_pwd = getResource.Rows[0]["assessor_pwd"].ToString();
				orReturn.probate_url = getResource.Rows[0]["probate_url"].ToString();
				orReturn.probate_user = getResource.Rows[0]["probate_user"].ToString();
				orReturn.probate_pwd = getResource.Rows[0]["probate_pwd"].ToString();
				orReturn.other_url = getResource.Rows[0]["other_url"].ToString();
				orReturn.other_user = getResource.Rows[0]["other_user"].ToString();
				orReturn.other_pwd = getResource.Rows[0]["other_pwd"].ToString();
				orReturn.ucc_url = getResource.Rows[0]["ucc_url"].ToString();
				orReturn.foreclosure_url = getResource.Rows[0]["foreclosure_url"].ToString();
				orReturn.plat_url = getResource.Rows[0]["plat_url"].ToString();
				orReturn.map_url = getResource.Rows[0]["map_url"].ToString();
				orReturn.sheriff_url = getResource.Rows[0]["sheriff_url"].ToString();
				orReturn.county_homepage = getResource.Rows[0]["county_homepage"].ToString();
				orReturn.comments = getResource.Rows[0]["comments"].ToString();

				return orReturn;
			}
			else
			{
				return null;
			}
		}
	}
}
