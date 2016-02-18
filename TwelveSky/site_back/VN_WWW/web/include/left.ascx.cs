﻿using System;
using System.Web.UI;
using System.Collections;

namespace _12sky2.web.include {
	public partial class left : UserControl {
		public string TITL = string.Empty;
		public string SUB_TITL = string.Empty;
		private const string C_WEB_RESOURCE = "/web/include/head.ascx";

		public string setTITL {
			set { TITL = value; }
		}
		public string setSUB_TITL {
			set { SUB_TITL = value; }
		}

		protected void Page_Load(object sender, EventArgs e) {
			if ( !IsPostBack ) {
				setMenu();
			}
		}

		// 라벨에 텍스트 입력
		private static string fnLabelText(string pKey) {
			return ResourceValues.AppResourceText(C_WEB_RESOURCE, pKey);
		}

		private void setMenu() {
			try {
				PAGE_TITLE.InnerHtml = fnLabelText(TITL);

				string menuHTML = "";
				ArrayList vMenuList = MENU.getMenu(TITL);

				foreach ( object vMenu in vMenuList ) {
					string[] _menu = vMenu.ToString().Split(',');
					string _class = "";

					if ( _menu[0].Trim().Equals(SUB_TITL) ) {
						_class = "class='on'";
					}
					menuHTML += $"<li><a href='{_menu[1].Trim()}' {_class}>{_menu[2].Trim()}</a></li>";
				}

				PAGE_MENU.InnerHtml = menuHTML;
			} catch ( Exception ex ) {
				SYS.Save_Log(ex.Message);
			}
		}
	}
}