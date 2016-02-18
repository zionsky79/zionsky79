﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _12sky2.admin.support
{
    public partial class list : System.Web.UI.Page
    {
        webservice.T_QUST T_QUST = new webservice.T_QUST();

        private static int totalCnt = 0;
        private string NAT_CD = SYS.NAT_CD;

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] KEY = { };
            if (!SYS.is_check(this.Page, KEY)) return;

            if (!IsPostBack)
            {
                if (!SYS.is_null(Request.QueryString["SCH_TXT"]))
                {
                    SCH_TXT.Text = Request.QueryString["SCH_TXT"].ToString();
                }

                getList();
            }
        }
        /*********************************************************************************************************************/
        /* 검색
        /*********************************************************************************************************************/
        //
        protected void btn_search_Click(object sender, EventArgs e)
        {
            string SCH = "?";
            if (!SYS.is_null(SCH_TXT.Text))
            {
                if (!SYS.is_null(SCH)) SCH += "&";
                SCH += "SCH_TXT=" + SCH_TXT.Text;
            }

            Response.Redirect("list.aspx" + SCH);
        }
        /*********************************************************************************************************************/
        /* get list
        /*********************************************************************************************************************/
        //
        private void getList()
        {
            try
            {
                int tmpTotalCnt = T_QUST.getTotalCnt(null, NAT_CD, SCH_TXT.Text);

                UI.paging(this, PAGING, TOTAL_PAGE, NOW_PAGE, tmpTotalCnt, int.Parse(SYS.LIST_EA));
                tmpTotalCnt = tmpTotalCnt - ((int.Parse(NOW_PAGE.Text) - 1) * int.Parse(SYS.LIST_EA));
                totalCnt = tmpTotalCnt;

                DataTable result = T_QUST.getList(null, NAT_CD, int.Parse(NOW_PAGE.Text), SCH_TXT.Text);

                LIST.DataSource = result;
                LIST.DataBind();

                if (result.Rows.Count == 0) NO_LIST.Visible = true;
                else NO_LIST.Visible = false;
            }
            catch (Exception ex)
            {
                //SYS.Save_Log(ex.Message);
            }

        }
        /*********************************************************************************************************************/
        /* data list click
        /*********************************************************************************************************************/
        //
        protected void btn_list_Click(object sender, EventArgs e)
        {
            LinkButton lnkBtn = (LinkButton)sender;
            string[] REMOVE = { };
            Response.Redirect(SYS.makeURL(this, "read.aspx", REMOVE) + "SEQ=" + lnkBtn.CommandName);
        }
    }
}