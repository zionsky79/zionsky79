﻿using System;
using System.Data;

using Field.TwelveWebAppTier.Dal;

namespace Web.TwelveSky.web {
	public partial class policy : BasePage {
		private readonly string gConnStr = ConnString.fnGetName("FieldWeb");

		protected void Page_Load(object sender, EventArgs e) {
			C_WEB_RESOURCE = "/web/policy.aspx";

			if ( IsPostBack ) {
				return;
			}


			try {
				fnInitParameter();
				fnInitDefaultSetting();

				fnDisplayArticle();
			} catch ( Exception ex ) {
				string vMessage = $"{fnLabelText("msgError_01")} [{ex.Message}]";
				fnMessageText(vMessage);
				fnWriterLog(ex);
			}
		}


		#region initialize layer
		// parameter 수집
		private void fnInitParameter() {
			pMenu.Value		= Request.QueryString["m"];
			pWrite.Value	= Request.QueryString["w"]; // 현재 페이지 번호

			// 잘 못된 접근
			if ( string.IsNullOrEmpty(pMenu.Value) || string.IsNullOrEmpty(pWrite.Value) ) {
				Response.Redirect("/");
			}
		}

		// 게시판 기본 세팅
		private void fnInitDefaultSetting() {
			DataRow[] vMenuInfo = MenuList.fnMenuName(pMenu.Value);

			if ( vMenuInfo.Length < 1 ) {
				Response.Redirect("/");
				return;
			}
			if ( Convert.ToByte(vMenuInfo[0]["cType"]) != 10 ) {
				Response.Redirect("/");
				return;
			}


			lblNavTitle.Text	= vMenuInfo[0]["cMenuName"].ToString();
			lblPageTitle.Text	= lblNavTitle.Text;
		}
		#endregion initialize layer


		#region binding layer
		private void fnDisplayArticle() {
			int vMenuNo		= Convert.ToInt32(pMenu.Value);
			long vWriteNo	= Convert.ToInt64(pWrite.Value);

			uspGetArticleDetailInfo oDTO = new uspGetArticleDetailInfo
			{	pMenuNo		= vMenuNo
			,	pWriteNo	= vWriteNo
			,	pPublisher	= gPublisher
			,	pLanguage	= Convert.ToByte(ConfigValues.EnvText.cLangNo)
			,	pLimitDate	= gLimitDate
			,	pIsRead		= false
			,	pIsAround	= false
			,	pIsFile		= false
			};
			oDTO.fnGetResultSet(gConnStr);

			if ( oDTO.oReturnNo != 0 ) {
				Response.Redirect("/");
				return;
			}


			lblContents.Text = oDTO.oContents;
		}
		#endregion binding layer
	}
}