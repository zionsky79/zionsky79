﻿using System.Data;
using System.Data.SqlClient;

using Field.Framework.Data;

namespace Field.SiteManagerAppTier.Dal {
	public class KWP00105_SG_WS_GRP_USER_AUTH_C {
		public int pAuthGroup;
		public string pAdminList;
		public int oReturnNo;

		public int fnSetWriteInfo(string pConnString) {
			using ( SqlConnection vConn = new SqlConnection(pConnString) ) {
				SqlCommand vCmd = new SqlCommand("dbo.KWP00105_SG_WS_GRP_USER_AUTH_C", vConn)
				{	CommandType		= CommandType.StoredProcedure
				,	CommandTimeout	= DTO_ConfigValues.EnvTime.cmdTimeOutBasic
				};

				vCmd.Parameters.Add("@pAuthGroup"	, SqlDbType.Int).Value = pAuthGroup;
				vCmd.Parameters.Add("@pAdminList"	, SqlDbType.VarChar, -1).Value = pAdminList;
				vCmd.Parameters.Add("@oReturnNo"	, SqlDbType.Int).Direction = ParameterDirection.Output;

				vConn.Open();
				vCmd.ExecuteNonQuery();
				vConn.Close();

				oReturnNo = ParameterConvert.ToInt(vCmd.Parameters["@oReturnNo"].Value);
			}

			return oReturnNo;
		}
	}
}