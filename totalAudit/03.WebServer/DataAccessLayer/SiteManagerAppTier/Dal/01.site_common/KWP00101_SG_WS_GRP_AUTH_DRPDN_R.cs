﻿using System.Data;
using System.Data.SqlClient;

using Field.Framework.Data;

namespace Field.SiteManagerAppTier.Dal {
	public class KWP00101_SG_WS_GRP_AUTH_DRPDN_R {
		public long pAdminNo;
		public byte pModeNo;
		public int oReturnNo;

		public DataTable fnGetResultSet(string pConnString) {
			DataSet dsResult = new DataSet();

			using ( SqlConnection vConn = new SqlConnection(pConnString) ) {
				SqlCommand vCmd = new SqlCommand("dbo.KWP00101_SG_WS_GRP_AUTH_DRPDN_R", vConn)
				{	CommandType		= CommandType.StoredProcedure
				,	CommandTimeout	= DTO_ConfigValues.EnvTime.cmdTimeOutBasic
				};

				vCmd.Parameters.Add("@pAdminNo"	, SqlDbType.Int).Value = pAdminNo;
				vCmd.Parameters.Add("@pMode"	, SqlDbType.TinyInt).Value = pModeNo;
				vCmd.Parameters.Add("@oReturnNo", SqlDbType.Int).Direction = ParameterDirection.Output;

				SqlDataAdapter adapter = new SqlDataAdapter(vCmd);
				adapter.Fill(dsResult);
				vConn.Close();

				oReturnNo = ParameterConvert.ToInt(vCmd.Parameters["@oReturnNo"].Value);
			}

			return dsResult.Tables[0];
		}
	}
}